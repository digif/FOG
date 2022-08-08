using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
[RequireComponent(typeof(Collider2D))]
public class DeathZone : MonoBehaviour
{
    [SerializeField]
    GameEvent onDeath = null;

    [SerializeField]
    GameEvent onPause = null;

    [SerializeField]
    BoolVariable isDead = null;

    [SerializeField]
    BoolVariable isPaused = null;

    float pauseDelay = 1.0f;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            if(!isDead.Value)
            {
                isDead.Value = true;
                onDeath.Raise();
            }
        }
    }

    private void Update() {
        if (isDead.Value)
        {
            if (pauseDelay > 0)
                pauseDelay -= Time.deltaTime;
            else
                if (!isPaused.Value)
                {
                    onPause.Raise();
                }
        }
    }
}
*/