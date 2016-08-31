using System;

namespace Assignment.Score
{
    class ScoreReturn
    {
        public ScoreReturn(int lScore, int lTotal)
        {
            score = lScore * 10;
            total = lTotal * 10;
        }
        public int score;
        public int total;
    }

    class Score
    {
        public static Classes.SystemObjects.Other.ScoreItem ovenTimerUsed = new Classes.SystemObjects.Other.ScoreItem();
        public static Classes.SystemObjects.Other.ScoreItem ovenTimerRightTemperature = new Classes.SystemObjects.Other.ScoreItem();
        public static Classes.SystemObjects.Other.ScoreItem ovenRightTemperature = new Classes.SystemObjects.Other.ScoreItem();
        public static Classes.SystemObjects.Other.ScoreItem caketinButtered = new Classes.SystemObjects.Other.ScoreItem();

        public static ScoreReturn getScore()
        {
            int score = 0;
            int totalScore = 0;

            if (ovenTimerUsed.correct) score++;
            totalScore++;
            if (ovenTimerRightTemperature.correct) score++;
            totalScore++;
            if (ovenRightTemperature.correct) score++;
            totalScore++;
            if (caketinButtered.correct) score++;
            totalScore++;

            return new ScoreReturn(score, totalScore);
        }
    }
}
