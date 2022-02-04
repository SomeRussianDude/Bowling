using System.Linq;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ScoreDisplayTest
{
    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01FirstRoll()
    {
        int[] rolls = {1};
        string framesString = "1";
        Assert.AreEqual(framesString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T02FirstThreeRegularRolls()
    {
        int[] rolls = {1, 1, 1};
        string framesString = "111";
        Assert.AreEqual(framesString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T03FirstStrike()
    {
        int[] rolls = {10};
        string framesString = "X ";
        Assert.AreEqual(framesString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T04FirstStrikeAndSomeRegulars()
    {
        int[] rolls = {10, 5, 2};
        string framesString = "X 52";
        Assert.AreEqual(framesString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T05SecondFrameStrikeAndSomeRegulars()
    {
        int[] rolls = {1, 1, 10, 5, 2};
        string framesString = "11X 52";
        Assert.AreEqual(framesString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T06SpareHandling()
    {
        int[] rolls = {1, 9};
        string framesString = "1/";
        Assert.AreEqual(framesString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T07SpareHandlingAndSomeRegulars()
    {
        int[] rolls = {1, 9, 1, 2, 3, 7};
        string framesString = "1/123/";
        Assert.AreEqual(framesString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T08BonusFrameStrikes()
    {
        int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10};
        string framesString = "111111111111111111XX";
        Assert.AreEqual(framesString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T09StrikePrecededByZero()
    {
        int[] rolls = {1, 0, 10};
        string framesString = "10X ";
        Assert.AreEqual(framesString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }
    [Test]
    public void T10PerfectGame()
    {
        int[] rolls = {10,10,10,10,10,10,10,10,10,10,10,10};
        string framesString = "X X X X X X X X X XXX";
        Assert.AreEqual(framesString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }
}