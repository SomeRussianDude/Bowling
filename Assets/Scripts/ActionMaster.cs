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

    private int[] bowls = new int[22];
    private int bowl = 1;

    public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid number of pins");
        }

        bowls[bowl] = pins;
        if (pins == 10)
        {
            bowl += 2;
            return Action.EndTurn;
        }

        if (bowl % 2 != 0)
        {
            bowl++;
            return Action.Tidy;
        }

        if (bowl % 2 == 0)
        {
            bowl++;
            return Action.EndTurn;
        }

        throw new UnityException("Don't know what action to return");
    }
}