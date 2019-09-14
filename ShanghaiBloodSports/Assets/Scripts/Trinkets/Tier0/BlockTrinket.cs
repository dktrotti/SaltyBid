using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Events;
using Assets.Scripts.Input;
using Assets.Scripts.Moves;
using UnityEngine;

namespace Assets.Scripts.Trinkets.Tier0
{
    abstract class BlockTrinket : TrinketBase
    {
        private readonly Handler handler;

        public override GameEventHandler EventHandler => handler;

        protected BlockTrinket(Handler handler)
        {
            this.handler = handler;
        }

        public override void onEquip(Character owner)
        {
            handler.owner = owner;
        }

        protected abstract class Handler : GameEventHandler
        {
            private readonly Animator animator;

            public Character owner;

            public Handler(Animator animator)
            {
                this.animator = animator;
            }

            protected abstract bool isTypeBlockable(Moves.MoveType type);
            protected abstract RelativeInputSequence getInputSequence();
            protected abstract string getAnimationTriggerName();

            public override void onEvent(HitEvent e)
            {
                var target = e.Args.target;
                var move = e.Args.move;
                var buffer = owner.InputBuffer;
                var translator = owner.InputTranslator;

                if (target == owner
                    && move.Blockable
                    && isTypeBlockable(move.Type)
                    && buffer.Peek(translator.Translate(getInputSequence())))
                {
                    e.Cancel();
                    animator.SetTrigger(getAnimationTriggerName());
                }
            }
        }
    }

    class LowBlockTrinket : BlockTrinket
    {
        public override string Name => "Shin Guards";
        public override string Description => "Allows blocking attacks aimed at the shins";
        public override Sprite Sprite => null;

        public LowBlockTrinket(Animator animator) : base(new LowBlockHandler(animator)) {}

        private class LowBlockHandler : Handler
        {
            public LowBlockHandler(Animator animator) : base(animator) {}

            protected override string getAnimationTriggerName()
            {
                return "low_block";
            }

            protected override RelativeInputSequence getInputSequence()
            {
                return new RelativeInputSequence(new RelativeInput(
                    RelativeJoystickPosition.DOWN_BACKWARD));
            }

            protected override bool isTypeBlockable(MoveType type)
            {
                return type == MoveType.LOW;
            }
        }
    }

    class HighBlockTrinket : BlockTrinket
    {
        public override string Name => "Non-shin Guards";
        public override string Description => "Allows blocking attacks aimed at everything but the shins";
        public override Sprite Sprite => null;

        public HighBlockTrinket(Animator animator) : base(new HighBlockHandler(animator)) { }

        private class HighBlockHandler : Handler
        {
            public HighBlockHandler(Animator animator) : base(animator) { }

            protected override string getAnimationTriggerName()
            {
                return "high_block";
            }

            protected override RelativeInputSequence getInputSequence()
            {
                return new RelativeInputSequence(new RelativeInput(
                    RelativeJoystickPosition.BACKWARD));
            }

            protected override bool isTypeBlockable(MoveType type)
            {
                return type == MoveType.MID || type == MoveType.HIGH;
            }
        }
    }
}
