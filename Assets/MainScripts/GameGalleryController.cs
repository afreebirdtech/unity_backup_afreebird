using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGalleryController : MonoBehaviour
{
    Camera camera;
    private void Awake()
    {
        camera = Camera.main;
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("OpeningScene");
    }

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Print1()
    {
        print(1);
    }

    public void Print2()
    {
        print(2);
    }

    public void Print3()
    {
        print(3);
    }

    public void Print4()
    {
        print(4);
    }

    public void Print5()
    {
        print(5);
    }

    public void Print6()
    {
        print(6);
    }

}
