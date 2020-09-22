using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.amazon_online_assessment_problems
{
    /*
     * 
     * 
     * https://aonecode.com/amazon-online-assessment-questions#lsv
     * https://leetcode.com/discuss/interview-question/233724/amazon-oa-2019-longest-string-made-up-of-only-vowels
        Given a string of lower charasters, remove at most two substrings of any length from the given string such that the remaining string contains vowels('a','e','i','o','u') only.

        Your aim is to maximise the length of the remaining string. Output the length of remaining string after removal of at most two substrings.

        NOTE: The answer may be 0, i.e. removing the entire string.
        Example1:
        Input:
        earthproblem
        Output:
        2
        Example2:
        Input:
        letsgosomewhere
        Output:
        3     
     * 
     */
    public class longest_string_made_up_of_only_vowels
    {
        /*
         * Logic : Count all substring in given string with its length
         * 
         * Case 1 : There is no vovel at beginning or end of string. Answer is the longest vowel substring : XXXX + vowel_substring + XXXX
         * 
         * Case 2 : There is vowel at either begining or end of string. Answer is case1 + vowel substring at begining or end
         * 
         * Case 3: Tehre is vowel at both beginning or end of string. start + end + max (other substring with vowel)
         * 
         */
    }
}
