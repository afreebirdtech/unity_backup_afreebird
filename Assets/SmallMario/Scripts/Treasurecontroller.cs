using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasurecontroller : MonoBehaviour
{
    public GameObject ParticlePrefab;
    public GameObject ShowTreasure;
    public Animator animator;
    bool isClosed = true;
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player") && isClosed)
        {
            isClosed = false;
            animator.SetBool("isOpen", true);
            Instantiate(ParticlePrefab, transform.position, Quaternion.identity);
            ShowTreasure.SetActive(true);
            MarioGameController.instance.GetOneTreasure();
            MarioGameController.instance.PlayTreasureSound();
        }
    }
}
