using System;
using mergeandmatch.Controller;

namespace mergeandmatch
{
    class Program
    {
        static void Main(string[] args)
        {
            FileOperations fileOperations;

            Console.WriteLine("info: enter file path press enter");
            Console.Write("File Path:(Sample.txt)");
            var filePath = Console.ReadLine();
            
            //Initiate file by sending file url or choosing default
            fileOperations =(!string.IsNullOrEmpty(filePath)) ? 
                new FileOperations(filePath) 
                :new FileOperations();

            var fileStr = fileOperations.ReadFromFile();

            var match = new MatchAndMerge();
            match.ConvertToShortestString(fileStr);

            Console.WriteLine("\n**************RESULT*****************");
            Console.WriteLine(fileStr[0]);
            
            Console.ReadKey();
        }

    }
}