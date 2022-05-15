using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    Vector2 SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
       SpawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Enemy"){
            transform.position = SpawnPoint;
        }
    }
    
    

    
}
