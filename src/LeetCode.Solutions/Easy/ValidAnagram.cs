namespace LeetCode.Solutions.Easy;

public static class ValidAnagram
{
    /*
        242. Valid Anagram
        Link: https://leetcode.com/problems/valid-anagram/description/
        
        Given two strings s and t, return true if t is an anagram of s, and false otherwise.
        An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
        
        Example 1:
       
           Input: s = "anagram", t = "nagaram"
           Output: true
           
        Example 2:
       
           Input: s = "rat", t = "car"
           Output: false
           
        Constraints:
       
           1 <= s.length, t.length <= 5 * 104
           s and t consist of lowercase English letters.
     
        Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?
    */

    public static bool BruteForce(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        Dictionary<char, int> sNrOfChars = new();
        Dictionary<char, int> tNrOfChars = new();

        for (int i = 0; i < s.Length; i++)
        {
            char sCurrentChar = s[i];
            char tCurrentChar = t[i];

            if (sNrOfChars.ContainsKey(sCurrentChar))
            {
                sNrOfChars[sCurrentChar]++;
            }
            else
            {
                sNrOfChars.Add(sCurrentChar, 1);
            }

            if (tNrOfChars.ContainsKey(tCurrentChar))
            {
                tNrOfChars[tCurrentChar]++;
            }
            else
            {
                tNrOfChars.Add(tCurrentChar, 1);
            }
        }

        foreach (var (sKey, sVal) in sNrOfChars)
        {
            if (!tNrOfChars.TryGetValue(sKey, out int tVal) || tVal != sVal)
            {
                return false;
            }
        }
        
        return true;
    }

    public static bool BySorting(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }
        
        char[] sArr = s.ToCharArray();
        char[] tArr = t.ToCharArray();
        
        Array.Sort(sArr);
        Array.Sort(tArr);

        return new string(sArr) == new string(tArr);
    }
    
    public static bool ByAsci(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }
            
        int[] sCounter = new int[26];
        int[] tCounter = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            sCounter[s[i] - 'a']++;
            tCounter[t[i] - 'a']++;
        }

        for (int i = 0; i < 26; i++)
        {
            if (sCounter[i] != tCounter[i])
            {
                return false;
            }
        }

        return true;
    }
}