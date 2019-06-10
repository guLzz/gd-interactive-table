using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public GameObject PlayerNumber;
    public GameObject ObjectNumber;
    public GameObject Timer;
    public GameObject Level;

    public static int _numberPlayers = 2;
    public static int _numberObjects = 3;
    public static int _timer = 60;
    public static int _level = 3;   

    public Sprite Game23, Game24, Game25, Game33, Game34, Game35, Game43, Game44, Game45;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        int.TryParse(Timer.GetComponent<Text>().text, out _timer);
    }

    public void SetPlayerValue(GameObject signal)
    {
        int.TryParse(PlayerNumber.GetComponent<Text>().text, out _numberPlayers);

        switch (signal.name)
        {
            case "PlayerMinus":
                if (_numberPlayers == 2)
                {
                    Debug.Log("Minimo 2");
                    return;
                }
                _numberPlayers--;
                PlayerNumber.GetComponent<Text>().text = _numberPlayers.ToString();
                break;
            case "PlayerPlus":
                if (_numberPlayers == 4)
                {
                    Debug.Log("Máximo 4");
                    return;
                }
                _numberPlayers++;
                PlayerNumber.GetComponent<Text>().text = _numberPlayers.ToString();
                break;
            default:
                break;
        }
        //Update no Preview do Mapa
        PreviewScript.UpdatePreview(Game23, Game24, Game25, Game33, Game34, Game35, Game43, Game44, Game45);
    }

    public void SetObjectValue(GameObject signal)
    {
        int.TryParse(ObjectNumber.GetComponent<Text>().text, out _numberObjects);

        switch (signal.name)
        {
            case "ObjectMinus":
                if (_numberObjects == 3)
                {
                    Debug.Log("Minimo 3");
                    return;
                }
                _numberObjects--;
                ObjectNumber.GetComponent<Text>().text = _numberObjects.ToString();
                break;
            case "ObjectPlus":
                if (_numberObjects == 6)
                {
                    Debug.Log("Máximo 6");
                    return;
                }
                _numberObjects++;
                ObjectNumber.GetComponent<Text>().text = _numberObjects.ToString();
                break;
            default:
                break;
        }
    }

    //public void SetTimerValue(GameObject signal)
    //{
    //    int.TryParse(Timer.GetComponent<Text>().text, out _timer);

    //    switch (signal.name)
    //    {
    //        case "TimerMinus":
    //            if (_timer == 60)
    //            {
    //                Debug.Log("Minimo 60");
    //                return;
    //            }
    //            _timer = _timer -5;
    //            Timer.GetComponent<Text>().text = _timer.ToString();
    //            break;
    //        case "TimerPlus":
    //            if (_timer == 300)
    //            {
    //                Debug.Log("Máximo 300 Segundos");
    //                return;
    //            }
    //            _timer = _timer + 5;
    //            Timer.GetComponent<Text>().text = _timer.ToString();
    //            break;
    //        default:
    //            break;
    //    }
    //}

    public void SetLevelValue(GameObject signal)
    {
        int.TryParse(Level.GetComponent<Text>().text, out _level);
        switch (signal.name)
        {
            case "LevelMinus":
                if (_level == 3)
                {
                    Debug.Log("Minimo 3");
                    return;
                }
                _level--;
                Level.GetComponent<Text>().text = _level.ToString();
                break;
            case "LevelPlus":
                if (_level == 5)
                {
                    Debug.Log("Máximo 5");
                    return;
                }
                _level++;
                Level.GetComponent<Text>().text = _level.ToString();
                break;
            default:
                break;
        }
        //Update no Preview do Mapa
        PreviewScript.UpdatePreview(Game23, Game24, Game25, Game33, Game34, Game35, Game43, Game44, Game45);
    }

}
