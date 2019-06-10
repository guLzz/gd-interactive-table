using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //public Collider RedBasket;
    //public Collider YellowBasket;
    //private GameObject _yellowBasket;

    public static int score;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = score.ToString();
    }
}
