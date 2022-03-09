using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//use system namespace to make this class serializable
[Serializable]
public class Line
{
    public Vector3[] positions;
    public Gradient color;
    public AnimationCurve width;

    //Line class Initializer. Takes in a LineRenderer and stores its data in the respective places
    public Line(LineRenderer lineRenderer)
    {
        positions = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(positions);
        color = lineRenderer.colorGradient;
        width = lineRenderer.widthCurve;
    }   

    public void Draw()
    {
        GameObject newLineRenderer = GameObject.Instantiate(TouchDraw.staticLinePrefab, Vector3.zero, Quaternion.identity);
        LineRenderer lineRenderer = newLineRenderer.GetComponent<LineRenderer>();
        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
        lineRenderer.colorGradient = color;
        lineRenderer.widthCurve = width;
    }
}
