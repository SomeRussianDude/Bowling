using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{
    [SerializeField] private Text standingDisplay;

    private GameManager gameManager;
    
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private int pinsFallen = 0;
    private bool ballLeftBox = false;
    private float lastChangeTime;

    public int LastStandingCount => lastStandingCount;

    public int LastSettledCount
    {
        get => lastSettledCount;
        set => lastSettledCount = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();

        if (ballLeftBox)
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
        gameManager.Bowl(pinsFallen);

        lastStandingCount = -1; //Indicates  pins have settled and ball is not back in the box
        ballLeftBox = false;
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

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            ballLeftBox = true;
            standingDisplay.color = Color.red;
        }
    }
}