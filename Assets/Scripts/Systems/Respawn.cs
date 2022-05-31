using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    GameEvent onReset;

    [SerializeField]
    Transform playerPosition;

    [SerializeField]
    Vector2Variable currentRespawnPoint;

    [SerializeField]
    GameEvent onUnpause = null;

    [SerializeField]
    BoolVariable isDead = null;


    private void Awake()
    {
        onReset.Add(PlayerRespawn);
    }

    private void OnDisable()
    {
        onReset.Remove(PlayerRespawn);
    }

    private void PlayerRespawn()
    {
        playerPosition.position = currentRespawnPoint.Value;
        isDead.Value = false;
        onUnpause.Raise();


    }
}
