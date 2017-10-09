//using UnityEngine;
//using UnityEditor;
//using UnityEngine.TestTools;
//using NUnit.Framework;
//using System.Collections;
//using System.Collections.Generic;

//public class ActionMasterTest
//{
//	private ActionMaster.Action endTurnReset = ActionMaster.Action.EndTurnReset;
//	private ActionMaster.Action endTurnHold = ActionMaster.Action.EndTurnHold;
//	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
//	private ActionMaster.Action reset = ActionMaster.Action.Reset;
//	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
//	private ActionMaster.Action hold = ActionMaster.Action.Hold;

//	private List<int> pinFalls;

//	[SetUp]
//	public void Setup()
//	{
//		pinFalls = new List<int>();
//	}

//	[Test]
//	public void T01_OneStrikeReturnsEndTurn()
//	{
//		pinFalls.Add(10);
//		Assert.AreEqual(endTurnReset, ActionMaster.NextAction(pinFalls));
//	}

//	[Test]
//	public void T02_BowlInMiddleFrameReturnsTidy()
//	{
//		pinFalls.Add(3);
//		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
//	}

//	[Test]
//	public void T03_Bowl0Bowl0ReturnsEndTurnHold()
//	{
//		pinFalls.Add(0);
//		ActionMaster.NextAction(pinFalls);
//		pinFalls.Add(0);
//		Assert.AreEqual(endTurnHold, ActionMaster.NextAction(pinFalls));
//	}

//	[Test]
//	public void T04_Frame21ReturnsEndGame()
//	{
//		for (int i = 0; i < 20; i++)
//		{
//			pinFalls.Add(1);
//			ActionMaster.NextAction(pinFalls);
//		}
//		pinFalls.Add(4);
//		Assert.AreEqual(endGame, ActionMaster.NextAction(pinFalls));
//	}

//	[Test]
//	public void T05_Bowl5InFrame20ReturnsEndGameIfNotSpare()
//	{
//		for (int i = 0; i < 19; i++)
//		{
//			pinFalls.Add(5);
//			ActionMaster.NextAction(pinFalls);
//		}

//		pinFalls.Add(4);
//		Assert.AreEqual(endGame, ActionMaster.NextAction(pinFalls));
//	}

//	[Test]
//	public void T06_Bowl0Bowl1ReturnsEndTurnReset()
//	{
//		pinFalls.Add(0);
//		ActionMaster.NextAction(pinFalls);
//		pinFalls.Add(1);
//		Assert.AreEqual(endTurnReset, ActionMaster.NextAction(pinFalls));
//	}

//	[Test]
//	public void T07_Bowl0InMiddleFrameReturnsHold()
//	{
//		pinFalls.Add(0);
//		Assert.AreEqual(hold, ActionMaster.NextAction(pinFalls));
//	}

//	// Add test for STRIKE - X - Y in the last three frames
//	[Test]
//	public void T08_StrikeBowl5InFrame19and20ReturnsTidy()
//	{
//		for (int i = 0; i < 18; i++)
//		{
//			pinFalls.Add(1);
//			ActionMaster.NextAction(pinFalls);
//		}
//		pinFalls.Add(10);
//		Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
//		pinFalls.Add(5);
//		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
//	}
//	[Test]
//	public void T09_Bowl5InFrame20ReturnsResetIfSpare()
//	{
//		for (int i = 0; i < 19; i++)
//		{
//			pinFalls.Add(3);
//			ActionMaster.NextAction(pinFalls);
//		}

//		pinFalls.Add(7);
//		Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
//	}

//	[Test]
//	public void T10_Bowl0InFrame20AfterStrikeReturnsHold()
//	{
//		for (int i = 0; i < 18; i++)
//		{
//			pinFalls.Add(3);
//			ActionMaster.NextAction(pinFalls);
//		}

//		pinFalls.Add(10);
//		Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
//		pinFalls.Add(0);
//		Assert.AreEqual(hold, ActionMaster.NextAction(pinFalls));
//	}

//	[Test]
//	public void T11_DoubleStrikeInFrames19and20ReturnsReset()
//	{
//		for (int i = 0; i < 18; i++)
//		{
//			pinFalls.Add(3);
//			ActionMaster.NextAction(pinFalls);
//		}

//		pinFalls.Add(10);
//		Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
//		pinFalls.Add(10);
//		Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
//	}

//	[Test]
//	public void T12_Bowl0Bowl10ReturnsEndTurnReset()
//	{
//		pinFalls.Add(0);
//		Assert.AreEqual(hold, ActionMaster.NextAction(pinFalls));
//		pinFalls.Add(10);
//		Assert.AreEqual(endTurnReset, ActionMaster.NextAction(pinFalls));
//	}

//	[Test]
//	public void T13_TenthFrameTurkeyReturnsEndGame()
//	{
//		for (int i = 0; i < 18; i++)
//		{
//			pinFalls.Add(3);
//			ActionMaster.NextAction(pinFalls);
//		}

//		pinFalls.Add(10);
//		Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
//		pinFalls.Add(10);
//		Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
//		pinFalls.Add(10);
//		Assert.AreEqual(endGame, ActionMaster.NextAction(pinFalls));
//	}

//	// A UnityTest behaves like a coroutine in PlayMode
//	// and allows you to yield null to skip a frame in EditMode
//	[UnityTest]
//	public IEnumerator ScoreTestWithEnumeratorPasses()
//	{
//		// Use the Assert class to test conditions.
//		// yield to skip a frame
//		yield return null;
//	}
//}
