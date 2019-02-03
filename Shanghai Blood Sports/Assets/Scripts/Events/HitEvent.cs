namespace Assets.Scripts.Events {
    public class HitEventArgs : EventArgs { }

    public class HitEvent : Event<HitEventArgs> {
        public HitEvent(HitEventArgs args, EventSource source) : base(args, source) {
        }
    }
}
