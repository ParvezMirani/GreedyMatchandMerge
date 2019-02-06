using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace mergeandmatch.Controller
{
    class FileOperations
    {
        private readonly string fileUrl;

        public FileOperations()//initialize with default file string
        {
            fileUrl = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\..\Sample.txt");
        }

        public FileOperations(string fileUrl)//initialize with user selected file
        {
            this.fileUrl = fileUrl;
        }

        public List<string> ReadFromFile()
        {
            var fileData = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileUrl);

                //Read the first line of text
                fileData = sr.ReadToEnd();

                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPS!! Something Went Wrong:\n "+e);
            }

            //convert string into string list by new line
            List<string> result = fileData.Split(new[] { Environment.NewLine },StringSplitOptions.None).ToList();
            
            return result;
        }
    }
}
