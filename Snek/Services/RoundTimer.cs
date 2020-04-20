using Snek.Models;
using System;
using System.Collections.Generic;
using System.Timers;

namespace Snek.Services
{
    public class RoundTimer
    {
        private Timer timer;
        private readonly int MINIMUM_INTERVAL = 300;
        private readonly int easySetting = 8000;
        private readonly int normalSetting = 600;
        private readonly int hardSetting = 500;
        private readonly int decrementStep = 15;


        public event TickEventHandler OnTick;
        public delegate void TickEventHandler(Object source, ElapsedEventArgs e);

        public bool IsEnabled { get; set; } = false;

        public RoundTimer(Difficulty difficulty)
        {
            timer = new Timer(SetIntervalByDifficulty(difficulty));
        }

        public void Run()
        {
            timer.AutoReset = true;
            timer.Elapsed += OnTickEvent;
            IsEnabled = true;
            timer.Start();
        }

        public void Stop()
        {
            IsEnabled = false;
            timer.Close();
        }

        public void DecreaseInterval()
        {
            if (timer.Interval > MINIMUM_INTERVAL)
            {
                timer.Interval -= decrementStep;
            }
        }

        protected virtual void OnTickEvent(Object source, ElapsedEventArgs e)
        {
            var handler = OnTick;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Sets the duration of the starting timer interval based on the user's chosen difficulty setting.
        /// </summary>
        /// <param name="difficulty"></param>
        /// <returns>integer representing the starting timer interval</returns>
        private int SetIntervalByDifficulty(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy: return easySetting;
                case Difficulty.Normal: return normalSetting;
                case Difficulty.Hard: return hardSetting;
                default: return normalSetting;
            }
        }
    }
}