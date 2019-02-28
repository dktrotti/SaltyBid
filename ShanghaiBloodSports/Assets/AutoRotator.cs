using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class AutoRotator : MonoBehaviour
{
    private static readonly int FACE_RIGHT = 180;
    private static readonly int FACE_LEFT = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ToLeftOfOpponent())
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, FACE_LEFT);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, FACE_RIGHT);
        }
    }

    private bool ToLeftOfOpponent()
    {
        var opponent = GetComponent<Character>()?.Opponent;
        var relativeXPosition = opponent.transform.position.x - transform.position.x;

        return relativeXPosition > 0;
    }
}
