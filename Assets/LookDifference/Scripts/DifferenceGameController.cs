using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifferenceGameController : MonoBehaviour
{
    public GameObject TipPanel;
    public static DifferenceGameController instance;
    [HideInInspector]
    public bool gameover;
    public GameObject FinishPanel;
    public GameObject DiedPanel;
    public GameObject PausePanel;
    public AudioSource music;
    public Image countDown;
    public Text findText;
    public Image timeBar;
    public float TimeLimit;
    public Animator clockAnim;
    public Animator CompleteAnim;

    public AudioSource SpecialMusic;
    public AudioClip getScoreSound;

    float timer;
    bool isPaused;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        timer = TimeLimit;
        Time.timeScale = 1;
        isPaused = false;

    }

    void Update()
    {
        if (DifferenceScoreSystem.score == 5)
            //Complete the game
        {
            Time.timeScale = 0;
            FinishPanel.SetActive(true);
            CompleteAnim.SetTrigger("complete");
        }
        timer -= Time.deltaTime;
        //countDown.text = timer.ToString("0");
        findText.text = "Found:" + DifferenceScoreSystem.score.ToString() + "/5";
        timeBar.fillAmount = Mathf.Lerp(0, 1, timer / TimeLimit);
        if (timer < 15f)
        {
            countDown.color = new Color(0.78f,0.21f,0.21f,0.70f);
            clockAnim.SetBool("Alarm", true);
        }
        if(timer < 0)
        {
            Time.timeScale = 0;
            DiedPanel.SetActive(true);
        }
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            PausePanel.SetActive(true);
            Time.timeScale = 0;
            music.Pause();
            //clockAnim.speed = 0;
        }

    }

    public void Resume()
    {
        if (isPaused)
        {
            isPaused = false;
            PausePanel.SetActive(false);
            Time.timeScale = 1;
            music.UnPause();
        }

    }

    public void RestartGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        music.UnPause();
        DifferenceScoreSystem.score = 0;
    }

    public void GetScore()
    {
        DifferenceScoreSystem.score++;
        SpecialMusic.clip = getScoreSound;
        SpecialMusic.Play();
    }

    public void GoToAnotherScene(string SceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneName);
    }

    public void TipButton()
    {
        if (TipPanel.activeInHierarchy)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        TipPanel.SetActive(!TipPanel.activeInHierarchy);
    }

}
