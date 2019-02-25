using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{

    void Start()
    {
        GameObject music = GameObject.FindGameObjectWithTag("Music");
        if(music != null)
        {
            musicPlayer mp = music.GetComponent<musicPlayer>();
            mp.PlayMusic();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void loadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
