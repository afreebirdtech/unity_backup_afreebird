using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class LongClickButton : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private bool click = false;
    private float pointerDownTimer;

    public VideoPlayer video;
    public Animator anim;
    private Animator Dancer;
    public float requireHoldTime;
    public UnityEvent onLongClick;
    public RawImage outside;
    public float timeToDelete = 5f;
    private float timer;

    void Awake()
    {
        Reset();
        video.Prepare();
        timer = 0;
        Dancer = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
        if (anim.GetBool("Break"))
        {
            anim.SetBool("Break", false);
        }
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= timeToDelete && !pointerDown)
        {
            Destroy_Button();
        }
        if(!click && pointerDown)
        {
            click = true;
            outside.enabled = true;
            Dancer.SetTrigger("SuperMove1");
        }
        if (pointerDown)
        {
            outside.GetComponent<RawImage>().gameObject.SetActive(true);
            outside.texture = video.texture;
            video.Play();
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer >= requireHoldTime)
            {
                if(onLongClick != null)
                {
                    onLongClick.Invoke();
                    Reset();
                    DanceScoreSystem.score += 100;
                }
            }
            if(anim.GetBool("Break") == false)
            {
                anim.SetBool("Break", true);
            }
            Invoke("Destroy_Button", requireHoldTime);
        }
        if(click && !pointerDown) 
            //already click once
        {
            Dancer.Play("Idle");
            Destroy_Button();
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }

    public void Destroy_Button()
    {
        Destroy(gameObject);
    }

}
