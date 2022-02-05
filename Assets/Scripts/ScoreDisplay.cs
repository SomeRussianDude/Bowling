using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private List<Text> rollsTexts;

    [SerializeField] private List<Text> frameScoreTexts;

    // Start is called before the first frame update
    void Start()
    {
        EmptyRollCard();
        EmptyFrameScores();
    }

    private void EmptyFrameScores()
    {
        foreach (var frame in frameScoreTexts)
        {
            frame.text = " ";
        }
    }

    private void EmptyRollCard()
    {
        foreach (var text in rollsTexts)
        {
            text.text = " ";
        }
    }

    public void FillRollCard(List<int> rolls)
    {
        string rollsString = FormatRolls(rolls);
        for (int i = 0; i < rollsString.Length; i++)
        {
            rollsTexts[i].text = rollsString[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";
        for (int i = 0; i < rolls.Count; i++)
        {
            int scoreBox = output.Length + 1;

            if (rolls[i] == 0)
            {
                output += "-";
            }
            else if ((scoreBox % 2 == 0 || scoreBox == 21) && rolls[i] + rolls[i - 1] == 10)
            {
                output += "/";
            }
            else if (rolls[i] == 10 && scoreBox < 19)
            {
                output += "X ";
            }
            else if (rolls[i] == 10)
            {
                output += "X";
            }
            else
            {
                output += rolls[i].ToString();
            }
        }

        return output;
    }

    public void FillFrames(List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++)
        {
            frameScoreTexts[i].text = frames[i].ToString();
        }
    }
}