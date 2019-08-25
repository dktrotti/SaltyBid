using NUnit.Framework;
using Assets.Scripts.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Input.Tests
{
    public class InputBufferImplTests
    {
        private readonly InputSequence SEQUENCE =
            new InputSequence(new List<Input> {
                new Input(JoystickPosition.DOWN),
                new Input(JoystickPosition.DOWN_RIGHT),
                new Input(JoystickPosition.RIGHT),
                new Input(Button.BUTTON1)
            });

        private InputBufferImpl buffer;

        [SetUp]
        public void SetUp()
        {
            buffer = new InputBufferImpl();
        }

        [Test]
        public void WhenBufferIsEmpty_MatchFails()
        {
            Assert.IsFalse(buffer.Match(SEQUENCE));
        }

        [Test]
        public void WhenSequenceIsIncomplete_MatchFails()
        {
            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));

            Assert.IsFalse(buffer.Match(SEQUENCE));
        }

        [Test]
        public void WhenSequenceIsInterrupted_MatchFails()
        {
            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_LEFT));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON1 },
                JoystickPosition.NEUTRAL));

            Assert.IsFalse(buffer.Match(SEQUENCE));
        }

        [Test]
        public void WhenBufferHasAdditionalButtonPresses_MatchFails()
        {
            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON1, Button.BUTTON2 },
                JoystickPosition.NEUTRAL));

            Assert.IsFalse(buffer.Match(SEQUENCE));
        }

        [Test]
        public void WhenSequenceIsPresent_MatchSucceeds()
        {
            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON1 },
                JoystickPosition.NEUTRAL));

            Assert.IsTrue(buffer.Match(SEQUENCE));
        }

        [Test]
        public void WhenSequenceIsPresentWithInputBefore_MatchSucceeds()
        {
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON2 },
                JoystickPosition.DOWN_LEFT));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON1 },
                JoystickPosition.NEUTRAL));

            Assert.IsTrue(buffer.Match(SEQUENCE));
        }

        [Test]
        public void WhenSequenceIsPresentWithInputAfter_MatchSucceeds()
        {
            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON1 },
                JoystickPosition.NEUTRAL));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON2 },
                JoystickPosition.DOWN_LEFT));

            Assert.IsTrue(buffer.Match(SEQUENCE));
        }

        [Test]
        public void WhenBufferHasJoystickInputDuringButtonPress_MatchSucceeds()
        {
            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON1 },
                JoystickPosition.UP_RIGHT));

            Assert.IsTrue(buffer.Match(SEQUENCE));
        }

        [Test]
        public void WhenMatchIsCalledAgain_MatchFails()
        {
            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON1 },
                JoystickPosition.NEUTRAL));

            Assert.IsTrue(buffer.Match(SEQUENCE));
            Assert.IsFalse(buffer.Match(SEQUENCE));
        }

        [Test]
        public void WhenSequenceIsMatched_OldInputsAreCleared()
        {
            var sequence2 = new InputSequence(new List<Input>() {
                new Input(JoystickPosition.DOWN),
                new Input(JoystickPosition.DOWN_LEFT)
            });

            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_LEFT));

            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON1 },
                JoystickPosition.NEUTRAL));

            Assert.IsTrue(buffer.Match(SEQUENCE));
            Assert.IsFalse(buffer.Match(sequence2));
        }

        [Test]
        public void WhenMaximumNumberOfInputsAreReceived_OldInputsAreCycled()
        {
            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_LEFT));

            for (int i = 0; i < 199; i++)
            {
                buffer.AddInputState(new InputState(JoystickPosition.LEFT));
            }

            Assert.IsFalse(buffer.Match(new InputSequence(
                new List<Input>() { new Input(JoystickPosition.DOWN) })));
            Assert.IsTrue(buffer.Match(new InputSequence(
                new List<Input>() { new Input(JoystickPosition.DOWN_LEFT) })));
        }

        [Test]
        public void WhenPeekIsCalledMultipleTimes_PeekSucceeds()
        {
            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON1 },
                JoystickPosition.NEUTRAL));

            Assert.IsTrue(buffer.Peek(SEQUENCE));
            Assert.IsTrue(buffer.Peek(SEQUENCE));
        }

        [Test]
        public void WhenBufferContainsRepeatedInputs_MatchSucceeds()
        {
            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON1 },
                JoystickPosition.NEUTRAL));

            Assert.IsTrue(buffer.Match(SEQUENCE));
        }

        [Test]
        public void WhenBufferContainsMultipleMatches_MatchSucceedsMultipleTimes()
        {
            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON1 },
                JoystickPosition.NEUTRAL));

            buffer.AddInputState(new InputState(JoystickPosition.DOWN));
            buffer.AddInputState(new InputState(JoystickPosition.DOWN_RIGHT));
            
            Assert.IsTrue(buffer.Match(SEQUENCE));

            buffer.AddInputState(new InputState(JoystickPosition.RIGHT));
            buffer.AddInputState(new InputState(
                new HashSet<Button>() { Button.BUTTON1 },
                JoystickPosition.NEUTRAL));

            Assert.IsTrue(buffer.Match(SEQUENCE));
        }
    }
}