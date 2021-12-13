using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Pickable : MonoBehaviour
{

    // variables
    [SerializeField]
    IntegerVariable coins = null;


    // components
    [SerializeField]
    AudioSource sound = null;

    [SerializeField]
    SpriteRenderer image = null;


    //local variables
    bool activated = false;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !activated)
        {
            activated = true;
            coins.Value +=1;
            sound.Play();
            image.enabled = false;
            Destroy(gameObject, 1.0f);
        }
    }
}
