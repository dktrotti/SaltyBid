using Assets.Scripts.Moves;

namespace Assets.Scripts.Events
{
    public class HitEventArgs : EventArgs {
        public readonly Move move;
        public readonly Character source;
        public readonly Character target;

        public HitEventArgs(Move move, Character source, Character target)
        {
            this.move = move;
            this.source = source;
            this.target = target;
        }
    }

    public class HitEvent : GameEvent<HitEventArgs>
    {
        public HitEvent(HitEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
