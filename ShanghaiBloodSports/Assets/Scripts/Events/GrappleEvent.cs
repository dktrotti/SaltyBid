namespace Assets.Scripts.Events
{
    public class GrappleEventArgs : EventArgs { }

    public class GrappleEvent : GameEvent<GrappleEventArgs>
    {
        public GrappleEvent(GrappleEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
