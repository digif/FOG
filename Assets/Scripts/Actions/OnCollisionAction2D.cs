using UnityEngine;
using Utils;

namespace Actions
{
    [RequireComponent(typeof(Collider2D))]
    public class OnCollisionAction2D : IAction
    {
        public string[] tagToTriggerWith;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!CheckTags.CompareTagList(other.gameObject, tagToTriggerWith)) return;
            
            foreach (var behaviour in behaviours)
            {
                behaviour.interact = other.gameObject;
            }

            Raise();
        }
    }
}
