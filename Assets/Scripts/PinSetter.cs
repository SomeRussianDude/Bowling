using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    [SerializeField] private GameObject pinSet;

    private ActionMasterOld _actionMasterOld;
    private Animator animator;
    private PinCounter pinCounter;


    // Start is called before the first frame update
    void Start()
    {
        _actionMasterOld = new ActionMasterOld();
        animator = GetComponent<Animator>();
        pinCounter = FindObjectOfType<PinCounter>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void PerformAction(ActionMasterOld.Action action)
    {
        switch (action)
        {
            case ActionMasterOld.Action.Tidy:
                animator.SetTrigger("tidyTrigger");
                break;
            case ActionMasterOld.Action.EndTurn:
                animator.SetTrigger("resetTrigger");
                pinCounter.LastSettledCount = 10;
                break;
            case ActionMasterOld.Action.Reset:
                animator.SetTrigger("resetTrigger");
                pinCounter.LastSettledCount = 10;
                break;
            case ActionMasterOld.Action.EndGame:
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