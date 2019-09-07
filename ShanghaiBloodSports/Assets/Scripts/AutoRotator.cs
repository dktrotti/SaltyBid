using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class AutoRotator : MonoBehaviour
{
    private bool prevState;

    // Start is called before the first frame update
    void Start()
    {
        prevState = ToLeftOfOpponent();
    }

    // Update is called once per frame
    void Update()
    {
        bool newState = ToLeftOfOpponent();
        if (newState != prevState)
        {
            transform.Rotate(0, 180, 0);
        }
        prevState = newState;
    }

    public bool FacingRight()
    {
        return prevState;
    }

    private bool ToLeftOfOpponent()
    {
        var opponent = GetComponent<Character>()?.Opponent;
        var relativeXPosition = opponent.transform.position.x - transform.position.x;

        return relativeXPosition > 0;
    }
}
