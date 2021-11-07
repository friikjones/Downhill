using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject hs_label, ls_label;
    public float hs_value, ls_value;
    private string hs_string, ls_string;

    public GameObject newBestLabel;
    public AudioSource menuSounds;

    private void Start()
    {
        ls_value = PlayerPrefs.GetFloat("Last_Score", 0);
        ls_string = ls_value.ToString("00.00");
        ls_label.GetComponent<Text>().text = ls_string;
        ls_label.transform.GetChild(0).GetComponent<Text>().text = ls_string;

        hs_value = PlayerPrefs.GetFloat("High_Score", 0);
        hs_string = hs_value.ToString("00.00");
        hs_label.GetComponent<Text>().text = hs_string;
        hs_label.transform.GetChild(0).GetComponent<Text>().text = hs_string;

        if (hs_value - ls_value < .01f)
        {
            newBestLabel.SetActive(true);
        }
    }

    public void LoadMenu()
    {
        Vibration.QuickVibration();
        menuSounds.Play();
        SceneManager.LoadScene("1_MenuScene", LoadSceneMode.Single);
    }

    [ContextMenu("Erase HighScore")]
    public void EraseHighScore()
    {
        PlayerPrefs.SetFloat("High_Score", 0);
        PlayerPrefs.SetFloat("Last_Score", 0);
    }

}

