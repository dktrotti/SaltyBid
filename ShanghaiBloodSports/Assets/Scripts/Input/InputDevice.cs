using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Input
{
    /// <summary>
    /// Abstraction for an input device to be used to fill an InputBuffer.
    /// </summary>
    interface InputDevice
    {
        InputState GetInputState();
    }

    class KeyboardDevice : InputDevice
    {
        private Keyboard keyboard;

        public KeyboardDevice(Keyboard keyboard)
        {
            this.keyboard = keyboard;
        }

        public InputState GetInputState()
        {
            bool button1Pressed = keyboard[Key.J].ReadValue() == 1;
            bool button2Pressed = keyboard[Key.K].ReadValue() == 1;
            bool button3Pressed = keyboard[Key.U].ReadValue() == 1;
            bool button4Pressed = keyboard[Key.I].ReadValue() == 1;
            JoystickPosition joystickPosition = getJoystickPosition();

            return new InputState(
                    button1Pressed,
                    button2Pressed,
                    button3Pressed,
                    button4Pressed,
                    joystickPosition);
        }

        private JoystickPosition getJoystickPosition()
        {
            bool leftPressed = keyboard[Key.A].ReadValue() == 1;
            bool rightPressed = keyboard[Key.D].ReadValue() == 1;
            bool upPressed = keyboard[Key.W].ReadValue() == 1;
            bool downPressed = keyboard[Key.S].ReadValue() == 1;

            // Note: This assumes that an invalid combination will never be pressed.
            // This logic could definitely be improved.
            if (leftPressed && upPressed) return JoystickPosition.UP_LEFT;
            else if (leftPressed && downPressed) return JoystickPosition.DOWN_LEFT;
            else if (rightPressed && upPressed) return JoystickPosition.UP_RIGHT;
            else if (rightPressed && downPressed) return JoystickPosition.DOWN_RIGHT;
            else if (upPressed) return JoystickPosition.UP;
            else if (downPressed) return JoystickPosition.DOWN;
            else if (leftPressed) return JoystickPosition.LEFT;
            else if (rightPressed) return JoystickPosition.RIGHT;
            else return JoystickPosition.NEUTRAL;
        }
    }

    /// <summary>
    /// Represents the state of an InputDevice
    /// </summary>
    public class InputState
    {
        public IDictionary<Button, bool> buttons { get; }
        public JoystickPosition joystickPosition { get; }

        public InputState(
            bool button1Pressed,
            bool button2Pressed,
            bool button3Pressed,
            bool button4Pressed,
            JoystickPosition joystickPosition)
        {
            buttons = new Dictionary<Button, bool>() {
                [Button.BUTTON1] = button1Pressed,
                [Button.BUTTON2] = button2Pressed,
                [Button.BUTTON3] = button3Pressed,
                [Button.BUTTON4] = button4Pressed,
            };
            this.joystickPosition = joystickPosition;
        }
    }

    public enum Button
    {
        BUTTON1,
        BUTTON2,
        BUTTON3,
        BUTTON4
    }

    public enum JoystickPosition
    {
        UP_LEFT,
        UP,
        UP_RIGHT,
        LEFT,
        NEUTRAL,
        RIGHT,
        DOWN_LEFT,
        DOWN,
        DOWN_RIGHT
    }
}
