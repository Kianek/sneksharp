using Snek.Models;
using System;
namespace Snek.Services
{
    /// <summary>
    /// Wraps the DirectionMapper class, and communicates with the Engine via events,
    /// which are raised in response to user direction input.
    /// </summary>
    public class DirectionInputListener
    {
        private Point previousLocation;
        private DirectionMapper mapper;
        public bool IsListening { get; private set; }

        // Events and Delegates
        public event EventHandler<DirectionEventArgs> OnKeyPress;

        public DirectionInputListener(DirectionMapper mapper)
        {
            this.mapper = mapper;
            IsListening = false;
            previousLocation = new Point();
        }

        protected virtual void OnDirectionChange(Object source, DirectionEventArgs e)
        {
            var handler = OnKeyPress;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Starts the input event loop, and invokes the assigned event handler when the user
        /// presses one of the arrow keys.
        /// </summary>
        public void Listen()
        {
            Direction direction;
            Point newLocation;
            IsListening = true;
            var handler = OnKeyPress;
            while (IsListening)
            {
                direction = mapper.GetDirectionFromKey(Console.ReadKey(true));
                newLocation = mapper.CalculateNewPosition(previousLocation, direction);
                OnDirectionChange(this, new DirectionEventArgs(direction, previousLocation, newLocation));
                previousLocation = newLocation;
            }
        }

        /// <summary>
        /// Terminates the event loop by setting IsListening to false.
        /// </summary>
        public void Stop() => IsListening = false;
    }
}