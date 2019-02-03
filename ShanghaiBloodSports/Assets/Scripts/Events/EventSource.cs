using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
    public class EventSource
    {
        private object source;
        private EventSource parent;

        public EventSource(object source) : this(source, null) { }

        public EventSource(object source, EventSource parent)
        {
            this.source = source;
            this.parent = parent;
        }

        /// <summary>
        /// Indicates whether the source chain contains the specified object.
        /// </summary>
        public bool Contains(object obj)
        {
            if (source == obj)
            {
                return true;
            }
            if (parent == null)
            {
                return false;
            }
            return parent.Contains(obj);
        }

        /// <summary>
        /// Checks the entire source chain for an instance of the specified type. The first instance
        /// found will be returned, or null if the specified type is not in the source chain.
        /// </summary>
        public T GetAncestor<T>() where T : class
        {
            return (source as T) ?? parent?.GetAncestor<T>();
        }
    }
}
