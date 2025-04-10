using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;

    [Header("Ground Check")]
    [SerializeField]
    LayerMask groundLayer;
    bool isGround;
    float groundCheckDistance = 1.4f;

    [Header("이동")]
    float xInput;
    bool isMoving;
    float moveSpeed = 10f;
    bool playerRight = true;

    [Header("점프")]
    [SerializeField]
    float jumpForce = 7f;    

    [Header("대쉬")]
    bool isDash;
    float dashSpeed = 25f; // 대쉬 속도
    float dashDuration = 0.25f; // 대쉬 지속 시간
    float remainingDashDuration; // 남은 대쉬 지속 시간
    public float dashCoolTime = 2.0f;
    public float remainingDashCoolTime; // 대쉬 쿨타임

    [Header("공격")]
    float comboResetTime = 1.0f; // 콤보 리셋 시간
    float remainingComboResetTime; // 남은 콤보 리셋 시간
    int combo = 0;
    bool canCombo = true;

    void Start() // 초기화
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGround();
        GetInput(); // 입력받기
        FlipControl(); // 좌우 방향 전환
        Movement();
        AnimationController();
        CoolTimeController();
    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround) // 땅에 있을때, 
            {
                Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (remainingDashCoolTime <= 0 && !isDash) // 쿨타임이 없고, 대쉬 중이 아닐 때
            {
                Dash();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            Debug.Log("Attack");
        }
    }

    private void Dash()
    {
        isDash = true;
        remainingDashDuration = dashDuration; // 대쉬 지속 시간 초기화
        remainingDashCoolTime = dashCoolTime; // 대쉬 쿨타임 초기화
    }

    private void Attack()
    {
        if (!isGround) // 공중에 있을 때
        {
            return;
        }
        else
        {
            if(combo == 0)
            {
                combo = 1;
                canCombo = false;
            }
            if (combo == 1 && canCombo)
            {
                combo = 2;
                canCombo = false;
            }
            remainingComboResetTime = comboResetTime; // 콤보 리셋 시간 초기화
        }
    }

    void Movement()
    {
        if (combo > 0) //공격 중일 떄
        {
            rb.linearVelocity = new Vector2(0, 0);
        }
        else if (isDash)
        {
            rb.linearVelocity = new Vector2(xInput * dashSpeed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
        }

    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void AnimationController()
    {
        isMoving = rb.linearVelocity.x != 0;

        anim.SetFloat("yVelocity", rb.linearVelocityY);
        anim.SetBool("run", isMoving);
        anim.SetBool("isGround", isGround);
        anim.SetBool("isDash", isDash);
        anim.SetInteger("combo", combo);
    }

    private void FlipControl()
    {
        if (playerRight && xInput < 0)
        {
            Flip();
            playerRight = false;
        }
        else if (!playerRight && xInput > 0)
        {
            Flip();
            playerRight = true;
        }
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
    void CheckGround()
    {
        isGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }

    private void CoolTimeController()
    {
        remainingDashDuration -= Time.deltaTime; // 대쉬 지속 시간 감소
        if (remainingDashDuration <= 0) // 대쉬 지속시간이 끝났을 경우
        {
            isDash = false;
        }
        remainingDashCoolTime -= Time.deltaTime; // 대쉬 쿨타임 감소
        remainingComboResetTime -= Time.deltaTime;

        if(remainingComboResetTime <= 0) // 콤보 리셋 시간
        {
            combo = 0;
        }
    }

    void EnableComboWindow() // 애니메이션 종료 직전
    {
        canCombo = true;  // 다음 공격이 가능해짐
    }

    void ResetCombo() // 애니메이션 종료
    {
        canCombo = false;
        combo = 0; // 콤보 초기화
    }
}
