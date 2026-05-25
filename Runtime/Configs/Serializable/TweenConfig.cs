using System;
using UnityEngine;

namespace DOTweenConfigs
{
    /// <summary>
    /// Base tween config for any other tween config. Contains
    /// duration parameter which any tweening in DOTween has.
    /// </summary>
    [Serializable]
    public class TweenConfig
    {
        public TweenConfig(float duration, Ease ease, int loops)
        {
            
        }
        
        [SerializeField] private float m_duration = 1f;        
        [SerializeField] private Ease ease = Ease.OutQuad;
        [SerializeField] private int loops = 1;
        [SerializeField] private LoopType loopType = 1;

        public float Duration
        {
            get { return m_duration; }
        }
    }
}
