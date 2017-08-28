using MezunBilgiSistemi;
using MezunBilgiSistemi.BST_CLasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LinkedList : LinkedListADT
{
    
    static bstNode root;
    
    public bstNode sortedListToBST()
    {
        int n = countNodes(Head);
        return sortedListToBSTRecur(n);
    }
    public Node temp;
    private bstNode sortedListToBSTRecur(int n,bool ilk =true)
    {
        
        if (ilk)
        {
            temp = Head;
        }
        if (n <= 0)
            return null;
        bstNode left = sortedListToBSTRecur(n / 2,false);
        bstNode root = new bstNode((Ogrenci)(temp.Data));
        root.sol = left;
        temp = temp.Next;
        root.sag = sortedListToBSTRecur(n - n / 2 - 1,false);
        return root;
    }
    int countNodes(Node head)
    {
        int count = 0;
        Node temp = head;
        while (temp != null)
        {
            temp = temp.Next;
            count++;
        }
        return count;
    }

    public override void InsertFirst(object value)
    {
        Node Temp = new Node(value);
        if ((Head == null))
        {
            Head = Temp;
        }
        else {
            Temp.Next = Head;
            Head = Temp;
        }

        Size++;
    }
    public void sortedInsert(Node new_node)
    {

        Node current;
       
        if (Head == null || ((Ogrenci)(Head.Data)).ogrenciNo >= ((Ogrenci)(new_node.Data)).ogrenciNo)
        {
            new_node.Next = Head;
            Head = new_node;
        }
    else
    {
            current = Head;
            while (current.Next != null && ((Ogrenci)(Head.Data)).ogrenciNo < ((Ogrenci)(new_node.Data)).ogrenciNo)
            {
                current = current.Next;
            }
            new_node.Next = current.Next;
            current.Next = new_node;
            
        }
        Size++;
    }
    public override void InsertLast(object value)
    {
        Node Temp = new Node(value);
        if ((Head == null))
        {
            Head = Temp;
        }
        else {
            Node count = Head;
            while ((count.Next != null))
            {
                count = count.Next;
            }

            count.Next = Temp;
        }

        Size++;
    }


    public override void InsertPos(int pozisyon, object value)
    {
        Node Temp = new Node(value);
        if (((pozisyon > Size) || (pozisyon < 0)))
        {
            throw new Exception("Hatali Pozisyon!");
        }
        else if ((pozisyon == 1))
        {
            this.InsertFirst(value);
        }
        else {
            Node count = Head;
            for (int i = 1; (i
                        < (pozisyon - 1)); i++)
            {
                if ((count.Next != null))
                {
                    count = count.Next;
                }

            }

            Temp.Next = count.Next;
            count.Next = Temp;
        }

        Size++;
    }


    public override string DeleteFirst()
    {
        Node temp=new Node();
        if ((Head != null))
        {
            
            if ((Head.Next == null))
            {
                temp = Head;
                Head = null;
                
            }
            else {
                temp = Head;
                Head = Head.Next;
            }
            
            Size--;

        }
        else
        {
            return null;
        }
        return ((Ogrenci)temp.Data).Ad;

    }


    public override void DeleteLast()
    {
        Node count = Head;
        while ((count != null))
        {
            if ((count.Next.Next == null))
            {
                count.Next = null;
                break;
            }
            else {
                count = count.Next;
            }

        }

        Size--;
    }

    void deleteNode(int ogrno)
    {
        // Store head node
        Node temp = Head, prev = null;

        // If head node itself holds the key to be deleted
        if (temp != null && ((Ogrenci)(temp.Data)).ogrenciNo == ogrno)
        {
            Head = temp.Next; 
            return;
        }

        // Search for the key to be deleted, keep track of the
        // previous node as we need to change temp.next
        while (temp != null && ((Ogrenci)(temp.Data)).ogrenciNo != ogrno)
        {
            prev = temp;
            temp = temp.Next;
        }

        
        if (temp == null) return;

       
        prev.Next = temp.Next;
    }
    public override void DeletePos(int ogrno)
    {
        // Store head node
        Node temp = Head, prev = null;

        // If head node itself holds the key to be deleted
        if (temp != null && ((Ogrenci)(temp.Data)).ogrenciNo == ogrno)
        {
            Head = temp.Next;
            return;
        }

        // Search for the key to be deleted, keep track of the
        // previous node as we need to change temp.next
        while (temp != null && ((Ogrenci)(temp.Data)).ogrenciNo != ogrno)
        {
            prev = temp;
            temp = temp.Next;
        }


        if (temp == null) return;


        prev.Next = temp.Next;

    }

            
            
        

    


    public override Node getElement(int ogrNo)
    {
        Node count = Head;
        if (Head == null)
        {
            return null;
        }
        if (((Ogrenci)(Head.Data)).ogrenciNo==ogrNo)
        {
            return Head;
        }
            for (int i = 1; i < Size; i++)
            {
                if (((Ogrenci)(count.Data)).ogrenciNo == ogrNo)
                {
                return count;
                    
                }
                if ((count.Next != null))
                {
                    count = count.Next;
                }
        }
        if (count==Head)
        {
            return null;
        }
        return count;
    }
    public void Guncelle (int ogrno,Ogrenci yenibilgi)
    {
        Node eskibilgi;
       eskibilgi=getElement(ogrno);
       eskibilgi.Data = yenibilgi;
    }
    public void bubbleSort(Node start)
    {
        bool swapped;
        Node ptr1 = new Node();
        Node lptr = null;

        
        if (ptr1 == null)
            return;

        do
        {
            swapped = false;
            ptr1 = start;

            while (ptr1.Next != lptr)
            {
                if (((Ogrenci)ptr1.Data).mezunbilgi.notOrtalamasi <= ((Ogrenci)ptr1.Next.Data).mezunbilgi.notOrtalamasi)
                {
                    this.swap(ptr1, ptr1.Next);
                    swapped = true;
                }
                ptr1 = ptr1.Next;
            }
            lptr = ptr1;
        }
        while (swapped);
    }

   
    void swap(Node first, Node second)
    {
        Node temp = new Node();
        temp.Data = first.Data;
        first.Data = second.Data;
        second.Data = temp.Data;
    }




}