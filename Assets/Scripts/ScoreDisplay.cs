using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    [SerializeField] private List<Text> bowls;

    [SerializeField] private List<Text> frameScores;
    // Start is called before the first frame update
    void Start()
    {
        EmptyRollCard();
        EmptyFrameScores();
    }

    private void EmptyFrameScores()
    {
        foreach (var frame  in frameScores)
        {
            frame.text = " ";
        }
    }

    private void EmptyRollCard()
    {
        foreach (var text in bowls)
        {
            text.text = " ";
        }
    }
    public void FillRollCard(List<int> rolls)
    {
        string currentRoll;
        for (int i = 0; i < rolls.Count; i++)
        {
            if (rolls[i] == 10)
            {
                currentRoll = "X";
            }
            else
            {
                currentRoll = rolls[i].ToString();
            }

            bowls[i].text = currentRoll;
        }
    }
}
