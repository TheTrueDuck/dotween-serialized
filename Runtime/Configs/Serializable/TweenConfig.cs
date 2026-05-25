using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace DOTweenConfigs
{
    /// <summary>
    /// Base tween config for any other tween config. Contains
    /// duration parameter which any tweening in DOTween has.
    /// </summary>
    [Serializable]
    public class TweenConfig
    {
        public TweenConfig(float duration = 1f, Ease ease = Ease.OutQuad, int loops = 1, LoopType loopType = LoopType.Restart)
        {
            this.duration = duration;
            this.ease = ease;
            // DOTween.defaultEaseType
            // DOTween.defaultEaseOvershootOrAmplitude
            // DOTween.defaultEasePeriod
            this.loops = loops;
            //1
            this.loopType = loopType;
            // DOTween.defaultLoopType
            
            // DOTween.defaultTimeScaleIndependent
            // DOTween.defaultUpdateType
            
        }
        
        [SerializeField] private float duration = 1f;        
        [SerializeField] private float delay = 0f;        
        [SerializeField] private Ease ease = Ease.OutQuad;
        [SerializeField] private float easeOvershootOrAmplitude; //show if ease is flash bounce custom elastic  back
        [SerializeField] private float easePeriod;//show if ease is flash bounce custom elastic
        
        [SerializeField] private int loops = 1;
        [SerializeField] private LoopType loopType = LoopType.Restart;
        
        [SerializeField] private UnityEvent onStart;
        [SerializeField] private UnityEvent onUpdate;
        [SerializeField] private UnityEvent onComplete;
        
        [SerializeField] private UnityEvent onCreated;
        [SerializeField] private UnityEvent onKill;
        
        [SerializeField] private UnityEvent onPlay;
        [SerializeField] private UnityEvent onPause;
        [SerializeField] private UnityEvent onRewind;
        
        [SerializeField] private UnityEvent onStepComplete;
        [SerializeField] private UnityEvent<int> onWaypointChanged;
        
        
        //backwards
        //id
        //update type
        //time scale
        
        
        //asPrependedIntervalIfSequence
        //speed based

        public float Duration => duration;
        public Ease Ease => ease;
        public int Loops => loops;
        public LoopType LoopType => loopType;
    }
}
