using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Input
{
    /// <summary>
    /// Stores a fixed length history of inputs, and allows matching against an
    /// InputSequence to check whether a set of inputs has been received.
    /// </summary>
    public class InputBuffer : MonoBehaviour
    {
        private const int BUFFER_LENGTH = 200;
        
        private readonly Queue<InputState> buffer = new Queue<InputState>();
        private InputDevice device;

        void Start()
        {
            // TODO: Stop using hardcoded device
            device = new KeyboardDevice(Keyboard.current);
        }

        void Update()
        {
            buffer.Enqueue(device.GetInputState());
            trimBuffer(BUFFER_LENGTH);
        }

        public bool Match(InputSequence sequence)
        {
            // TODO: Thread safety concerns?
            int index = find(sequence);
            trimBuffer(index);
            return index != -1;
        }

        public bool Peek(InputSequence sequence)
        {
            return find(sequence) != -1;
        }

        /// <summary>
        /// Finds the index of the first InputState matching the provided
        /// sequence, or -1 if not found.
        /// </summary>
        private int find(InputSequence sequence)
        {
            var matcher = new InputSequenceMatcher(sequence);
            foreach ((InputState state, int index) in buffer.Select((x, i) => (x, i)))
            {
                if (matcher.isMatch(state))
                {
                    if (matcher.isComplete())
                    {
                        return index;
                    }
                }
                else
                {
                    matcher = new InputSequenceMatcher(sequence);
                }
            }
            return -1;
        }

        private void trimBuffer(int length)
        {
            // TODO: Make this method thread safe
            while (buffer.Count > length)
            {
                buffer.Dequeue();
            }
        }
    }
}
