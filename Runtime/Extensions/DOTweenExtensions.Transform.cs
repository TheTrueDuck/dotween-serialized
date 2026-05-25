using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace DOTweenConfigs
{
    public static partial class DOTweenExtensions
    {
        public static TweenerCore<T1, T2, TPlugOptions> SetProperties<T1, T2, TPlugOptions>(this TweenerCore<T1, T2, TPlugOptions> tween, ToTweenConfig<T2> c) where TPlugOptions : struct, IPlugOptions
        {
            return tween.From(c.From).SetEase(c.Ease).SetLoops(c.Loops, c.LoopType);
        }

        public static TweenerCore<Vector3, Vector3, VectorOptions> DoMove(this Transform target, Position3DTweenConfig c) => target.DOMove(c.To, c.Duration, c.Snapping).SetProperties(c);
        // public static Tweener DOMove(this Transform target, Position3DTweenConfig c) => target.DOMove(c.To, c.Duration, c.Snapping).SetProperties(c);
        // public static Tweener DOMove(this Transform target, Position3DTweenConfig c) => target.DOMove(c.To, c.Duration, c.Snapping).SetEase(c.Ease);
        // public static Tweener DOMove(this Transform target, Position3DTweenConfig c) => target.DOMove(c.To, c.Duration, c.Snapping);
        public static Tweener DOMoveX(this Transform target, Position1DTweenConfig c) => target.DOMoveX(c.To, c.Duration, c.Snapping);
        public static Tweener DOMoveY(this Transform target, Position1DTweenConfig c) => target.DOMoveY(c.To, c.Duration, c.Snapping);
        public static Tweener DOMoveZ(this Transform target, Position1DTweenConfig c) => target.DOMoveZ(c.To, c.Duration, c.Snapping);
        public static Tweener DOLocalMove(this Transform target, Position3DTweenConfig c) => target.DOLocalMove(c.To, c.Duration, c.Snapping);
        public static Tweener DOLocalMoveX(this Transform target, Position1DTweenConfig c) => target.DOLocalMoveX(c.To, c.Duration, c.Snapping);
        public static Tweener DOLocalMoveY(this Transform target, Position1DTweenConfig c) => target.DOLocalMoveY(c.To, c.Duration, c.Snapping);
        public static Tweener DOLocalMoveZ(this Transform target, Position1DTweenConfig c) => target.DOLocalMoveZ(c.To, c.Duration, c.Snapping);
        public static Tweener DOScale(this Transform target, Scale3DTweenConfig c) => target.DOScale(c.To, c.Duration);
        public static Tweener DOScaleX(this Transform target, Scale1DTweenConfig c) => target.DOScaleX(c.To, c.Duration);
        public static Tweener DOScaleY(this Transform target, Scale1DTweenConfig c) => target.DOScaleY(c.To, c.Duration);
        public static Tweener DOScaleZ(this Transform target, Scale1DTweenConfig c) => target.DOScaleZ(c.To, c.Duration);
        public static Tweener DOShakePosition(this Transform target, SnapShakeTweenConfig c) => target.DOShakePosition(c.Duration, c.Strength, c.Vibrato, c.Randomness, c.Snapping, c.FadeOut);
        public static Tweener DOShakePosition(this Transform target, SnapShake3DTweenConfig c) => target.DOShakePosition(c.Duration, c.Strength, c.Vibrato, c.Randomness, c.Snapping, c.FadeOut);
        public static Tweener DOShakeRotation(this Transform target, ShakeTweenConfig c) => target.DOShakeRotation(c.Duration, c.Strength, c.Vibrato, c.Randomness, c.FadeOut);
        public static Tweener DOShakeRotation(this Transform target, Shake3DTweenConfig c) => target.DOShakeRotation(c.Duration, c.Strength, c.Vibrato, c.Randomness, c.FadeOut);
        public static Tweener DOShakeScale(this Transform target, ShakeTweenConfig c) => target.DOShakeScale(c.Duration, c.Strength, c.Vibrato, c.Randomness, c.FadeOut);
        public static Tweener DOShakeScale(this Transform target, Shake3DTweenConfig c) => target.DOShakeScale(c.Duration, c.Strength, c.Vibrato, c.Randomness, c.FadeOut);
    }
}
