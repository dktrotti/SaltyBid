namespace Assets.Scripts.Events
{
    public class BlockEventArgs : EventArgs { }

    public class BlockEvent : GameEvent<BlockEventArgs>
    {
        public BlockEvent(BlockEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
