using System.Collections;
using System.Collections.Generic;
using FSLib.FSEvents.SO;
using UnityEngine;

public class ManlyBadassHero : MonoBehaviour
{
    [SerializeField] private FsVoidEventSo onDeath = null;

    [SerializeField] private FsVoidEventSo onReset = null;

    [SerializeField]
    BoolVariable isDead = null;

    private const float RespawnDelay = 1.0f;

    private float delay = 0f;
    
    private void ThreeDaysLater()
    {
        delay = RespawnDelay;
    }

    private void Update()
    {
        if (!isDead.Value) return;
        
        if (delay > 0f)
            delay -= Time.deltaTime;
        else
            onReset.Invoke();
    }
}
