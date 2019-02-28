using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Character Opponent { get; private set; }

    public double Health { get; set; } = 100;
    public double Guard { get; set; } = 100;

    // Start is called before the first frame update
    void Start()
    {
        Opponent = FindObjectsOfType<Character>().Where(c => c != this).Single();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
