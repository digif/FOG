using System.Collections;
using System.Collections.Generic;
using FSLib.FSEvents.SO;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Vector2Variable currentRespawnPoint;
    [SerializeField] private FsVoidEventSo onUnpause = null;
    [SerializeField] private BoolVariable isDead = null;
    
    private void PlayerRespawn()
    {
        playerPosition.position = currentRespawnPoint.Value;
        isDead.Value = false;
        onUnpause.Invoke();
    }
}
