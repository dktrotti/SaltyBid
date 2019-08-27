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
    public abstract class MoveTrinket : TrinketBase
    {
        private readonly GameEventHandler handler;
        private readonly Character owner;

        public override GameEventHandler EventHandler => handler;

        public MoveTrinket(Character owner)
        {
            handler = new Handler(this);
            this.owner = owner;
        }

        public abstract void OnUpdate();

        private class Handler : GameEventHandler
        {
            private readonly MoveTrinket trinket;

            public Handler(MoveTrinket trinket)
            {
                this.trinket = trinket;
            }

            public override void onEvent(UpdateEvent e)
            {
                if (trinket.owner.CurrentMove == null)
                {
                    trinket.OnUpdate();
                }
            }
        }
    }
}
