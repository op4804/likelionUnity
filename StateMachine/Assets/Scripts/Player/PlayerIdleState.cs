using UnityEngine;
using UnityEngine.Windows;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        player.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();   
        
        if(xInput == player.facingDirection && player.IsGround())
        {
            return;
        }

        if (xInput != 0)
            stateMachine.ChangeState(player.moveState);
    }
}
