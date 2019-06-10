using System.Collections;
using System.Collections.Generic;
using Utilities;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsValues : MonoBehaviour
{
    public GameObject TimerValue;
    public GameObject TimerV2Value;

    // Start is called before the first frame update
    void Start()
    {
        int _secondsTimer = OptionsManager._timer;

        TimerValue.GetComponent<Text>().text = _secondsTimer.ToString();
        TimerV2Value.GetComponent<Text>().text = _secondsTimer.ToString();
        InvokeRepeating("UpdateTimers", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        CheckEndGame();
    }

    public void UpdateTimers()
    {
        int _newtimer;
        int.TryParse(TimerValue.GetComponent<Text>().text, out _newtimer);
        _newtimer--;

        TimerValue.GetComponent<Text>().text = _newtimer.ToString();
        TimerV2Value.GetComponent<Text>().text = _newtimer.ToString();
    }

    public void CheckEndGame()
    {
        int timer;
        int.TryParse(TimerValue.GetComponent<Text>().text, out timer);

        int redOb = GameObject.FindGameObjectsWithTag("RedObject").Length;
        var yellowOb = GameObject.FindGameObjectsWithTag("YellowObject").Length;
        var blueOb = GameObject.FindGameObjectsWithTag("BlueObject").Length;
        var greenOb = GameObject.FindGameObjectsWithTag("GreenObject").Length;

        int totalObjs = redOb + yellowOb + blueOb + greenOb;
        //Debug.Log(totalObjs);

        if (timer == 0)
        {
            //Muda para o ecrã com pontuação e com opcoes Restart ou Back2Menu
            SceneManager.LoadScene(Scenes.EndGame.ToString());
        }
        else if (totalObjs == 0)
        {
            SceneManager.LoadScene(Scenes.EndGame.ToString());
        }
    }
}
