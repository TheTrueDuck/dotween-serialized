using System;
using DG.Tweening;
using UnityEditor.EditorTools;
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
        
        //actually the eases aren't a part of shake, so they should go to To. but i mean there is also dopath which also uses eases except like back and eleastic
        //do i make this an interface? like shake?
        public Ease Ease = Ease.OutQuad;
        public float EaseOvershootOrAmplitude; //show if ease is flash bounce custom elastic  back
        public float EasePeriod;//show if ease is flash bounce custom elastic
        //what about custom animation curves?
        
        public float Delay = 0f;     
        [Tooltip("In sequences whether the delay should happen once (false), or every loop (true).")]   
        public bool AsPrependedIntervalIfSequence = true; //show if Delay != 0 //maybe put in advanced
        
        public int Loops = 1;
        public LoopType LoopType = LoopType.Restart;//only show if loops != 1
        
        [Tooltip("When true, instead of tweening for a fixed duration at a variable speed, tween for a variable duration at a fixed speed.")]
        public bool IsSpeedBased = false;
        
        //advanced                
        public GameObject Link = null;
        public LinkBehaviour LinkBehaviour = LinkBehaviour.KillOnDestroy; //only show if Target != null
        
        public UpdateType UpdateType = UpdateType.Normal;
        public bool IsIndependentUpdate = false;
        
        public float TimeScale = 1f;
        public bool IsBackwards = false; //what about is inverted
        
        public object Id = null;
        public string StringId = null;
        public int IntId = -999;
        
        //Not implementing
        //recyclable
        //auto kill
        //auto play
        //set immediately
        
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
    }
}
