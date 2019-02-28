using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private Character character;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        character = GetComponentInParent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            switch (character.CurrentState)
            {
                case Character.State.NEUTRAL:
                    animator.SetBool("back_walk", false);
                    animator.SetBool("forward_walk", false);
                    animator.SetBool("midair", false);
                    break;
                case Character.State.MIDAIR:
                    animator.SetBool("back_walk", false);
                    animator.SetBool("forward_walk", false);
                    animator.SetBool("midair", true);
                    break;
                case Character.State.BACK_WALK:
                    animator.SetBool("back_walk", true);
                    animator.SetBool("forward_walk", false);
                    animator.SetBool("midair", false);
                    break;
                case Character.State.FORWARD_WALK:
                    animator.SetBool("back_walk", false);
                    animator.SetBool("forward_walk", true);
                    animator.SetBool("midair", false);
                    break;
            }
        }
    }

    public void onAnimationEvent(string eventName)
    {
        character.CurrentMove?.OnAnimationEvent(eventName);
        if (character.CurrentMove == null)
        {
            Debug.LogError($"Received animation event with no current move: {eventName}");
        }
    }
}
