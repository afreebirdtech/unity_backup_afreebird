using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DanceGameController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform mycanvas;
    public GameObject buttonPrefab;
    public Animator dancerAnim;
    public float offset = 1f, LengthOfLevel;
    public Material bluecolor, redcolor;
    public GameObject ballPrefab,superballPrefab1;
    public Text theScore;
    public Transform collector;
    public float SuperBubbleLastTime = 5f;
    bool nextLevel = false;

    Dictionary<Transform, float> SuperMove_1_Collections;
    Dictionary<Transform, float> NormalCollections;
    List<float> SupermoveList1,ButtonList,NormalList;
    float Timer;

    //private int score = 0;

    public float time_to_create = 2f;
    public float time_to_delete = 2f;

    public float randmax_x = 5f, randmin_x = -5f, randmax_y = 5f, randmin_y = -5f;

    void Start()
    {
        Timer = 0;
        if (NormalList == null)
        {
            NormalList = new List<float> {03.32f,
                04.28f, 05.30f, 06.25f, 07.20f,
                09.25f,
                12.17f, 13.27f,14.18f,15.03f,16.10f,
                19.00f, 20.05f, 21.05f, 21.48f,
                22.47f, 23.42f,
                25.38f, 26.38f, 27.38f, 29.00f, 29.38f,
                30.38f, 31.33f, 32.47f, 34.27f };
        }

        if(SuperMove_1_Collections == null)
        {
            SuperMove_1_Collections = new Dictionary<Transform, float>();
        }

        if (NormalCollections == null)
        {
            NormalCollections = new Dictionary<Transform, float>();
        }

        // ButtonB 左右走
        if (SupermoveList1 == null)
        {
            SupermoveList1 = new List<float> { 2.33f,4.28f,8.2f,18.05f,21.45f};
        }

        // ButtonA 转圈
        if(ButtonList == null)
        {
            ButtonList = new List<float> { 10.17f, 25.13f};
        }

    }

    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer > LengthOfLevel)
        {
            nextLevel = true;
        }
        if (nextLevel)
        {
            GoToNextLevel();
        }
        theScore.text = "Score: " + DanceScoreSystem.score;
        Touch[] alltouches = Input.touches;
        if (alltouches.Length > 0)
        {
            // all the touches
            foreach (var touch in alltouches)
            {
                Vector2 curpos = Camera.main.ScreenToWorldPoint(touch.position);

                // click to remove keys in normal
                foreach (var item in NormalCollections)
                {
                    Vector2 eachpos = item.Key.position;
                    if (Vector2.Distance(eachpos, curpos) < offset)
                    {
                        if (item.Key.gameObject.CompareTag("NormalBall"))
                        {
                            //score += 10;
                            DanceScoreSystem.score += 10;
                            var controller = item.Key.gameObject.GetComponent<SuperBubbleController>();
                            controller.BreakBubble();
                            NormalCollections.Remove(item.Key);
                            break;
                        }
                    }
                }

                // click to remove keys in supermove
                foreach (Transform temp in SuperMove_1_Collections.Keys)
                {
                    Vector2 ballpos = temp.position;
                    if (Vector2.Distance(curpos, ballpos) < offset)
                    {
                        if (temp.gameObject.CompareTag("SuperBall"))
                        {
                            //score += 50;
                            DanceScoreSystem.score += 50;
                            SuperBubbleController controller = temp.gameObject.GetComponent<SuperBubbleController>();
                            controller.BreakBubble();
                            dancerAnim.SetTrigger("SuperMove2");
                            if(rb.velocity.x > 0)
                            {
                                dancerAnim.SetBool("MoveRight", true);
                            }
                            else
                            {
                                dancerAnim.SetBool("MoveRight", false);
                            }
                            SuperMove_1_Collections.Remove(temp);
                            //Invoke("Destroy(temp.gameObject)", 0.5f);
                            //Destroy(temp.gameObject);
                            break;
                        }
                    }
                }
            }
        }
        Create_Bubble();
        Delete_Normal();

        Create_Super_Bubble1();
        Clean_Super_Bubble1();

        Create_Button();
    }

    //NormalList already
    void Create_Bubble()
    {
        if (NormalList.Count == 0) return;
        float first = NormalList[0];
        if (Timer > first)
        {
            NormalList.RemoveAt(0);
            float x = Random.Range(randmin_x, randmax_x);
            float y = Random.Range(randmin_y, randmax_y);
            Vector2 rand;
            rand.x = x;
            rand.y = y;
            GameObject each;
            if (Random.Range(0, 5) > 1)
            {
                each = Instantiate(ballPrefab, rand, Quaternion.identity, collector);
                each.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.1f, 0.5f), Random.Range(0.1f, 0.5f), Random.Range(0.5f, 1), 0.8f);
                NormalCollections[each.transform] = Timer + Random.Range(time_to_delete, time_to_delete * 2);
            }
        }
    }

    void Create_Super_Bubble1()
    {
        if(SupermoveList1.Count > 0)
        {
            float compare = SupermoveList1[0];
            if(Timer >= compare)
            {
                SupermoveList1.RemoveAt(0);
                float x = Random.Range(randmin_x, randmax_x);
                float y = Random.Range(randmin_y, randmax_y);
                Vector2 rand;
                rand.x = x;
                rand.y = y;
                GameObject each = Instantiate(superballPrefab1, rand, Quaternion.identity, collector);
                SuperMove_1_Collections[each.transform] = SuperBubbleLastTime + compare;
                //print(compare);
            }
        }
    }

    void Create_Button()
    {
        if(ButtonList.Count > 0)
        {
            float compare = ButtonList[0];
            if (Timer >= compare)
            {
                ButtonList.RemoveAt(0);
                float x = Random.Range(randmin_x, randmax_x);
                float y = Random.Range(randmin_y, randmax_y);
                Vector2 rand = Camera.main.WorldToScreenPoint(new Vector2(x, y));
                GameObject each = Instantiate(buttonPrefab, rand, Quaternion.identity, mycanvas);
                print(compare);
            }
        }
    }

    void Clean_Super_Bubble1()
    {
        foreach(Transform temp in SuperMove_1_Collections.Keys)
        {
            if (Timer > SuperMove_1_Collections[temp]){
                SuperMove_1_Collections.Remove(temp);
                Destroy(temp.gameObject);
                break;
            }
        }
    }

    void Delete_Normal()
    {
        foreach (var item in NormalCollections)
        {
            if(Timer > item.Value)
            {
                Destroy(item.Key.gameObject);
                NormalCollections.Remove(item.Key);
                break;
            }
        }

    }

    void GoToNextLevel() { }

}
