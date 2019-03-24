using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Trinkets.BaseTrinkets
{
    class DeathTrinket : TrinketBase
    {
        private Handler handler;
        private Character owner;

        public override string Name => "Frailty of Man";
        public override string Description => "People die when they are killed.";
        public override Sprite Sprite => null;
        public override Events.GameEventHandler EventHandler => handler;

        public DeathTrinket()
        {
            handler = new Handler(this);
        }

        public override void onEquip(Character owner)
        {
            this.owner = owner;
        }

        private class Handler : Events.GameEventHandler
        {
            private readonly DeathTrinket trinket;

            public Handler(DeathTrinket trinket)
            {
                this.trinket = trinket;
            }

            public override void onEvent(DamageEvent e)
            {
                e.AddOnResolve(args => {
                    if (args.target == trinket.owner && args.damage >= trinket.owner.Health)
                    {
                        trinket.owner.setDead();
                    }
                });
            }
        }
    }
}
