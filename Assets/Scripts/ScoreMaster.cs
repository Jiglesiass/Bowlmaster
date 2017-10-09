using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
    // Returns a list of cumulative scores like a normal score card
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

    // Returns a list of individual frame scores, NOT cumulative
    public static List<int> ScoreFrames(List<int> rolls)
	{
		List<int> frameList = new List<int>();

        bool firstBowl = true;

        for (int i = 0; i < rolls.Count; i++) {

            bool isStrike = (firstBowl && rolls[i] >= 10);
            if (isStrike) {
                if (rolls.Count > i + 2) {
                    frameList.Add(rolls[i] + rolls[i + 1] + rolls[i + 2]);
                    firstBowl = true;
                } else return frameList;
            }

            if (firstBowl) {
                firstBowl = false;
            } else {
                frameList.Add(rolls[i-1] + rolls[i]);
                firstBowl = true;
            }
        }
        
		return frameList;
	}
}
