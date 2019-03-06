using Assets.Scripts.Moves;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayer : MonoBehaviour
{
    private MockInputBuffer inputBuffer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        inputBuffer = GetComponent<MockInputBuffer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("neutral"))
        {
            if (inputBuffer.Match(KeyCode.J))
            {
                Punch.StartAnimation(animator);
            }

            if (inputBuffer.Match(KeyCode.K))
            {
                LowKick.StartAnimation(animator);
            }

            if (inputBuffer.Match(KeyCode.I))
            {
                HighKick.StartAnimation(animator);
            }

            if (inputBuffer.Peek(KeyCode.O))
            {
                animator.SetBool("high_block", true);
            }

            if (inputBuffer.Peek(KeyCode.L))
            {
                animator.SetBool("low_block", true);
            }
        }

        if (!inputBuffer.Peek(KeyCode.O))
        {
            animator.SetBool("high_block", false);
        }

        if (!inputBuffer.Peek(KeyCode.L))
        {
            animator.SetBool("low_block", false);
        }
    }
}
