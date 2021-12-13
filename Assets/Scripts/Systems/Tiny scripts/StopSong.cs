using UnityEngine;
using UnityEngine.Events;

    public class StopSong : MonoBehaviour
    {
        
    [SerializeField]
    GameEvent onWin = null;

    // components
    [SerializeField]
    AudioSource music = null;

    void Awake() 
    {
        if (onWin != null)
            onWin.Add(OnWin);
    }

    void OnWin ()
    {
        music.Stop();
    }

    void OnDisable() 
    {
        if (onWin != null)
            onWin.Remove (OnWin);
    }
}