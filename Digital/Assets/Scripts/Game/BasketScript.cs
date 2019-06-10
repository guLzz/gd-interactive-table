using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class BasketScript : MonoBehaviour
{
    private AudioSource _audioClip;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        _audioClip = GetComponent<AudioSource>();
        _audioClip.volume = 0.5f;
        if (scene.name!="Tutorial")
            deleteObjects();
        
    }

    // Update is called once per frame
    void Update()
    {
        //deleteObjects();
    }

    private void deleteObjects()
    {
        var cyaRedObject = GameObject.FindGameObjectsWithTag("RedObject");
        var cyaGreenObject = GameObject.FindGameObjectsWithTag("GreenObject");
        var cyaBlueObject = GameObject.FindGameObjectsWithTag("BlueObject");
        var cyaYellowObject = GameObject.FindGameObjectsWithTag("YellowObject");

        //var cyaRedFinalObject = GameObject.FindGameObjectsWithTag("RedFinal");
        //var cyaGreenFinalObject = GameObject.FindGameObjectsWithTag("GreenFinal");
        //var cyaBlueFinalObject = GameObject.FindGameObjectsWithTag("BlueFinal");
        //var cyaYellowFinalObject = GameObject.FindGameObjectsWithTag("YellowFinal");

        for (int i = OptionsManager._numberObjects; i < 6; i++)
        {
            switch (OptionsManager._numberPlayers)
            {
                case 4:
                    Destroy(cyaRedObject[i]);
                    Destroy(GameObject.Find(cyaRedObject[i].name + "Final"));
                    Destroy(cyaYellowObject[i]);
                    Destroy(GameObject.Find(cyaYellowObject[i].name + "Final"));
                    Destroy(cyaBlueObject[i]);
                    Destroy(GameObject.Find(cyaBlueObject[i].name + "Final"));
                    Destroy(cyaGreenObject[i]);
                    Destroy(GameObject.Find(cyaGreenObject[i].name + "Final"));
                    break;
                case 3:
                    Destroy(cyaRedObject[i]);
                    Destroy(GameObject.Find(cyaRedObject[i].name + "Final"));
                    Destroy(cyaYellowObject[i]);
                    Destroy(GameObject.Find(cyaYellowObject[i].name + "Final"));
                    Destroy(cyaBlueObject[i]);
                    Destroy(GameObject.Find(cyaBlueObject[i].name + "Final"));
                    break;
                case 2:
                    Destroy(cyaRedObject[i]);
                    Destroy(GameObject.Find(cyaRedObject[i].name + "Final"));
                    Destroy(cyaYellowObject[i]);
                    Destroy(GameObject.Find(cyaYellowObject[i].name + "Final"));
                    break;
                default:
                    Debug.Log("Wrong number of players?");
                    break;
            }
        }
    }

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        //script is for both baskets so it needs to compare the
        //basket tag with the object tag to confirm it's the same color
        if (tag == "YellowBasket" && collision.gameObject.tag == "YellowObject")
        {
            SetFinalPosition(collision);
        }
        else if(tag == "RedBasket" && collision.gameObject.tag == "RedObject")
        {
            SetFinalPosition(collision);
        }
        else if (tag == "GreenBasket" && collision.gameObject.tag == "GreenObject")
        {
            SetFinalPosition(collision);
        }
        else if (tag == "BlueBasket" && collision.gameObject.tag == "BlueObject")
        {
            SetFinalPosition(collision);
        }
    }

    private void SetFinalPosition(UnityEngine.Collision collision)
    {
        var objFinal = GameObject.Find(collision.gameObject.name + "Final");

        //set the sprite's alpha to 1 -> fully opaque
        Color auxColor = objFinal.GetComponent<SpriteRenderer>().color;
        auxColor.a = 1f;
        objFinal.GetComponent<SpriteRenderer>().color = auxColor;

        Destroy(collision.gameObject);

        _audioClip.Play();

        //var score = GameObject.Find("ScoreValue");
        //if (score != null)
        //{
        ScoreManager.score++;
        Debug.Log("score++");
            //score.GetComponent<Text>().text = ScoreManager.score.ToString();
        //}                    
    }


}
