using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeAdjust : MonoBehaviour
{
    public bool amFx;

    private AudioSource thisAudio;

    void Start()
    {
        SetVolume();
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "2_OptionsScene")
        {
            SetVolume();
        }
    }

    void SetVolume()
    {
        thisAudio = this.GetComponent<AudioSource>();
        if (amFx)
        {
            thisAudio.volume = PlayerPrefs.GetFloat("Fx_Volume");
        }
        else
        {
            thisAudio.volume = PlayerPrefs.GetFloat("Music_Volume");
        }

    }
}
