using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewScript
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //UpdatePreview();
    }

    public static void UpdatePreview(Sprite Game23, Sprite Game24, Sprite Game25, Sprite Game33, Sprite Game34, Sprite Game35, Sprite Game43, Sprite Game44, Sprite Game45)
    {
        var mapObject = GameObject.FindGameObjectWithTag("PreviewMap");
        var mapImage = mapObject.GetComponent<Image>();
        switch (OptionsManager._level)
        {
            case 3:
                switch (OptionsManager._numberPlayers)
                {
                    case 2:
                        mapImage.sprite = Game23;
                        break;
                    case 3:
                        mapImage.sprite = Game33;
                        break;
                    case 4:
                        mapImage.sprite = Game43;
                        break;
                    default:
                        Debug.Log("error in player numbers X");
                        break;
                }               
                break;
            case 4:
                switch (OptionsManager._numberPlayers)
                {
                    case 2:
                        mapImage.sprite = Game24;
                        break;
                    case 3:
                        mapImage.sprite = Game34;
                        break;
                    case 4:
                        mapImage.sprite = Game44;
                        break;
                    default:
                        Debug.Log("error in player numbers Y");
                        break;
                }
                break;
            case 5:
                switch (OptionsManager._numberPlayers)
                {
                    case 2:
                        mapImage.sprite = Game25;
                        break;
                    case 3:
                        mapImage.sprite = Game35;
                        break;
                    case 4:
                        mapImage.sprite = Game45;
                        break;
                    default:
                        Debug.Log("error in player numbers Z");
                        break;
                }
                break;
            default:
                Debug.Log("error.");
                break;
        }
    }
}
