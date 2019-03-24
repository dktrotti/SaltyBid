namespace Assets.Scripts.Events
{
    public class ParryEventArgs : EventArgs { }

    public class ParryEvent : GameEvent<ParryEventArgs>
    {
        public ParryEvent(ParryEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
