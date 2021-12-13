using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    GameObject nextLevelButton = null;

    [SerializeField]
    GameObject autorunTuto = null;

    [SerializeField]
    GameObject thanks = null;


    [SerializeField]
    StringVariable nextLevel = null;

    [SerializeField]
    BoolVariable isDead = null;

    [SerializeField]
    BoolVariable isWin = null;

    [SerializeField]
    UnityEvent onDead = null;

    [SerializeField]
    UnityEvent onWin = null;

    // Start is called before the first frame update
    void Start()
    {
        if (isDead.Value)
            onDead.Invoke();
        if (isWin.Value)
            onWin.Invoke();

        if (isWin.Value)
        {
            if (nextLevel.Value == "")
            {
                thanks.SetActive(true);
                nextLevelButton.SetActive(false);
            }
            else
            {
                thanks.SetActive(false);
                nextLevelButton.SetActive(true);
            }

            if (nextLevel.Value != "Scenes/Levels/Auto-Run test")
                autorunTuto.SetActive(false);
            else
                autorunTuto.SetActive(true);
        }
        else
        {
            thanks.SetActive(false);
            nextLevelButton.SetActive(false);
            autorunTuto.SetActive(false);
        }
        
    }
}
