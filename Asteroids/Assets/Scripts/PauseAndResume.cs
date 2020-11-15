using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndResume : MonoBehaviour
{

    bool paused = false;

    void PauseGame()
    {
        Time.timeScale = 0;
        paused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        paused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (!paused)
                PauseGame();
            else
                ResumeGame();
        }
    }
}
