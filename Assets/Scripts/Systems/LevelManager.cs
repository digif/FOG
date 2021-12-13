using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // variables
    [SerializeField]
    Vector2 PlayerSpawnCoordinates = new Vector2(0,0);

    [SerializeField]
    bool autorun = false;

    [SerializeField]
    StringVariable currentLevel = null;

    [SerializeField]
    StringVariable nextLevel = null;

    [SerializeField]
    string m_currentLevel = "";

    [SerializeField]
    string m_nextLevel = "";


    // parameters
    [SerializeField]
    Vector2Variable PlayerSpawn = null;


    // events
    [SerializeField]
    GameEvent onLevelStarted = null;
    [SerializeField]
    GameEvent onWin = null;


    // states
    [SerializeField]
    BoolVariable isAutorunLevel = null;
    [SerializeField]
    BoolVariable isExplorationLevel = null;
    [SerializeField]
    BoolVariable isDead = null;
    [SerializeField]
    BoolVariable isLevelCompleted = null;

    // components
    [SerializeField]
    AudioSource music = null;

    void Awake() {
        onLevelStarted.Add (OnLevelStarted);
        if (onWin != null)
            onWin.Add(OnWin);
        isDead.Value = false;

        PlayerSpawn.Value = PlayerSpawnCoordinates;
        if (autorun)
        {
            isAutorunLevel.Value = true;
            isExplorationLevel.Value = false;
        }
        else
        {
            isAutorunLevel.Value = false;
            isExplorationLevel.Value = true;
        }

        currentLevel.Value = m_currentLevel;
        nextLevel.Value = m_nextLevel;

    }

    void OnWin ()
    {
        if (isLevelCompleted != null)
            isLevelCompleted.Value = true;
    }

    private void OnDisable() 
    {
        if (onWin != null)
            onWin.Remove (OnWin);
        onLevelStarted.Remove (OnLevelStarted);
    }

    void OnLevelStarted ()
    {
        music.Play();
    }
}
