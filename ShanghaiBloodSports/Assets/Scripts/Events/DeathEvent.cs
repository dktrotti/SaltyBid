namespace Assets.Scripts.Events
{
    public class DeathEventArgs : EventArgs { }
    public class DeathEvent : GameEvent<DeathEventArgs>
    {
        public DeathEvent(DeathEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
