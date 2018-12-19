using UnityEngine;

public static class Game
{
    public static GameMan gameManager;

    [RuntimeInitializeOnLoadMethod]
    public static void GameInitialize()
    {
        //Set a framerate limit since I don't like v-sync.
        Application.targetFrameRate = 150;

        //Load and then instantiate our GameMan.
        gameManager = GameObject.Instantiate(Resources.Load<GameMan>(("Game Manager")));

        //We load the HUD canvas and instantiate it at runtime, because it's a giant
        //pain in the ass in the scene view, as it's a giant plane that swallows clicks.
        GameObject.Instantiate(Resources.Load<Canvas>("HUD"));
    }

    public static void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}