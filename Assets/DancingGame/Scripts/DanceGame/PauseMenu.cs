using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public AudioSource music;
    public GameObject pauseButton;

    // Update is called once per frame
    void Update()
    {

    }

    public void PausetheMenu()
    {
        if (!isPaused)
        {
            isPaused = true;
            gameObject.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0;
            music.Pause();
        }
    }

    public void Resume()
    {
        if (isPaused)
        {
            isPaused = false;
            gameObject.SetActive(false);
            pauseButton.SetActive(true);
            Time.timeScale = 1;
            music.UnPause();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isPaused = false;
        //gameObject.SetActive(false);
        //pauseButton.SetActive(true);
        Time.timeScale = 1;
        DanceScoreSystem.score = 0;
    }
}
