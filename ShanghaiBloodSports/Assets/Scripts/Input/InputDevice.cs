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
    public interface InputDevice
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
            var buttons = new HashSet<Button>();
            if (keyboard[Key.J].ReadValue() == 1) buttons.Add(Button.BUTTON1);
            if (keyboard[Key.K].ReadValue() == 1) buttons.Add(Button.BUTTON2);
            if (keyboard[Key.U].ReadValue() == 1) buttons.Add(Button.BUTTON3);
            if (keyboard[Key.I].ReadValue() == 1) buttons.Add(Button.BUTTON4);
            JoystickPosition joystickPosition = getJoystickPosition();

            return new InputState(
                    buttons,
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
        public HashSet<Button> Buttons { get; }
        public JoystickPosition JoystickPosition { get; }

        public InputState(JoystickPosition joystickPosition)
            : this(new HashSet<Button>(), joystickPosition) {}

        public InputState(
            IEnumerable<Button> pressedButtons,
            JoystickPosition joystickPosition)
        {
            this.Buttons = new HashSet<Button>(pressedButtons);
            this.JoystickPosition = joystickPosition;
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
