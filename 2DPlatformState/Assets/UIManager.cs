using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;

    public Text playerDashCoolTimeText;


    private void Update()
    {
        playerDashCoolTimeText.text = "�뽬 ��Ÿ�� : " + player.remainingDashCoolTime.ToString("F2") + "�� (" + player.dashCoolTime.ToString("F2") + "��)";
    }
}
