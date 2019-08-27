using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Events;
using Assets.Scripts.Input;
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

    public class PunchTrinket : MoveTrinket
    {
        private readonly Animator animator;
        private readonly InputBuffer inputBuffer;
        
        private static readonly InputSequence inputSequence =
            new InputSequence(new List<Input.Input> {
                new Input.Input(JoystickPosition.RIGHT),
                new Input.Input(Button.BUTTON1)
            });

        public override string Name => "Fist of the North Star";
        public override string Description => "Omae wa mou shindeiru";
        public override Sprite Sprite => null;

        public PunchTrinket(
            Character owner,
            Animator animator,
            InputBuffer inputBuffer) : base(owner)
        {
            this.animator = animator;
            this.inputBuffer = inputBuffer;
        }

        public override void OnUpdate()
        {
            if (inputBuffer.Match(inputSequence))
            {
                animator.SetTrigger("punch");
            }
        }
    }
}
