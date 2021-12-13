using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelAccess : MonoBehaviour
{
    // states
    [SerializeField]
    BoolVariable isPreviousLevelCompleted = null;


    // components
    [SerializeField]
    Button startLevel = null;

    void Start()
    {
        if (isPreviousLevelCompleted.Value)
            startLevel.interactable = true;
        else
            startLevel.interactable = false;
    }
}
