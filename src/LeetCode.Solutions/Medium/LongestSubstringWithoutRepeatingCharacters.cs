namespace LeetCode.Solutions.Medium;

public static class LongestSubstringWithoutRepeatingCharacters
{
    /*
        3. Longest Substring Without Repeating Characters
        Link: https://leetcode.com/problems/longest-substring-without-repeating-characters/description/

        Given a string s, find the length of the longest 
        substring
        without repeating characters.

        

        Example 1:

        Input: s = "abcabcbb"
        Output: 3
        Explanation: The answer is "abc", with the length of 3.
        Example 2:

        Input: s = "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.
        Example 3:

        Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
        

        Constraints:

        0 <= s.length <= 5 * 104
        s consists of English letters, digits, symbols and spaces.

    */

    public static int BruteForceSolution(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        int result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            List<char> uniqueChars = [s[i]];
            for (int j = i + 1; j < s.Length; j++)
            {
                if (!uniqueChars.Contains(s[j]))
                {
                    uniqueChars.Add(s[j]);
                }
                else
                {
                    break;
                }
            }
            result = Math.Max(result, uniqueChars.Count());
        }

        return result;
    }

    public static int SlidingWindowSolution(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        Dictionary<char, int> nums = new();
        int left = 0;
        int right = 0;
        int result = 0;

        while (right < s.Length)
        {
            char r = s[right];
            if (nums.ContainsKey(r))
            {
                nums[r]++;
            }
            else
            {
                nums.Add(r, 1);
            }

            while (nums[r] > 1)
            {
                char l = s[left];
                nums[l]--;
                left++;
            }

            result = Math.Max(result, right - left + 1);
            right++;
        }


        return result;
    }

    public static int FastestSolution(string s)
    {
        Queue<char> queue = new();
        int result = 0;

        foreach (char character in s)
        {
            while (queue.Contains(character))
            {
                queue.Dequeue();
            }

            queue.Enqueue(character);
            result = Math.Max(result, queue.Count);
        }

        return result;
    }
}