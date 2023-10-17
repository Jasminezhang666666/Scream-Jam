using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    public float maxSpeed = 7f;
    public bool canMove = false;

    private Rigidbody2D rb;
    private float currentSpeed;
    private KeyCode previousKey;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = 0f;
        previousKey = KeyCode.None;
    }

    private void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (previousKey != KeyCode.A)
                {
                    currentSpeed = 0;
                }
                currentSpeed = Mathf.MoveTowards(currentSpeed, -maxSpeed, speed * Time.deltaTime);
                previousKey = KeyCode.A;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (previousKey != KeyCode.D)
                {
                    currentSpeed = 0;
                }
                currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, speed * Time.deltaTime);
                previousKey = KeyCode.D;
            }
            else
            {
                currentSpeed = 0;
                previousKey = KeyCode.None;
            }

            rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
        }
    }
}
