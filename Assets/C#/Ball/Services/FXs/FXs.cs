using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.C_.Ball.Services.FXs
{
    class FXs
    {
        public enum Clips
        {
            FLAME1 = 0,
            FLAME2,
            FLAME3,
            FLAME4,
            FLAME5,
            BALL
        }

        public FXs()
        {
            FxDic = new Dictionary<AudioClip, AudioSource>();
        }

        public Dictionary<AudioClip, AudioSource> FxDic
        {
            get;

            set;
        }

        public static float GetRandomVol()
        {
            Double randVal = new System.Random().NextDouble();

            return (float)randVal;
        }
    }
}
