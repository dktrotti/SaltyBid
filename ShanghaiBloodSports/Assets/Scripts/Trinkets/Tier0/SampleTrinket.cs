using UnityEngine;
using UnityEditor;
using Assets.Scripts.Events;

public class SampleTrinket : TrinketBase
{
    private Sprite sprite = Resources.Load<Sprite>("Assets/Art/Sprites/punch");
    private GameEventHandler handler = new Handler();

    public override string Name => "Sample Trinket";
    public override string Description => "This is a sample trinket";
    public override Sprite Sprite => sprite;
    public override GameEventHandler EventHandler => handler;

    private class Handler : GameEventHandler
    {
        public override void onEvent(HitEvent e)
        {
            Debug.Log("Hit event occurred");
        }
    }
}