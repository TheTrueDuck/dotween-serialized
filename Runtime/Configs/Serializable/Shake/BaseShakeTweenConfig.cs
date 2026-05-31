using System;
using DG.Tweening;
using UnityEngine;

namespace DOTweenConfigs
{
    [Serializable]
    public class BaseShakeTweenConfig<T> : TweenConfig// todo make this an interface? also remove the shake non snap configs, like fr they can share a bool
    {
        public T Strength;
        public int Vibrato = 10;
        public float Randomness = 90;
        public bool FadeOut = true;
        public ShakeRandomnessMode ShakeRandomnessMode = ShakeRandomnessMode.Full;
    }
}
