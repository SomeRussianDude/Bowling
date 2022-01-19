using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    [SerializeField] private Text standingDisplay;
    private bool ballEnteredBox;
    
    // Start is called before the first frame update
    void Start()
    {
        ballEnteredBox = false;
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();
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
}
