using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundLayer;

    public Transform orientation; // CameraHolder
    public MouseLook mouseLook;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Nếu đang mở chuột (UI mode) → không di chuyển
        if (!mouseLook.IsLocked()) return;

        // Check ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = orientation.forward * z + orientation.right * x;
        move.y = 0;

        rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.z * speed);

        // Nhảy
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
}