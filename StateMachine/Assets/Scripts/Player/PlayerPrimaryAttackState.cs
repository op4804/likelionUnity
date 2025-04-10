using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{

    private int comboCounter;

    private float lastAttackTime;
    private float comboWindow = 2.0f;

    public PlayerPrimaryAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        if(comboCounter > 2 || Time.time >= lastAttackTime + comboWindow)
        {
            comboCounter = 0;
        }
        player.anim.SetInteger("comboCounter", comboCounter);

        float attackDir = player.facingDirection;
        if (xInput != 0)
        {
            attackDir = xInput;
        }

        // player.anim.speed = 3.0f; // -> 애니메이션 배속(공격속도)

        player.SetVelocity(player.attackMovement[comboCounter].x * attackDir, player.attackMovement[comboCounter].y);

        stateTimer = 0.1f;
    }
    public override void Exit()
    {
        base.Exit();

        player.StartCoroutine("BusyFor", 0.1f);

        comboCounter++;
        lastAttackTime = Time.time;
    }
    public override void Update()
    {
        base.Update();

        if(stateTimer <= 0.0f)
        {
            player.ZeroVelocity();
        }

        if (triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}

