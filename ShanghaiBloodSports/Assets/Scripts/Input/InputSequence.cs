using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Input
{
    /// <summary>
    /// Represents a sequence of inputs that can be matched against an InputBuffer.
    /// </summary>
    // TODO: Is this class necessary?
    public class InputSequence
    {
        public IEnumerable<Input> inputs { get; }

        public InputSequence(IEnumerable<Input> inputs)
        {
            this.inputs = inputs;
        }
    }

    /// <summary>
    /// Represents a required input as part of an InputSequence.
    /// </summary>
    public class Input
    {
        public IEnumerable<Button> buttons { get; }
        public JoystickPosition? joystickPosition { get; }

        public Input(Button button)
        {
            this.buttons = new List<Button>() { button };
            this.joystickPosition = null;
        }

        public Input(JoystickPosition joystickPosition)
        {
            this.buttons = new List<Button>();
            this.joystickPosition = joystickPosition;
        }

        public Input(IEnumerable<Button> buttons, JoystickPosition joystickPosition)
        {
            this.buttons = buttons;
            this.joystickPosition = joystickPosition;
        }

        bool Matches(InputState inputState)
        {
            bool joystickMatches = joystickPosition.HasValue
                    && joystickPosition == inputState.joystickPosition;
            bool buttonsMatch = inputState.buttons.All(
                    pair => pair.Value == buttons.Contains(pair.Key));

            return joystickMatches && buttonsMatch;
        }
    }
}
