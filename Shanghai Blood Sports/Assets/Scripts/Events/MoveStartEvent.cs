namespace Assets.Scripts.Events {
    public class MoveStartEventArgs : EventArgs { }

    public class MoveStartEvent : Event<MoveStartEventArgs> {
        public MoveStartEvent(MoveStartEventArgs args, EventSource source) : base(args, source) {
        }
    }
}
