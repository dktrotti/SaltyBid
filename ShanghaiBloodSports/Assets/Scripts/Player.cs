using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private Animator animator;
    private State state = State.NEUTRAL;
    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var input = Input.GetAxis("Horizontal");
        var movement = input * speed;

        if (!grounded)
        {
            state = State.MIDAIR;
        }
        else if (input < 0)
        {
            state = State.BACK_WALK;
        }
        else if (input > 0)
        {
            state = State.FORWARD_WALK;
        }
        else
        {
            state = State.NEUTRAL;
        }

        UpdateAnimator();

        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && state != State.MIDAIR)
        {
            rb.AddForce(new Vector3(0, 200, 0));
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("neutral"))
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                animator.SetTrigger("punch");
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                animator.SetTrigger("low_kick");
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                animator.SetTrigger("high_kick");
            }

            if (Input.GetKey(KeyCode.O))
            {
                animator.SetBool("high_block", true);
            }

            if (Input.GetKey(KeyCode.L))
            {
                animator.SetBool("low_block", true);
            }
        }

        if (!Input.GetKey(KeyCode.O))
        {
            animator.SetBool("high_block", false);
        }

        if (!Input.GetKey(KeyCode.L))
        {
            animator.SetBool("low_block", false);
        }
    }

    private void UpdateAnimator()
    {
        switch (state)
        {
            case State.NEUTRAL:
                animator.SetBool("back_walk", false);
                animator.SetBool("forward_walk", false);
                animator.SetBool("midair", false);
                break;
            case State.MIDAIR:
                animator.SetBool("back_walk", false);
                animator.SetBool("forward_walk", false);
                animator.SetBool("midair", true);
                break;
            case State.BACK_WALK:
                animator.SetBool("back_walk", true);
                animator.SetBool("forward_walk", false);
                animator.SetBool("midair", false);
                break;
            case State.FORWARD_WALK:
                animator.SetBool("back_walk", false);
                animator.SetBool("forward_walk", true);
                animator.SetBool("midair", false);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            grounded = false;
        }
    }

    public enum State
    {
        NEUTRAL,
        MIDAIR,
        BACK_WALK,
        FORWARD_WALK
    };
}
