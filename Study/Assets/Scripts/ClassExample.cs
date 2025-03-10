using UnityEngine;

public class ClassExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public class Player
    {
        public string name;
        public int score;

        public Player(string playerName, int playerScore)
        {
            name = playerName;
            score = playerScore;
        }

        public void ShowInfo()
        {
            Debug.Log("Player : " + name + ", Score : " + score);
        }
    }

    void Start()
    {
        Player myPlayer = new Player("Hero", 10);
        myPlayer.ShowInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
