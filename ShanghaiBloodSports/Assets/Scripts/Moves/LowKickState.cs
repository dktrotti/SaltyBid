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
        protected override Move GetMove(Player player)
        {
            return new LowKick(player);
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

        public LowKick(Player player) : base(player) { }

        public static void StartAnimation(Animator animator)
        {
            animator.SetTrigger("low_kick");
        }

        protected override void handleAnimationEvent(object sender, AnimationEventArgs e)
        {
            switch (e.Type)
            {
                case AnimationEventType.HITBOX_ACTIVATE:
                    player.setHitboxState(Player.HitboxPath.RIGHT_FOOT, true);
                    break;
                case AnimationEventType.HITBOX_DEACTIVATE:
                    player.setHitboxState(Player.HitboxPath.RIGHT_FOOT, false);
                    break;
            }
        }
    }
}
