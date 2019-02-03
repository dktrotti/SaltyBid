namespace Assets.Scripts.Events
{
    public class UpdateEventArgs : EventArgs { }

    public class UpdateEvent : Event<UpdateEventArgs>
    {
        public UpdateEvent(UpdateEventArgs args, EventSource source) : base(args, source)
        {
        }
    }
}
