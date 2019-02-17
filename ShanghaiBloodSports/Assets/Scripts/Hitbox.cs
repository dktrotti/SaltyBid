using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Hitbox : MonoBehaviour
{
    public bool Active { get; set; } = false;

    private Character owner {
        get {
            return GetComponentInParent<Character>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        Hitbox other = col.collider.GetComponent<Hitbox>();
        if (other != null && Active && !other.Active)
        {
            // TODO: Find a way to deactive the entire move?
            // This allows the same move to hit the opponent multiple times in different hitboxes
            Active = false;

            owner.Opponent.Health -= 10;
            // TODO: Emit hit event with owner's current move
        }
    }
}
