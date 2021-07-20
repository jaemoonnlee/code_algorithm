using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Solution_Easy
    {
        #region attempted
        // TODO easy problems

        #endregion
        #region solved
        // add here

        /// <summary>
        /// 108. Convert Sorted Array to Binary Search Tree
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            int len = nums.Length;
            if (len == 1)
                return new TreeNode(nums[0]);
            if (len == 2)
                return new TreeNode(nums[1], new TreeNode(nums[0]));

            return MakeTree(nums, 0, len - 1);
        }
        private TreeNode MakeTree(int[] nums, int start, int end)
        {
            if (end < start)
                return null;
            //int mid = end + ((start - end) / 2);
            int mid = (end - start + 1) / 2;
            int[] leftArr = new int[mid];
            int[] rightArr = new int[end - mid];
            for (int i = 0; i < mid; i++)
                leftArr[i] = nums[i];
            for (int i = 0; i < end - mid; i++)
                rightArr[i] = nums[i + mid + 1];

            TreeNode temp = new TreeNode(nums[mid]);
            //temp.left = MakeTree(nums, start, mid - 1);
            //temp.right = MakeTree(nums, mid + 1, end);
            temp.left = MakeTree(leftArr, 0, leftArr.Length - 1);
            temp.right = MakeTree(rightArr, 0, rightArr.Length - 1);
            return temp;
        }

        /// <summary>
        /// 104. Maximum Depth of Binary Tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            // The number of nodes in the tree is in the range [0, 10^4].
            // -100 <= Node.val <= 100

            // Given the root of a binary tree, return its maximum depth.
            // A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
            return (root == null) ? 0 : FindLastDepth(root, 1); ;
        }
        private int FindLastDepth(TreeNode root, int level)
        {
            if (root == null)
                return level - 1;
            else
                return Math.Max(FindLastDepth(root?.left, level + 1), FindLastDepth(root?.right, level + 1));
        }

        /// <summary>
        /// 101. Symmetric Tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            return IsMirror(root?.left, root?.right);
        }
        private bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
                return left?.val == right?.val;

            if (left.val != right.val)
                return false;

            return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
        }

        /// <summary>
        /// 100. Same Tree
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;

            if (p.val != q.val)
                return false;
            return (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));
        }

        /// <summary>
        /// 88. Merge Sorted Array
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // nums1.length == m + n
            // nums2.length == n
            // 0 <= m, n <= 200
            // 1 <= m + n <= 200
            // - 10^9 <= nums1[i], nums2[i] <= 10^9

            // Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
            // The number of elements initialized in nums1 and nums2 are m and n respectively.
            // You may assume that nums1 has a size equal to m + n such that it has enough space to hold additional elements from nums2.

            // edit nums1
            for (int i = 0; i < n; i++)
                nums1[m + i] = nums2[i];
            List<int> temp = nums1.ToList<int>();
            temp.Sort();
            int idx = 0;
            foreach (var item in temp.ToArray())
                nums1[idx++] = item;
        }

        /// <summary>
        /// 83. Remove Duplicates from Sorted List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            // Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.

            // The number of nodes in the list is in the range[0, 300].
            // -100 <= Node.val <= 100
            // The list is guaranteed to be sorted in ascending order.
            if (head == null)
                return null;
            if (head.next == null)
                return head;

            ListNode ret = new ListNode(head.val);
            ListNode lastNode;
            int saved = head.val;// init value
            ListNode tempNode = head.next;
            int tempVal;
            while (true)
            {
                tempVal = tempNode.val;
                if (saved != tempVal)
                {
                    lastNode = getLast(ret);
                    lastNode.next = new ListNode(tempVal);
                    saved = tempVal;
                }
                if (tempNode.next != null)
                    tempNode = tempNode.next;
                else
                    break;
            }

            return ret;
        }

        /// <summary>
        /// 70. Climbing Stairs
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            // 1 <= n <= 45
            // You are climbing a staircase. It takes n steps to reach the top.
            // Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top ?
            if (n == 1) return 1;
            if (n == 2) return 2;

            int one = 1;
            int two = 2;

            for (int i = 2; i < (n + 1); i++)
            {
                int temp = one + two;
                one = two;
                two = temp;
            }
            return one;
        }

        /// <summary>
        /// 69. Sqrt(x)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            // Given a non-negative integer x, compute and return the square root of x.
            // Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.

            // 0 <= x <= 2^31 - 1
            double temp = Math.Sqrt(x);
            int ret = (int)temp;

            return ret;
        }

        /// <summary>
        /// 67. Add Binary
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            string ret = string.Empty;
            int len;
            int tempA, tempB;
            if (a.Length > b.Length)
            {
                len = a.Length;
                b = b.PadLeft(len, '0');
            }
            else
            {
                len = b.Length;
                a = a.PadLeft(len, '0');
            }

            // simply add
            for (int i = 0; i < len; i++)
            {
                int.TryParse(a[i].ToString(), out tempA);
                int.TryParse(b[i].ToString(), out tempB);
                ret += (tempA + tempB);
            }

            // convert 2 => 10, 3 => 11
            int idx2, idx3;
            StringBuilder sb;
            while (ret.Contains("2") || ret.Contains("3"))
            {
                sb = new StringBuilder();
                idx2 = ret.LastIndexOf('2');
                idx3 = ret.LastIndexOf('3');
                if (idx3 == -1)
                {
                    if (idx2 != 0)
                    {
                        int.TryParse(ret[idx2 - 1].ToString(), out tempA);
                        sb.Append(ret.Substring(0, idx2 - 1));
                        sb.Append(tempA + 1);
                        sb.Append(0);
                        sb.Append(ret.Substring(idx2 + 1));
                    }
                    else if (idx2 == 0)
                    {
                        ret = ret.Replace("2", "10");
                        break;
                    }
                    else
                        break;
                }
                else
                {
                    if (idx3 != 0)
                    {
                        int.TryParse(ret[idx3 - 1].ToString(), out tempA);
                        sb.Append(ret.Substring(0, idx3 - 1));
                        sb.Append(tempA + 1);
                        sb.Append(1);
                        sb.Append(ret.Substring(idx3 + 1));
                    }
                    else if (idx3 == 0)
                    {
                        ret = ret.Replace("3", "11");
                        break;
                    }
                }
                ret = sb.ToString();
            }
            return ret;
        }

        /// <summary>
        /// 66. Plus One
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            int len = digits.Length;
            int[] ret;
            if (!digits.Contains(9))
            {
                digits[len - 1]++;
                return digits;
            }
            else
            {
                // 9[i] goes 1[i-1], 0[i]
                ret = hasNine(digits);
                return ret;
            }

        }
        private int[] hasNine(int[] org)
        {
            int len = org.Length;
            // return variable
            int[] ret;

            int temp = len - 1;
            org[temp]++;
            while (temp > -1)
            {
                if (org[temp] == 10)
                {
                    if (temp != 0)
                    {
                        org[temp] = 0;
                        org[temp - 1]++;
                    }
                    else
                        break;
                }
                temp--;
            }

            if (org[0] == 10)
            {
                ret = new int[org.Length + 1];
                org.CopyTo(ret, 1);
                ret[0] = 1;
                ret[1] = 0;
            }
            else
            {
                ret = new int[len];
                org.CopyTo(ret, 0);
            }

            return ret;
        }

        /// <summary>
        /// 58. Length of Last Word
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLastWord(string s)
        {
            string[] arr = s.Trim().Split(' ');
            if (arr.Length == 0) return 0;
            return arr[arr.Length - 1].Length;
        }

        /// <summary>
        /// 53. Maximum Subarray
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            int len = nums.Length;
            if (len == 0)
                return 0;
            if (len == 1)
                return nums[0];

            // do something when length is over 1;
            // return value
            int ret = 0;
            // calculate value
            int temp = 0;
            // init value = sum all;
            nums.Sum(num => ret += num);

            // 1 <= idx < len
            int idx = len - 1;
            // 0 <= i <= len - idx + 1
            int i;
            while (idx > 0)
            {
                temp = 0;
                // sum of sub-array start with 0.
                for (int j = 0; j < idx; j++)
                    temp += nums[j];

                if (ret < temp)
                    ret = temp;
                // delete first element then add nums[last index + 1]
                // warn IndexOutOfRangeException
                for (i = 0; i < len - idx; i++)
                {
                    temp -= nums[i];
                    temp += nums[idx + i];

                    if (ret < temp)
                        ret = temp;
                }
                idx--;
            }
            return ret;
        }

        /// <summary>
        /// 35. Search Insert Position
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int len = nums.Length;
            if (target > nums[len - 1])
                return len;
            if (target <= nums[0])
                return 0;

            // try to binary search
            int start, end;
            start = 0;
            end = len - 1;
            int idx = (start + end) / 2;
            while (true)
            {
                if (target > nums[idx])
                    start = idx;
                else if (target < nums[idx])
                    end = idx;
                else
                    return idx;

                idx = (start + end) / 2;
                if (end - start == 1)
                    return idx + 1;
            }
        }

        /// <summary>
        /// 28. Implement strStr()
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            // 0 <= haystack.length, needle.length <= 5 * 104
            // haystack and needle consist of only lower-case English characters.
            if (needle.Equals("") || needle == string.Empty)
                return 0;
            int idx;
            string temp_str;
            string temp;
            if (!haystack.Contains(needle))
                return -1;
            else
            {
                idx = haystack.IndexOf(needle[0]);
                temp = haystack.Substring(idx, needle.Length);
                while (true)
                {
                    if (temp.Equals(needle))
                        return idx;
                    temp_str = haystack.Substring(idx++ + 1);
                    idx += temp_str.IndexOf(needle[0]);
                    temp = haystack.Substring(idx, needle.Length);
                }
            }
        }

        /// <summary>
        /// 27. Remove Element
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int RemoveElement(int[] nums, int val)
        {
            int len = nums.Length;
            if (len == 0)
                return 0;
            int idx = 0;
            for (int i = 0; i < len; i++)
            {
                if (val != nums[i])
                {
                    nums[idx] = nums[i];
                    idx++;
                }
            }

            return idx;
        }

        /// <summary>
        /// 26. Remove Duplicates from Sorted Array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            int len = nums.Length;
            if (len == 0)
                return 0;
            int idx = 1;
            int temp = nums[0];
            for (int i = 1; i < len; i++)
            {
                if (temp != nums[i])
                {
                    temp = nums[i];
                    nums[idx] = nums[i];
                    idx++;
                }
            }

            return idx;
        }

        /// <summary>
        /// 21. Merge Two Sorted Lists
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            // The number of nodes in both lists is in the range[0, 50].
            // -100 <= Node.val <= 100
            // Both l1 and l2 are sorted in non-decreasing order.(asc)
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            ListNode ret = null;
            ListNode lastNode = null;

            while (true)
            {
                if (l1.val < l2.val)
                {
                    // add child
                    if (ret == null)
                        ret = new ListNode(l1.val);
                    else
                        lastNode.next = new ListNode(l1.val);
                    lastNode = getLast(ret);

                    // re-organize origin Nodes
                    if (l1.next == null) // it means that this is the lastNode.
                    {
                        lastNode.next = l2;
                        break;
                    }
                    else
                        l1 = l1.next;
                }
                else
                {
                    // add child
                    if (ret == null)
                        ret = new ListNode(l2.val);
                    else
                        lastNode.next = new ListNode(l2.val);
                    lastNode = getLast(ret);

                    // re-organize origin Nodes
                    if (l2.next == null) // it means that this is the lastNode.
                    {
                        lastNode.next = l1;
                        break;
                    }
                    else
                        l2 = l2.next;
                }
            }
            return ret;
        }

        /// <summary>
        /// 14. Longest Common Prefix
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            // Write a function to find the longest common prefix string amongst an array of strings.
            // If there is no common prefix, return an empty string "".

            // 0 <= strs.length <= 200
            // 0 <= strs[i].length <= 200
            // strs[i] consists of only lower-case English letters.
            if (strs.Length == 0) return "";
            if (strs.Length == 1) return strs[0];
            string temp;
            temp = checkChar(strs[0], strs[1]);
            for (int i = 0; i < strs.Length; i++)
            {
                temp = checkChar(temp, strs[i]);
                if (temp.Equals(""))
                    break;
            }

            return temp;
        }
        private string checkChar(string a, string b)
        {
            string ret = "";
            int len;
            if (a.Length > b.Length)
                len = b.Length;
            else
                len = a.Length;

            for (int i = 0; i < len; i++)
            {
                if (a.ElementAt(i).Equals(b.ElementAt(i)))
                    ret += a.ElementAt(i);
                else
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 13. Roman to Integer
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            // I    1
            // V    5
            // X    10
            // L    50
            // C    100
            // D    500
            // M    1000
            // I can be placed before V(5) and X(10) to make 4 and 9.
            // X can be placed before L(50) and C(100) to make 40 and 90.
            // C can be placed before D(500) and M(1000) to make 400 and 900.
            char temp;
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                temp = s.ElementAt(i);
                switch (temp)
                {
                    case 'I':
                        if (i != (s.Length - 1))
                            if (s.ElementAt(i + 1) == 'V' || s.ElementAt(i + 1) == 'X')
                                sum -= 1;
                            else
                                sum += 1;
                        else
                            sum += 1;
                        break;
                    case 'V':
                        sum += 5;
                        break;
                    case 'X':
                        if (i != (s.Length - 1))
                            if (s.ElementAt(i + 1) == 'L' || s.ElementAt(i + 1) == 'C')
                                sum -= 10;
                            else
                                sum += 10;
                        else
                            sum += 10;
                        break;
                    case 'L':
                        sum += 50;
                        break;
                    case 'C':
                        if (i != (s.Length - 1))
                            if (s.ElementAt(i + 1) == 'D' || s.ElementAt(i + 1) == 'M')
                                sum -= 100;
                            else
                                sum += 100;
                        else
                            sum += 100;
                        break;
                    case 'D':
                        sum += 500;
                        break;
                    case 'M':
                        sum += 1000;
                        break;
                }
            }
            return sum;
        }

        /// <summary>
        /// 9. Palindrome Number
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            // return (IsPalindrome) ? true : false;
            string xStr = "" + x;
            char[] arr = xStr.ToCharArray();
            int len = arr.Length;
            for (int i = 0; i < (len / 2); i++)
                if (arr[i] == arr[(len - 1) - i])
                    continue;
                else
                    return false;
            return true;
        }

        /// <summary>
        /// 7. Reverse Integer
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            // return (out of range) ? 0 : reverse x;
            if (x == 0)
                return 0;

            string temp = string.Empty;
            bool neg = false;
            if (x > 0)
            {
                temp = "" + x;
            }
            else
            {
                temp = "" + x;
                temp = temp.Replace('-', ' ');
                neg = true;
            }

            temp = reverseString(temp);

            int ret;
            try
            {
                ret = Convert.ToInt32(temp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ret = 0;
                return ret;
            }
            if (neg)
                return -ret;
            else
                return ret;
        }
        private string reverseString(string org)
        {
            char[] rev = org.ToCharArray();
            Array.Reverse(rev);
            return new string(rev);
        }

        /// <summary>
        /// 1. Two Sum
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            int[] ret = new int[2];
            for (int i = 0; i < nums.Length; i++)
                for (int j = (i + 1); j < nums.Length; j++)
                    if (nums[i] + nums[j] == target)
                    {
                        ret[0] = i;
                        ret[1] = j;
                        return ret;
                    }
            return null;
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
        private ListNode getLast(ListNode head)
        {
            while (head.next != null)
                head = head.next;
            return head;
        }
        private void showNodes(ListNode head)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            while (true)
            {
                sb.Append(head.val);
                if (head.next != null)
                {
                    sb.Append(", ");
                    head = head.next;
                }
                else
                    break;
            }
            sb.Append("]");
            Console.WriteLine($">> {sb.ToString()} ");
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
        private string searchTreeByInorder(TreeNode center)
        {
            StringBuilder sb = new StringBuilder();
            string left = "l";
            string right = "r";
            if (center != null)
            {
                left = searchTreeByInorder(center.left);
                right = searchTreeByInorder(center.right);
            }
            if (center != null)
                sb.Append(center.val);
            else
                sb.Append("c");
            sb.Append(left);
            sb.Append(right);

            return sb.ToString();
        }
        #endregion
    }
}
