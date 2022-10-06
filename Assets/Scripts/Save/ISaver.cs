using UnityEngine;

namespace Save
{
    public abstract class ISaver : MonoBehaviour
    {
        [SerializeField] protected string specificName;
        public bool loadAtStart = true;
        public bool loadOnDeath = true;

        protected void Start()
        {
            if (!loadAtStart) return;
            
            Load();
        }

        public abstract void Save();
        public abstract void Load();
    }
}
