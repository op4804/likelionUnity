using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;

    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject("EventManager");
                instance = singletonObject.AddComponent<EventManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else // �ν��Ͻ��� null�� �ƴҰ�� -> ��, �̹� �ν��Ͻ��� ������ ���
        {
            Destroy(gameObject);
        }
    }

    // �̺�Ʈ�� �������� �����ϰ� �����ϴ� ��ųʸ�
    private Dictionary<string, Action<object>> eventDictionary = new Dictionary<string, Action<object>>();

    // �̺�Ʈ�� ������ �߰�
    public void AddListener(string eventName, Action<object> listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action<object> thisEvent)) // �ش� �̺�Ʈ�� �̹� �����Ѵٸ�
        {
            thisEvent += listener;
            eventDictionary[eventName] = thisEvent; // ������ �߰�
        }
        else
        {
            eventDictionary.Add(eventName, listener);
        }
    }

    // �̺�Ʈ���� ������ ����
    public void RemoveListener(string eventName, Action<object> listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[eventName] = thisEvent;
        }
    }

    // �̺�Ʈ�߻�(��� ���������� �˸�)
    public void TriggerEvent(string eventName, object data = null)
    {
        if (eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent?.Invoke(data);
        }
    }
}
