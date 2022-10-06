using UnityEngine;
using Utils;

namespace Save
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerSave : MonoBehaviour
    {
        public string[] tagToTriggerWith;
    
        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (CheckTags.CompareTagList(other.gameObject, tagToTriggerWith))
                other.GetComponent<ISaver>().Save();
        }
    }
}
