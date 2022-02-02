using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<int> bowls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;

    private ScoreDisplay scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int pinFall)
    {
        bowls.Add(pinFall);
        ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
        pinSetter.PerformAction(nextAction);
        scoreDisplay.FillRollCard(bowls);
        ball.Reset();
    }
}