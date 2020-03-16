using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyGameController : MonoBehaviour
{
    public static FlappyGameController instance;
    public GameObject DiedPanel;
    public bool gameover = false;
    public float scrollspeed = -1.5f;
    private float score = 0f;
    public Text scoretext;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BirdDied()
    {
        gameover = true;
        DiedPanel.SetActive(true);
    }

    public void BirdScored()
    {
        if (gameover)
        {
            return;
        }
        score++;
        scoretext.text = "Score: " + score.ToString();
    }

    public void GoToMainMenu(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
