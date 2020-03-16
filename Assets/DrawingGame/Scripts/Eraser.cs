using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target != null && target.tag == "drawing")
        {
            Debug.Log("Destroy");
            Destroy(target.gameObject);
        }
    }
}
