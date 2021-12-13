using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    // variables
    [SerializeField]
    float waitForIntroToFinish = 30.0f;

    [SerializeField]
    StringVariable currentLevelName = null;

    [SerializeField]
    StringVariable nextLevelName = null;


    // states
    [SerializeField]
    BoolVariable isAutorunLevel = null;

    [SerializeField]
    BoolVariable isPaused = null;

    [SerializeField]
    BoolVariable isDead = null;

    [SerializeField]
    BoolVariable isWin = null;


    // event
    [SerializeField]
    GameEvent onStartMenu = null;

    [SerializeField]
    GameEvent onPause = null;

    [SerializeField]
    GameEvent onUnpause = null;

    [SerializeField]
    GameEvent onRestartLevel = null;

    [SerializeField]
    GameEvent onNextLevel = null;

    [SerializeField]
    GameEvent onLevelStarted = null;


    // local variables
    List<Scene> loadedScenes;

    Scene pauseScene;

    Scene introScene;

    Scene level;

    Scene player;

    Scene fog;

    bool isLevelStarted = false;


    private void Awake() 
    {
        loadedScenes = new List<Scene>();
        onPause.Add(OnPause);
        onUnpause.Add(OnUnpause);

        onStartMenu.Add(StartMainMenu);
        onRestartLevel.Add(StartLevel);
        onNextLevel.Add(NextLevel);
    }

    private void OnDisable() 
    {
        onPause.Remove(OnPause);
        onUnpause.Remove(OnUnpause);

        onStartMenu.Remove(StartMainMenu);
        onRestartLevel.Remove(StartLevel);
        onNextLevel.Remove(NextLevel);
    }

    void Start() {

        introScene = LoadScene("Scenes/Cinematics/Intro");
    }

    void Update() {
        if(introScene.isLoaded)
        {
            if(waitForIntroToFinish > 0)
                waitForIntroToFinish -= Time.deltaTime;
            else
            {
                StartMainMenu();
            }
        }

        if (level.isLoaded && !player.isLoaded)
        {
            player = LoadScene("Player");
            if (isAutorunLevel.Value)
                fog = LoadScene("F.O.G");
        }

        if (!isLevelStarted && player.isLoaded && (!isAutorunLevel.Value || fog.isLoaded))
        {
            onLevelStarted.Raise();
            isLevelStarted = true;
        }
    }


    void OnPause ()
    {
        if(pauseScene.path == null)
            pauseScene = LoadScene("Scenes/Menus/Pause Menu");
        Time.timeScale = 0.0f;
        isPaused.Value = true;
    }

    void OnUnpause ()
    {
        isPaused.Value = false;
        Time.timeScale = 1.0f;
        if(pauseScene.path != null)
            UnloadScene(pauseScene);
    }


    void UnloadScene (Scene m_scene)
    {
        if(m_scene.isLoaded)
            SceneManager.UnloadSceneAsync(m_scene);
        while (m_scene.isLoaded);
        loadedScenes.Remove(m_scene);
    }

    void UnloadScenes()
    {
        OnUnpause();
        foreach (var m_scene in loadedScenes)
        {
            if(m_scene.isLoaded)
                SceneManager.UnloadSceneAsync(m_scene);
            while (m_scene.isLoaded);
        }
        loadedScenes.Clear();
    }

    Scene LoadScene(string sceneName)
    {
        Scene newScene = SceneManager.LoadScene(sceneName, new LoadSceneParameters(LoadSceneMode.Additive));
        loadedScenes.Add(newScene);
        return newScene;
    }

    
    void StartMainMenu ()
    {
        UnloadScenes();
        LoadScene("Scenes/Menus/Main Menu");
    }

    void StartLevel()
    {
        isDead.Value = false;
        isWin.Value = false;
        UnloadScenes();
        isLevelStarted = false;
        level = LoadScene(currentLevelName.Value);
    }

    void NextLevel()
    {
        currentLevelName.Value = nextLevelName.Value;
        nextLevelName.Value = "";
        StartLevel();
    }
}
