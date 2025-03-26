using System;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumpUp = 1;
    private Vector3 direction;
    float power = 2;

    public GameObject slash;

    public GameObject jumpDust;

    // 그림자
    public GameObject shadow;
    List<GameObject> sh = new List<GameObject>();

    // 이펙트
    public GameObject hitLazer;

    Animator pAnimator;
    Rigidbody2D pRig2D;
    SpriteRenderer sp;


    public bool isJump = false;

    // 벽

    public Transform wallChk;
    public float wallchkDistance;
    public LayerMask wLayer;
    public bool isWall;
    public float slidingSpeed;
    public float wallJumpPower;
    public bool isWallJump;
    int isRight = 1;



    void Start()
    {
        pAnimator = GetComponent<Animator>();
        pRig2D = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
        sp = GetComponent<SpriteRenderer>();
    }

    void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal");

        if (direction.x < 0)
        {
            sp.flipX = true;
            pAnimator.SetBool("run", true);
            isRight = -1;
        }
        else if (direction.x > 0)
        {
            sp.flipX = false;
            pAnimator.SetBool("run", true);
            isRight = 1;

        }
        else if (direction.x == 0)
        {
            pAnimator.SetBool("run", false);

            for (int i = 0; i < sh.Count; i++)
            {
                Destroy(sh[i]);

            }
            sh.Clear();

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isWall)
            {
                WallJump();
            }
            else
            {
                Jump();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        pAnimator.SetTrigger("attack");
        Instantiate(hitLazer, transform.position, Quaternion.identity);
    }
    public void Att()
    {
        if (sp.flipX == false) // 오른쪽
        {
            pRig2D.AddForce(Vector2.right * power, ForceMode2D.Impulse);
        }
        else
        {
            pRig2D.AddForce(Vector2.left * power, ForceMode2D.Impulse);
        }
        GameObject go = Instantiate(slash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        // go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
    }

    void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(pRig2D.position, Vector3.down, Color.green);
        Debug.DrawRay(pRig2D.position, Vector3.right * isRight * wallchkDistance, Color.blue);

        // 레이 캐스트로 땅 체크

        RaycastHit2D rayHit = Physics2D.Raycast(pRig2D.position, Vector3.down, 1, LayerMask.GetMask("Ground"));

        if (pRig2D.linearVelocityY < 0)
        {
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.7f)
                {
                    pAnimator.SetBool("jump", false);
                    isJump = false;
                }
            }
        }
    }

    void Update()
    {
        KeyInput();
        Move();

        // 벽체크
        isWall = Physics2D.Raycast(wallChk.position, Vector2.right * isRight, wallchkDistance, wLayer);
        pAnimator.SetBool("grab", isWall);
        if (isWall)
        {
            pRig2D.linearVelocity = new Vector2(pRig2D.linearVelocityX, pRig2D.linearVelocityY * slidingSpeed);
            isWallJump = false;
        }
    }

    void Jump()
    {
        if (isJump)
        {

        }
        else
        {
            JumpDust();
            pRig2D.linearVelocity = Vector2.zero;
            pRig2D.AddForce(new Vector2(0, jumpUp), ForceMode2D.Impulse);
            pAnimator.SetBool("jump", true);

        }
    }

    void WallJump()
    {
        if (isWallJump)
        {

        }
        else
        {

        }
        //벽을 잡고있는 상태에서 점프
        isWallJump = true;
        //벽점프 먼지
        JumpDust();
        Invoke("FreezeX", 0.3f);
        //물리
        pRig2D.linearVelocity = new Vector2(-isRight * wallJumpPower, 0.9f * wallJumpPower);
        sp.flipX = sp.flipX == false ? true : false;
        isRight = -isRight;
    }

    void FreezeX()
    {
        isWallJump = false;
    }

    public void RunShadow()
    {
        if (sh.Count < 6)
        {
            GameObject go = Instantiate(shadow, transform.position, Quaternion.identity);
            go.GetComponent<Shadow>().TwSpeed = 10 - (sh.Count * 0.9f);
            go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
            sh.Add(go);
        }
    }

    //

    public void LandDust(GameObject dust)
    {
        Instantiate(dust, transform.position + new Vector3(0, -0.4f, 0), Quaternion.identity);
    }
    public void JumpDust()
    {
        Instantiate(jumpDust, transform.position + new Vector3(0, -0.4f, 0), Quaternion.identity);
    }
}
