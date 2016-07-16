using System;
using System.Collections.Generic;



namespace Calculator
{
    public class HCalculator
    {
        private List<double> hDifferentials = new List<double>();
        private int totalRounds { get; }
        public int getTotalRounds() {
            return totalRounds;
        }
        public HCalculator(List<double> list) {
            hDifferentials = list;
            totalRounds = hDifferentials.Count;
        }

        private double computeIndex(List<double> diffList, int upTo) {
            double runningTotal = 0;
            double average = 0;

            for (int i = 0; i < upTo; i++) {
                runningTotal = runningTotal + diffList[i];
            }
            average = (runningTotal / upTo) * .96;
            double truncated = Math.Truncate(average * 10) / 10;

            return truncated;
        }

        public double getIndex(int upTo) {
            return computeIndex(hDifferentials, upTo);
        }




    }
}
