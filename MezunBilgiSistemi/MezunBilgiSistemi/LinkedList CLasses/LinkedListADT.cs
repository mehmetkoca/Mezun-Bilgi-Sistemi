
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
   public abstract class LinkedListADT
    {
    public Node Head;
    public int Size = 0;

    public abstract void InsertFirst(object value);
    public abstract void InsertLast(object value);
    public abstract void InsertPos(int pozisyon, object value);
    public abstract string DeleteFirst();
    public abstract void DeleteLast();
    public abstract void DeletePos(int pozisyon);
    public abstract Node getElement(int pozisyon);
    }
}
