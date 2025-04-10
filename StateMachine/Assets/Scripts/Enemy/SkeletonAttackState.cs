using UnityEngine;

public class SkeletonAttackState : EnemyState
{
    private EnemySkeleton skeleton;

    public SkeletonAttackState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton _skeleton) : base(_enemy, _stateMachine, _animBoolName)
    {
        this.skeleton = _skeleton;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();

        skeleton.ZeroVelocity();

        if(triggerCalled)
        {
            skeleton.stateMachine.ChangeState(skeleton.battleState);
        }
    }
    public override void Exit()
    {
        base.Exit();
        skeleton.lastTimeAttacked = Time.time;
    }
}
