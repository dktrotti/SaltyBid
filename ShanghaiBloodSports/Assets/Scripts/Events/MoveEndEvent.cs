namespace Assets.Scripts.Events
{
    public class MoveEndEventArgs : EventArgs { }

    public class MoveEndEvent : GameEvent<MoveEndEventArgs>
    {
        public MoveEndEvent(MoveEndEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
