using System;
using UnityEngine;

namespace DOTweenConfigs
{
    /// <summary>
    /// Generic tween config for tweening to some value.
    /// </summary>
    [Serializable]
    public class ToTweenConfig<T> : TweenConfig
    {
        [SerializeField] private T to;
        [SerializeField] private bool andComeFrom = false; //technically there could be just a from as well, enum?
        [SerializeField] private T from; //show if andComeFrom == true
        [SerializeField] private bool isRelative = false; //show if andComeFrom == false


        public T To => to;
        public T From => from;


        public ToTweenConfig()
        {
        }
        
        public ToTweenConfig(T to)
        {
            this.to = to;
        }
    }
}
public enum TweenTargets //merge isRelative in here?
{
    ToOnly = 0b01,
    FromTo = 0b11,
    FromOnly = 0b10,
    // FromAToB,
    // FromHereToB,
    // FromAToHere,
}