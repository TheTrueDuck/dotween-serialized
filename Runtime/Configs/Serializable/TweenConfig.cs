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
            Duration = duration;
            Ease = ease;
            // DOTween.defaultEaseType
            // DOTween.defaultEaseOvershootOrAmplitude
            // DOTween.defaultEasePeriod
            Loops = loops;
            //1
            LoopType = loopType;
            // DOTween.defaultLoopType
            
            // DOTween.defaultTimeScaleIndependent
            // DOTween.defaultUpdateType
            
        }
        
        public float Duration = 1f;        
        
        //common
        public Ease Ease = Ease.OutQuad;
        public float EaseOvershootOrAmplitude; //show if ease is flash bounce custom elastic  back
        public float EasePeriod;//show if ease is flash bounce custom elastic
        
        public float Delay = 0f;        
        
        public int Loops = 1;
        public LoopType LoopType = LoopType.Restart;//only show if loops != 1
        
        //events
        public UnityEvent OnStart;
        public UnityEvent OnUpdate;
        public UnityEvent OnComplete;
        
        public UnityEvent OnCreated;
        public UnityEvent OnKill;
        
        public UnityEvent OnPlay;
        public UnityEvent OnPause;
        public UnityEvent OnRewind;
        
        public UnityEvent OnStepComplete;
        public UnityEvent<int> OnWaypointChanged;
        
        //advanced
        public UpdateType UpdateType = UpdateType.Normal;
        public bool IsIndependentUpdate = false;
        
        public float TimeScale = 1f;
        public bool IsBackwards = false;
        
        public object Id = null;
        public string StringId = null;
        public int IntId = -999;
        
        
        
        //asPrependedIntervalIfSequence
        //speed based
    }
}
