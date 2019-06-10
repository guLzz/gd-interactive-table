using Utilities;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Play()
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

        public void Tutorial()
        {
            SceneManager.LoadScene(Scenes.Tutorial.ToString());
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
