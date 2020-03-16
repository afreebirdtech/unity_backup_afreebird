using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBubbleController : MonoBehaviour
{
    Animator anim;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void BreakBubble()
    {
        anim.SetTrigger("Break");
        Invoke("Destroy_Bubble", time);
    }

    void Destroy_Bubble()
    {
        Destroy(gameObject);
    }
}
