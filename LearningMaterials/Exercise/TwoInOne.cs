namespace LearningMaterials.Exercise
{
    public class TwoInOne
    {
        // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-6.0
        // Via LinkedList. AddAfter O(1). Find O(n). Last O(1)
        public LinkedList<int> MergeFirstToSecond(LinkedList<int> fristList, LinkedList<int> secondList)
        {
            foreach (var item in secondList)
            {
                if (fristList.First != null)
                    fristList.AddAfter(fristList.Find(fristList.Last(l => l < item)), item);
            }
            return fristList;
        }

        // https://www.geeksforgeeks.org/merge-two-sorted-linked-lists/?tab=article
        // https://i.stack.imgur.com/jIGhf.png
        // Time Complexity: O(N + M), where N and M are the size of list1 and list2 respectively
        // Auxiliary Space: O(1)
        public class Node
        {
            public int data;
            public Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        public class MergeLists
        {
            Node head;

            public void addToTheLast(Node node)
            {
                if (head == null)
                {
                    head = node;
                }
                else
                {
                    Node temp = head;
                    while (temp.next != null)
                        temp = temp.next;
                    temp.next = node;
                }
            }

            void printList()
            {
                Node temp = head;
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
                Console.WriteLine();
            }

            public static void RunExample(String[] args)
            {
                MergeLists llist1 = new MergeLists();
                MergeLists llist2 = new MergeLists();

                llist1.addToTheLast(new Node(5));
                llist1.addToTheLast(new Node(10));
                llist1.addToTheLast(new Node(15));

                llist2.addToTheLast(new Node(2));
                llist2.addToTheLast(new Node(3));
                llist2.addToTheLast(new Node(20));

                llist1.head = new MergeNodes().sortedMerge(llist1.head,
                                                    llist2.head);
                Console.WriteLine("Merged Linked List is:");
                llist1.printList();
            }
        }

        public class MergeNodes
        {
            public Node sortedMerge(Node headA, Node headB)
            {
                Node dummyNode = new Node(0);
                Node tail = dummyNode;
                while (true)
                {
                    if (headA == null)
                    {
                        tail.next = headB;
                        break;
                    }
                    if (headB == null)
                    {
                        tail.next = headA;
                        break;
                    }

                    if (headA.data <= headB.data)
                    {
                        tail.next = headA;
                        headA = headA.next;
                    }
                    else
                    {
                        tail.next = headB;
                        headB = headB.next;
                    }

                    tail = tail.next;
                }
                return dummyNode.next;
            }
        }
    }
}
