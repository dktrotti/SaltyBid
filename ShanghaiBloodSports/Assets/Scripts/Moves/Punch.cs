using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Moves
{
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

        public Punch(Player player) : base(player) { }

        public override void StartAnimation()
        {
            animationEvents += handleAnimationEvent;

            player.Animator.SetTrigger("punch");
        }

        private void handleAnimationEvent(object sender, AnimationEventArgs e)
        {
            // TODO: Change this to an enum?
            switch (e.EventName)
            {
                case "hitboxActivate":
                    player.setHitboxState(Player.HitboxPath.RIGHT_HAND, true);
                    break;
                case "hitboxDeactivate":
                    player.setHitboxState(Player.HitboxPath.RIGHT_HAND, false);
                    break;
            }
        }
    }
}
