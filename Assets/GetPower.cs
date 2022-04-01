using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPower : MonoBehaviour
{
    public GameObject BlackLand;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("plop");
        GetNewPower();
    }

    
    public void GetNewPower()
    {
        for(int i =0;i< BlackLand.transform.childCount;i++)
        {
            //BlackLand.transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
            BlackLand.transform.GetChild(i).GetComponent<Animator>().SetBool("GetPower", true);
        }

       
    }
}
