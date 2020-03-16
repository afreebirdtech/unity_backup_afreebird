using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = -5f;
    public float time_to_turn = 3f;
    float timer = 0;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > time_to_turn)
        {
            speed *= -1;
            timer = 0;
        }
        Vector2 velocity = new Vector2(speed, rb.velocity.y);
        rb.velocity = velocity;

    }

}
