using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
class Subs 
{
    public float timing = 0.0f;
    [TextArea]
    public string text = "";

}

public class SubsManager : MonoBehaviour
{
    [SerializeField]
    Text textBox = null;
    [SerializeField]
    List<Subs> subs = null;
    int index = 0;

    float timmer = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(subs != null && subs.Count>0)
        {
            textBox.text = subs[index].text;
            timmer = subs[index].timing;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (index< subs.Count)
        {
            if (timmer > 0)
                timmer -= Time.deltaTime;
            else
            {
                index += 1;
                if(index < subs.Count)
                {
                    textBox.text = subs[index].text;
                    timmer = subs[index].timing;
                }
            }
        }

    }
}