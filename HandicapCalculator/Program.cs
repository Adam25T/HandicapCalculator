using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{

    class Program
    {
       public double computeHandicapDiff(double score, double rating, double slope)
        {
            return ((score - rating) * 113) / slope;
        }

        public double computeIndex(List<double> diffList, int upTo)
        {
            double runningTotal = 0;
            double average = 0;

            for (int i = 0; i < upTo; i++)
            {
                runningTotal = runningTotal + diffList[i];
            }
            average = (runningTotal / upTo) * .96;
            double truncated = Math.Truncate(average * 10) / 10;

            return truncated;
        }

        static void Main(string[] args)
        {
            List<double> differentials = new List<double>();
            Program p = new Program();


            Console.WriteLine("Enter file path for scores: ");
            string filePath = Console.ReadLine();
            string dafilePath = "C:\\Users\\Adam\\Documents\\scores_text.txt";
            try
            {
                using (StreamReader sr = new StreamReader(dafilePath))
                {
                    string valueLine;
                    double score;
                    double usgaRating;
                    double courseSlope;

                    while ((valueLine = sr.ReadLine()) != null)
                    {
                        //read the line in
                        String[] stringValues = valueLine.Split(' ');
                        //convert to doubles
                        score = Convert.ToDouble(stringValues[0]);
                        usgaRating = Convert.ToDouble(stringValues[1]);
                        courseSlope = Convert.ToDouble(stringValues[2]);
                        //calculate differential and store in list
                        differentials.Add(Math.Round(p.computeHandicapDiff(score, usgaRating, courseSlope), 1));

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Went Wrong");
            }

            //sort list from lowest to highest
            differentials.Sort();
            int number = differentials.Count();
            double handicapindex = 0;
            if (number < 5)
                Console.WriteLine("minimum number of rounds to get handicap index: {0}", 5 - number);
            if (number == 5 || number == 6)
                handicapindex = p.computeIndex(differentials, 1);
            if (number == 7 || number == 8)
                handicapindex = p.computeIndex(differentials, 2);
            if (number == 9 || number == 10)
                handicapindex = p.computeIndex(differentials, 3);
            if (number == 11 || number == 12)
                handicapindex = p.computeIndex(differentials, 4);
            if (number == 13 || number == 14)
                handicapindex = p.computeIndex(differentials, 5);
            if (number == 15 || number == 16)
                handicapindex = p.computeIndex(differentials, 6);
            if (number == 17)
                handicapindex = p.computeIndex(differentials, 7);
            if (number == 18)
                handicapindex = p.computeIndex(differentials, 8);
            if (number == 19)
                handicapindex = p.computeIndex(differentials, 9);
            if (number >= 20)
                handicapindex = p.computeIndex(differentials, 10);
            Console.WriteLine("Based on your {0} rounds, your USGA handicap index is: {1}", differentials.Count(), handicapindex);


            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
