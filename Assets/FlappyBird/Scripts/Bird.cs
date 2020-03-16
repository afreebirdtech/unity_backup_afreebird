using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isDead = false;
    Rigidbody2D rigidbody2d;
    Animator animator;
    private float UpForce = 200f;
    [SerializeField]
    private string nextlevel;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rigidbody2d.velocity = Vector2.zero;
                rigidbody2d.AddForce(new Vector2(0, UpForce));
                animator.SetTrigger("Flap");
                MusicController.instance.BirdFlySound();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Finish")
        {
            Invoke("FinishGame", 3f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;
        isDead = true;
        animator.SetTrigger("Die");
        MusicController.instance.BirdDiedSound();
        Invoke("Birddie", 1f);
    }

    void Birddie()
    {
        FlappyGameController.instance.BirdDied();
    }

    void FinishGame()
    {
        SceneManager.LoadScene(nextlevel);
    }
}
