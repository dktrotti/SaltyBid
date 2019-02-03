namespace Assets.Scripts.Events
{
    public class MoveEndEventArgs : EventArgs { }

    public class MoveEndEvent : Event<MoveEndEventArgs>
    {
        public MoveEndEvent(MoveEndEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
