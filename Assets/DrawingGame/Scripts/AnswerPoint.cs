using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPoint : MonoBehaviour
{
    private bool istouched = false;
    void OnTriggerEnter2D(Collider2D target)
    {
        if (istouched) return;
        if(target.tag == "drawing")
        {
            Debug.Log("GetScore");
            istouched = true;
            AnswersController.instance.addScore();
        }
    }
}
