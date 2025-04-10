using UnityEngine;

public class SkeletonIdleState : SkeletonGroundedState
{
    public SkeletonIdleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton _skeleton) : base(_enemy, _stateMachine, _animBoolName, _skeleton)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = skeleton.idleTime;
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer <= 0)
        {
            stateMachine.ChangeState(skeleton.moveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
