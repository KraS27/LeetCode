using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Easy
{
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

    public class TreeTask
    {
        int _sum = 0;      
             
        public IList<int> InorderTraversal(TreeNode root, List<int> arr)
        {
            if (root == null)
                return arr;
            else
                arr.Add(root.val);

            InorderTraversal(root.left, arr);
            InorderTraversal(root.right, arr);

            return arr;
        } 

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

        public int DeepestLeavesSum(TreeNode root)
        {
            int maxDepth = MaxDepth(root) - 1;

            DeepestLeavesSumHelper(root, maxDepth, 0);

            return _sum;
        }       
        public void DeepestLeavesSumHelper(TreeNode root, int maxDepth, int currentDepth)
        {
            if (root == null)
                return ;

            if (root.right == null && root.left == null && currentDepth == maxDepth)
            {
                _sum += root.val;
            }          
            else
            {
                DeepestLeavesSumHelper(root.left, maxDepth, currentDepth + 1);
                DeepestLeavesSumHelper(root.right, maxDepth, currentDepth + 1);
            }           
        }

        public TreeNode BstToGst(TreeNode root)
        {
            if (root == null)
                return root;
           
            BstToGst(root.right);
            _sum += root.val;
            root.val = _sum;
            BstToGst(root.left);

            return root;
        }

        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (cloned == null)
                return null;

            if (cloned.val == target.val)
                return cloned;

             GetTargetCopy(original, cloned.left, target);
            return   GetTargetCopy(original, cloned.right, target);
          
        }

        public TreeNode BstFromPreorder(int[] preorder)
        {
            TreeNode root = new(preorder[0]);

            for (int i = 1; i < preorder.Length; i++)
            {
                root = addIterative(root, preorder[i]);
            }

            return root;
        }
        private TreeNode AddNode(TreeNode root, int number)
        {
            if (root == null)
                return new TreeNode(number);

            if (number < root.val)
                root.left = AddNode(root.left, number);
            else
                root.right = AddNode(root.right, number);

            return root;
        }
        public TreeNode addIterative(TreeNode root, int value)
        {
       
            if (root == null)
            {
                return new TreeNode(value);
            }

            TreeNode current = root;

            while (true)
            {
                if (value < current.val)
                {
                    if (current.left == null)
                    {
                        current.left = new TreeNode(value);
                        break;
                    }
                    else
                    {
                        current = current.left;
                    }
                }
                else if (value > current.val)
                {
                    if (current.right == null)
                    {
                        current.right = new TreeNode(value);
                        break;
                    }
                    else
                    {
                        current = current.right;
                    }
                }
                else
                {
                    // Value already exists in the tree, do nothing or handle as desired
                    break;
                }
            }

            return root;
        }      
    }
}
