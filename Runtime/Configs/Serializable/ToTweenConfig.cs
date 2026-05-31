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
        public ToOrFrom ToOrFrom = ToOrFrom.ToOnly;
        public T To; //show depending on ToOrFrom
        public T From; //show depending on ToOrFrom
        public bool IsRelative = false; //also how does this work with MoveLocal and LocalPath


        public ToTweenConfig()
        {
        }
        
        public ToTweenConfig(T to)
        {
            this.To = to;
        }
    }
}
public enum ToOrFrom
{
    ToOnly = 0b01,
    ToAndFrom = 0b11,
    FromOnly = 0b10,
    
    FromAndTo = ToAndFrom,
}