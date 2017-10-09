using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScoreMasterTest
{
	[Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl23() {
        int[] rolls = { 2, 3 };
        int[] totals = { 5 };
        Assert.AreEqual(totals.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    //[UnityTest]
    //public IEnumerator ScoreMasterTestWithEnumeratorPasses()
    //{
    //	// Use the Assert class to test conditions.
    //	// yield to skip a frame
    //	yield return null;
    //}
}
