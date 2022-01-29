using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    [SerializeField] private GameObject pinSet;

    private ActionMaster actionMaster;
    private Animator animator;
    private PinCounter pinCounter;


    // Start is called before the first frame update
    void Start()
    {
        actionMaster = new ActionMaster();
        animator = GetComponent<Animator>();
        pinCounter = FindObjectOfType<PinCounter>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void PerformAction(ActionMaster.Action action)
    {
        switch (action)
        {
            case ActionMaster.Action.Tidy:
                animator.SetTrigger("tidyTrigger");
                break;
            case ActionMaster.Action.EndTurn:
                animator.SetTrigger("resetTrigger");
                pinCounter.LastSettledCount = 10;
                break;
            case ActionMaster.Action.Reset:
                animator.SetTrigger("resetTrigger");
                pinCounter.LastSettledCount = 10;
                break;
            case ActionMaster.Action.EndGame:
                throw new UnityException("Game ending not yet implemented");
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