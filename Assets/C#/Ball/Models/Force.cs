using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.C_.Ball.Models
{
    /// <summary>
    /// Holds all the physics
    /// </summary>
    public class Force
    {
        public const float MPH_MULTIPLIER = 2.2369f,
            LOWEST_FORCE = 151f;

        public const int SPEED1 = 31,
            SPEED2 = 41,
            SPEED3 = 50,
            SPEED4 = 60,
            SPEED5 = 72,
            LOWEST_MPH = 9;

        public Force()
        {
            X = 0f;

            Y = 0f;

            MaxSpeed = 9;

            ReachedSpeed1 = false;

            ReachedSpeed2 = false;

            ReachedSpeed3 = false;

            ReachedSpeed4 = false;

            ReachedSpeed5 = false;

            MPH = 0;
        }

        public float X
        {
            get;

            set;
        }

        public float Y
        {
            get;

            set;
        }

        public bool ReachedSpeed1
        {
            get;

            set;
        }

        public bool ReachedSpeed2
        {
            get;

            set;
        }

        public bool ReachedSpeed3
        {
            get;

            set;
        }

        public bool ReachedSpeed4
        {
            get;

            set;
        }

        public bool ReachedSpeed5
        {
            get;

            set;
        }

        public int MPH
        {
            get;

            set;
        }

        public int MaxSpeed
        {
            get;

            set;
        }

        /// <summary>
        /// Lowers the velocities x and y axis of a rigid body based on the factor
        /// </summary>
        /// <param name="factor">Value used for decreasing</param>
        /// <param name="body">Body wished to be slowed down</param>
        /// <returns>The new velocity vector2</returns>
        public static Vector2 DecreaseVelocity(int factor, Rigidbody2D body)
        {
            Vector2 velocity = body.velocity;

            //Slowdown speed if time isn't stopped
            if (Time.timeScale > 0)
            {
                if (velocity.x > 0)
                {
                    velocity.x -= factor;
                }

                else
                {
                    velocity.x += factor;
                }

                if (velocity.y > 0)
                {
                    velocity.y -= factor;
                }

                else
                {
                    velocity.y += factor;
                }
            }

            return velocity;
        }

        /// <summary>
        /// Flips a rigidbodys x and y velocity polarity. Also, increases its velocity based of a factor. 
        /// </summary>
        /// <param name="body">Body used for inversion</param>
        /// <param name="factor">Factor that increases velocity</param>
        /// <returns>New inverted velocity</returns>
        public static Vector2 VelocityInverter(Rigidbody2D body, int factor)
        {
            Vector2 velocity = body.velocity;

            if (velocity.x > 0)
            {
                velocity.x *= -1;

                velocity.x -= factor;
            }

            else
            {
                velocity.x = Mathf.Abs(velocity.x);

                velocity.x += factor;
            }

            if (velocity.y > 0)
            {
                velocity.y *= -1;

                velocity.y -= factor;
            }

            else
            {
                velocity.y = Mathf.Abs(velocity.y);

                velocity.y += factor;
            }

            return velocity;
        }
    }
}
