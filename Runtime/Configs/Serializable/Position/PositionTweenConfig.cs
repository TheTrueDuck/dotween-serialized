using System;
using UnityEngine;

namespace DOTweenConfigs
{
    [Serializable]
    public class PositionTweenConfig<T> : ToTweenConfig<T>
    {
        public bool Snapping = false;
    }
 }
