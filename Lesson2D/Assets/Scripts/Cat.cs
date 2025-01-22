using UnityEngine;

public class Cat : MonoBehaviour
{
    public float speed;
    public bool isJumping;
    public float jumpSpeed;
    Rigidbody2D rigidBody;

    Vector3 GetDirection()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, 0, 0);
        return direction;
    }

    private void Move(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private bool CheckJumpingInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Jump(float jumpSpeed)
    {
        rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FinishWall")
        {

        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 5.0f;
        isJumping = false;
        jumpSpeed = 5.5f;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(GetDirection(), speed);
        if (CheckJumpingInput())
        {
            Jump(jumpSpeed);
        }
    }
}
