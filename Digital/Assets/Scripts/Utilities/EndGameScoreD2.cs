using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScoreD2 : MonoBehaviour
{
    private GameObject [] scores;
    private GameObject[] highscores;
    public static int _highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateScores()
    {
        scores = GameObject.FindGameObjectsWithTag("Score");
        highscores = GameObject.FindGameObjectsWithTag("Highscore");

        foreach (var score in scores)
        {
            score.GetComponent<Text>().text = ScoreManager.score.ToString();
        }
        if (ScoreManager.score > _highscore)
        {
            _highscore = ScoreManager.score; 
        }
        foreach (var highscore in highscores)
        {
            highscore.GetComponent<Text>().text = _highscore.ToString();
        }
    }
}
