using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverlayCarryOverScript : MonoBehaviour
{

    private static OverlayCarryOverScript _instance;
    public static OverlayCarryOverScript Instance { get { return _instance; } }

    public AudioSource audioSource;

    void Awake()
    {
        CheckForInstance();

        DontDestroyOnLoad(this.gameObject);
    }

    void CheckForInstance()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void FixedUpdate()
    {

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "G_GameScene")
        {
            audioSource.enabled = false;
        }
        else
        {
            audioSource.enabled = true;
        }
    }

}
