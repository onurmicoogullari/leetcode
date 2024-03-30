using System.Runtime.InteropServices.JavaScript;
using System.Text;

namespace LeetCode.Solutions.Medium;
public static class LargestPalindromicNumber
{ 
    /*
        2384. Largest Palindromic Number
        Link: https://leetcode.com/problems/largest-palindromic-number/description/

        You are given a string num consisting of digits only.

        Return the largest palindromic integer (in the form of a string) that can be formed using digits taken from num. It should not contain leading zeroes.

        Notes:

            You do not need to use all the digits of num, but you must use at least one digit.
            The digits can be reordered.


        Example 1:

            Input: num = "444947137"
            Output: "7449447"
            Explanation:

                Use the digits "4449477" from "444947137" to form the palindromic integer "7449447".
                It can be shown that "7449447" is the largest palindromic integer that can be formed.

        Example 2:

            Input: num = "00009"
            Output: "9"
            Explanation:

                It can be shown that "9" is the largest palindromic integer that can be formed.
                Note that the integer returned should not contain leading zeroes.


        Constraints:

            1 <= num.length <= 105
            num consists of digits.
    */
    
    /*
        Strategy:
        1. Count the number of occurrences for each digit
        2. Take the largest digit with an even number of occurrences and add half of them to the left segment of the palindromic number
        3. Take the largest digit with an odd number of occurrences and use it as the center of the palindormic number
        4. Mirror the values of the left segment to the right segment (ex. left: 431, right: 134)
        5. Compose the left, center (if any) and right parts to form the largest palindromic number
    */

    public static string BruteForce(string num)
    {   
        Dictionary<int, int> numsFrequency = new Dictionary<int, int>();
        List<string> leftSegment = new List<string>();
        int? center = null;
        StringBuilder result = new StringBuilder();
        
        for (int i = 0; i < num.Length; i++)
        {
            int number = int.Parse(num[i].ToString());

            if (numsFrequency.ContainsKey(number))
            {
                numsFrequency[number]++;
            }
            else
            {
                numsFrequency.Add(number, 1);
            }
        }

        numsFrequency = numsFrequency.OrderByDescending(n => n.Key).ToDictionary();

        if (numsFrequency.Count == 1 && numsFrequency.ContainsKey(0))
        {
            return numsFrequency.FirstOrDefault().Key.ToString();
        }

        foreach (var (number, frequency) in numsFrequency)
        {
            int occurrences = frequency;
            
            if (occurrences > 1)
            {
                if (occurrences % 2 != 0)
                {
                    occurrences = occurrences - 1;
                    if (!center.HasValue || number > center)
                    {
                        center = number;
                    }
                }
                
                if (number == 0 && leftSegment.Count == 0)
                {
                    continue;
                }
                
                int nrOfTimesInLeftSegment = occurrences / 2;
                
                while (nrOfTimesInLeftSegment > 0)
                {
                    leftSegment.Add(number.ToString());
                    nrOfTimesInLeftSegment--;
                }
            }
            else if (!center.HasValue || number > center)
            {
                center = number;
            }
        }

        foreach (var number in leftSegment)
        {
            result.Append(number);
        }

        if (center.HasValue)
        {
            result.Append(center);
        }

        foreach (var number in leftSegment.ToArray().Reverse())
        {
            result.Append(number);
        }

        return result.ToString();
    }

    public static string Efficient(string num)
    {
        // Each position in the array represents a possible digit (0-9)
        int[] numsFrequency = new int[10];
        
        StringBuilder leftSegment = new StringBuilder();
        StringBuilder rightSegment = new StringBuilder();
        int center = -1;
        
        foreach (var digit in num)
        {
            // Take the digit that is represented as a char and subtract 0 to convert to an integer
            numsFrequency[digit - '0']++;
        }
        
        // Start with the biggest possible digit, which is 9, and go backwards
        for (int i = 9; i >= 0; i--)
        {
            // If 0 is the current digit, and the left segment is empty, then this is no trailing zero 
            if (i == 0 && leftSegment.Length == 0)
            {
                return center == -1
                    ? "0"
                    : center.ToString();
            }
            
            // Take the number of occurrences of the current digit and divide it by two to know how many to add to the left segment
            for (int j = 0; j < numsFrequency[i] / 2; j++)
            {
                leftSegment.Append(i);
            }

            // Assign the digit with the highest value that is odd as the center of the palindromic number
            if (numsFrequency[i] % 2 == 1 && center == -1)
            {
                center = i;
            }
        }

        // Mirror the left segment to the right segment
        for (int i = leftSegment.Length - 1; i >= 0; i--)
        {
            rightSegment.Append(leftSegment[i]);
        }

        // If we don't have a digit for the center of the palindromic number, just compose the left and right segments
        if (center == -1)
        {
            return leftSegment.ToString() + rightSegment.ToString();
        }

        // Compose left, center and right segments
        return leftSegment.ToString() + center.ToString() + rightSegment.ToString();
    }
}