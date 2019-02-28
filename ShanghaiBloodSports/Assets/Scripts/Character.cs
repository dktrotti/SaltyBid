using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    private TextMesh healthIndicator;
    private double health = 100;
    private double guard = 100;

    public Character Opponent { get; private set; }

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
        Opponent = FindObjectsOfType<Character>().Where(c => c != this).Single();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
