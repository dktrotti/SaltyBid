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
        private readonly InputBufferImpl buffer = new InputBufferImpl();
        private InputDevice device;

        void Start()
        {
            // TODO: Stop using hardcoded device
            device = new KeyboardDevice(Keyboard.current);
        }

        void Update()
        {
            buffer.AddInputState(device.GetInputState());
        }

        public bool Match(InputSequence sequence)
        {
            return buffer.Match(sequence);
        }

        public bool Peek(InputSequence sequence)
        {
            return buffer.Peek(sequence);
        }
    }

    /// <summary>
    /// This class was split from InputBuffer for testing. Unity was not working
    /// with the test assembly, so the testable component has been separated from
    /// the Unity component.
    /// </summary>
    public class InputBufferImpl
    {
        private const int BUFFER_LENGTH = 200;
        
        private readonly Queue<InputState> buffer = new Queue<InputState>();

        /// <summary>
        /// Adds an InputState to the buffer.
        /// 
        /// Note: This method is visible for testing purposes. It should not
        /// be used externally.
        /// </summary>
        public void AddInputState(InputState input)
        {
            buffer.Enqueue(input);
            trimBuffer(BUFFER_LENGTH);
        }

        public bool Match(InputSequence sequence)
        {
            // TODO: Thread safety concerns?
            int index = find(sequence);
            if (index != -1)
            {
                var newLen = buffer.Count - (index + 1);
                trimBuffer(newLen);
            }
            return index != -1;
        }

        public bool Peek(InputSequence sequence)
        {
            return find(sequence) != -1;
        }

        /// <summary>
        /// Finds the index of the first (i.e oldest) InputState matching
        /// the provided sequence, or -1 if not found.
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
