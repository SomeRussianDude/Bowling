using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Ball>();
    }

    public void DragStart()
    {
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd()
    {
        dragEnd = Input.mousePosition;
        endTime = Time.time;
        var dragDuration = endTime - startTime;
        var launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
        var launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;
        var launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
        ball.Launch(launchVelocity);
    }
    public void MoveStart(float xNudge)
    {
        ball.transform.Translate(new Vector3(xNudge,0,0));
    }

}