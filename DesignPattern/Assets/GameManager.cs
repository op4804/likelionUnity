using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public GameObject ScoreText;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject("GameManager");
                instance = singletonObject.AddComponent<GameManager>();
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

    private void Start()
    {
        EventManager.Instance.AddListener("scoreChanged", OnScoreChanged);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 cameraPosision = Camera.main.transform.position;
            Vector3 scrrenMousePosition = Input.mousePosition;
            scrrenMousePosition.z = 100;
            Vector3 worldMousePostion = Camera.main.ScreenToWorldPoint(scrrenMousePosition);
            
            GameObject newBullet = BulletFactory.Instance.FIreBullet(cameraPosision);
            newBullet.GetComponent<Rigidbody>().AddForce(worldMousePostion - cameraPosision * 5, ForceMode.Impulse);


        }
    }

    private void OnScoreChanged(object data)
    {
        ScoreText.GetComponent<Text>().text = "Score : " + data.ToString();
    }

}
