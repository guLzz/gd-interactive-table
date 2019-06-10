using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class WallManager : MonoBehaviour
{
    private AudioSource _audioClip;
    // Start is called before the first frame update
    void Start()
    {
        _audioClip = GetComponent<AudioSource>();
        _audioClip.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (tag == "Wall" && ( collision.gameObject.tag == "YellowObject" || collision.gameObject.tag == "RedObject" || collision.gameObject.tag == "BlueObject" || collision.gameObject.tag == "GreenObject"))
        {
            _audioClip.Play();
        }
    }
}
