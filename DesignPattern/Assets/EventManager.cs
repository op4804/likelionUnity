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
        else // 인스턴스가 null이 아닐경우 -> 즉, 이미 인스턴스가 존재할 경우
        {
            Destroy(gameObject);
        }
    }

    // 이벤트와 옵저버를 연결하고 관리하는 딕셔너리
    private Dictionary<string, Action<object>> eventDictionary = new Dictionary<string, Action<object>>();

    // 이벤트에 옵저버 추가
    public void AddListener(string eventName, Action<object> listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action<object> thisEvent)) // 해당 이벤트가 이미 존재한다면
        {
            thisEvent += listener;
            eventDictionary[eventName] = thisEvent; // 옵저버 추가
        }
        else
        {
            eventDictionary.Add(eventName, listener);
        }
    }

    // 이벤트에서 옵저버 제거
    public void RemoveListener(string eventName, Action<object> listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[eventName] = thisEvent;
        }
    }

    // 이벤트발생(모든 옵저버에게 알림)
    public void TriggerEvent(string eventName, object data = null)
    {
        if (eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent?.Invoke(data);
        }
    }
}
