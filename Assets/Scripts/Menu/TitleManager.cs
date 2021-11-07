using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public AudioSource buttonAudioSource;
    public AudioSource gameAudioSource;

    private void Awake()
    {
        Vibration.QuickVibration();
        Input.backButtonLeavesApp = true;
    }
    public void LoadOptions()
    {
        Vibration.QuickVibration();
        if (buttonAudioSource != null)
            buttonAudioSource.Play();
        SceneManager.LoadScene("2_CustomizationScene", LoadSceneMode.Single);
    }

    public void LoadGame()
    {
        Vibration.QuickVibration();
        if (gameAudioSource != null)
            gameAudioSource.Play();
        SceneManager.LoadScene("G_GameScene", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Vibration.QuickVibration();
        if (buttonAudioSource != null)
            buttonAudioSource.Play();
        Application.Quit();
    }

}
