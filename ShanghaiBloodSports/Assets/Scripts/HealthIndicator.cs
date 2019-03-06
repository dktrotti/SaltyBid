using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    private TextMesh indicator;
    private Character character;

    // Start is called before the first frame update
    void Start()
    {
        indicator = GetComponent<TextMesh>();
        character = GetComponentInParent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        indicator.text = $"Health: {character.Health}\nGuard: {character.Guard}";
    }
}
