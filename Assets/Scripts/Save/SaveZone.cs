using FSLib.FSEvents.SO;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class SaveZone : MonoBehaviour
{
    [SerializeField] private FsVoidEventSo onDeath = null;

    [SerializeField] private Transform respawnPoint;

    [SerializeField] private Vector2Variable currentRespawnPoint;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        currentRespawnPoint.Value = respawnPoint.position;
    }
}
