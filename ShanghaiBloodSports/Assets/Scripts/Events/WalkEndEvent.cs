namespace Assets.Scripts.Events
{
    public class WalkEndEventArgs : EventArgs { }

    public class WalkEndEvent : GameEvent<WalkEndEventArgs>
    {
        public WalkEndEvent(WalkEndEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
