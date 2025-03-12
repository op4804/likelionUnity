using UnityEngine;

public class Singleton : MonoBehaviour
{

    

    // 유니티에서 싱글톤을 사용하면 하나의 인스턴스만 유지하면서 어디서나 접근 가능.
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
        Debug.Log("싱글톤 메세지");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
