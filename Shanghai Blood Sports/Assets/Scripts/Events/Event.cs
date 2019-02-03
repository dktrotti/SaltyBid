using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events {
    public class EventArgs { }

    public class Event<ARGS> where ARGS : EventArgs {
        /// <summary>
        /// The original arguments of the event.
        /// </summary>
        public ARGS Args { get; }
        /// <summary>
        /// The source of this event.
        /// </summary>
        public EventSource Source { get; }

        private bool cancelled = false;
        private List<Func<ARGS, ARGS>> resolveHandlers = new List<Func<ARGS, ARGS>>();
        private List<Action<ARGS>> cancelHandlers = new List<Action<ARGS>>();

        public Event(ARGS args, EventSource source) {
            Args = args;
            Source = source;
        }

        /// <summary>
        /// Adds an action to be executed if the event is cancelled. The arguments will be the same
        /// as the original event arguments, and cannot be modified.
        /// </summary>
        public void AddOnCancel(Action<ARGS> func) {
            cancelHandlers.Add(func);
        }

        /// <summary>
        /// Adds an action to be executed if the event resolves. The arguments may be modified by
        /// returning an instance of the arguments with the desired modifications. These modifications
        /// will be visible to other event handlers.
        /// </summary>
        public void AddOnResolve(Func<ARGS, ARGS> func) {
            resolveHandlers.Add(func);
        }

        /// <summary>
        /// Adds an action to be executed if the event resolves. The arguments may have been modified
        /// by other event handlers.
        /// </summary>
        /// <param name="func"></param>
        public void AddOnResolve(Action<ARGS> func) {
            AddOnResolve(args => {
                func(args);
                return args;
            });
        }

        /// <summary>
        /// If an event is cancelled, then the cancellation handlers will be executed when the
        /// Execute() method is called. The resolve handers will not be called.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the event type does not support cancellation</exception>
        public virtual void Cancel() {
            cancelled = true;
        }

        /// <summary>
        /// Executes the appropriate handlers.
        /// </summary>
        /// <returns>The modified arguments, or null if the event was cancelled.</returns>
        public ARGS Execute() {
            if (cancelled) {
                cancelHandlers.ForEach(f => f(Args));
                return null;
            } else {
                return resolveHandlers.Aggregate(Args, (args, f) => f(args));
            }
        }
    }
}
