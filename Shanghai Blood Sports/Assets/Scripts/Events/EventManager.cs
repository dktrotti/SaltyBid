using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events {
    class EventManager {
        private HashSet<EventHandler> handlers = new HashSet<EventHandler>();

        public void AddHandler(EventHandler handler) {
            handlers.Add(handler);
        }

        public void RemoveHandler(EventHandler handler) {
            handlers.Remove(handler);
        }

        /// <summary>
        /// Raises the specified event with no special handling. Events that require special
        /// handling will have a non generic overload, which should always be preferred if available.
        /// </summary>
        public void raiseEvent<EVENT, ARGS>(EVENT e)
            where EVENT : Event<ARGS>
            where ARGS : EventArgs {
            foreach (var handler in handlers) {
                if (!e.Source.Contains(handler)) {
                    handler.onEvent<EVENT, ARGS>(e);
                }
            }

            e.Execute();
        }
        
        // TODO: Add raiseEvent overloads for events that need additional handling
        // e.g. Hit event -> Damage event
    }
}
