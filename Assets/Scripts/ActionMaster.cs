using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    public enum Action
    {
        Tidy,
        Reset,
        EndTurn,
        EndGame
    }

    private int[] rolls = new int[23];
    private int roll = 1;

    public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid number of pins");
        }

        rolls[roll] = pins;

        if (roll == 22)
        {
            return Action.EndGame;
        }
        if (roll == 21)
        {
            roll++;
            return Action.Reset;
        }

        if (roll == 19 && pins == 10)
        {
            roll += 2;
            return Action.Reset;
        }
        if (roll == 20 && pins + rolls[roll - 1] == 10)
        {
            roll++;
            return Action.Reset;
        }
        
        if (roll == 20)
        {
            return Action.EndGame;
        }
        if (pins == 10)
        {
            roll += 2;
            return Action.EndTurn;
        }

        if (roll % 2 != 0)
        {
            roll++;
            return Action.Tidy;
        }

        if (roll % 2 == 0)
        {
            roll++;
            return Action.EndTurn;
        }

        throw new UnityException("Don't know what action to return");
    }
}