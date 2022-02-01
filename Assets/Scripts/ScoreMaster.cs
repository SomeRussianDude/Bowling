using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreMaster
{
    // Returns a list of cumulative scores like a normal score card
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScore = new List<int>();
        int runningScore = 0;
        foreach (var frameScore in ScoreFrames(rolls))
        {
            runningScore += frameScore;
            cumulativeScore.Add(runningScore);
        }

        return cumulativeScore;
    }

    // Returns a list of individual frame scores
    public static List<int> ScoreFrames(List<int> rolls)
    {
        var currentFrameScore = 0;
        var currentRoll = 1;

        List<int> frameList = new List<int>();

        for (var index = 0; index < rolls.Count; index++)
        {
            if (frameList.Count == 10)
            {
                break;
            }

            currentFrameScore += rolls[index];

            // Strike bonus situations handling 
            if (currentRoll % 2 != 0 && rolls[index] == 10 && index + 2 < rolls.Count)
            {
                currentRoll += 2;
                currentFrameScore += rolls[index + 1] + rolls[index + 2];
                frameList.Add(currentFrameScore);
                currentFrameScore = 0;
                continue;
            }

            // Spare bonus situations handling
            if (currentRoll % 2 == 0 && currentFrameScore == 10 && index + 1 < rolls.Count)
            {
                currentRoll++;
                currentFrameScore += rolls[index + 1];
                frameList.Add(currentFrameScore);
                currentFrameScore = 0;
                continue;
            }

            // Regular roll situations
            if (currentRoll % 2 == 0 && currentFrameScore < 10)
            {
                currentRoll++;
                frameList.Add(currentFrameScore);
                currentFrameScore = 0;
            }
            else
            {
                currentRoll++;
            }
        }

        return frameList;
    }

    // A method to return the maximum possible score in the game based on the rolls
    // public static int MaxScore(List<int> rolls)
    // {
    //     int maxScore = 300;
    //     
    //     return maxScore;
    // }
}