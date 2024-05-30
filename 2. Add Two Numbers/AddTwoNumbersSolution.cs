/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

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

public class AddTwoNumbersSolution
{
    static void Main(string[] args)
    {
        ListNode l1_1 = new ListNode(1);
        ListNode l1_2 = new ListNode(2);
        ListNode l1_3 = new ListNode(3);
        l1_1.next = l1_2;
        l1_2.next = l1_3;

        ListNode l2_1 = new ListNode(4);
        ListNode l2_2 = new ListNode(5);
        ListNode l2_3 = new ListNode(6);
        l2_1.next = l2_2;
        l2_2.next = l2_3;

        //随便定义两个链表作为测试用例，实际上两个链表的长度可以不相等
        //期望结果 123 + 456 = 579

        var result1 = AddTwoNumbers1(l1_1, l2_1);
        Console.Write("result1 = ");
        while (result1 != null)
        {
            Console.Write(result1.val);
            result1 = result1.next;
        }

        Console.Write("\n"); //换行

        var result2 = AddTwoNumbers2(l1_1, l2_1);
        Console.Write("result2 = ");
        while (result2 != null)
        {
            Console.Write(result2.val);
            result2 = result2.next;
        }
    }

    /// <summary>
    /// 比较简洁的版本
    /// </summary>
    public static ListNode AddTwoNumbers1(ListNode l1, ListNode l2)
    {
        ListNode result = new ListNode(0);//新建一个用于储存结果的链表
        ListNode current = result;//当前节点
        int carry = 0;//当前进位
        while (l1 != null || l2 != null || carry != 0)
        {
            int sum = carry;//当前节点的值等于进位的值
            if(l1 != null)
            {
                //如果链表1不为空，当前节点的值加上链表1的值，并移动到下一个节点
                sum = sum + l1.val;
                l1 = l1.next;
            }
            if (l2 != null)
            {
                //如果链表2不为空，当前节点的值加上链表1的值，并移动到下一个节点
                sum = sum + l2.val;
                l2 = l2.next;
            }
            carry = sum / 10;
            current.next = new ListNode(sum % 10);
            current = current.next;
        }
        return result.next;
    }

    /// <summary>
    /// 把carry换成了一个bool值，可能对初学者来说读起来更容易理解逻辑？
    /// </summary>
    /// <param name="l1"></param>
    /// <param name="l2"></param>
    /// <returns></returns>
    public static ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
    {
        ListNode result = new ListNode(0);//新建一个用于储存结果的链表
        ListNode current = result;//当前节点
        bool needCarry = false;//是否需要进位
        while (l1 != null || l2 != null || needCarry)
        {
            int sum = 0;
            if (needCarry) 
            {
                sum = sum + 1;//需要进位的话，当前节点的值加1
            }
            if (l1 != null)
            {
                //如果链表1不为空，当前节点的值加上链表1的值，并移动到下一个节点
                sum = sum + l1.val;
                l1 = l1.next;
            }
            if (l2 != null)
            {
                //如果链表2不为空，当前节点的值加上链表1的值，并移动到下一个节点
                sum = sum + l2.val;
                l2 = l2.next;
            }
            needCarry = sum >= 10;//大于10的话，下一个节点需要进位
            if (needCarry)
            {
                current.next = new ListNode(sum - 10);//将当前结果储存位下一个节点
            }
            else
            {
                current.next = new ListNode(sum);
            }
            current = current.next;//移动到下一个节点
        }
        return result.next;//因为第一位占位用的0，所以返回的时候从第二位开始
    }
}