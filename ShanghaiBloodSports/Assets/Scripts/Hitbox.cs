using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Hitbox : MonoBehaviour
{
    public bool Active { get; set; } = false;
    private EventManager eventManager;

    private Character owner {
        get {
            return GetComponentInParent<Character>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        eventManager = GameObject.Find("FightScene")?.GetComponent<EventManager>();
        if (eventManager == null)
        {
            Debug.LogError("EventManager not found");
        }
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

            Character character = GetComponentInParent<Character>();
            Character target = other.GetComponentInParent<Character>();
            eventManager.raiseEvent(new HitEvent(
                new HitEventArgs(
                    character.CurrentMove,
                    character,
                    target),
                new EventSource(this)));
        }
    }
}
