using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    // variables
    [SerializeField]
    Collider2D hurtbox = null;

    void OnDeath()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] overlapingColliders = {};
        if (hurtbox != null)
            hurtbox.OverlapCollider(new ContactFilter2D(), overlapingColliders);
            foreach (Collider2D hit in overlapingColliders)
                if(hit.name=="player")
                    OnDeath();
    }

}
