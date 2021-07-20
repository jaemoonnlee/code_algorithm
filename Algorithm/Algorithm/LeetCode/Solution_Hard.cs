using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Solution_Hard
    {
        #region attempted
        // TODO hard problems

        #endregion
        #region solved
        //

        /// <summary>
        /// 4. Median of Two Sorted Arrays
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // nums1.length == m
            // nums2.length == n
            // 0 <= m <= 1000
            // 0 <= n <= 1000
            // 1 <= m + n <= 2000
            // - 10^6 <= nums1[i], nums2[i] <= 10^6

            // Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
            List<int> temp = new List<int>();
            foreach (int item in nums1)
                temp.Add(item);
            foreach (int item in nums2)
                temp.Add(item);
            temp.Sort();

            int len = temp.Count;
            int mid = len / 2;

            return (len % 2 == 0) ? (double)((temp.ElementAt(mid - 1)) + temp.ElementAt(mid)) / 2 : temp.ElementAt(mid);
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
