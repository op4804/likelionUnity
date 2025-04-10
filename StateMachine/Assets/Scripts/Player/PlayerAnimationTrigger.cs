using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
}
