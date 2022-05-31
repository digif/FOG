using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WinZone : MonoBehaviour
{
    [SerializeField]
    GameEvent onWin = null;

    [SerializeField]
    GameEvent onPause = null;

    [SerializeField]
    BoolVariable isWin = null;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            if(!isWin.Value)
            {
                isWin.Value = true;
                onWin.Raise();
                onPause.Raise();
            }
        }
    }
}
