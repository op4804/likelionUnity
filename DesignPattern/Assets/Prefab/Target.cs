using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    Material mat;
    int score = 0;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        mat.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        score += 10;
        EventManager.Instance.TriggerEvent("scoreChanged", score);
    }

}
