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

    private bool FirstBonusFrame()
    {
        return (roll == 21 && rolls[19] == 10 );
    }
    
    public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid number of pins");
        }

        rolls[roll] = pins;

        //Second bonus roll returns EndGame
        if (roll == 22)
        {
            return Action.EndGame;
        }

        //First bonus roll handling
        if (FirstBonusFrame() && pins < 10)
        {
            roll++;
            return Action.Tidy;
        }
        else if (FirstBonusFrame() && pins == 10)
        {
            roll++;
            return Action.EndTurn;
        }

        //Single bonus frame returns EndGame
        if (roll == 21 && (rolls[19] + rolls[20] == 10))
        {
            return Action.EndGame;
        }


        //Last frame strike returns Reset
        if (roll == 19 && pins == 10)
        {
            roll += 2;
            return Action.Reset;
        }

        //Last frame spare returns Reset
        if (roll == 20 && pins + rolls[roll - 1] == 10)
        {
            roll++;
            return Action.Reset;
        }

        //Ordinary last frame returns EndGame
        if (roll == 20)
        {
            return Action.EndGame;
        }

        //Strike returns EndTurn
        if (pins == 10)
        {
            roll += 2;
            return Action.EndTurn;
        }

        //Odd rolls return Tidy
        if (roll % 2 != 0)
        {
            roll++;
            return Action.Tidy;
        }

        //Even rolls return EndTurn
        if (roll % 2 == 0)
        {
            roll++;
            return Action.EndTurn;
        }

        throw new UnityException("Don't know what action to return");
    }
}