using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using ScoreFileReader;

namespace System.IO
{
    class program { 
        static void Main(string[] args)
        {
            ScoreReader reader = new ScoreReader();
            HCalculator p = new HCalculator(reader.getDifferentials());
            //sort list from lowest to highest
            
            int number = reader.getDifferentials().Count();
            double handicapindex = 0;
            if (number < 5)
                Console.WriteLine("minimum number of rounds to get handicap index: {0}", 5 - number);
            if (number == 5 || number == 6)
                handicapindex = p.getIndex(1);
            if (number == 7 || number == 8)
                handicapindex = p.getIndex(2);
            if (number == 9 || number == 10)
                handicapindex = p.getIndex(3);
            if (number == 11 || number == 12)
                handicapindex = p.getIndex(4);
            if (number == 13 || number == 14)
                handicapindex = p.getIndex(5);
            if (number == 15 || number == 16)
                handicapindex = p.getIndex(6);
            if (number == 17)
                handicapindex = p.getIndex(7);
            if (number == 18)
                handicapindex = p.getIndex(8);
            if (number == 19)
                handicapindex = p.getIndex(9);
            if (number >= 20)
                handicapindex = p.getIndex(10);
            Console.WriteLine("Based on your {0} rounds, your USGA handicap index is: {1}", differentials.Count(), handicapindex);


            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
}