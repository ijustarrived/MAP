using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.C_.Game.Models
{
    /// <summary>
    /// An animation helper
    /// </summary>
    class Animatron
    {
        public Animatron()
        {
            AnimationRunning = false;

            AnimationEnded = false;

            AnimationDuration = 20;

            Red = 0f;

            Green = 0f;

            Blue = 0f;

            InitialAlpha = 0.392f;

            FinalAlpha = 0f;
        }

        public bool AnimationEnded
        {
            get;

            set;
        }

        public bool AnimationRunning
        {
            get;

            set;
        }

        /// <summary>
        /// In frames. So if you want it to last 10 updates. Just pass 10
        /// </summary>
        public int AnimationDuration
        {
            get;

            set;
        }

        public float InitialAlpha
        {
            get;

            set;
        }

        public float FinalAlpha
        {
            get;

            set;
        }

        public float Red
        {
            get;

            set;
        }

        public float Green
        {
            get;

            set;
        }

        public float Blue
        {
            get;

            set;
        }

        public void Start()
        {
            if (!AnimationRunning)
                AnimationRunning = !AnimationRunning;
        }

        public Color FadeOutObject(int frameCount, Color color)
        {
            if (AnimationRunning)
            {
                if (frameCount < AnimationDuration)
                {
                    if (InitialAlpha != FinalAlpha)
                    {
                        InitialAlpha -= 0.030f;

                        color = new Color(Red, Green, Blue, InitialAlpha);
                        //rend.material.color = new Color(Red, Green, Blue, InitialAlpha);
                    }
                }

                else
                {
                    AnimationEnded = !AnimationEnded;

                    AnimationRunning = !AnimationEnded;
                }
            }

            return color;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="color"></param>
        /// <param name="alphaSubstract">Value used to substract initial alpha</param>
        /// <returns></returns>
        public Color FadeOutObject(int frameCount, Color color, float alphaSubstract)
        {
            if (AnimationRunning)
            {
                if (frameCount < AnimationDuration)
                {
                    if (InitialAlpha != FinalAlpha)
                    {
                        InitialAlpha -= alphaSubstract;

                        color = new Color(Red, Green, Blue, InitialAlpha);
                        //rend.material.color = new Color(Red, Green, Blue, InitialAlpha);
                    }
                }

                else
                {
                    AnimationEnded = !AnimationEnded;

                    AnimationRunning = !AnimationEnded;
                }
            }

            return color;
        }
    }
}
