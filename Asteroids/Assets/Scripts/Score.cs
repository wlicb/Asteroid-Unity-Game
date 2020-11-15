using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    const string scorePrefix = "Score: ";
    public static int score = 0;

    void Start()
    {
        scoreText.text = scorePrefix + score.ToString();
    }


    void Update()
    {
        scoreText.text = scorePrefix + score.ToString();
    }
}
