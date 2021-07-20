using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
    // [Link] https://programmers.co.kr/learn/challenges
    class Level2
    {
        #region attempted
        // TODO Level2 problems

        #endregion
        #region solved



        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12941
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int MakeMinimumInSumOfTwoMul(int[] A, int[] B)
        {
            int answer = 0;
            Array.Sort(A);
            Array.Sort(B);
            Array.Reverse(B);
            int len = A.Length;
            for (int i = 0; i < len; i++)
                answer += A[i] * B[i];
            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/43165
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int DfsOrBfs(int[] numbers, int target)
        {
            int len = numbers.Length;
            int min = 0;
            int max = 0;

            foreach (int num in numbers)
            {
                min -= num;
                max += num;
            }
            if (target == min || target == max)
                return 1;

            return Dfs(numbers, target, 0, 0);
        }
        private int Dfs(int[] arr, int goal, int idx, int num)
        {
            if (idx == arr.Length)
                if (goal == num)
                    return 1;
                else
                    return 0;
            else
                return Dfs(arr, goal, idx + 1, num + arr[idx]) + Dfs(arr, goal, idx + 1, num - arr[idx]);
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/42586
        /// </summary>
        /// <param name="progresses"></param>
        /// <param name="speeds"></param>
        /// <returns></returns>
        public int[] DevelopeSpeed(int[] progresses, int[] speeds)
        {
            List<int> answer = new List<int>();

            Queue<int> q = new Queue<int>();// init
            for (int i = 0; i < progresses.Length; i++)
                q.Enqueue(progresses[i]);
            Queue<int> q_speed = new Queue<int>();// init
            for (int i = 0; i < progresses.Length; i++)
                q_speed.Enqueue(speeds[i]);
            int tempProgress = -1;
            int tempSpeed = -1;
            Stack<int> st = new Stack<int>();
            int len;
            while (q.Count != 0)
            {
                len = q.Count;
                // 하루 작업
                for (int i = 0; i < len; i++)
                {
                    tempProgress = q.Dequeue();
                    tempSpeed = q_speed.Dequeue();
                    tempProgress += tempSpeed;
                    q.Enqueue(tempProgress);
                    q_speed.Enqueue(tempSpeed);
                }

                // 작업도 확인
                for (int i = 0; i < len; i++)
                {
                    tempProgress = q.Peek();
                    if (tempProgress >= 100)
                    {
                        Console.WriteLine($"[{i}/{len}]{tempProgress}");
                        st.Push(q.Dequeue());
                        q_speed.Dequeue();
                    }
                    else
                        break;
                }

                // 배포
                if (st.Count != 0)
                {
                    answer.Add(st.Count);
                    st.Clear();
                }
            }
            return answer.ToArray();
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/42746
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public string MakeMaxNumber(int[] numbers)
        {
            StringBuilder sb = new StringBuilder();
            List<int[]> listArray = getDigitList(numbers);
            listArray.Sort((x, y) =>
                          (x[0] != y[0]) ?
                          y[0].CompareTo(x[0]) :
                          getInt(y, x).CompareTo(getInt(x, y)));

            if (listArray[0][0] == 0) return "0";

            foreach (int[] arr in listArray)
                foreach (int num in arr)
                    sb.Append(num);
            return sb.ToString();
        }
        private int[] getDigitArray(int input)
        {
            List<int> list = new List<int>();
            while (input / 10 != 0)
            {
                list.Add(input % 10);
                input /= 10;
            }
            list.Add(input % 10);
            int[] ret = list.ToArray();
            Array.Reverse(ret);
            return ret;
        }
        private List<int[]> getDigitList(int[] inputArr)
        {
            List<int[]> list = new List<int[]>();
            int len = inputArr.Length;

            for (int i = 0; i < len; i++)
                list.Add(getDigitArray(inputArr[i]));

            return list;
        }
        private int getInt(int[] a, int[] b)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int x in a)
                sb.Append(x);
            foreach (int y in b)
                sb.Append(y);
            return Convert.ToInt32(sb.ToString());
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12981
        /// </summary>
        /// <param name="n"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int[] WordChain(int n, string[] words)
        {
            int[] answer = { 0, 0 };
            int len = words.Length;
            List<string> list = new List<string>();
            char pre_ch = ' ';
            char ch;
            string pre_str, str;
            // init
            str = words[0];
            list.Add(str);
            for (int i = 1; i < len; i++)
            {
                str = words[i];
                ch = str[0];
                pre_str = words[i - 1];
                pre_ch = pre_str[pre_str.Length - 1];
                if ((pre_ch != ch) || (list.Contains(str)))
                {
                    answer[0] = (i % n) + 1;
                    answer[1] = (i / n) + 1;
                    break;
                }
                else
                    list.Add(str);
            }
            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/76502
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int rotateBracket(string s)
        {
            int answer = 0;
            int len = s.Length;
            string temp;
            for (int i = 0; i < len; i++)
            {
                temp = s.Substring(i, len - i) + s.Substring(0, i);
                if (checkBracket(temp))
                    answer++;
            }
            return answer;
        }
        private bool checkBracket(string bracket)
        {
            char[] arr = bracket.ToCharArray();
            int len = arr.Length;
            Stack<char> st = new Stack<char>();

            char open = ' ';
            char temp;
            for (int i = 0; i < len; i++)
            {
                temp = arr[i];
                if (temp == '(' || temp == '[' || temp == '{')
                    st.Push(temp);
                else
                {
                    if (st.Count == 0)
                        return false;
                    else
                    {
                        try
                        {
                            open = st.Pop();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (open == ' ')
                            return false;
                        else if (open == '(' && temp == ')')
                            continue;
                        else if (open == '[' && temp == ']')
                            continue;
                        else if (open == '{' && temp == '}')
                            continue;
                        else
                            return false;
                    }
                }
            }
            if (st.Count == 0)
                return true;
            else
                return false;
        }
        #endregion
        #region extra

        #endregion
    }
}
