using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class EventManager : MonoBehaviour
    {
        private HashSet<GameEventHandler> handlers = new HashSet<GameEventHandler>();

        public void AddHandler(GameEventHandler handler)
        {
            handlers.Add(handler);
        }

        public void RemoveHandler(GameEventHandler handler)
        {
            handlers.Remove(handler);
        }

        void Update()
        {
            raiseEvent<UpdateEvent, UpdateEventArgs>(new UpdateEvent(
                new UpdateEventArgs(), new EventSource(this)));
        }

        /// <summary>
        /// Raises the specified event with no special handling. Events that require special
        /// handling will have a non generic overload, which should always be preferred if available.
        /// </summary>
        public void raiseEvent<EVENT, ARGS>(EVENT e)
            where EVENT : GameEvent<ARGS>
            where ARGS : EventArgs
        {
            foreach (var handler in handlers)
            {
                if (!e.Source.Contains(handler))
                {
                    handler.onEvent<EVENT, ARGS>(e);
                }
            }

            e.Execute();
        }
        
        public void raiseEvent(HitEvent e)
        {
            foreach (var handler in handlers)
            {
                if (!e.Source.Contains(handler))
                {
                    handler.onEvent<HitEvent, HitEventArgs>(e);
                }
            }

            HitEventArgs result = e.Execute();
            if (result != null)
            {
                raiseEvent(new DamageEvent(
                    new DamageEventArgs(result.target, result.move.Damage),
                    new EventSource(e, e.Source)));
            }
        }

        public void raiseEvent(DamageEvent e)
        {
            foreach (var handler in handlers)
            {
                if (!e.Source.Contains(handler))
                {
                    handler.onEvent<DamageEvent, DamageEventArgs>(e);
                }
            }

            DamageEventArgs result = e.Execute();
            if (result != null)
            {
                result.target.Health -= result.damage;
            }
        }
    }
}
