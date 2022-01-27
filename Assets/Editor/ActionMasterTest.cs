using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;

[TestFixture]
public class ActionMasterTest
{
    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;


    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
    }

    [Test]
    public void T01Bowl_FirstStrike_ReturnsEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02Bowl_8Pins_ReturnsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T03Bowl_Spare_ReturnsEndTurn()
    {
        int[] rolls = new[] {8, 2};
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T04Bowl_LastFrame_ReturnsEndGame()
    {
        for (int i = 0; i < 20; i++)
        {
            pinFalls.Add(2);
        }

        Assert.AreEqual(endGame, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T05Bowl_LastFrameSpare_ReturnsReset()
    {
        for (int i = 0; i < 19; i++)
        {
            pinFalls.Add(2);
        }

        pinFalls.Add(8);
        Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T06Bowl_LastFrameStrike_ReturnsReset()
    {
        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(2);
        }

        pinFalls.Add(10);
        Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T07Bowl_FirstBonusBowl_ReturnsTidy()
    {
        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(2);
        }

        pinFalls.Add(10);
        pinFalls.Add(2);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T08Bowl_SecondBonusBowl_ReturnsEndGame()
    {
        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(2);
        }

        pinFalls.Add(10);
        pinFalls.Add(10);
        pinFalls.Add(4);
        Assert.AreEqual(endGame, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T09Bowl_SingleBonusBowl_ReturnsEndGame()
    {
        for (int i = 0; i < 19; i++)
        {
            pinFalls.Add(2);
        }

        pinFalls.Add(8);
        pinFalls.Add(2);
        Assert.AreEqual(endGame, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T10Bowl_FirstBonusStrike_ReturnsReset()
    {
        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(2);
        }

        pinFalls.Add(10);
        pinFalls.Add(10);
        Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T11Bowl_TheRollPrecededBySecondDelivery10_ReturnsTidy()
    {
        pinFalls.Add(0);
        pinFalls.Add(10);
        pinFalls.Add(1);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T12Dondi10thFrameTurkey()
    {
        int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10};
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
}