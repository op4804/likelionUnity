using UnityEngine;

public class Entity : MonoBehaviour
{

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    [Header("�浹 ó��")]
    // �� üũ
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] protected float groundCheckDistance = 0.1f;
    [SerializeField] protected LayerMask groundLayer;
    // �� üũ
    [SerializeField] protected Transform wallCheckTransform;
    [SerializeField] protected float wallCheckDistance = 0.1f;

    public int facingDirection { get; private set; } = 1; // 1: ������, -1: ����
    protected bool facingRight = true; // true: ������, false: ����

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Update()
    {

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
    public void ZeroVelocity()
    {
        rb.linearVelocity = Vector2.zero;
    }
    #endregion

}