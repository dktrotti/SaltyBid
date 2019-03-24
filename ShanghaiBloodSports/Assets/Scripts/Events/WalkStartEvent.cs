namespace Assets.Scripts.Events
{
    public class WalkStartEventArgs : EventArgs { }

    public class WalkStartEvent : GameEvent<WalkStartEventArgs>
    {
        public WalkStartEvent(WalkStartEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
