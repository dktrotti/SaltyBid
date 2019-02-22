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

        protected readonly Player player;

        public Move(Player player)
        {
            this.player = player;
        }

        public void OnAnimationEvent(string eventName)
        {
            animationEvents(this, new AnimationEventArgs(eventName));
        }
    }

    public class AnimationEventArgs : EventArgs
    {
        public string EventName { get; private set; }

        public AnimationEventArgs(string eventName)
        {
            EventName = eventName;
        }
    }

    public enum MoveType
    {
        HIGH,
        MID,
        LOW
    }
}
