using UnityEngine;

public class SkeletonGroundedState : EnemyState
{
    protected EnemySkeleton skeleton;

    protected Transform playerTransform;
    public SkeletonGroundedState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton _skeleton) : base(_enemy, _stateMachine, _animBoolName)
    {
        this.skeleton = _skeleton;
    }
    public override void Enter()
    {
        base.Enter();
        playerTransform = GameObject.Find("Player").transform;
    }
    public override void Update()
    {
        base.Update();

        if (skeleton.IsPlayer() || Vector2.Distance(skeleton.transform.position, playerTransform.position) < 2)
        {
            stateMachine.ChangeState(skeleton.battleState);
        }

    }
    public override void Exit()
    {
        base.Exit();
    }
}

