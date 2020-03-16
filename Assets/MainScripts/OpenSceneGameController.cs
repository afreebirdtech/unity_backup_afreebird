using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneGameController : MonoBehaviour
{
    public string NextScene;
    public GameObject PopUpPanel;

    private void Update()
    {

    }

    public void GotoNext()
    {
        SceneManager.LoadScene(NextScene);
    }
}
