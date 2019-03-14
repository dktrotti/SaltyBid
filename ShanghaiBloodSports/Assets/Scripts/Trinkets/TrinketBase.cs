using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrinketBase
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract Sprite Sprite { get; }
    public abstract EventHandler EventHandler { get; }

    public virtual void onEquip(Character owner) { }
    public virtual void onUnequip() { }
}
