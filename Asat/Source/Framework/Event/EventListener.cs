namespace Asat.Framework.Event
{
    /// <summary>
    /// Defines the necessary functionality for a class to be able to register with an event manager
    /// as an event listener.
    /// </summary>
    public interface EventListener
    {
        /// <summary>
        /// Called when an event type that this event listener is listening to is launched.
        /// </summary>
        /// <typeparam name="DataType">The type of data attached to the event</typeparam>
        /// <param name="eve">The event</param>
        void OnEventReceived<DataType>(Event<DataType> eve);
    }
}
