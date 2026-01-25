using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] float Speed = 6;
    [SerializeField] float JumpForce = 10;
    private Animator anim;
    [SerializeField] bool grounded;
    float horizontalInput;
    private float scaleNum = 6;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * Speed, body.linearVelocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(scaleNum, scaleNum, scaleNum);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-scaleNum, scaleNum, scaleNum);

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, JumpForce);
            grounded = false;
        }


        anim.SetBool("Run", horizontalInput != 0);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && grounded;
    }
}