using System;
using UnityEngine;

namespace FSLib.FSEvents.SO
{
    public class FsThreeArgumentEventSo<T0, T1, T2> : ScriptableObject
    {
        public Action<T0, T1, T2> fsThreeArgumentAction;
    }
}