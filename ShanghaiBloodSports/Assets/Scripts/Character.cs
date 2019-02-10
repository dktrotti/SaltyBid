using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    private TextMesh healthIndicator;
    private double health = 100;
    private double guard = 100;
    private static readonly int FACE_RIGHT = 180;
    private static readonly int FACE_LEFT  = 0;

    public double Health {
        get => health;
        set {
            health = value;
            healthIndicator.text = $"Health: {health}\nGuard: {guard}";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        healthIndicator = transform.GetChild(0).GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void Update()
    {
        if(ToLeftOfOpponent())
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, FACE_LEFT);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, FACE_RIGHT);
        }
    }

    private Character GetOpponent()
    {
        return FindObjectsOfType<Character>().Where(c => c != this).Single();
    }

    private bool ToLeftOfOpponent()
    {
        var opponent = GetOpponent();

        var relativeXPosition = opponent.transform.position.x - transform.position.x;

        return relativeXPosition > 0;
    }
}
