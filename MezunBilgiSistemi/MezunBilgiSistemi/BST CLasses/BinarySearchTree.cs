using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi.BST_CLasses
{
    public class BinarySearchTree
    {
        public bstNode root;
        public string preorder = "";
        public string inorder = "";
        public string postorder = "";
        public BinarySearchTree()
        {

        }
        public BinarySearchTree(bstNode node)
        {
            this.root = node;
        }



        public string preOrder(bstNode node, bool ilk = true)
        {
            if (ilk)
            {
                node = this.root;
            }

            if (node == null)
                return "";
            preorder += "//" + node.ogrenci.Ad + "<" + node.ogrenci.mezunbilgi.bolumAd + " \n";
            preOrder(node.sol, false);
            preOrder(node.sag, false);
            return preorder;
        }
        public string inOrder(bstNode node, bool ilk = true)
        {
            if (ilk)
            {
                node = this.root;
            }
            if (node == null)
                return "";

            inOrder(node.sol, false);
            inorder += "//" + node.ogrenci.Ad + "<" + node.ogrenci.mezunbilgi.bolumAd + " \n";
            inOrder(node.sag, false);
            return inorder;
        }
        public string postOrder(bstNode node, bool ilk = true)
        {
            if (ilk)
            {
                node = this.root;
            }
            if (node == null)
                return "";
            postOrder(node.sol, false);
            postOrder(node.sag, false);
            postorder += "//" + node.ogrenci.Ad + "<" + node.ogrenci.mezunbilgi.bolumAd + "\n ";

            return postorder;
        }
       public string notorttemp = "";
        public string GetElementByNotOrtalamasi(bstNode node)
        {
            if (node == null)
                return "";
            if (node.ogrenci.mezunbilgi.notOrtalamasi >= 90)
            {
                notorttemp += " // " + node.ogrenci.Ad + " //\n ";
            }
            GetElementByNotOrtalamasi(node.sol);
            GetElementByNotOrtalamasi(node.sag);
            return notorttemp;
        }
        public string getElementByOgrenciAd(bstNode node, int no)
        {

            if (node.ogrenci.ogrenciNo == no)
            {
                return "//" + node.ogrenci.Ad + "//" + "//" + node.ogrenci.Adres + "//" + "//" + node.ogrenci.dogumTarihiYil + "//" + "//" + node.ogrenci.ePosta + "//" +
                    "//" + node.ogrenci.ilgiAlani + "//" + "//" + node.ogrenci.ogrenciNo + "//" + "//" + node.ogrenci.Uyruk + "//" + "//" + node.ogrenci.telNo + "//" + "//" + node.ogrenci.mezunbilgi.okulAd + "//" + "//" + node.ogrenci.mezunbilgi.bolumAd + "//";
            }
            GetElementByNotOrtalamasi(node.sol);
            GetElementByNotOrtalamasi(node.sag);
            return "ogrenci bulunamadi";
        }
       public string ingilizcetemp = "";
        public string GetElementByIngilizce(bstNode node)
        {
            if (node == null)
                return null;
            if (node.ogrenci.yabanciDil == "advanced")
            {
                ingilizcetemp += " // " + node.ogrenci.Ad + " // \n";
            }
            GetElementByIngilizce(node.sol);
            GetElementByIngilizce(node.sag);
            return ingilizcetemp;

        }
        public Boolean kisiSil(String kisiAdi)
        {
            bstNode simdiki = root;
            bstNode ebeveyn = root;
            Boolean solMu = true;

            while (kisiAdi.CompareTo(simdiki.ogrenci.Ad) != 0)
            {
                ebeveyn = simdiki;
                if (kisiAdi.CompareTo(simdiki.ogrenci.Ad) < 0)
                {
                    solMu = true;
                    simdiki = simdiki.sol;
                }
                else {
                    solMu = false;
                    simdiki = simdiki.sag;
                }
                if (simdiki == null)
                    return false;
            }

            if (simdiki.sol == null && simdiki.sag == null)
            {
                if (simdiki == root)
                    root = null;
                else if (solMu)
                    ebeveyn.sol = null;
                else
                    ebeveyn.sag = null;
            }
            else if (simdiki.sag == null)
            {
                if (simdiki == root)
                    root = simdiki.sol;
                else if (solMu)
                    ebeveyn.sol = simdiki.sol;
                else
                    ebeveyn.sag = simdiki.sol;
            }
            else if (simdiki.sol == null)
            {
                if (simdiki == root)
                    root = simdiki.sag;
                else if (solMu)
                    ebeveyn.sol = simdiki.sag;
                else
                    ebeveyn.sag = simdiki.sag;
            }
            else {
                bstNode successor = this.successor(simdiki);
                if (simdiki == root)
                    root = successor;
                else if (solMu)
                    ebeveyn.sol = successor;
                else
                    ebeveyn.sag = successor;

                successor.sol = simdiki.sol;
            }
            return true;
        }
        private bstNode successor(bstNode bstnode)
        {
            bstNode ebeveyn = bstnode;
            bstNode successor = bstnode;
            bstNode simdiki = bstnode.sag;

            while (simdiki != null)
            {
                ebeveyn = successor;
                successor = simdiki;
                simdiki = simdiki.sol;
            }
            if (successor != bstnode.sag)
            {
                ebeveyn.sol = successor.sag;
                successor.sag = bstnode.sag;
            }
            return successor;
        }
        double maxDeger=0;
        bstNode temp;
        public bstNode FindBest(bstNode node)
        {
            if (node == null)
                return null;
            if (node.ogrenci.mezunbilgi.notOrtalamasi >= maxDeger)
            {
                temp = node;
                maxDeger = temp.ogrenci.mezunbilgi.notOrtalamasi;
            }
            FindBest(node.sol);
            FindBest(node.sag);
            return temp;
        }
    }
}
            

    
