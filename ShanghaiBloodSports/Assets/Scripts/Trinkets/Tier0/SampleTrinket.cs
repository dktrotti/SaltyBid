using UnityEngine;
using UnityEditor;
using Assets.Scripts.Events;

public class SampleTrinket : TrinketBase
{
    private Sprite sprite = Resources.Load<Sprite>("Assets/Art/Sprites/punch");
    private EventHandler handler = new Handler();

    public override string Name => "Sample Trinket";
    public override string Description => "This is a sample trinket";
    public override Sprite Sprite => sprite;
    public override EventHandler EventHandler => handler;

    private class Handler : EventHandler
    {
        public override void onEvent(HitEvent e)
        {
            Debug.Log("Hit event occurred");
        }
    }
}