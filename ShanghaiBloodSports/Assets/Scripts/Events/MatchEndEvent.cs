namespace Assets.Scripts.Events
{
    public class MatchEndEventArgs : EventArgs { }

    public class MatchEndEvent : GameEvent<MatchEndEventArgs>
    {
        public MatchEndEvent(MatchEndEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
