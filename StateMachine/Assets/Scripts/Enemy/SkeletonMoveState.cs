using UnityEngine;

public class SkeletonMoveState : SkeletonGroundedState
{
    public SkeletonMoveState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton _skeleton) : base(_enemy, _stateMachine, _animBoolName, _skeleton)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        skeleton.SetVelocity(skeleton.moveSpeed * skeleton.facingDirection, skeleton.rb.linearVelocityY);

        if (skeleton.IsWall() || !skeleton.IsGround())
        {
            skeleton.Flip();
            stateMachine.ChangeState(skeleton.idleState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }

}
