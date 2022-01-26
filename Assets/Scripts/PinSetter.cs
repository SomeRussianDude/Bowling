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
    private int lastSettledCount = 10;
    private int pinsFallen = 0;
    private bool ballEnteredBox;
    private float lastChangeTime;
    private Ball ball;
    private ActionMaster actionMaster;
    private Animator animator;

    public int LastStandingCount => lastStandingCount;

    // Start is called before the first frame update
    void Start()
    {
        ballEnteredBox = false;
        ball = FindObjectOfType<Ball>();
        actionMaster = new ActionMaster();
        animator = GetComponent<Animator>();
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
        pinsFallen = lastSettledCount - CountStanding();
        lastSettledCount = CountStanding();
        AnimatorAction(actionMaster.Bowl(pinsFallen));
        ball.Reset();
        lastStandingCount = -1;
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }

    private void AnimatorAction(ActionMaster.Action action)
    {
        switch (action)
        {
            case ActionMaster.Action.Tidy:
                animator.SetTrigger("tidyTrigger");
                break;
            case ActionMaster.Action.EndTurn:
                animator.SetTrigger("resetTrigger");
                lastSettledCount = 10;
                break;
            case ActionMaster.Action.Reset:
                animator.SetTrigger("resetTrigger");
                lastSettledCount = 10;
                break;
            case ActionMaster.Action.EndGame:
                throw new UnityException("Game ending not yet implemented");
        }
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