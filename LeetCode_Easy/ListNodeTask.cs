﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}