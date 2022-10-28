using UnityEngine;
using Utils;

namespace Actions
{
    [RequireComponent(typeof(Collider2D))]
    public class OnTriggerAction2D : IAction
    {
        public string[] tagToTriggerWith;

        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
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
