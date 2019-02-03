namespace Assets.Scripts.Events
{
    public class JumpEventArgs : EventArgs { }

    public class JumpEvent : Event<JumpEventArgs>
    {
        public JumpEvent(JumpEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
