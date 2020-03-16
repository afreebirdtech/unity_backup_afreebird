using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineController : MonoBehaviour
{
    public GameObject materialPrefab;
    public Image colorHboard;
    public Image colorVboard;
    public GameObject linePrefab;
    public Transform lineparent;
    public GameObject eraser;
    private bool iserased;

    private int layer;
    float colorH;
    float colorV;
    Line CurrentLine;

    public Material blackcolor;

    private void Start()
    {
        colorH = 0;
        colorV = 1;

        Material another = new Material(blackcolor);
        iserased = false;
        LineRenderer renderer = linePrefab.GetComponent<LineRenderer>();
        another.color = Color.HSVToRGB(colorH, 1, colorV);
        renderer.material = another;
        colorHboard.color = another.color;
        colorVboard.color = another.color;
        renderer.startWidth = 0.05f;
    }

    private void Update()
    {
        if (iserased)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                eraser.transform.position = pos;
            }
        }
        if (!iserased)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (pos.x < 0)
                {
                    CurrentLine = null;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                GameObject LineGo = Instantiate(linePrefab);
                CurrentLine = LineGo.GetComponent<Line>();
                LineGo.transform.parent = lineparent;
                LineGo.GetComponent<LineRenderer>().sortingOrder = layer;
                layer++;
            }

            if (Input.GetMouseButtonUp(0))
            {
                CurrentLine = null;
            }

            if (CurrentLine != null)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                CurrentLine.UpdateLine(pos);
            }
        }

    }

    public void erase()
    {
        iserased = true;
    }


    public void paint()
    {
        iserased = false;
    }

    public void Change_pensize(float num)
    {
        iserased = false;
        LineRenderer renderer = linePrefab.GetComponent<LineRenderer>();
        renderer.startWidth = num/10;
    }

    public void Change_color(float num)
    {
        //Material material = Instantiate()
        Material another = new Material(blackcolor);
        iserased = false;
        LineRenderer renderer = linePrefab.GetComponent<LineRenderer>();
        colorH = 1 - num;
        another.color = Color.HSVToRGB(colorH, 1, colorV);
        renderer.material = another;
        colorHboard.color = another.color;
        colorVboard.color = another.color;
    }


    public void Change_Depth(float num)
    {
        Material another = new Material(blackcolor);
        iserased = false;
        LineRenderer renderer = linePrefab.GetComponent<LineRenderer>();
        colorV = 1 - num;
        another.color = Color.HSVToRGB(colorH, 1, colorV);
        renderer.material = another;
        colorHboard.color = another.color;
        colorVboard.color = another.color;
    }
}
