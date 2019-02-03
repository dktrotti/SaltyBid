namespace Assets.Scripts.Events
{
    public class DamageEventArgs : EventArgs { }

    public class DamageEvent : Event<DamageEventArgs>
    {
        public DamageEvent(DamageEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
