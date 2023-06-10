using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Easy
{
    public class TreeTask
    {       
        static List<int> result = new List<int>();

        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
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
    }
}
