using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed = 0.01f;
    [SerializeField] private float jumpPower = 100.0f;
    private bool isOnFloor;
    private Rigidbody rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        isOnFloor = true;
    }
    void Update()
    {
        Handle_MoveMent();
        Handle_Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null)
        {
            isOnFloor = true;
        }
        if (collision.collider.gameObject.CompareTag("Lava"))
        {
            Debug.Log("Game Over!!");
            Object.Destroy(this.gameObject);
        }
    }

    void Handle_Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
        {
            Debug.Log("jump");
            isOnFloor = false;
            rb.AddForce(Vector3.up * jumpPower);
        }
    }
    void Handle_MoveMent()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        this.transform.position += new Vector3(-xMove, 0, -yMove) * playerMoveSpeed;
    }
}
