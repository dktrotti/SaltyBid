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
        public IEnumerable<Input> Inputs { get; }

        public InputSequence(IEnumerable<Input> inputs)
        {
            this.Inputs = inputs;
        }
    }

    /// <summary>
    /// Stateful class for keeping track of progress while matching an InputBuffer
    /// against an InputSequence.
    /// </summary>
    class InputSequenceMatcher
    {
        private readonly IEnumerator<Input> sequence;
        // Keep track of previous input to allow a single Input to match
        // repeatedly. This wouldn't be necessary if IEnumerator had a peek()
        // method, but it works for now.
        private Input previousInput;
        private bool complete = false;

        public InputSequenceMatcher(InputSequence sequence)
        {
            this.sequence = sequence.Inputs.GetEnumerator();
            // Start by advancing the enumerator, makes match() logic simpler
            if (this.sequence.MoveNext() == false)
            {
                // Indicates empty InputSequence
                complete = true;
            }
        }

        /// <summary>
        /// Checks if the provided InputState matches the current position in
        /// the InputSequence. If the state does match, this method will also
        /// advance the internal position in the sequence.
        /// 
        /// Note: Will always return true if the full input sequence has been\
        /// matched.
        /// </summary>
        public bool isMatch(InputState inputState)
        {
            if (isComplete())
            {
                return true;
            }

            if (sequence.Current.Matches(inputState))
            {
                previousInput = sequence.Current;
                if (!sequence.MoveNext())
                {
                    complete = true;
                }
                return true;
            }
            else if (previousInput?.Matches(inputState) ?? false)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Indicates whether the full input sequence has been matched.
        /// </summary>
        public bool isComplete()
        {
            return complete;
        }
    }

    /// <summary>
    /// Represents a required input as part of an InputSequence.
    /// </summary>
    public class Input
    {
        public HashSet<Button> Buttons { get; }
        public JoystickPosition? JoystickPosition { get; }

        public Input(Button button)
        {
            this.Buttons = new HashSet<Button>() { button };
            this.JoystickPosition = null;
        }

        public Input(JoystickPosition joystickPosition)
        {
            this.Buttons = new HashSet<Button>();
            this.JoystickPosition = joystickPosition;
        }

        public Input(IEnumerable<Button> buttons, JoystickPosition joystickPosition)
        {
            this.Buttons = new HashSet<Button>(buttons);
            this.JoystickPosition = joystickPosition;
        }

        public bool Matches(InputState inputState)
        {
            bool joystickMatches = !JoystickPosition.HasValue
                    || JoystickPosition == inputState.JoystickPosition;
            bool buttonsMatch = Buttons.SetEquals(inputState.Buttons);

            return joystickMatches && buttonsMatch;
        }
    }
}
