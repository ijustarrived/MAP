using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.C_.Game
{
    /// <summary>
    /// Contains all the main properties of the game
    /// </summary>
    public class GameWrapper
    {
        public enum Scenes
        {
            Splash,
            Main
        }

        public enum MouseButtons
        {
            Left,
            Right
        }

        public GameWrapper()
        {
            HasStarted = false;

            isMusicOn = true;

            IsSoundOn = true;
        }

        public bool HasStarted
        {
            get;

            set;
        }

        public bool IsSoundOn
        {
            get;

            set;
        }

        public bool isMusicOn
        {
            get;

            set;
        }
    }
}
