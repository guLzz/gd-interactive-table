using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicScript : MonoBehaviour
{
    private static AudioSource _audioClip;
    public static float musicTimer = 0;
    public Sprite _mute, _unmute;
    private static bool _ismuted = false;

    // Start is called before the first frame update
    void Start()
    {
        var iconObject = GameObject.FindGameObjectWithTag("SoundIcon");
        _audioClip = iconObject.GetComponent<AudioSource>();
        _audioClip.time = musicTimer;
        getSound();
        
    }

    // Update is called once per frame
    void Update()
    {
        musicTimer = _audioClip.time;
        keyMute();
    }

    public void MuteUnmute()
    {
        var iconObject = GameObject.FindGameObjectWithTag("SoundIcon");
        var soundIcon = iconObject.GetComponent<Image>();
        Debug.Log(_ismuted);
        if (_ismuted)
        {
            soundIcon.sprite = _unmute;
            _audioClip.UnPause();
            _ismuted = false;
            //Debug.Log("unpause");
        }
        else
        {
            soundIcon.sprite = _mute;
            _audioClip.Pause();
            _ismuted = true;
            //Debug.Log("pause");
        }
    }

    public void getSound()
    {
        var iconObject = GameObject.FindGameObjectWithTag("SoundIcon");
        var soundIcon = iconObject.GetComponent<Image>();
        if (_ismuted)
        {
            soundIcon.sprite = _mute;
            _audioClip.Pause();
            _ismuted = true;
            //Debug.Log("is paused");
        }
        else
        {
            soundIcon.sprite = _unmute;
            _audioClip.UnPause();
            _ismuted = false;
            //Debug.Log("is unpaused");
        }
    }

    public void keyMute()
    {
        if (Input.GetKeyDown("space"))
        {
            MuteUnmute();
        }
    }
}
