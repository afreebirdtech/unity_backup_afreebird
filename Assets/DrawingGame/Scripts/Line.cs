using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer linerenderer;
    public EdgeCollider2D edgeCollider2D;

    List<Vector2> points;

    public void UpdateLine(Vector2 mouseclick)
    {
        if(points == null )//|| mouseclick.x < 0)
        {
            points = new List<Vector2>();
            SetPoint(mouseclick);
            return;
        }

        if (Vector2.Distance(points[points.Count-1],mouseclick)>.1f)
        {
            SetPoint(mouseclick);
        }

    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        linerenderer.positionCount = points.Count;
        linerenderer.SetPosition(points.Count - 1, point);

        if(points.Count > 1)
        {
            edgeCollider2D.points = points.ToArray();
        }
    }
}
