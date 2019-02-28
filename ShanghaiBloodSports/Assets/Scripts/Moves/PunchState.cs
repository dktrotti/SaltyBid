using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Moves
{
    public class PunchState : MoveState
    {
        protected override Move GetMove(Character character)
        {
            return new Punch(character);
        }
    }

    public class Punch : Move
    {
        public override string Name => "Punch";
        public override int Damage => 10;
        public override int GuardDamage => 10;
        public override MoveType Type => MoveType.HIGH;
        public override int MeterCost => 0;
        public override TimeSpan StunDuration => TimeSpan.Zero;
        public override bool Blockable => true;
        public override bool Parryable => true;

        public Punch(Character character) : base(character) { }

        public static void StartAnimation(Animator animator)
        {
            animator.SetTrigger("punch");
        }

        protected override void handleAnimationEvent(object sender, AnimationEventArgs e)
        {
            switch (e.Type)
            {
                case AnimationEventType.HITBOX_ACTIVATE:
                    character.setHitboxState(Character.HitboxPath.RIGHT_HAND, true);
                    break;
                case AnimationEventType.HITBOX_DEACTIVATE:
                    character.setHitboxState(Character.HitboxPath.RIGHT_HAND, false);
                    break;
            }
        }
    }
}
