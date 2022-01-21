using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    [SerializeField] private Text standingDisplay;

    private int lastStandingCount = -1;
    private bool ballEnteredBox;
    private float lastChangeTime;
    private float distanceToRaise = 0.4f;
    private Ball ball;

    public int LastStandingCount => lastStandingCount;

    // Start is called before the first frame update
    void Start()
    {
        ballEnteredBox = false;
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();

        if (ballEnteredBox)
        {
            CheckStanding();
        }
    }

    private void CheckStanding()
    {
        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    private void PinsHaveSettled()
    {
        ball.Reset();
        lastStandingCount = -1;
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }


    public int CountStanding()
    {
        int pinsStanding = 0;
        Pin[] pins = FindObjectsOfType<Pin>();
        foreach (var pin in pins)
        {
            if (pin.IsStanding())
            {
                pinsStanding++;
            }
        }

        return pinsStanding;
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherObject = other.gameObject;
        if (otherObject.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var otherObject = other.gameObject;
        if (otherObject.GetComponent<Pin>())
        {
            Destroy(otherObject, 1f);
        }
    }

    public void RaisePins()
    {
        Pin[] pins = FindObjectsOfType<Pin>();
        foreach (var pin in pins)
        {
            pin.GetComponent<Rigidbody>().useGravity = false;
            pin.transform.Translate(0, distanceToRaise, 0);
        }
    }

    public void LowerPins()
    {
        Pin[] pins = FindObjectsOfType<Pin>();
        foreach (var pin in pins)
        {
            pin.transform.Translate(0, -distanceToRaise, 0);
            pin.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void RenewPins()
    {
        print("New pins have been delivered");
    }
}