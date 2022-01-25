using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster actionMaster;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;

    [SetUp]
    public void Setup()
    {
        actionMaster = new ActionMaster();
    }
    // [Test]
    // public void PassingTest () {
    //     Assert.AreEqual (1, 1);
    // }

    [Test]
    public void T01Bowl_FirstStrike_ReturnsEndTurn()
    {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T02Bowl_8Pins_ReturnsTidy()
    {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T03Bowl_Spare_ReturnsEndTurn()
    {
        actionMaster.Bowl(8);
        Assert.AreEqual(endTurn, actionMaster.Bowl(2));
    }

    [Test]
    public void T04Bowl_LastFrame_ReturnsEndGame()
    {
        for (int i = 0; i < 19; i++)
        {
            actionMaster.Bowl(2);
        }

        Assert.AreEqual(endGame, actionMaster.Bowl(2));
    }

    [Test]
    public void T05Bowl_LastFrameSpare_ReturnsReset()
    {
        for (int i = 0; i < 19; i++)
        {
            actionMaster.Bowl(2);
        }

        Assert.AreEqual(reset, actionMaster.Bowl(8));
    }

    [Test]
    public void T06Bowl_LastFrameStrike_ReturnsReset()
    {
        for (int i = 0; i < 18; i++)
        {
            actionMaster.Bowl(2);
        }

        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T07Bowl_FirstBonusBowl_ReturnsTidy()
    {
        for (int i = 0; i < 18; i++)
        {
            actionMaster.Bowl(2);
        }

        actionMaster.Bowl(10);
        Assert.AreEqual(tidy, actionMaster.Bowl(4));
    }

    [Test]
    public void T08Bowl_SecondBonusBowl_ReturnsEndGame()
    {
        for (int i = 0; i < 18; i++)
        {
            actionMaster.Bowl(2);
        }

        actionMaster.Bowl(10);
        actionMaster.Bowl(10);
        Assert.AreEqual(endGame, actionMaster.Bowl(4));
    }

    [Test]
    public void T09Bowl_SingleBonusBowl_ReturnsEndGame()
    {
        for (int i = 0; i < 19; i++)
        {
            actionMaster.Bowl(2);
        }

        actionMaster.Bowl(8);
        Assert.AreEqual(endGame, actionMaster.Bowl(4));
    }

    [Test]
    public void T10Bowl_FirstBonusStrike_ReturnsEndTurn()
    {
        for (int i = 0; i < 18; i++)
        {
            actionMaster.Bowl(2);
        }

        actionMaster.Bowl(10);
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));

    }
}