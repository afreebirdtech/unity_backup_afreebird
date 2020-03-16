using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceController : MonoBehaviour
{
    [SerializeField]
    private GameObject block;
    Rigidbody2D rb;
    public float detect = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position+Vector2.up*0.2f, 
            Vector2.down,detect, LayerMask.GetMask("Player"));
        if(hit)
        {
            drop();
        }
    }

    void drop()
    {
        block.SetActive(false);
    }
}
