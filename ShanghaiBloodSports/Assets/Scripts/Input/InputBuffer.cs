using System;
using System.Collections;
using System.Collections.Generic;
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
        
        private readonly Queue<InputState> buffer;
        private InputDevice device;

        void Start()
        {
            device = new KeyboardDevice(Keyboard.current);
        }

        void Update()
        {
            buffer.Enqueue(device.GetInputState());
            trimBuffer();
        }

        public bool Match(InputSequence sequence)
        {
            throw new NotImplementedException();
        }

        public bool Peek(InputSequence sequence)
        {
            throw new NotImplementedException();
        }

        private void trimBuffer()
        {
            // TODO: Make this method thread safe
            while (buffer.Count > BUFFER_LENGTH)
            {
                buffer.Dequeue();
            }
        }
    }
}
