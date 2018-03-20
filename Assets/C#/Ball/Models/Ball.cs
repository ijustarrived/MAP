using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.C_.Ball.Models
{
    public class Ball
    {
        /// <summary>
        /// Indicates when the @FrameCount should be reset to 0
        /// </summary>
        public const int FPS_COUNT_RESET = 300;

        public Ball()
        {
            Body = new Rigidbody2D();

            Force = new Force();

            FrameCount = 0;
        }

        [SerializeField]
        public Rigidbody2D Body
        {
            get;

            set;
        }

        public Force Force
        {
            get;

            set;
        }

        public int PreviousVelocityFrame
        {
            get;

            set;
        }

        public int FrameCount
        {
            get;

            set;
        }
    }
}
