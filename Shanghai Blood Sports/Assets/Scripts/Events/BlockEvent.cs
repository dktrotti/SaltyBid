namespace Assets.Scripts.Events {
    public class BlockEventArgs : EventArgs { }

    public class BlockEvent : Event<BlockEventArgs> {
        public BlockEvent(BlockEventArgs args, EventSource source) : base(args, source) {
        }
    }
}
