namespace Assets.Scripts.Events
{
    public class DamageEventArgs : EventArgs {
        public readonly Character target;
        public readonly int damage;

        public DamageEventArgs(Character target, int damage)
        {
            this.target = target;
            this.damage = damage;
        }
    }

    public class DamageEvent : GameEvent<DamageEventArgs>
    {
        public DamageEvent(DamageEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
