using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi.BST_CLasses
{
    public class bstNode
    {
        public Ogrenci ogrenci;

        public bstNode sol;

        public bstNode sag;

        public bstNode()
        {
           
        }

        public bstNode(Ogrenci ogrenci)
        {
            this.ogrenci = ogrenci;
          
            this.sol = null;
            this.sag = null;
        }
    }
}
