using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DrawGameController : MonoBehaviour
{
    public static DrawGameController instance;
    public string scenename;
    public Image nextButton;
    public GameObject finishPanel;
    public GameObject pausePanel;
    public Animator completeAnim;
    bool ableToNext = false;
    bool showNext = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        if(!showNext && AnswersController.instance.score > 8)
        {
            nextButton.color = new Color(1, 1, 1);
        }
        if (!ableToNext && AnswersController.instance.score > 8)
        {
            ableToNext = true;

        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(scenename);
    }

    public void clickNext()
    {
        if (!ableToNext)
        {
            Debug.Log("UnableToGoNext");
            return;
        }
        finishPanel.SetActive(true);
        completeAnim.SetTrigger("complete");
    }

    public void clickMenu()
    {
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
    }

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
