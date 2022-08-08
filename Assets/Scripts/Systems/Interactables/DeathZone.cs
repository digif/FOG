using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DeathZone : MonoBehaviour
{
    [SerializeField]
    GameEvent onDeath = null;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            onDeath.Raise();
        }
    }
}
