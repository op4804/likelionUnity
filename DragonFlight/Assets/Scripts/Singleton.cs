using UnityEngine;

public class Singleton : MonoBehaviour
{

    

    // ����Ƽ���� �̱����� ����ϸ� �ϳ��� �ν��Ͻ��� �����ϸ鼭 ��𼭳� ���� ����.
    public static Singleton Instance { get; set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowMessage()
    {
        Debug.Log("�̱��� �޼���");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
