using Assets.Scripts.Moves;

namespace Assets.Scripts.Events
{
    public class HitEventArgs : EventArgs {
        public readonly Move move;
        public readonly Player source;
        public readonly Character target;

        public HitEventArgs(Move move, Player source, Character target)
        {
            this.move = move;
            this.source = source;
            this.target = target;
        }
    }

    public class HitEvent : Event<HitEventArgs>
    {
        public HitEvent(HitEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
