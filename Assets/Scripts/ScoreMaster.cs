using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster
{

    
	public static List<int> ScoreCumulative (List<int> rolls)
	{
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls)) {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
	}

    public static List<int> ScoreFrames(List<int> rolls)
	{
		List<int> frameList = new List<int>();

		foreach (int roll in rolls)
		{
			
		}

		return frameList;
	}

}
