using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZone : MonoBehaviour
{
    [SerializeField]
    GameEvent onDeath = null;

    [SerializeField]
    Transform respawnPoint;

    [SerializeField]
    Vector2Variable currentRespawnPoint;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            currentRespawnPoint.Value = respawnPoint.position;
        }
    }
}
