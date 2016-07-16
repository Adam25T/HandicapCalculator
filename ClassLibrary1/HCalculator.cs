using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class HCalculator
    {
        private List<double> hDifferentials = new List<double>();
        
        public HCalculator(List<double> list) {
            hDifferentials = list;
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
