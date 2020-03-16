using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    GameObject player;
    private void Awake()
    {
        player = transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.collider.tag == "Ground")
        {
            player.GetComponent<MarioPlayerController>().onground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D target)
    {
        if (target.collider.tag == "Ground")
        {
            player.GetComponent<MarioPlayerController>().onground = false;
        }
    }
}
