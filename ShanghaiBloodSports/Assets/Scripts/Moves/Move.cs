using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Moves
{
    public abstract class Move
    {
        public event EventHandler<AnimationEventArgs> animationEvents;

        public abstract string Name { get; }
        public abstract int Damage { get; }
        public abstract int GuardDamage { get; }
        public abstract MoveType Type { get; }
        public abstract int MeterCost { get; }
        public abstract TimeSpan StunDuration { get; }
        public abstract bool Blockable { get; }
        public abstract bool Parryable { get; }
        protected abstract void handleAnimationEvent(object sender, AnimationEventArgs e);

        protected readonly Player player;

        public Move(Player player)
        {
            this.player = player;
            animationEvents += handleAnimationEvent;
        }

        public void OnAnimationEvent(string eventName)
        {
            AnimationEventType type;
            switch (eventName)
            {
                case "hitboxActivate":
                    type = AnimationEventType.HITBOX_ACTIVATE;
                    break;
                case "hitboxDeactivate":
                    type = AnimationEventType.HITBOX_DEACTIVATE;
                    break;
                default:
                    Debug.LogError($"Unknown animation event: {eventName}");
                    return;
            }
            animationEvents(this, new AnimationEventArgs(type));
        }
    }

    public class AnimationEventArgs : EventArgs
    {
        public AnimationEventType Type { get; }

        public AnimationEventArgs(AnimationEventType type)
        {
            Type = type;
        }
    }

    public enum MoveType
    {
        HIGH,
        MID,
        LOW
    }

    public enum AnimationEventType
    {
        HITBOX_ACTIVATE,
        HITBOX_DEACTIVATE
    }
}
