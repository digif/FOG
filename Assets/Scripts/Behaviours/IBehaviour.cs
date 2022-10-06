using UnityEngine;

namespace Behaviours
{
    public abstract class IBehaviour : MonoBehaviour
    {
        public GameObject interact;
    
        protected abstract void Action();
    }
}
