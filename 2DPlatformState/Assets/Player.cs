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

    [Header("�̵�")]
    float xInput;
    bool isMoving;
    float moveSpeed = 10f;
    bool playerRight = true;

    [Header("����")]
    [SerializeField]
    float jumpForce = 7f;    

    [Header("�뽬")]
    bool isDash;
    float dashSpeed = 25f; // �뽬 �ӵ�
    float dashDuration = 0.25f; // �뽬 ���� �ð�
    float remainingDashDuration; // ���� �뽬 ���� �ð�
    public float dashCoolTime = 2.0f;
    public float remainingDashCoolTime; // �뽬 ��Ÿ��

    [Header("����")]
    float comboResetTime = 1.0f; // �޺� ���� �ð�
    float remainingComboResetTime; // ���� �޺� ���� �ð�
    int combo = 0;
    bool canCombo = true;

    void Start() // �ʱ�ȭ
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGround();
        GetInput(); // �Է¹ޱ�
        FlipControl(); // �¿� ���� ��ȯ
        Movement();
        AnimationController();
        CoolTimeController();
    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround) // ���� ������, 
            {
                Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (remainingDashCoolTime <= 0 && !isDash) // ��Ÿ���� ����, �뽬 ���� �ƴ� ��
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
        remainingDashDuration = dashDuration; // �뽬 ���� �ð� �ʱ�ȭ
        remainingDashCoolTime = dashCoolTime; // �뽬 ��Ÿ�� �ʱ�ȭ
    }

    private void Attack()
    {
        if (!isGround) // ���߿� ���� ��
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
            remainingComboResetTime = comboResetTime; // �޺� ���� �ð� �ʱ�ȭ
        }
    }

    void Movement()
    {
        if (combo > 0) //���� ���� ��
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
        remainingDashDuration -= Time.deltaTime; // �뽬 ���� �ð� ����
        if (remainingDashDuration <= 0) // �뽬 ���ӽð��� ������ ���
        {
            isDash = false;
        }
        remainingDashCoolTime -= Time.deltaTime; // �뽬 ��Ÿ�� ����
        remainingComboResetTime -= Time.deltaTime;

        if(remainingComboResetTime <= 0) // �޺� ���� �ð�
        {
            combo = 0;
        }
    }

    void EnableComboWindow() // �ִϸ��̼� ���� ����
    {
        canCombo = true;  // ���� ������ ��������
    }

    void ResetCombo() // �ִϸ��̼� ����
    {
        canCombo = false;
        combo = 0; // �޺� �ʱ�ȭ
    }
}
