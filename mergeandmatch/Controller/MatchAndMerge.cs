
using System.Collections.Generic;

namespace mergeandmatch.Controller
{
    class MatchAndMerge
    {
        public string ConvertToShortestString(List<string> fileData)
        {
            while (fileData.Count > 1)//loop until last string
            {
                int maxLength = 0;
                string mergeStr1 = fileData[0], mergeStr2 = fileData[1];

                foreach (var strI in fileData)
                {
                    foreach (var strJ in fileData)
                    {
                        if (strI == strJ) continue;
                        int overlapLength = LongestCommonSubstring(strI, strJ);
                        if (overlapLength > maxLength)//if longest overlap update merge data
                        {
                            maxLength = overlapLength;
                            mergeStr1 = strI;
                            mergeStr2 = strJ;
                        }
                    }
                }

                fileData.Remove(mergeStr1);//remove string
                fileData.Remove(mergeStr2);//remove string

                if (mergeStr2.Length == maxLength)
                    fileData.Add(mergeStr1);//string2 is contained string
                else
                    fileData.Add(MergeTwoStrings(mergeStr1, mergeStr2, maxLength));//merge two strings
            }
            return fileData[0];//returns final result
        }

        private static string MergeTwoStrings(string right, string left, int length)
        {
            left = left.Substring(length);
            return right + left;
        }

        private static int LongestCommonSubstring(string s1, string s2)//find the longest overlap match
        {
            int s1len = s1.Length, s2len = s2.Length, overlap = 0;

            for (int i = 0; i < s1.Length && overlap != s2len; i++)
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
