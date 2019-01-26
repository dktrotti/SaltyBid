using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        var input = Input.GetAxis("Horizontal"); // This will give us left and right movement (from -1 to 1). 
        var movement = input * speed;

        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(new Vector3(0, 200, 0)); // Adds 100 force straight up, might need tweaking on that number
        }

        //if (input != 0) {
        //    animator.SetBool("walking", true);
        //} else {
        //    animator.SetBool("walking", false);
        //}

        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Neutral")) {
        //    if (Input.GetKeyDown(KeyCode.J)) {
        //        animator.SetTrigger("punch");
        //    }

        //    if (Input.GetKeyDown(KeyCode.K)) {
        //        animator.SetTrigger("low_kick");
        //    }

        //    if (Input.GetKeyDown(KeyCode.I)) {
        //        animator.SetTrigger("high_kick");
        //    }

        //    if (Input.GetKey(KeyCode.O)) {
        //        animator.SetBool("high_block", true);
        //    }

        //    if (Input.GetKey(KeyCode.L)) {
        //        animator.SetBool("low_block", true);
        //    }
        //}

        //if (!Input.GetKey(KeyCode.O)) {
        //    animator.SetBool("high_block", false);
        //}

        //if (!Input.GetKey(KeyCode.L)) {
        //    animator.SetBool("low_block", false);
        //}
    }

    void OnTriggerEnter2D(Collider2D col) // col is the trigger object we collided with
    {

    }
}
