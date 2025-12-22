using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] float Speed = 8;
    [SerializeField] float JumpForce = 3.5f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * Speed, body.linearVelocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, JumpForce);
        }

    }
}