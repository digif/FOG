using System.Collections;
using System.Collections.Generic;
using Save;
using UnityEngine;

public class TriggerSave : MonoBehaviour
{
    public string[] tagToTriggerWith;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        for (var i = 0; i < tagToTriggerWith.Length; i++)
        {
            if (!other.CompareTag("Player")) continue;

            other.GetComponent<ISaver>().Save();
        }
    }
}
