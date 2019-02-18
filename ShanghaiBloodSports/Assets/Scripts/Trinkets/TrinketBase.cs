using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrinketBase : ScriptableObject
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract Sprite Sprite { get; }
    public abstract EventHandler EventHandler { get; }
}
