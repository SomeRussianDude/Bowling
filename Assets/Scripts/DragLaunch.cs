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
        var launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration / 100;
        var launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration / 100;
        var launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
        if (!ball.IsRolling)
        {
            ball.Launch(launchVelocity);
        }
    }

    public void MoveStart(float xNudge)
    {
        if (!ball.IsRolling)
        {
            var ballPos = ball.transform.position;
            var xPos = Mathf.Clamp(ballPos.x + xNudge, -0.45f, 0.45f);
            var yPos = ballPos.y;
            var zPos = ballPos.z;
            ballPos = new Vector3(xPos, yPos, zPos);
            ball.transform.position = ballPos;
        }
    }
}