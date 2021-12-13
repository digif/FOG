using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundsManager : MonoBehaviour
{
    // variables
    [SerializeField]
    AudioClip deathSound = null;

    // events
    [SerializeField]
    GameEvent onDeath = null;

    // components
    [SerializeField]
    AudioSource audioSource = null;

    void Awake()
    {
        onDeath.Add(OnDeath);
    }

    void OnDisable()
    {
        onDeath.Remove(OnDeath);
    }

    void OnDeath() { audioSource.PlayOneShot(deathSound); }

}
