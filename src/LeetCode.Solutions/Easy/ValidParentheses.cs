namespace LeetCode.Solutions.Easy;

public static class ValidParentheses
{
    /*
        20. Valid Parentheses
        Link: https://leetcode.com/problems/valid-parentheses/description/
        
        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
       
        An input string is valid if:
       
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
        
       
        Example 1:
       
           Input: s = "()"
           Output: true
           
        Example 2:
       
           Input: s = "()[]{}"
           Output: true
           
        Example 3:
       
           Input: s = "(]"
           Output: false
        
        Constraints:
       
           1 <= s.length <= 104
           s consists of parentheses only '()[]{}'.
    */

    public static bool Solution1(string s)
    {
        Dictionary<char, char> parentheses = new Dictionary<char, char>()
        {
            {')', '('},
            {'}', '{'},
            {']', '['},
        };
        Stack<char> prev = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            char current = s[i];
            if (parentheses.TryGetValue(current, out char val))
            {
                
                if (prev.Count == 0 || prev.Pop() != val)
                {
                    return false;
                }
            }
            else
            {
                prev.Push(current);
            }
        }

        return prev.Count == 0;
    }

    public static bool Solution2(string s)
    {
        Dictionary<char, char> parentheses = new Dictionary<char, char>()
        {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'},
        };
        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            char current = s[i];
            if (parentheses.ContainsKey(current))
            {
                stack.Push(current);
            }
            else
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                char prev = stack.Pop();
                if (parentheses[prev] != current)
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}