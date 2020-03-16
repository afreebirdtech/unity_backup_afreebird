using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCircle : MonoBehaviour
{
    Image circle;
    float timer = 0;
    public float time_to_finish = 2f;
    // Start is called before the first frame update
    void Start()
    {
        circle = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= time_to_finish)
        {
            timer += Time.deltaTime;
            circle.fillAmount = Mathf.Lerp(0, 1, timer / time_to_finish);
        }
    }
}
