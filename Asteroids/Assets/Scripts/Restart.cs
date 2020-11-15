using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField]
    Ship ship;

    [SerializeField]
    Text restartText;
    public static float gameLevel = 1;

    bool isChosingGameLevel = false;

    public static bool isGameOver = false;



    void Update()
    {
        if (Ship.dead)
        {
            restartText.text = "Game Over! " + 
                "\nYour Total Score is : " + Score.score +
                "\nPress Left Shift Key to Restart." +
                "\nPress Esc to Leave the Game.";
            Time.timeScale = 0;
            isGameOver = true;
            
        }

        if (Input.GetKey(KeyCode.LeftShift) || isChosingGameLevel)
        {
            isChosingGameLevel = true;

            ChooseGameLevel();
            isGameOver = false;
        }
    }

    void ChooseGameLevel()
    {
        Time.timeScale = 0;
        restartText.text = "\nPress Number Keys(1 to 4) to Choose Game Level of Next Round";
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameLevel = 1;
            isChosingGameLevel = false;
            Ship.dead = false;
        }


        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameLevel = 2;
            isChosingGameLevel = false;
            Ship.dead = false;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameLevel = 3;
            isChosingGameLevel = false;
            Ship.dead = false;


        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameLevel = 4;
            isChosingGameLevel = false;
            Ship.dead = false;
        }
    }
}
