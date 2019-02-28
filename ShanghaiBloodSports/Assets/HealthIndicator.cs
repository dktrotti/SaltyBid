using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class HealthIndicator : MonoBehaviour
{
    private TextMesh healthIndicator;

    // Start is called before the first frame update
    void Start()
    {
        healthIndicator = transform.GetChild(0).GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void Update()
    {
        var character = GetComponent<Character>();
        healthIndicator.text = $"Health: {character.Health}\nGuard: {character.Guard}";
    }
}
