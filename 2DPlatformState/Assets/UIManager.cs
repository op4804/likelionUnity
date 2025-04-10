using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;

    public Text playerDashCoolTimeText;


    private void Update()
    {
        playerDashCoolTimeText.text = "대쉬 쿨타임 : " + player.remainingDashCoolTime.ToString("F2") + "초 (" + player.dashCoolTime.ToString("F2") + "초)";
    }
}
