namespace LeetCode.Solutions.Easy;

public static class RomanToInteger
{
    /*
       13. Roman to Integer
       Link: https://leetcode.com/problems/roman-to-integer/description/
       Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
       
       Symbol       Value
       I             1
       V             5
       X             10
       L             50
       C             100
       D             500
       M             1000
       For example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.
       
       Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
       
       I can be placed before V (5) and X (10) to make 4 and 9. 
       X can be placed before L (50) and C (100) to make 40 and 90. 
       C can be placed before D (500) and M (1000) to make 400 and 900.
       Given a roman numeral, convert it to an integer.
       
        
       
       Example 1:
       
           Input: s = "III"
           Output: 3
           Explanation: III = 3.
           
       Example 2:
       
           Input: s = "LVIII"
           Output: 58
           Explanation: L = 50, V= 5, III = 3.
           
       Example 3:
       
           Input: s = "MCMXCIV"
           Output: 1994
           Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
        
       
       Constraints:
       
           1 <= s.length <= 15
           s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
           It is guaranteed that s is a valid roman numeral in the range [1, 3999]. 
    */
    
    public static int BruteForce(string s)
    {
        Dictionary<char, int> nums = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000},
        };
        
        int result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char current = s[i];
            if (i + 1 <= s.Length - 1)
            {
                char next = s[i + 1];
                switch (current)
                {
                    case 'I':
                        if (next == 'V' || next == 'X')
                        {
                            result += nums[next] - nums[current];
                            // Increment 1 manually, and the loop will also increment 1. Since we handled the value of 2 elements.
                            i++;
                        }
                        else
                        {
                            result += nums[current];
                        }
                        break;
                    case 'X':
                        if (next == 'L' || next == 'C')
                        {
                            result += nums[next] - nums[current];
                            // Increment 1 manually, and the loop will also increment 1. Since we handled the value of 2 elements.
                            i++;
                        }
                        else
                        {
                            result += nums[current];
                        }
                        break;
                    case 'C':
                        if (next == 'D' || next == 'M')
                        {
                            result += nums[next] - nums[current];
                            // Increment 1 manually, and the loop will also increment 1. Since we handled the value of 2 elements.
                            i++;
                        }
                        else
                        {
                            result += nums[current];
                        }
                        break;
                    default:
                        result += nums[current];
                        break;
                }
            }
            else
            {
                result += nums[current];
            }
        }

        return result;
    }

    public static int Compact(string s)
    {
        Dictionary<string, int> nums = new Dictionary<string, int>()
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000},
            {"IV", 4},
            {"IX", 9},
            {"XL", 40},
            {"XC", 90},
            {"CD", 400},
            {"CM", 900},
        };
        
        int result = 0;
        int i = 0;

        while (i < s.Length)
        {
            if (i + 1 <= s.Length - 1)
            {
                string key = s.Substring(i, 2);
                if (nums.TryGetValue(key, out int val))
                {
                    result += val;
                    i += 2;
                    continue;
                }
            }

            result += nums[s[i].ToString()];
            i++;
        }

        return result;
    }

    public static int Efficient(string s)
    {
        Dictionary<char, int> nums = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        int total = 0;
        int prevValue = 0;

        foreach (char c in s)
        {
            int value = nums[c];
            if (value > prevValue)
            {
                total += value - (2 * prevValue); // Subtract the value of previous character twice
            }
            else
            {
                total += value;
            }
            prevValue = value;
        }

        return total;
    }
}