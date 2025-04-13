using UnityEngine;

public class SkeletonStunState : EnemyState
{
    private EnemySkeleton skeleton;
    public SkeletonStunState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton skeleton) : base(enemy, stateMachine, animBoolName)
    {
        this.skeleton = skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        skeleton.fx.InvokeRepeating("RedColorBlink", 0, 0.1f);

        stateTimer = skeleton.stunDuration;

        // skeleton.SetVelocity(skeleton.facingDirection * skeleton.stunDirection.x * -1, skeleton.stunDirection.y);
        rb.linearVelocity = new Vector2(skeleton.facingDirection * skeleton.stunDirection.x * -1, skeleton.stunDirection.y);
    }

    public override void Exit()
    {
        base.Exit();

        skeleton.fx.Invoke("CancleRedBlink", 0);
    }
    public override void Update()
    {
        base.Update();
        if (stateTimer <= 0.0f)
        {
            stateMachine.ChangeState(skeleton.idleState);
        }
    }
}
