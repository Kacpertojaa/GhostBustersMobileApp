using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 direction = new Vector2(movementJoystick.Horizontal, movementJoystick.Vertical);

        if (direction.magnitude != 0)
        {
            rb.velocity = direction.normalized * playerSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
