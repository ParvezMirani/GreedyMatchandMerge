
using System.Collections.Generic;

namespace mergeandmatch.Controller
{
    class MatchAndMerge
    {
        public string ConvertToShortestString(List<string> fileData)
        {
            while (fileData.Count > 1)//loop until last string
            {
                int maxOverlapLength = 0;
                string mergeStr1 = fileData[0], mergeStr2 = fileData[1];

                foreach (var strI in fileData)
                {
                    foreach (var strJ in fileData)
                    {
                        if (strI == strJ) continue;//skip the self comparision

                        int newOverlapLength = FindLongestCommonSubstring(strI, strJ);//find the substring perfect overlaps

                        if (newOverlapLength > maxOverlapLength)//if new lenght is longest then update data
                        {
                            maxOverlapLength = newOverlapLength;
                            mergeStr1 = strI;
                            mergeStr2 = strJ;
                        }
                    }
                }

                fileData.Remove(mergeStr1);//remove string
                fileData.Remove(mergeStr2);//remove string

                if (mergeStr2.Length == maxOverlapLength || mergeStr1==mergeStr2)
                    fileData.Add(mergeStr1);//string2 is contained string or both strings are equal
                else
                    fileData.Add(MergeTwoStrings(mergeStr1, mergeStr2, maxOverlapLength));//merge two strings
            }
            return fileData[0];//returns final result
        }

        /// <summary>
        /// merges two string and deletes overlaps between them
        /// </summary>
        /// <param name="right">string 1</param>
        /// <param name="left">string 2</param>
        /// <param name="overlapLength">length of overlap</param>
        /// <returns>Merged string</returns>
        private static string MergeTwoStrings(string right, string left, int overlapLength)
        {
            left = left.Substring(overlapLength);//remove the substring 
            return right + left;
        }
        /// <summary>
        /// find the longest perfect overlap 
        /// </summary>
        /// <param name="s1">String 1</param>
        /// <param name="s2">String 1</param>
        /// <returns>lenght of overlap</returns>
        private static int FindLongestCommonSubstring(string s1, string s2)
        {
            int s1len = s1.Length, s2len = s2.Length, overlap = 0;

            for (int i = 0; i < s1.Length && overlap != s2len; i++)//loop through string characters
            {
                string s1Pref = s1.Substring(i, 1), s2Pref = s2.Substring(overlap, 1);

                if (s1Pref.Equals(s2Pref))//found match
                    overlap++;
                else if (overlap > 0 && !s1Pref.Equals(s2Pref))//not contained
                    overlap = 0;
            }

            return overlap;
        }
    }

}
