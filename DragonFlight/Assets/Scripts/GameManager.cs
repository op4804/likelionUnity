using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    int score = 0;
    public Text scoreText;
    public Text startText;


    private void Awake()
    {
     if(GameManager.instance == null)
        {
            GameManager.instance = this;
        }   
    }

    private void Start()
    {
        StartCoroutine(StartCounter());
    }
    IEnumerator StartCounter()
    {
        int i = 3;
        while(i > 0)
        {
            startText.text = i.ToString();
            yield return new WaitForSeconds(1f);

            i--;

            if(i == 0)
            {
                startText.gameObject.SetActive(false);
            }
        }
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score;
    }


    private void Update()
    {
        
    }
}
