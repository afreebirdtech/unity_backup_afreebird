using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MarioPlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform groundcheck;

    [SerializeField]
    private string MainMenu;
    public float checkradius;
    public LayerMask mask;
    public Animator animator;
    public Rigidbody2D controller;
    public Joystick joystick;


    bool isdied = false;
    bool isPressed;
    public float runSpeed = 5f;
    float horizontalMove = 0f;
    bool forward = true;
    public float JumpForce = 500f;

    public bool onground;

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.transform.tag == "Enemies")
        {
            MarioGameController.instance.PlayDiedSound();
            Invoke("Died_Reload", 2f);
            isdied = true;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.CompareTag("Flag") && MarioGameController.instance.hasThree())
        {
            MarioGameController.instance.PlayFlagSound();
            Invoke("GotoMainMenu", 2f);
        }
    }

    void Update()
    {
        float verticalvalue = joystick.Vertical;
        if (isdied) return;
        if (onground)
        {
            animator.SetBool("Jump", false);
        }
        if (transform.position.y < -10f)
        {
            MarioGameController.instance.PlayDiedSound();
            Invoke("Died_Reload",2f);
            isdied = true;
        }
        if(onground && isPressed)
        {
            Jump();
            isPressed = false;
        }
        
        horizontalMove = joystick.Horizontal * runSpeed;
        if(joystick.Horizontal > .2f)
        {
            horizontalMove = runSpeed;
        }else if(joystick.Horizontal < -.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0;
        }
        if(horizontalMove > 0 && !forward)
        {
            Flip();
        }else if(horizontalMove < 0 && forward)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        if (isdied) {
            controller.velocity = Vector2.zero;
            animator.SetFloat("Speed", 0);
            return;
        }
        
        Vector2 velocity = new Vector2(horizontalMove, controller.velocity.y);
        controller.velocity = velocity;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    }

    void Flip()
    {
        forward = !forward;
        Vector3 place = transform.localScale;
        place.x *= -1;
        transform.localScale = place;
    }

    void Jump()
    {
        onground = false;
        controller.AddForce(new Vector2(0f, JumpForce));
        animator.SetBool("Jump", true);
        MarioGameController.instance.PlayJumpSound();
    }

    void Died_Reload()
    {
        MarioGameController.instance.ChangeScene(SceneManager.GetActiveScene().name);
    }

    void GotoMainMenu()
    {
        MarioGameController.instance.ChangeScene(MainMenu);
    }

    public void PressJump()
    {
        isPressed = true;
    }

}
