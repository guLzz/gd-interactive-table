using UnityEngine;
using Utilities;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorial0;
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;
    public GameObject tutorial4;
    public GameObject tutorial5;
    public GameObject tutorial6;
    public GameObject tutorial7;
    public GameObject tutorial8;
    public GameObject tutorial9;
    public GameObject tutorialEnd;

    private GameObject _banana;
    private GameObject _maca;
    private int _state;

    // Start is called before the first frame update
    void Start()
    {
        _state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial0.activeSelf) _state = 0;
        else if (tutorial1.activeSelf) _state = 1;
        else if (tutorial2.activeSelf) _state = 2;
        else if (tutorial3.activeSelf) _state = 3;
        else if (tutorial4.activeSelf) _state = 4;
        else if (tutorial5.activeSelf) _state = 5;
        else if (tutorial6.activeSelf) _state = 6;
        else if (tutorial7.activeSelf) _state = 7;
        else if (tutorial8.activeSelf) _state = 8;
        else if (tutorial9.activeSelf) _state = 9;
        else if (tutorialEnd.activeSelf) _state = 10;

        switch (_state)
        {
            case 3:
                _banana = GameObject.Find("/Canvas-Mesa/Tutorial-3/Banana");
                _maca = GameObject.Find("/Canvas-Mesa/Tutorial-3/Maca");
                if (_banana == null && _maca == null)
                {
                    _state = 4;
                    tutorial3.SetActive(false);
                    tutorial4.SetActive(true);
                }
                break;
            case 6:
                _banana = GameObject.Find("/Canvas-Mesa/Tutorial-6/Banana");
                _maca = GameObject.Find("/Canvas-Mesa/Tutorial-6/Maca");
                if (_banana == null && _maca == null)
                {
                    _state = 7;
                    tutorial6.SetActive(false);
                    tutorial7.SetActive(true);
                }
                break;
            case 8:
                _banana = GameObject.Find("/Canvas-Mesa/Tutorial-8/Banana");
                _maca = GameObject.Find("/Canvas-Mesa/Tutorial-8/Maca");
                if (_banana == null && _maca == null)
                {
                    _state = 9;
                    tutorial8.SetActive(false);
                    tutorial9.SetActive(true);
                }
                break;
            case 9:
                _banana = GameObject.Find("/Canvas-Mesa/Tutorial-9/Banana");
                _maca = GameObject.Find("/Canvas-Mesa/Tutorial-9/Maca");
                if (_banana == null && _maca == null)
                {
                    _state = 10;
                    tutorial9.SetActive(false);
                    tutorialEnd.SetActive(true);
                }
                break;
            default: break;
        }
    }

    public void QuitTutorial()
    {
        SceneManager.LoadScene(Scenes.MainMenu.ToString());
    }

    public void RestartTutorial()
    {
        SceneManager.LoadScene(Scenes.Tutorial.ToString());
    }
}
