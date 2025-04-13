using UnityEngine;

public class EnemySkeleton : Enemy
{
    #region States
    public SkeletonIdleState idleState { get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    public SkeletonBattleState battleState { get; private set; }
    public SkeletonAttackState attackState { get; private set; }
    public SkeletonStunState stunState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new SkeletonIdleState(this, stateMachine, "idle", this);
        moveState = new SkeletonMoveState(this, stateMachine, "move", this);
        battleState = new SkeletonBattleState(this, stateMachine, "move", this);
        attackState = new SkeletonAttackState(this, stateMachine, "attack", this);
        stunState = new SkeletonStunState(this, stateMachine, "stun", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    private void AnimationTrigger()
    {

    }
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackDistance, playerLayer);
    }

    public override bool CanBeStunned()
    {
        if (base.CanBeStunned())
        {
            stateMachine.ChangeState(stunState);
            return true;
        }
        return false;
    }
}
