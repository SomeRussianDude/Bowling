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
        var currentFrame = 0;
        var currentRoll = 1;
        List<int> frameList = new List<int>() {0};
        foreach (var roll in rolls)
        {
            if (currentRoll % 2 != 0)
            {
                frameList[currentFrame] += roll;
            }
        }

        return frameList;
    }
}