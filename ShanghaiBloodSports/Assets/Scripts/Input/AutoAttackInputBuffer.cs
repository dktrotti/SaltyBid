using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public class AutoAttackInputBuffer : MonoBehaviour, IInputBuffer
    {
        public InputDevice Device { get; } = new DummyDevice();

        private DateTime lastAttackTime = DateTime.MinValue;
        public int secondsBetweenAttacks;

        public bool Match(InputSequence sequence)
        {
            var now = DateTime.Now;
            if (now > lastAttackTime.AddSeconds(secondsBetweenAttacks))
            {
                lastAttackTime = now;
                return true;
            }
            return false;
        }

        public bool Peek(InputSequence sequence)
        {
            return false;
        }
    }

    public class DummyDevice : InputDevice
    {
        public InputState GetInputState()
        {
            return new InputState(JoystickPosition.NEUTRAL);
        }
    }
}
