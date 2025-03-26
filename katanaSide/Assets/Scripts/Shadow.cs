using UnityEngine;

public class Shadow : MonoBehaviour
{
    private GameObject player;
    public float TwSpeed = 10;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, TwSpeed * Time.deltaTime);
    }
}
