using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Solution_Medium
    {
        #region attempted
        // TODO medium problems
        /// <summary>
        /// 5. Longest Palindromic Substring
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            // 1 <= s.length <= 1000
            // s consist of only digits and English letters(lower-case and / or upper -case).

            // Given a string s, return the longest palindromic substring in s.
            int len = s.Length;
            if (len == 1)
                return s;

            int idx, even_check, odd_check;
            bool even = false;
            bool odd = false;
            string temp = s.Substring(0, 2);
            string calculated = temp;
            for (idx = 2; idx < len; idx++)
            {
                if (s[idx].Equals(temp[idx - 2]))
                {
                    // odd palindrome
                }
                else if (even || s[idx].Equals(temp[idx - 1]))
                {
                    // even palindrome
                    if (!even)
                    {
                        // add s[idx] after temp's tail
                        temp += s[idx];
                        // check bool so then give a chance check again
                        even = true;
                    }
                    else
                    {
                        if (s[idx].Equals(temp[idx - (temp.Length)]))
                        {
                            // fit
                            temp += s[idx];
                        }
                        else
                        {
                            // not fit

                            even = false;
                        }
                    }

                }
                else
                {
                    temp += s[idx];
                }

            }

            return "";
        }
        #endregion
        #region solved
        //



        /// <summary>
        /// 3. Longest Substring Without Repeating Characters
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            // 0 <= s.length <= 5 * 10^4
            // s consists of English letters, digits, symbols and spaces.

            // Given a string s, find the length of the longest substring without repeating characters.
            int len = s.Length;
            if (len == 0)
                return 0;

            int ret = -1;
            List<char> list = new List<char>();
            int idx;
            for (idx = 0; idx < len; idx++)
            {
                char c = s[idx];
                if (list.Contains(c))
                {
                    s = s.Substring(s.IndexOf(c) + 1);
                    len = s.Length;
                    if (ret < list.Count)
                        ret = list.Count;
                    list.Clear();

                    idx = 0;
                    c = s[idx];
                }
                list.Add(c);
            }
            if (ret < list.Count)
                ret = list.Count;
            return ret;
        }

        /// <summary>
        /// 2. Add Two Numbers
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            /*
             You are given two non-empty linked lists representing two non-negative integers.
             The digits are stored in reverse order, and each of their nodes contains a single digit.
             Add the two numbers and return the sum as a linked list.
             You may assume the two numbers do not contain any leading zero, except the number 0 itself.
            */
            /*
             당신은 두 개의 비어있지 않고 음수가 아닌 정수의 linked list가 주어집니다.
             각 자릿수는 역순으로 저장되어 있고, 각 노드는 한자릿수의 숫자(0-9)가 입력됐다.
             주어진 두 수를 더하고, 같은 방식으로 반환해라(역순, 하나의 노드에 한자릿수 저장)
             각 숫자는 0이 아닌 이상 0으로 시작하지 않는다.
             */

            // The number of nodes in each linked list is in the range[1, 100].
            // 0 <= Node.val <= 9
            // It is guaranteed that the list represents a number that does not have leading zeros.
            if (l1 == null && l2 == null)
                return null;
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            return AddTwoList(l1, l2);
        }
        private ListNode AddTwoList(ListNode l1, ListNode l2, bool over9 = false)
        {
            if (l1 == null && l2 == null)
                if (over9)
                    return new ListNode(1);
                else
                    return null;
            if (l1 == null)
                return AddList(l2, over9);
            if (l2 == null)
                return AddList(l1, over9);

            bool next = false;
            int sum = l1.val + l2.val;
            if (over9) sum++;
            if (sum > 9)
            {
                next = true;
                sum -= 10;
            }
            return new ListNode(sum, AddTwoList(l1?.next, l2?.next, next));
        }
        private ListNode AddList(ListNode l1, bool over9 = false)
        {
            if (l1 == null)
                if (over9)
                    return new ListNode(1);
                else
                    return null;

            bool next = false;
            int sum = l1.val;
            if (over9) sum++;
            if (sum > 9)
            {
                next = true;
                sum -= 10;
            }
            return new ListNode(sum, AddList(l1?.next, next));
        }
        #endregion
        #region extra
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        #endregion
    }
}
