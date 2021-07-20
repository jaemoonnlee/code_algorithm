using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
    // [Link] https://programmers.co.kr/learn/challenges
    class Level1
    {
        #region attempted
        // TODO Level1 problems
        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12977
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MakePrimeNumber(int[] nums)
        {
            HashSet<int> primeNums = new HashSet<int>();
            int answer = 0;
            // 3 <= nums.Length <= 50
            // 1 <= nums[i] <= 1000, unique
            int len = nums.Length;

            List<int> numsList = new List<int>(nums);
            bool[] checkers = new bool[len];// init false;

            // foreach(int i in temp)
            //     answer += i;

            return primeNums.Count;
        }
        private bool IsPrimeNumber(int check)
        {
            for (int i = 2; i < check; i++)
                if (check % i == 0)
                    return false;
            return true;
        }
        private int pickNums(int[] arr, int cnt, int sum = 0)
        {
            int len = arr.Length;
            List<int> sub_arr = new List<int>();
            for (int i = 0; i < len; i++)
            {
                if (cnt != 0)
                {
                    sum += arr[i];
                    for (int j = 0; j < len - 1; j++)
                    {
                        if (j == i) continue;
                        sub_arr.Add(arr[j]);
                    }
                    pickNums(sub_arr.ToArray(), cnt - 1, sum);
                }
                else
                {
                    return IsPrimeNumber(sum) ? 1 : 0;
                }
            }

            return 0;
        }
        #endregion
        #region solved



        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/77884
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int AddOrSubForDivisors(int left, int right)
        {
            int answer = 0;
            for (int i = left; i < right + 1; i++)
                if (countOfDivisors(i) % 2 == 0)
                    answer += i;
                else
                    answer -= i;
            return answer;
        }
        private int countOfDivisors(int input)
        {
            if (input == 1)
                return 1;
            int result = 2;
            for (int i = 2; i < input; i++)
                if (input % i == 0)
                    result++;
            return result;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12915
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string[] SortingTwice(string[] strings, int n)
        {
            int len = strings.Length;
            string[] answer = strings;
            string temp = string.Empty;
            for (int i = 0; i < len - 1; i++)
            {
                if (!compareStr(answer[i], answer[i + 1], n))
                {
                    temp = answer[i];
                    answer[i] = answer[i + 1];
                    answer[i + 1] = temp;
                    i = -1;
                    continue;
                }
            }
            return answer;
        }
        private bool compareStr(string a, string b, int idx)
        {
            if (a[idx] == b[idx])
                return a.CompareTo(b) < 0;
            else
                return (a[idx] < b[idx]);
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12926
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CaesarPassword(string s, int n)
        {
            StringBuilder sb = new StringBuilder();
            // a-z(26: 0-25)(97-122)
            const int LOWER = 97;
            // A-Z(65-90)
            const int UPPER = 65;
            char[] c_lower = new char[]
            {
                'a','b','c','d','e',
                'f','g','h','i','j',
                'k','l','m','n','o',
                'p','q','r','s','t',
                'u','v','w','x','y','z'
            };
            char[] c_upper = new char[]
            {
                'A','B','C','D','E',
                'F','G','H','I','J',
                'K','L','M','N','O',
                'P','Q','R','S','T',
                'U','V','W','X','Y','Z'
            };

            char[] org = s.ToCharArray();
            int len = org.Length;
            int temp;
            for (int i = 0; i < len; i++)
            {
                temp = org[i];
                if (temp > 90)// a-z(65-90)
                {
                    temp -= LOWER;
                    temp += n;
                    temp %= 26;
                    sb.Append(c_lower[temp]);
                }
                else if (temp > 32)// A-Z(97-122)
                {
                    temp -= UPPER;
                    temp += n;
                    temp %= 26;
                    sb.Append(c_upper[temp]);
                }
                else// blank(32)
                    sb.Append(' ');
            }
            return sb.ToString();
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12932
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] ReverseInt(long n)
        {
            int[] answer;
            char[] c = n.ToString().ToCharArray();
            Array.Reverse(c);
            answer = new int[c.Length];
            for (int i = 0; i < c.Length; i++)
                answer[i] = int.Parse("" + c[i]);

            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12933
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long OrderDesc(long n)
        {
            long answer = 0;
            List<long> list = new List<long>();
            int idx = 0;
            while (n / 10 != 0)
            {
                list.Add(n % 10);
                n /= 10;
            }

            list.Add(n % 10);
            list.Sort();// asc
            //list.Sort((x, y) => y.CompareTo(x));// desc
            foreach (long l in list)
                answer += (l * (long)Math.Pow(10, idx++));
            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12934
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long IsSqrt(long n)
        {
            double temp = Math.Sqrt(n);
            if (temp - (int)temp == 0)
                return (long)Math.Pow(temp + 1, 2);
            return -1;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12940
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int[] GetLcmGcd(int n, int m)
        {
            int[] answer = new int[2];
            int lcm, gcd, i;
            int max, min;
            max = Math.Max(n, m);
            min = Math.Min(n, m);
            lcm = n * m;
            gcd = 1;
            List<int> divisors_n = new List<int>();
            for (i = n; i > 0; i--)
                if (n % i == 0)
                    divisors_n.Add(i);
            List<int> divisors_m = new List<int>();
            for (i = m; i > 0; i--)
                if (m % i == 0)
                    divisors_m.Add(i);
            // lcm
            for (int j = lcm - 1; j >= max; j--)
            {
                if (j % n == 0 && j % m == 0)
                    lcm = j;
            }
            // gcd
            for (int j = gcd + 1; j <= min; j++)
            {
                if (n % j == 0 && m % j == 0)
                    gcd = j;
            }
            answer[0] = gcd;
            answer[1] = lcm;
            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12943
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int CollatzConjecture(int num)
        {
            int answer = 0;
            long temp = num;
            while (temp != 1)
            {
                if (answer++ > 500)
                    return -1;
                if (temp % 2 == 0)
                {
                    temp /= 2;
                }
                else
                {
                    temp = (temp * 3) + 1;
                }
            }
            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12944
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public double GetAverage(int[] arr)
        {
            double sum = 0;
            foreach (int i in arr)
                sum += i;
            int len = arr.Length;

            return sum / len;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12954
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public long[] MakeArray(int x, int n)
        {
            long[] answer = new long[n];
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += x;
                answer[i] = sum;
            }
            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12947
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsHarshad(int x)
        {
            int sum = 0;
            int temp = x;
            while (temp / 10 != 0)
            {
                sum += temp % 10;
                temp /= 10;
            }
            sum += temp % 10;
            return (x % sum == 0) ? true : false;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12930
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MakeStringWeird(string s)
        {
            string answer = "";
            string[] arr = s.Split(' ');
            int len;
            foreach (string temp in arr)
            {
                Console.WriteLine($"{temp}");
                len = temp.Length;
                if (len != 0)
                    for (int i = 0; i < len; i++)
                    {
                        if (i % 2 == 0)
                            answer += temp[i].ToString().ToUpper();
                        else
                            answer += temp[i].ToString().ToLower();
                    }
                answer += " ";
            }
            return answer.Substring(0, answer.Length - 1);
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12925
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int SetString2int(string s)
        {
            int answer = 0;
            bool neg = false;
            if (s[0] == '+' || s[0] == '-')
            {
                if (s[0] == '-')
                    neg = true;
                s = s.Substring(1);
                int.TryParse(s, out answer);
                if (neg)
                    answer = -answer;
            }
            else
                int.TryParse(s, out answer);
            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12919
        /// </summary>
        /// <param name="seoul"></param>
        /// <returns></returns>
        public string FindKim(string[] seoul)
        {
            int idx = -1;
            int len = seoul.Length;
            for (idx = 0; idx < len; idx++)
            {
                if (seoul[idx] == "Kim")
                    break;
            }
            return $"김서방은 {idx}에 있다";
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12917
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string SetStringDesc(string s)
        {
            string answer = string.Empty;
            List<char> list = new List<char>(s);
            list.Sort();
            foreach (char c in list)
                answer = c + answer;

            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12910
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int[] FindDivEqualsZero(int[] arr, int divisor)
        {
            List<int> list = new List<int>();
            int len = arr.Length;
            for (int i = 0; i < len; i++)
                if (arr[i] % divisor == 0)
                    list.Add(arr[i]);
            if (list.Count == 0)
                return new int[] { -1 };
            list.Sort();
            return list.ToArray();
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12922
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string MakeSubak(int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                if (i % 2 != 0)
                    sb.Append("박");
                else
                    sb.Append("수");
            }
            return sb.ToString();
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12937
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string IsEven(int num)
        {
            return (num % 2 == 0) ? "Even" : "Odd";
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12935
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] GetRidOfMinimum(int[] arr)
        {
            int len = arr.Length;
            if (len == 1)
                return new int[] { -1 };

            int[] answer = new int[len - 1];
            List<int> org = new List<int>(arr);
            org.Sort();
            int min = org[0];

            int idx = 0;
            for (int i = 0; i < len; i++)
            {
                if (arr[i] == min) continue;
                answer[idx++] = arr[i];
            }
            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12931
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SumOfDigit(int n)
        {
            int answer = 0;
            while (n / 10 != 0)
            {
                answer += n % 10;
                n /= 10;
            }
            answer += n % 10;
            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12918#
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool FindDigitWhereLenIs4or6(string s)
        {
            int len = s.Length;
            if (len == 4 || len == 6)
            {
                Regex reg = new Regex("[0-9]{4,6}");
                return reg.IsMatch(s);
            }
            else
                return false;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12950
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int[,] SumOfMatrix(int[,] arr1, int[,] arr2)
        {
            int len1 = arr1.GetLength(0);
            int len2 = arr1.GetLength(1);
            int[,] answer = new int[len1, len2];

            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    answer[i, j] = arr1[i, j] + arr2[i, j];
                }
            }

            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12948
        /// </summary>
        /// <param name="phone_number"></param>
        /// <returns></returns>
        public string VeilPhoneNum(string phone_number)
        {
            string answer = "";
            int len = phone_number.Length;

            for (int i = 0; i < len - 4; i++)
            {
                answer += "*";
            }
            answer += phone_number.Substring(len - 4);
            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/68644?language=csharp
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int[] SumOfTwoPicked(int[] numbers)
        {
            // int[] answer = new int[] {};
            List<int> check = new List<int>();
            int len = numbers.Length;
            int temp;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (j == i)
                        continue;
                    temp = numbers[i] + numbers[j];
                    if (check.Contains(temp))
                        continue;
                    else
                        check.Add(temp);
                }
            }
            check.Sort();
            return check.ToArray();
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12912
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public long SumBetweenAandB(int a, int b)
        {
            long answer = 0;

            int x, y;
            x = (a > b) ? b : a;
            y = (a <= b) ? b : a;

            for (int i = x; i <= y; i++)
            {
                answer += i;
            }

            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/70128
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int GetSumDotProduct(int[] a, int[] b)
        {
            int temp = 0;
            for (int i = 0; i < a.Length; i++)
            {
                temp = temp + (a[i] * b[i]);
            }

            return temp;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12928
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SumOfDivisors(int n)
        {
            int answer = 0;

            List<int> divisors = new List<int>();
            for (int i = n; i > 0; i--)
            {
                if (n % i == 0)
                    divisors.Add(i);
            }

            foreach (int i in divisors)
                answer += i;

            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/42840
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>
        public int[] MockTest(int[] answers)
        {
            int[] answer;

            int len = answers.Length;// as index
            int ansCnt1st = 0;
            int ansCnt2nd = 0;
            int ansCnt3rd = 0;
            // 1,2,3,4,5
            int[] p_1st = new int[] { 1, 2, 3, 4, 5 };
            int len_1st = p_1st.Length;
            // 2,1,2,3,2,4,2,5
            int[] p_2nd = new int[] { 2, 1, 2, 3, 2, 4, 2, 5 };
            int len_2nd = p_2nd.Length;
            // 3,3,1,1,2,2,4,4,5,5
            int[] p_3rd = new int[] { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };
            int len_3rd = p_3rd.Length;

            for (int i = 0; i < len; i++)
            {
                if (answers[i] == p_1st[i % len_1st])
                    ansCnt1st++;
                if (answers[i] == p_2nd[i % len_2nd])
                    ansCnt2nd++;
                if (answers[i] == p_3rd[i % len_3rd])
                    ansCnt3rd++;
            }

            int[] temp = new int[] { ansCnt1st, ansCnt2nd, ansCnt3rd };
            // temp = temp.Sort();
            int max = Math.Max(Math.Max(temp[0], temp[1]), temp[2]);
            int cnt = 0;
            bool b1 = false;
            bool b2 = false;
            bool b3 = false;

            if (max == ansCnt1st)
            {
                cnt++;
                b1 = true;
            }
            if (max == ansCnt2nd)
            {
                cnt++;
                b2 = true;
            }
            if (max == ansCnt3rd)
            {
                cnt++;
                b3 = true;
            }
            answer = new int[cnt];
            cnt = 0;
            if (b1) answer[cnt++] = 1;
            if (b2) answer[cnt++] = 2;
            if (b3) answer[cnt++] = 3;

            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/42748
        /// </summary>
        /// <param name="array"></param>
        /// <param name="commands"></param>
        /// <returns></returns>
        public int[] NumberOfK(int[] array, int[,] commands)
        {
            int[] answer;

            // variables
            int start = -1;
            int end = -1;
            int idx = -1;
            List<int> list = new List<int>();
            // length
            int len_main = array.Length;
            int len_sub = commands.Length / 3;
            // Console.WriteLine($"len_sub = {len_sub}");
            answer = new int[len_sub];
            for (int i = 0; i < len_sub; i++)
            {
                list = new List<int>();

                start = commands[i, 0];
                end = commands[i, 1];
                idx = commands[i, 2];
                // input
                for (int j = 0; j < (end - start + 1); j++)
                {
                    list.Add(array[start - 1 + j]);
                }
                // sort
                list.Sort();
                // foreach (int l in list)
                //     Console.Write($"{l}");
                // Console.WriteLine("");
                answer[i] = list[idx - 1];
            }

            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/42862
        /// </summary>
        /// <param name="n"></param>
        /// <param name="lost"></param>
        /// <param name="reserve"></param>
        /// <returns></returns>
        public int ShareClothes(int n, int[] lost, int[] reserve)
        {
            int temp = 0;

            List<int> list_rsv = new List<int>(reserve);
            List<int> list_lst = new List<int>(lost);
            List<int> list = new List<int>();

            foreach (int i in list_rsv)
            {
                foreach (int j in list_lst)
                {
                    if (i == j)
                    {
                        list.Add(i);
                        break;
                    }
                }
            }

            foreach (int i in list)
            {
                list_lst.Remove(i);
                list_rsv.Remove(i);
            }

            for (int i = 0; i < list_lst.Count; i++)
            {
                int temp_plus = list_lst[i] + 1;
                int temp_minus = list_lst[i] - 1;

                foreach (int j in list_rsv)
                {
                    if (j == temp_plus || j == temp_minus)
                    {
                        list_rsv.Remove(j);
                        temp++;
                        break;
                    }
                }
            }

            return n - (list_lst.Count - temp);
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12901
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string FindDayIn2016(int a, int b)
        {
            string[] week = new string[] { "THU", "FRI", "SAT", "SUN", "MON", "TUE", "WED" };
            // 2016.1.1. FRI
            // 2016.2.1~29.
            int[] days = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] month = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int total_day = 0;
            int idx = 0;
            foreach (int i in month)
            {
                if (a == i)
                    break;
                idx++;
            }
            for (int i = 0; i < idx; i++)
                total_day += days[i];

            return week[(total_day + b) % 7];
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12903
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string GetMiddleString(string s)
        {
            return (s.Length % 2 != 0) ? s.Substring(s.Length / 2, 1) : s.Substring(s.Length / 2 - 1, 2);
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/77484
        /// </summary>
        /// <param name="lottos"></param>
        /// <param name="win_nums"></param>
        /// <returns></returns>
        public int[] LottoMaxMin(int[] lottos, int[] win_nums)
        {
            int[] answer = new int[2];

            HashSet<int> set_win = new HashSet<int>(win_nums);
            HashSet<int> set_minwoo = new HashSet<int>(lottos);
            if (set_minwoo.Contains(0))
                set_minwoo.Remove(0);
            int len = set_minwoo.Count;
            int len_possible = 6 - len;
            int max_cnt;
            int min_cnt = 0;

            if (len != 0)
                foreach (int w in set_win)
                {
                    if (set_minwoo.Contains(w))
                        min_cnt++;
                }
            max_cnt = len_possible + min_cnt;

            answer[0] = (max_cnt > 1) ? 7 - max_cnt : 6;
            answer[1] = (min_cnt > 1) ? 7 - min_cnt : 6;

            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12982
        /// </summary>
        /// <param name="d"></param>
        /// <param name="budget"></param>
        /// <returns></returns>
        public int GetBudget(int[] d, int budget)
        {
            int len_d = d.Length;
            int sum = 0;
            int idx = 0;
            foreach (int i in d)
                sum += i;

            if (sum <= budget)
                return len_d;
            else
            {
                List<int> list = new List<int>(d);
                list.Sort();
                sum = 0;
                while (sum <= budget)
                {
                    sum += list[idx++];
                }
                return --idx;
            }
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/68935
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ReverseTrinary(int n)
        {
            int answer = 0;
            Queue<int> q = new Queue<int>();

            // to3 using queue
            while (n >= 3)
            {
                q.Enqueue(n % 3);
                n /= 3;
            }
            q.Enqueue(n);

            // to10
            while (q.Count > 0)
            {
                int num = q.Dequeue();
                int mul = (int)Math.Pow(3, q.Count);
                answer += num * mul;
            }

            return answer;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/76501
        /// </summary>
        /// <param name="absolutes"></param>
        /// <param name="signs"></param>
        /// <returns></returns>
        public int AddPosNeg(int[] absolutes, bool[] signs)
        {
            int len = absolutes.Length;
            int[] arr = new int[len];
            for (int i = 0; i < len; i++)
            {
                if (signs[i])
                    arr[i] = absolutes[i];
                else
                    arr[i] = -absolutes[i];
            }
            int sum = 0;
            foreach (int i in arr)
                sum += i;
            return sum;
        }

        /// <summary>
        /// https://programmers.co.kr/learn/courses/30/lessons/12921
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindPrimeNumber(int n)
        {
            int answer = 0;
            int limit = (int)n / 2;// it is related with line 18 for declaring int i.
            // Console.WriteLine($"limit = {limit}");

            int[] num_array = new int[n + 1];
            for (int i = 2; i <= n; ++i)
                num_array[i] = i;

            for (int i = 2; i <= limit; ++i)
            {
                // Console.WriteLine($"num_array[{i}] = {num_array[i]}");
                if (num_array[i] == 0)
                    continue;

                for (int j = i * 2; j <= n; j += i)
                {
                    // Console.WriteLine($">> num_array[{j}] = {num_array[j]}");
                    if (num_array[j] == 0)
                        continue;

                    num_array[j] = 0;
                }
            }

            foreach (var num in num_array)
                if (num != 0)
                    answer++;

            return answer;
        }
        #endregion
        #region extra

        #endregion
    }
}
