using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PeriodLevelController : MonoBehaviour
{
    public GameObject EasyPanel, MediumPanel, HardPanel;
    public Image EasyPic, MediumPic, HardPic;
    public float r_dark, g_dark, b_dark, a_dark;
    public float r_clear, g_clear, b_clear, a_clear;
    Color dark;
    Color clear;

    void Start()
    {
        dark = new Color(r_dark, g_dark, b_dark, a_dark);
        clear = new Color(r_clear, g_clear, b_clear, a_clear);
        clickEasy();
    }

    public void clickEasy()
    {
        EasyPic.color = clear;
        MediumPic.color = dark;
        HardPic.color = dark;
        EasyPanel.SetActive(true);
        MediumPanel.SetActive(false);
        HardPanel.SetActive(false);
    }

    public void clickMedium()
    {
        EasyPic.color = dark;
        MediumPic.color = clear;
        HardPic.color = dark;
        EasyPanel.SetActive(false);
        MediumPanel.SetActive(true);
        HardPanel.SetActive(false);
    }

    public void clickHard()
    {
        EasyPic.color = dark;
        MediumPic.color = dark;
        HardPic.color = clear;
        EasyPanel.SetActive(false);
        MediumPanel.SetActive(false);
        HardPanel.SetActive(true);
    }

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
