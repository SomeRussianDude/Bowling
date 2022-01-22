using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    [SerializeField] private Text standingDisplay;
    [SerializeField] private GameObject pinSet;

    private int lastStandingCount = -1;
    private bool ballEnteredBox;
    private float lastChangeTime;
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


    public void RaisePins()
    {
        Pin[] pins = FindObjectsOfType<Pin>();
        foreach (var pin in pins)
        {
            pin.Raise();
        }
    }

    public void LowerPins()
    {
        Pin[] pins = FindObjectsOfType<Pin>();
        foreach (var pin in pins)
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Instantiate(pinSet, new Vector3(0, 0, 18.29f), Quaternion.identity);
    }
}