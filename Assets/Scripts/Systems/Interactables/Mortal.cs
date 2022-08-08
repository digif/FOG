using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortal : MonoBehaviour
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


    float delay = 0f;

    private void Awake()
    {
        onDeath.Add(OnDead);
    }

    private void OnDisable()
    {
        onDeath.Remove(OnDead);
    }
    private void OnDead()
    {
        if (!isDead.Value)
        {
            isDead.Value = true;
            delay = pauseDelay;
        }
    }

    private void Update()
    {
        if (isDead.Value)
        {
            if (delay > 0f)
                delay -= Time.deltaTime;
            else
            {
                if (!isPaused.Value)
                    onPause.Raise();
            }
        }
    }
}
