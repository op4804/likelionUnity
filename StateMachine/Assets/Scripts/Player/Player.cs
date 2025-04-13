using UnityEngine;
using System.Collections;

public class Player : Entity
{

    [Header("공격")]
    public Vector2[] attackMovement;
    public float counterAttackDuration = 0.2f;

    public bool isBusy { get; private set; } // 플레이어가 바쁜지 여부를 나타내는 변수?

    public float moveSpeed = 10f;
    public float jumpForce = 12f;

    [Header("대쉬")]
    public float dashSpeed = 100f;
    public float dashDuration = 0.05f;

    float dashCooldown = 0.5f;
    float dashCooldownCounter;
    public float dashDir { get; private set; }

    #region States
    private PlayerStateMachine stateMachine;

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    public PlayerPrimaryAttackState primaryAttackState { get; private set; }
    public PlayerCounterAttackState counterAttackState { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();
        // StateMachine 생성
        stateMachine = new PlayerStateMachine();

        // 각 State 생성
        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");
        jumpState = new PlayerJumpState(this, stateMachine, "jump");
        airState = new PlayerAirState(this, stateMachine, "jump");
        dashState = new PlayerDashState(this, stateMachine, "dash");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "wallSlide");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, "jump");
        primaryAttackState = new PlayerPrimaryAttackState(this, stateMachine, "attack");
        counterAttackState = new PlayerCounterAttackState(this, stateMachine, "counterAttack");
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        DashContoroller();
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    public void AnimationTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackCheckRadius);


        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
                hit.GetComponent<Enemy>().Damage();
        }
    }

    private void DashContoroller()
    {
        dashCooldownCounter -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownCounter <= 0)
        {
            dashCooldownCounter = dashCooldown;

            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
                dashDir = facingDirection;

            stateMachine.ChangeState(dashState);

        }
    }   
}
