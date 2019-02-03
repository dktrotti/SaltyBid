namespace Assets.Scripts.Events {
    public class WalkStartEventArgs : EventArgs { }

    public class WalkStartEvent : Event<WalkStartEventArgs> {
        public WalkStartEvent(WalkStartEventArgs args, EventSource source) : base(args, source) {
        }
    }
}
