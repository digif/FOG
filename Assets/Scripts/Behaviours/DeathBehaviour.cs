using Behaviours;
using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(Collider2D))]
    public class DeathBehaviour : IBehaviour
    {
        [SerializeField] private string[] tagToTriggerWith;

        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
        
        protected override void Action()
        {
            interact.SendMessage("Dead");
        }
    }
}
