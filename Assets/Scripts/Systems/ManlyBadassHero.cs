using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManlyBadassHero : MonoBehaviour
{

    [SerializeField]
    GameEvent onDeath = null;

    [SerializeField]
    GameEvent onReset = null;

    [SerializeField]
    BoolVariable isDead = null;

    float respawnDelay = 1.0f;

    float delay = 0f;

    private void Awake()
    {
        onDeath.Add(threeDaysLater);
    }

    private void OnDisable()
    {
        onDeath.Remove(threeDaysLater);
    }
    private void threeDaysLater()
    {
        delay = respawnDelay;
    }

    private void Update()
    {
        if (isDead.Value)
        {
            if (delay > 0f)
                delay -= Time.deltaTime;
            else
                onReset.Raise();
        }
    }
}
