using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerMove : MonoBehaviour
{
    private Rigidbody2D rB;
    private BoxCollider2D call;
    private Animator an;
    private SpriteRenderer sp;

    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState {idle, runing, jumping, falling}
    // Start is called before the first frame update
    private void Start()
    {
        call = GetComponent<BoxCollider2D>();
        sp = GetComponent<SpriteRenderer>();
        rB = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        Debug.Log("Move start");
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        bool isShooting = Input.GetKey(KeyCode.LeftControl);
        rB.velocity = new Vector2(dirX * 7f, rB.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rB.velocity = new Vector2(rB.velocity.x, 14f);
        }

        UpdateAmination(dirX, isShooting);
    }

    private void UpdateAmination(float dirX, bool isShooting)
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.runing;
            sp.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.runing;
            sp.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }


        if (rB.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rB.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        an.SetInteger("MovementState", (int)state);
        an.SetBool("IsShooting", isShooting);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(call.bounds.center, call.bounds.size, 0f, Vector2.down, 1f, jumpableGround);
    }
}
