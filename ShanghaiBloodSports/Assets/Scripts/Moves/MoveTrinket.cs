using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Moves
{
    public abstract class MoveTrinket : TrinketBase
    {
        private readonly Events.EventHandler handler;
        private readonly Character owner;

        public override Events.EventHandler EventHandler => handler;

        public MoveTrinket(Character owner)
        {
            handler = new Handler(this);
            this.owner = owner;
        }

        public abstract void OnUpdate();

        private class Handler : Events.EventHandler
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
