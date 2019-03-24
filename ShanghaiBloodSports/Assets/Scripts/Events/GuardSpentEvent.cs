namespace Assets.Scripts.Events
{
    public class GuardSpentEventArgs : EventArgs { }

    public class GuardSpentEvent : GameEvent<GuardSpentEventArgs>
    {
        public GuardSpentEvent(GuardSpentEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
