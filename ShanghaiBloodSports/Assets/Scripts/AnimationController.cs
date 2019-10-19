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
