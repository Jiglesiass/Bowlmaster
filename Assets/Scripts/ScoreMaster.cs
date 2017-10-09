using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster
{

    private struct Strike {
        public int bonusLeft;
        public int totalScore;
    }
    
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

        List<Strike> strikes = new List<Strike>();
        int savedRoll = -1;
        bool sparePending = false;


        for (int roll = 0; roll < rolls.Count; roll++) {

            if (sparePending) {
                frameList.Add(savedRoll + rolls[roll]);
                savedRoll = rolls[roll];
                sparePending = false;
                continue;
            }

            if (strikes.Count > 0) {

                strikes.ForEach(delegate (Strike strike) {
                    if (strike.bonusLeft > 1) {
                        strike.totalScore += rolls[roll];
                        strike.bonusLeft--;
                    } else {
                        frameList.Add(strike.totalScore);
                        strikes.Remove(strike);
                    }
                });
                continue;
            }

            if (roll % 2 == 0) {

                if (rolls[roll] == 10) { // strike
                    strikes.Add(new Strike { bonusLeft = 2, totalScore = 10 });
                } else {
                    savedRoll = rolls[roll];
                }
            } else {
                if (rolls[roll - 1] + rolls[roll] >= 10) { // spare
                    savedRoll = 10;
                    sparePending = true;
                } else {
                    frameList.Add(savedRoll + rolls[roll]);
                    savedRoll = -1;
                }
            }
        }

        // displaying frame list for debugging purposes
        frameList.ForEach(delegate (int roll) {
            Debug.Log(roll);
        });
        Debug.Log("---------------------------------------------");

		return frameList;
	}
}
