using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour
{

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public EntityFX fx { get; private set; }
    #endregion

    [Header("Knockback Settings")]
    [SerializeField] protected Vector2 knockbackDirection;
    [SerializeField] protected float knockbackDuration;
    protected bool isKnockback;

    [Header("Collision Settings")]
    public Transform attackCheck;
    public float attackCheckRadius = 0.5f;

    [SerializeField] Transform groundCheckTransform;
    [SerializeField] protected float groundCheckDistance = 0.1f;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform wallCheckTransform;
    [SerializeField] protected float wallCheckDistance = 0.1f;

    public int facingDirection { get; private set; } = 1;
    protected bool facingRight = true;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        fx = GetComponent<EntityFX>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Update()
    {

    }

    public virtual void Damage()
    {
        fx.StartCoroutine("FlashFX");
        StartCoroutine("HitKnockBack");
        Debug.Log(gameObject.name + "데미지를 입혔다.");

    }

    IEnumerator HitKnockBack()
    {
        isKnockback = true;
        rb.linearVelocity = new Vector2(knockbackDirection.x, knockbackDirection.y);
        yield return new WaitForSeconds(knockbackDuration);
        isKnockback = false;
    }


    #region collision
    public virtual bool IsGround()
    {
        return Physics2D.Raycast(groundCheckTransform.position, Vector2.down, groundCheckDistance, groundLayer);
    }
    public virtual bool IsWall()
    {
        return Physics2D.Raycast(wallCheckTransform.position, Vector2.right * facingDirection, wallCheckDistance, groundLayer);
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckTransform.position, groundCheckTransform.position + Vector3.down * groundCheckDistance);
        Gizmos.DrawLine(wallCheckTransform.position, wallCheckTransform.position + Vector3.right * facingDirection * wallCheckDistance);
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }

    #endregion

    #region Flip
    public virtual void Flip()
    {
        facingDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }
    #endregion

    #region Vecloity
    public virtual void SetVelocity(float _x, float _y)
    {
        rb.linearVelocity = new Vector2(_x, _y);
        FlipController(_x);
    }
    public void SetVelocityZero()
    {
        rb.linearVelocity = Vector2.zero;
    }
    #endregion

}