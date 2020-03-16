using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAppear : MonoBehaviour
{
    public Animator animator;
    bool isAppeared = false;
    private void Update()
    {
        if (isAppeared) return;
        if(AnswersController.instance.score > 8)
        {
            AppearButton();
        }
    }

    void AppearButton()
    {
        isAppeared = true;
        animator.SetBool("Appear", true);
    }
}
