using Assets.Scripts.Input;
using Assets.Scripts.Moves;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class SamplePlayer : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Character character = GetComponent<Character>();
        character.EquipTrinket(new PunchTrinket(character, animator));
        character.EquipTrinket(new LowKickTrinket(character, animator));
        character.EquipTrinket(new HighKickTrinket(character, animator));
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Reimplement blocking using a trinket
        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("neutral"))
        //{
        //    if (inputBuffer.Peek(KeyCode.O))
        //    {
        //        animator.SetBool("high_block", true);
        //    }

        //    if (inputBuffer.Peek(KeyCode.L))
        //    {
        //        animator.SetBool("low_block", true);
        //    }
        //}

        //if (!inputBuffer.Peek(KeyCode.O))
        //{
        //    animator.SetBool("high_block", false);
        //}

        //if (!inputBuffer.Peek(KeyCode.L))
        //{
        //    animator.SetBool("low_block", false);
        //}
    }
}
