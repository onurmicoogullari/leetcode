using System.Text;

namespace LeetCode.Solutions.Easy;

public static class LongestCommonPrefix
{
    /*
       14. Longest Common Prefix
       Link: https://leetcode.com/problems/longest-common-prefix/description/
       
       Write a function to find the longest common prefix string amongst an array of strings.
       If there is no common prefix, return an empty string "".
       
       Example 1:
       
           Input: strs = ["flower","flow","flight"]
           Output: "fl"
           
       Example 2:
       
           Input: strs = ["dog","racecar","car"]
           Output: ""
           Explanation: There is no common prefix among the input strings.
        
       Constraints:
       
           1 <= strs.length <= 200
           0 <= strs[i].length <= 200
           strs[i] consists of only lowercase English letters. 
    */

    public static string BruteForce(string[] strs)
    {
        if (strs.Length == 1)
        {
            return strs[0];
        }

        StringBuilder strBuilder = new StringBuilder();
        string firstStr = strs[0];
        
        // Iterate through every character in the first string in strs
        for (int i = 0; i < firstStr.Length; i++)
        {
            char currentChar = firstStr[i];

            // Start comparing each character to the ones in the same position in other strings in strs
            for (int j = 1; j < strs.Length; j++)
            {
                string compareToStr = strs[j];
                if (i <= compareToStr.Length - 1 )
                {
                    char compareToChar = compareToStr[i];
                    if (currentChar != compareToChar)
                    {
                        return strBuilder.ToString();
                    }
                }
                else
                {
                    return strBuilder.ToString();
                }
            }

            strBuilder.Append(currentChar);
        }
        
        return strBuilder.ToString();
    }

    public static string Efficient(string[] strs)
    {
        if (strs.Length == 1)
        {
            return strs[0];
        }
        
        string prefix = strs[0];

        for (int i = 1; i < strs.Length; i++)
        {
            string current = strs[i];
            while (!current.StartsWith(prefix) && prefix.Length > 0)
            {
                prefix = prefix.Substring(0, prefix.Length - 1);
            }
        }

        return prefix;
    }
}