using FSLib.FSEvents.SO;
using UnityEngine;

namespace Systems.Interactables
{
    [RequireComponent(typeof(Collider2D))]
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] FsVoidEventSo onDeath = null;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                onDeath.Invoke();
            }
        }
    }
}
