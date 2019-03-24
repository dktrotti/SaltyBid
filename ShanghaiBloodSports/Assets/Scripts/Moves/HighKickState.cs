using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Moves
{
    public class HighKickState : MoveState
    {
        protected override Move GetMove(Character character)
        {
            return new HighKick(character);
        }
    }

    public class HighKick : Move
    {
        public override string Name => "High Kick";
        public override int Damage => 20;
        public override int GuardDamage => 15;
        public override MoveType Type => MoveType.HIGH;
        public override int MeterCost => 0;
        public override TimeSpan StunDuration => TimeSpan.FromMilliseconds(100);
        public override bool Blockable => true;
        public override bool Parryable => true;

        public HighKick(Character character) : base(character) { }

        protected override void handleAnimationEvent(object sender, AnimationEventArgs e)
        {
            switch (e.Type)
            {
                case AnimationEventType.HITBOX_ACTIVATE:
                    character.setHitboxState(Character.HitboxPath.RIGHT_FOOT, true);
                    break;
                case AnimationEventType.HITBOX_DEACTIVATE:
                    character.setHitboxState(Character.HitboxPath.RIGHT_FOOT, false);
                    break;
            }
        }
    }

    public class HighKickTrinket : MoveTrinket
    {
        private readonly Animator animator;
        private readonly MockInputBuffer inputBuffer;

        public override string Name => "Chin Splitter";
        public override string Description => "It turns out that a split chin hurts a little more";
        public override Sprite Sprite => null;

        public HighKickTrinket(
            Character owner,
            Animator animator,
            MockInputBuffer inputBuffer) : base(owner)
        {
            this.animator = animator;
            this.inputBuffer = inputBuffer;
        }

        public override void OnUpdate()
        {
            if (inputBuffer.Match(KeyCode.I))
            {
                animator.SetTrigger("high_kick");
            }
        }
    }
}
