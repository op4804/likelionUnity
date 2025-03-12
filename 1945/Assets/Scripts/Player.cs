using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;

    // ����
    private Vector2 minBounds;
    private Vector2 maxBounds;

    Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();

        // ȭ���� ��踦 ����
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        maxBounds = new Vector2(topRight.x, topRight.y);
    }

    // Update is called once per frame
    void Update()
    {
        // �̵�
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        // ���� �ִϸ��̼� ����
        if (Input.GetAxis("Horizontal") <= -0.5f)
        {
            ani.SetBool("left", true);
        }
        else
        {
            ani.SetBool("left", false);
        }
        
        // ������ �ִϸ��̼� ����
        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            ani.SetBool("right", true);
        }
        else
        {
            ani.SetBool("right", false);
        }

        // �� �ִϸ��̼� ����
        if (Input.GetAxis("Vertical") >= 0.2f)
        {
            ani.SetBool("up", true);
        }
        else
        {
            ani.SetBool("up", false);
        }

        // transform.Translate(moveX, moveY, 0);

        // ��踦 ����� �ʵ��� ��ġ ����
        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;

    }
}



