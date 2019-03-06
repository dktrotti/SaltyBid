using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Moves
{
    public class LowKickState : MoveState
    {
        protected override Move GetMove(Character character)
        {
            return new LowKick(character);
        }
    }

    public class LowKick : Move
    {
        public override string Name => "Low Kick";
        public override int Damage => 5;
        public override int GuardDamage => 0;
        public override MoveType Type => MoveType.LOW;
        public override int MeterCost => 0;
        public override TimeSpan StunDuration => TimeSpan.FromMilliseconds(50);
        public override bool Blockable => true;
        public override bool Parryable => true;

        public LowKick(Character character) : base(character) { }

        public static void StartAnimation(Animator animator)
        {
            animator.SetTrigger("low_kick");
        }

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
}
