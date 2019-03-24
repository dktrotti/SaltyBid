namespace Assets.Scripts.Events
{
    public class StunEventArgs : EventArgs { }

    public class StunEvent : GameEvent<StunEventArgs>
    {
        public StunEvent(StunEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
