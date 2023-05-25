using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LeetCode_Easy
{
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

    class Program
    {
        static List<int> result = new List<int>();
        static bool isBalanced = true;

        static void Main(string[] args)
        {
            var test = DefangIPaddr("255.100.50.0");
        }
         
        public int BinarySearch(int[] nums, int number)
        {
            int left = 0;
            int right = nums.Length - 1;

            while(left <= right)
            {
                int mid = left + (right - left) / 2;

                if(number == nums[mid])
                {
                    return mid;
                }
                else if(number < nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left= mid + 1;
                }
            }

            return 0;
        }

        public int[] TwoSum(int[] nums, int target) // 1
        {
            Dictionary<int, int> dictator = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int difference = target - nums[i];

                if (dictator.ContainsKey(difference))
                {
                    return new int[2] { dictator[difference], i };
                }
                else
                {
                    dictator.TryAdd(nums[i], i);
                }
            }

            return null;
        }

        public bool IsPalindrome(int x) // 9
        {
            int result = 0;
            int xCopy = x;

            if (x < 0)
                return false;

            while (xCopy > 0)
            {
                result = xCopy % 10 + result * 10;
                xCopy /= 10;
            }

            return result == x ? true : false;
        }

        public int RomanToInt(string s)
        {
            int result = 0;
            Dictionary<char, int> map = new Dictionary<char, int>()
            {
                {'I',1},
                {'V',5},
                {'X',10},
                {'L',50},
                {'C',100},
                {'D',500},
                {'M',1000}
            };

            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1 && map[s[i]] < map[s[i + 1]])
                {
                    result -= map[s[i]];
                }
                else { result += map[s[i]]; }
            }
            return result;
        } // 13

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0) return "";

            string prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                }
            }

            return prefix;
        } // 14

        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    stack.Push(s[i]);
                }
                else if (stack.Count != 0)
                {
                    if (s[i] == ')' && stack.Peek() == '(' ||
                        s[i] == ']' && stack.Peek() == '[' ||
                        s[i] == '}' && stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                    else { return false; }
                }
                else { return false; }
            }
            if (stack.Count == 0) { return true; }
            else { return false; }
        } // 20
      
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {

            if (list1 == null) return list2;
            if (list2 == null) return list1;
            if (list1 == null && list2 == null) return null;

            if (list1.val <= list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list2.next, list1);
                return list2;
            }
        } // 21

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int index = 1;

            for (int i = 0; i < nums.Length - 1; i++)
            {

                if (nums[i] != nums[i + 1])
                {
                    nums[index++] = nums[i + 1];
                }

            }

            return index;
        } // 26

        public int RemoveElement(int[] nums, int val) // 27
        {
            int current = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[current] = nums[i];
                    current++;
                }
            }

            if (current == 0)
                return nums.Length;

            return current;
        }

        public int SearchInsert(int[] nums, int target) // 35
        {
            int b = 0;
            int e = nums.Length - 1; //[1,3,5,6], target = 2

            if (target > nums[e])
                return e + 1;

            if (target < nums[b])
                return b;

            while (b < e)
            {
                if (nums[b] < target && nums[b + 1] > target)
                    return b + 1;

                if (nums[e] > target && nums[e - 1] < target)
                    return e;

                if (nums[b] == target)
                    return b;

                if (nums[e] == target)
                    return e;

                b++;
                e--;
            }

            return 0;

        }

        public int LengthOfLastWord(string s) // 58
        {
            int result = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ' && result != 0)
                {
                    return result;
                }
                else if (s[i] == ' ')
                {
                    continue;
                }
                else { result++; }
            }

            return result;
        }

        public int[] PlusOne(int[] digits) //66
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] != 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }

            int[] newDigits = new int[digits.Length + 1];
            newDigits[0] = 1;

            return newDigits;

            //for (int i = digits.Length - 1; i > 0; i--)
            //{
            //    if (digits[i] + 1 == 10)
            //    {
            //        digits[i] = 0;
            //        digits[i - 1] = ++digits[i - 1];
            //        continue;
            //    }
            //    else if (digits[i] + 1 != 10 && i == digits.Length - 1)
            //    {
            //        digits[i] = ++digits[i];
            //        break;
            //    }
            //    else if (digits[i] == 10)
            //    {
            //        digits[i] = 0;
            //        continue;
            //    }
            //    break;
            //}

            //return digits;
        }

        public string AddBinary(string a, string b) // 67 not Easy
        {
            string result = null;


            return result;
        }

        public int MySqrt(int x) // 69
        {
            int first = 0;
            int last = x;

            while(first <= last)
            {
                long mid = (first + last) / 2;

                long temp = mid * mid;

                if (x == temp)
                {
                    return (int)mid;
                }
                else if (temp > x)
                {
                    last = (int)(mid - 1);
                }
                else
                {
                    first = (int)(mid + 1);
                }   
            }

            return last;
        }

        public int ClimbStairs(int n) // 70
        {            
            int a = 1, b = 1;
            
            while(n > 0)
            {
                b += a;
                a = b - a;
                n--;
            }
            return a;
            
            //   2
            // 1 1            2
            // 2

            //   3
            //1 1 1
            //2 1             3
            //1 2


            //   4
            //1 1 1 1
            //2 1 1
            //1 2 1           5
            //1 1 2
            //2 2

            //   5
            //1 1 1 1 1
            //2 1 1 1
            //1 2 1 1
            //1 1 2 1         8
            //1 1 1 2
            //1 2 2
            //2 1 2
            //2 2 1           

            //   6
            //1 1 1 1 1 1
            //2 1 1 1 1
            //1 2 1 1 1
            //1 1 2 1 1
            //1 1 1 2 1
            //1 1 1 1 2
            //2 2 1 1
            //1 2 1 2         13
            //2 1 2 1
            //1 1 2 2
            //1 2 2 1
            //2 1 1 2
            //2 2 2

            //Result: 5, 8, 13 - Fibonacci
        }

        public ListNode DeleteDuplicates(ListNode head)
        {           
            if (head == null || head.next == null)
                return head;

            if (head.val == head.next.val)
            {
                head.next = head.next.next;
                return DeleteDuplicates(head);
            }
            else
            {
                head.next = DeleteDuplicates(head.next);
                return head;
            }
        } //83

        public void Merge(int[] nums1, int m, int[] nums2, int n) // 88
        {
            //Merge(new int[6] { 1, 2, 3, 0, 0, 0 }, 3, new int[3] { 2, 5, 6 }, 3);
            //Merge(new int[6] { 4, 5, 6, 0, 0, 0 }, 3, new int[3] { 1, 2, 3 }, 3);
            //Merge(new int[6] { 4, 0, 0, 0, 0, 0 }, 1, new int[5] { 1, 2, 3, 5, 6 }, 5);
            //Merge(new int[1] { 0 }, 0, new int[1] { 1 }, 1);

            if (m == 0 && n != 0)
            {
                for (int i = 0; i < nums1.Length; i++)
                {
                    nums1[i] = nums2[i];
                }
            }
            else if (n != 0)
            {
                for (int i = 0; i < nums2.Length; i++)
                {
                    if (nums2[i] < nums1[m - 1])
                    {
                        for (int j = m - 1; j >= 0; j--)
                        {
                            if (nums2[i] < nums1[j])
                            {
                                nums1[j + 1] = nums1[j];
                                nums1[j] = nums2[i];
                            }
                        }
                        m++;
                    }
                    else
                    {
                        nums1[m] = nums1[m - 1];
                        nums1[m] = nums2[i];
                        m++;
                    }
                }
            }
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            if(root == null)
                return result;

            InorderTraversal(root.left);
            result.Add(root.val);
            InorderTraversal(root.right);

            return result;
        } // 94

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;

            if (p != null && q != null)
            {
                if (p.val == q.val)
                {
                    IsSameTree(p.left, q.left);
                    IsSameTree(p.right, q.right);
                    return true;
                }
            }
            return false;
        }

        public bool IsSymmetric(TreeNode root) // 101
        {
            return root is null ? false : IsSymmetricHelper(root.left, root.right);
        }
        public bool IsSymmetricHelper(TreeNode p, TreeNode q)
        {

            if (p == null || q == null)
                return p?.val == q?.val;

            if (p.val != q.val)
                return false;

            return IsSymmetricHelper(p.left, q.right) && IsSymmetricHelper(p.right, q.left);
        }

        public int MaxDepth(TreeNode root)
        {
            if (root is null)
                return 0;

            var left = MaxDepth(root.left);
            var right = MaxDepth(root.right);

            int res = 1 + Math.Max(left, right);

            return res;
        } // 104

        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBSTHelper(0, nums.Length - 1);

            TreeNode SortedArrayToBSTHelper(int left, int right)
            {
                if (left > right)
                {
                    return null;
                }
                int mid = left + (right - left) / 2;

                return new TreeNode(nums[mid], SortedArrayToBSTHelper(left, mid - 1), SortedArrayToBSTHelper(mid + 1, right));
            }
        } // 108

        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;

            if (Math.Abs(IsBalancedHelper(root.left) - IsBalancedHelper(root.right)) <= 1)
                return true && IsBalanced(root.left) && IsBalanced(root.right);
            else
                return false;
        }
        public int IsBalancedHelper(TreeNode node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(IsBalancedHelper(node.left), IsBalancedHelper(node.right));
        }

        public  int[] GetConcatenation(int[] nums)
        {
            int[] ans = new int[2 * nums.Length];

            for (int i = 0; i < ans.Length; i++)
            {
                ans[i] = nums[i];
                ans[i + nums.Length] = nums[i];
            }

            return ans;
        } //1929. Concatenation of Array     
        
        public int[] BuildArray(int[] nums) // 1920. Build Array from Permutation
        {
            int[] ans = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                ans[i] = nums[nums[i]];
            }

            return ans;
        }

        public static string DefangIPaddr(string address)// 1108. Defanging an IP Address
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < address.Length; i++)
            {
                if (address[i] == '.')
                    sb.Append(new char[] { '[', address[i], ']' });
                else
                    sb.Append(address[i]);
            }
           
            return sb.ToString();
        }
    }
}