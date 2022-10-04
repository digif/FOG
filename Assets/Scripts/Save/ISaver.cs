using System;
using UnityEngine;

namespace Save
{
    public abstract class ISaver : MonoBehaviour
    {
        [SerializeField] protected string specificName;
        [SerializeField] protected bool loadAtStart = true;

        protected void Start()
        {
            if (!loadAtStart) return;
            
            Load();
        }

        public abstract void Save();
        public abstract void Load();
    }
}
