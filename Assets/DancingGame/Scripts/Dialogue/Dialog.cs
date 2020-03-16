using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public GameObject nextButton;
    public string nextLevel;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    int index;
    public float typeSpeed = 0.1f;

    private void Start()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            nextButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index])
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void NextSentence()
    {
        nextButton.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            SceneManager.LoadScene(nextLevel);
        }
    }
}
