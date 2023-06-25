using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

    public class ListNodeTask
    {
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

        public ListNode MergeNodes(ListNode head) 
        {            
            return MergeNodesHelper(head.next, new ListNode());
        } // 2181. Merge Nodes in Between Zeros
        public ListNode MergeNodesHelper(ListNode head, ListNode result)
        {
            if (head == null || head.next == null)
                return result;

            if (head.val == 0)
            {
                result.next = new ListNode();
                MergeNodesHelper(head.next, result.next);
            }
            else
            {
                result.val += head.val;
                MergeNodesHelper(head.next, result);
            }

            return result;          
        }
       
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode();
            ListNode head = result;
            int sum = 0;
            while (l1 != null || l2 != null || sum > 0) // to keep running if we hava a value in l1, l2 or carry
            {
                // two if statments because l1 and l2 can be of different sizes
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }
                result.next = new ListNode(sum % 10); //digit
                sum /= 10; //carry
                result = result.next;
            }
            return head.next;
        }             
             
    }
}
