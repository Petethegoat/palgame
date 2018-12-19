using UnityEngine;

/*
    This is just a monobehaviour class for general game stuff.
    It's spawned on GameInitialization (in Game.cs) to handle
    things that we wanna do in the Update loop or whatever.
*/

public class GameMan : MonoBehaviour
{
    private void Start()
    {
        SetCursorLock(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.None)
            {
                Game.Quit();
            }

            SetCursorLock(false);
        }
        else if(Input.GetMouseButtonDown(0))
        {
            SetCursorLock(true);
        }
    }

    private void SetCursorLock(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }
}