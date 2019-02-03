namespace Assets.Scripts.Events
{
    public class MeterSpentEventArgs : EventArgs { }

    public class MeterSpentEvent : Event<MeterSpentEventArgs>
    {
        public MeterSpentEvent(MeterSpentEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
