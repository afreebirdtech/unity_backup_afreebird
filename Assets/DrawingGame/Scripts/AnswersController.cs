using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersController : MonoBehaviour
{
    public static AnswersController instance;
    public int score = 0;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void addScore()
    {
        score++;
    }
}
