using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScript : MonoBehaviour
{
    private GameObject _yellow;
    private GameObject _red;
    private GameObject _blue;
    private GameObject _green;

    // Start is called before the first frame update
    void Start()
    {
        getPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        _yellow = GameObject.FindGameObjectWithTag("YellowFinal");
        _red = GameObject.FindGameObjectWithTag("RedFinal");
        _blue = GameObject.FindGameObjectWithTag("BlueFinal");
        _green = GameObject.FindGameObjectWithTag("GreenFinal");
    }

    public void saveStats()
    {    
        var yellowName = _yellow.GetComponent<InputField>().text;
        var redName = _red.GetComponent<InputField>().text;
        var blueName = _blue.GetComponent<InputField>().text;
        var greenName = _green.GetComponent<InputField>().text;
    }

    public void getPlayers()
    {
        

        switch (OptionsManager._numberPlayers)
        {
            case 2:
                _blue.SetActive(false);
                _green.SetActive(false);
                break;
            case 3:
                _green.SetActive(false);
                break;
            default:
                Debug.Log("default");
                break;
        }
    }
}
