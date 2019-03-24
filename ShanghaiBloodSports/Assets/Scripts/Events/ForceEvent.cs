namespace Assets.Scripts.Events
{
    public class ForceEventArgs : EventArgs { }

    public class ForceEvent : GameEvent<ForceEventArgs>
    {
        public ForceEvent(ForceEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
