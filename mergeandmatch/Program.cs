using System;
using mergeandmatch.Controller;

namespace mergeandmatch
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialise 
            FileOperations fileOperations;
            var match = new MatchAndMerge();

            //get user file selection
            Console.WriteLine("info: enter file path or press enter");
            Console.Write("File Path:(Sample.txt)");
            var filePath = Console.ReadLine();
            
            //initalize with file path
            fileOperations =(!string.IsNullOrEmpty(filePath)) ? 
                new FileOperations(filePath) 
                :new FileOperations();
            
            //Read selected user file
            var fileStr = fileOperations.ReadFromFile();//returns List<string>

            //Match and merge to sortest string
            match.ConvertToShortestString(fileStr);//converts all fileStrings and returns with only one result

            //print result
            Console.WriteLine("\n**************RESULT*****************");
            Console.WriteLine(fileStr[0]);
            
            Console.ReadKey();
        }

    }
}