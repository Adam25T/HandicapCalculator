using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ScoreFileReader
{
    public class ScoreReader
    {
        private List<double> differentials = new List<double>();

        public List<double> getDifferentials() {
            differentials.Sort();
            return differentials;
        }

        private double computeHandicapDiff(double score, double rating, double slope) {
            return ((score - rating) * 113) / slope;
        }




        public ScoreReader() {
            Console.WriteLine("Enter file path for scores: ");
            string filePath = Console.ReadLine();
            string dafilePath = "C:\\Users\\Adam\\Documents\\GitHub\\HandicapCalculator\\scores_text.txt";
            try {
                using (StreamReader sr = new StreamReader(dafilePath)) {
                    string valueLine;
                    double score;
                    double usgaRating;
                    double courseSlope;

                    while ((valueLine = sr.ReadLine()) != null) {
                        //read the line in
                        String[] stringValues = valueLine.Split(' ');
                        //convert to doubles
                        score = Convert.ToDouble(stringValues[0]);
                        usgaRating = Convert.ToDouble(stringValues[1]);
                        courseSlope = Convert.ToDouble(stringValues[2]);
                        //calculate differential and store in list
                        differentials.Add(Math.Round(computeHandicapDiff(score, usgaRating, courseSlope), 1));

                    }
                }
            }
            catch (FileNotFoundException) {
                Console.WriteLine("Score reader could not find the file you specified...");
            }
            
        }
    }
}
