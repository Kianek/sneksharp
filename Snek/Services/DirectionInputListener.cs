using Snek.Models;
using System;
namespace Snek.Services
{
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
            // TODO: remove this
            previousLocation = new Point();
        }
        protected virtual void OnDirectionChange(Object source, DirectionEventArgs e)
        {
            var handler = OnKeyPress;
            handler?.Invoke(this, e);
        }

        public void Listen()
        {
            IsListening = true;
            Direction direction;
            Point newLocation;
            var handler = OnKeyPress;
            while (IsListening)
            {
                direction = mapper.GetDirectionFromKey(Console.ReadKey(true));
                newLocation = mapper.CalculateNewPosition(previousLocation, direction);
                OnDirectionChange(this, new DirectionEventArgs(direction, previousLocation, newLocation));
                previousLocation = newLocation;
            }
        }

        public void Stop() => IsListening = false;
    }
}