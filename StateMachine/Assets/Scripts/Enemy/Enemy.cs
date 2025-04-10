using UnityEngine;

public class Enemy : Entity
{
    [SerializeField]
    protected LayerMask playerLayer;

    [Header("이동 정보")]
    public float moveSpeed;
    public float idleTime;

    [Header("공격 정보")]
    public float attackDistance;
    public float attackCoolDown;
    [HideInInspector]
    public float lastTimeAttacked;
    public float battleTime;

    public EnemyStateMachine stateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine();
    }


    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    public virtual RaycastHit2D IsPlayer()
    {
        return Physics2D.Raycast(transform.position, Vector2.right * facingDirection, 50, playerLayer);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance + facingDirection, transform.position.y));
    }
}
