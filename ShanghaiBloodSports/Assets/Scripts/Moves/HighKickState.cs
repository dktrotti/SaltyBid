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
        protected override Move GetMove(Player player)
        {
            return new HighKick(player);
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

        public HighKick(Player player) : base(player) { }

        public static void StartAnimation(Animator animator)
        {
            animator.SetTrigger("high_kick");
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
