using System.Collections;
using System.Collections.Generic;
using Utilities;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class MenuScore : MonoBehaviour
{
    public GameObject ScoreD1;
    

    // Start is called before the first frame update
    void Start()
    {
        ScoreD1.GetComponent<Text>().text = ScoreManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Retry()
    {
        ScoreManager.score = 0;
        switch (OptionsManager._numberPlayers)
        {
            case 2:
                switch (OptionsManager._level)
                {
                    case 3:
                        SceneManager.LoadScene(Scenes.Game23.ToString());
                        break;
                    case 4:
                        SceneManager.LoadScene(Scenes.Game24.ToString());
                        break;
                    case 5:
                        SceneManager.LoadScene(Scenes.Game25.ToString());
                        break;
                    default:
                        Debug.Log("IDK");
                        break;
                }
                break;
            case 3:
                switch (OptionsManager._level)
                {
                    case 3:
                        SceneManager.LoadScene(Scenes.Game33.ToString());
                        break;
                    case 4:
                        SceneManager.LoadScene(Scenes.Game34.ToString());
                        break;
                    case 5:
                        SceneManager.LoadScene(Scenes.Game35.ToString());
                        break;
                    default:
                        Debug.Log("IDK");
                        break;
                }
                break;
            case 4:
                switch (OptionsManager._level)
                {
                    case 3:
                        SceneManager.LoadScene(Scenes.Game43.ToString());
                        break;
                    case 4:
                        SceneManager.LoadScene(Scenes.Game44.ToString());
                        break;
                    case 5:
                        SceneManager.LoadScene(Scenes.Game45.ToString());
                        break;
                    default:
                        Debug.Log("IDK");
                        break;
                }
                break;
            default:
                Debug.Log("Something went wrong lel");
                break;
        }
    }

    public void Back2Menu()
    {
        SceneManager.LoadScene(Scenes.MainMenu.ToString());
    }
}