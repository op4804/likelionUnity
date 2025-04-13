using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Transform playerTransform;
    private EnemySkeleton skeleton;

    private int moveDir;

    public SkeletonBattleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton skeleton) : base(_enemy, _stateMachine, _animBoolName)
    {
        this.skeleton = skeleton;
    }
    public override void Enter()
    {
        base.Enter();

        playerTransform = GameObject.Find("Player").transform;
    }
    public override void Update()
    {
        base.Update();

        if (skeleton.IsPlayer())
        {
            stateTimer -= skeleton.battleTime;

            if (skeleton.IsPlayer().distance < skeleton.attackDistance)
            {
                if (CanAttack())
                    stateMachine.ChangeState(skeleton.attackState);
            }
        }
        else
        {
            if (stateTimer <= 0)
            {
                stateMachine.ChangeState(skeleton.idleState);
            }
        }

        if (playerTransform.position.x > skeleton.transform.position.x)
            moveDir = 1;
        else if (playerTransform.position.x < skeleton.transform.position.x)
            moveDir = -1;

        skeleton.SetVelocity(skeleton.moveSpeed * moveDir, rb.linearVelocity.y);
    }
    public override void Exit()
    {
        base.Exit();
    }

    private bool CanAttack()
    {
        if (Time.time >= skeleton.lastTimeAttacked + skeleton.attackCoolDown)
        {
            skeleton.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }
}