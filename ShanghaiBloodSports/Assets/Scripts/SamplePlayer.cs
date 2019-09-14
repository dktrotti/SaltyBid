using Assets.Scripts.Input;
using Assets.Scripts.Moves;
using Assets.Scripts.Trinkets.Tier0;
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
        character.EquipTrinket(new LowBlockTrinket(animator));
        character.EquipTrinket(new HighBlockTrinket(animator));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
