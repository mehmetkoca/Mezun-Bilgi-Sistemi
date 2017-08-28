using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MezunBilgiSistemi.BST_CLasses;
using MezunBilgiSistemi.LinkedList_CLasses;

namespace MezunBilgiSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }
    
       
        LinkedList ogrenciler=new LinkedList();
        LinkedList ogrencilerSortedByNotOrtalamasi = new LinkedList();
        LinkedList sirketler = new LinkedList();
        BinarySearchTree GlobalTree= new BinarySearchTree();
        
        private void button1_Click(object sender, EventArgs e)
        {
            grpxSirket.Visible = false;
            grpxAgac.Visible = false;
            grpxOgrenci.Visible = true;
            
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            grpxOgrenci.Visible = false;
            grpxAgac.Visible = false;
            grpxSirket.Visible = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Ogrenci ogr = new Ogrenci();
            Node yeniNode = new Node();
            bstNode yeniBstNode = new bstNode();
            if (txtAd.Text==""|| txtAdres.Text == "" || txtBolumAd.Text == "" || txtkayitSirketAd.Text == "" || txtOkulAdi.Text == "" 
                || txtStajTarihi.Text == "" || txtTelNo.Text == "" || txtUyruk.Text == "" || txtYabanciDil.Text == "" || txtbaslangicTarihi.Text == "" ||
                txtBitisTarihi.Text == "" || txtDogumTarih.Text == "" || txtePosta.Text == "" || txtIlgiAlanlari.Text == "")
            {
                MessageBox.Show("Alanların Hepsini Doldurunuz Lütfen !!!!");
                return;
            }
            ogr.Ad = txtAd.Text;
            ogr.Adres = txtAdres.Text;
            ogr.dogumTarihiYil = Convert.ToInt32(txtDogumTarih.Text);
            ogr.ePosta = txtePosta.Text;
            ogr.ilgiAlani = txtIlgiAlanlari.Text;
            ogr.ogrenciNo = Convert.ToInt32(txtOgrenciNo.Text);
            ogr.telNo = Convert.ToInt32(txtTelNo.Text);
            ogr.Uyruk = txtUyruk.Text;
            ogr.yabanciDil = txtYabanciDil.Text;
            ogr.mezunbilgi.basariBelgeli = chckBasariBelgesi.Checked;
            ogr.mezunbilgi.baslangicTarihi = txtbaslangicTarihi.Text;
            ogr.mezunbilgi.bitisTarihi =txtBitisTarihi.Text;
            ogr.mezunbilgi.bolumAd = txtBolumAd.Text;
            ogr.mezunbilgi.notOrtalamasi = Convert.ToInt16(txtNotOrtalamasi.Text);
            ogr.mezunbilgi.okulAd = txtOkulAdi.Text;
            ogr.staj.deparOrGorev = txtDepartmanOrGorev.Text;
            ogr.staj.sirketAd = txtkayitSirketAd.Text;
            ogr.staj.stajTarihi =txtStajTarihi.Text;
            if (ogr.mezunbilgi.basariBelgeli==true)//basarı belgeli olma durumu
            {
                ogr.mezunbilgi.notOrtalamasi += 10;
            }
            yeniNode.Data = ogr;
            if (ogrenciler.Head != null)
            {
                if ((ogrenciler.getElement(ogr.ogrenciNo)) != null)
                {
                    if (((Ogrenci)(ogrenciler.getElement(ogr.ogrenciNo).Data)).ogrenciNo == ((Ogrenci)yeniNode.Data).ogrenciNo)
                    {
                        MessageBox.Show("Eklemek istediğiniz Oğrenci zaten var Güncelleme yapmak için Güncelle butonuna basınız.");
                        return;
                    }
                }
                
            }
           
            ogrenciler.sortedInsert(yeniNode);
            BinarySearchTree Ogrenciler = new BinarySearchTree(ogrenciler.sortedListToBST());
            GlobalTree = Ogrenciler;
            ogrencilerSortedByNotOrtalamasi.Head = ogrenciler.Head;
            ogrencilerSortedByNotOrtalamasi.Size = ogrenciler.Size;
            ogrencilerSortedByNotOrtalamasi.bubbleSort(ogrencilerSortedByNotOrtalamasi.Head);
            
        }

        private void btnMezunKaydet_Click(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Ogrenci ogr = new Ogrenci();
            Node yeniNode = new Node();
            bstNode yeniBstNode = new bstNode();
            if (txtAd.Text == "" || txtAdres.Text == "" || txtBolumAd.Text == "" || txtkayitSirketAd.Text == "" || txtOkulAdi.Text == ""
               || txtStajTarihi.Text == "" || txtTelNo.Text == "" || txtUyruk.Text == "" || txtYabanciDil.Text == "" || txtbaslangicTarihi.Text == "" ||
               txtBitisTarihi.Text == "" || txtDogumTarih.Text == "" || txtePosta.Text == "" || txtIlgiAlanlari.Text == "")
            {
                MessageBox.Show("Alanların Hepsini Doldurunuz Lütfen !!!!");
                return;
            }
            ogr.Ad = txtAd.Text;
            ogr.Adres = txtAdres.Text;
            ogr.dogumTarihiYil = Convert.ToInt32(txtDogumTarih.Text);
            ogr.ePosta = txtePosta.Text;
            ogr.ilgiAlani = txtIlgiAlanlari.Text;
            ogr.ogrenciNo = Convert.ToInt32(txtOgrenciNo.Text);
            ogr.telNo = Convert.ToInt32(txtTelNo.Text);
            ogr.Uyruk = txtUyruk.Text;
            ogr.yabanciDil = txtYabanciDil.Text;
            ogr.mezunbilgi.basariBelgeli = chckBasariBelgesi.Checked;
            ogr.mezunbilgi.baslangicTarihi = txtbaslangicTarihi.Text;
            ogr.mezunbilgi.bitisTarihi = txtBitisTarihi.Text;
            ogr.mezunbilgi.bolumAd = txtBolumAd.Text;
            ogr.mezunbilgi.notOrtalamasi = Convert.ToInt16(txtNotOrtalamasi.Text);
            ogr.mezunbilgi.okulAd = txtOkulAdi.Text;
            ogr.staj.deparOrGorev = txtDepartmanOrGorev.Text;
            ogr.staj.sirketAd = txtkayitSirketAd.Text;
            ogr.staj.stajTarihi = txtStajTarihi.Text;
            if (ogr.mezunbilgi.basariBelgeli == true && ogr.mezunbilgi.notOrtalamasi != 100)
            {
                    ogr.mezunbilgi.notOrtalamasi += 10;
            }
            yeniNode.Data = ogr;
            if (ogrenciler.getElement(ogr.ogrenciNo)!=null)
            {
                if (((Ogrenci)(ogrenciler.getElement(ogr.ogrenciNo)).Data).ogrenciNo == ((Ogrenci)yeniNode.Data).ogrenciNo)
                {
                    ogrenciler.Guncelle(ogr.ogrenciNo, ogr);
                    MessageBox.Show("Güncelle Gerçekleşmiştir.");
                }
                else
                {
                    MessageBox.Show("Güncellemek istediğiniz Öğrenci Bulunmamaktadır Lütfen Ogrenci Numarasını Tekrar Giriniz!");
                    return;
                }
            }
            
           
            BinarySearchTree Ogrenciler = new BinarySearchTree(ogrenciler.sortedListToBST());
            GlobalTree = Ogrenciler;
            ogrencilerSortedByNotOrtalamasi.Head = ogrenciler.Head;
            ogrencilerSortedByNotOrtalamasi.Size = ogrenciler.Size;
            ogrencilerSortedByNotOrtalamasi.bubbleSort(ogrencilerSortedByNotOrtalamasi.Head);
            
        }

        private void btnOgrenciSil_Click(object sender, EventArgs e)
        {
            if (txtOgrenciSil.Text=="")
            {
                MessageBox.Show("Ogrenci Numarasi Giriniz");
                return;
            }
            bstNode yeniBstNode = new bstNode();
            int ogrenciNo = Convert.ToInt16(txtOgrenciSil.Text);
            if (ogrenciler.getElement(ogrenciNo) != null)
            {
              
                    ogrenciler.DeletePos(ogrenciNo);
                BinarySearchTree Ogrenciler = new BinarySearchTree(ogrenciler.sortedListToBST());
                GlobalTree = Ogrenciler;
                ogrencilerSortedByNotOrtalamasi.Head = ogrenciler.Head;
                ogrencilerSortedByNotOrtalamasi.Size = ogrenciler.Size;
                if (ogrenciler.Head!=null)
                {
                    ogrencilerSortedByNotOrtalamasi.bubbleSort(ogrencilerSortedByNotOrtalamasi.Head);
                }
            }
            else
            {
                MessageBox.Show("Güncellemek istediğiniz Öğrenci Bulunmamaktadır Lütfen Ogrenci Numarasını Tekrar Giriniz!");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            grpxSirket.Visible = false;
            grpxOgrenci.Visible = false;
            grpxAgac.Visible = true;
        }

        private void btnIseAl_Click(object sender, EventArgs e)
        {
            bstNode temp;
            temp=GlobalTree.FindBest(GlobalTree.root);
            if (temp==null)
            {
                MessageBox.Show("Ogrenci olmadığı için işe alım Gerçekleşememiştir");return;
            }
            MessageBox.Show(temp.ogrenci.Ad + "  işe alınmıştır .");
        }

        private void btnOgrenciAra_Click(object sender, EventArgs e)
        {
            Node temp = new Node();
            temp=ogrenciler.getElement(Convert.ToInt16(txtOgrenciAra.Text));
            if (temp==null)
            {
                MessageBox.Show("Aradığınız Ogrenci bulunmamaktadır.");
                return;
            }
            lblOgrAd.Text = ((Ogrenci)temp.Data).Ad;
            lblOgrAdres.Text = ((Ogrenci)temp.Data).Adres;
            lblOgrOkulAdi.Text = ((Ogrenci)temp.Data).mezunbilgi.okulAd;
            lblOgrNo.Text = ((Ogrenci)temp.Data).ogrenciNo.ToString();
            lblOgrOrtalama.Text = ((Ogrenci)temp.Data).mezunbilgi.notOrtalamasi.ToString();
            lblOgrTel.Text = ((Ogrenci)temp.Data).telNo.ToString();
            lblOgrMail.Text = ((Ogrenci)temp.Data).ePosta;
            lblOgrUyruk.Text = ((Ogrenci)temp.Data).Uyruk;
            lblOgrYabanciDil.Text = ((Ogrenci)temp.Data).yabanciDil;
            lblOgrDogumTarihi.Text = ((Ogrenci)temp.Data).dogumTarihiYil.ToString();
            lblOgrIlgiAlani.Text = ((Ogrenci)temp.Data).ilgiAlani;
            lblOgrBolum.Text = ((Ogrenci)temp.Data).mezunbilgi.bolumAd;
            lblOgrOkulBas.Text = ((Ogrenci)temp.Data).mezunbilgi.baslangicTarihi;
            lblOgrOkulBit.Text = ((Ogrenci)temp.Data).mezunbilgi.bitisTarihi;
            lblOgrBasariBelge.Text = ((Ogrenci)temp.Data).mezunbilgi.basariBelgeli ? "Başari Belgesi var ":"Başari Belgesi yok";
            lblOgrStajAdi.Text = ((Ogrenci)temp.Data).staj.sirketAd;
            lblOgrStajTarih.Text = ((Ogrenci)temp.Data).staj.stajTarihi;
            lblOgrStajGorev.Text = ((Ogrenci)temp.Data).staj.deparOrGorev;




        }

        private void btnSirketKaydet_Click(object sender, EventArgs e)
        {
            Sirketler sirket = new Sirketler();
            sirket.sirketAd = txtSirketAdi.Text;
            sirket.adres = txtSirketAdres.Text;
            sirket.telNo = Convert.ToInt16( txtSirketTel.Text);
            sirketler.InsertFirst(sirket);
            MessageBox.Show(sirket.sirketAd + " adlı sirket kaydınız oluşturulmuştur");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            lstMezunListele.Items.Clear();
            int sayac = ogrencilerSortedByNotOrtalamasi.Size;
            for (int i = 1; i <=sayac ; i++)
            {
                lstMezunListele.Items.Add(ogrencilerSortedByNotOrtalamasi.DeleteFirst());
            }
            ogrencilerSortedByNotOrtalamasi.Head = ogrenciler.Head;
            ogrencilerSortedByNotOrtalamasi.Size = ogrenciler.Size;

        }

        private void btnSirala_Click(object sender, EventArgs e)
        {
            lstMezunListele.Items.Clear();
            Node temp = ogrenciler.Head;
            int sayac = ogrenciler.Size;
            for (int i = 1; i <= sayac; i++)
            {
                if (temp!=null)
                {
                    if (((Ogrenci)(temp.Data)).yabanciDil == cmbxIngilizceSeviyesi.SelectedItem.ToString())
                    {
                        lstMezunListele.Items.Add(((Ogrenci)ogrenciler.getElement(((Ogrenci)(temp.Data)).ogrenciNo).Data).Ad);
                        if (temp.Next!=null)
                        {
                            temp = temp.Next;
                        }
                       
                    }
                    if (temp.Next != null)
                    {
                        temp = temp.Next;
                    }
                    

                }
               
                
            }
        }

        private void btnInorder_Click(object sender, EventArgs e)
        {
            txtAgacKisiler.Clear();
            txtAgacKisiler.Text = GlobalTree.inOrder(GlobalTree.root);
            GlobalTree.inorder = "";
        }

        private void btnPreorder_Click(object sender, EventArgs e)
        {
            txtAgacKisiler.Clear();
            txtAgacKisiler.Text = GlobalTree.preOrder(GlobalTree.root);
            GlobalTree.preorder = "";
        }

        private void btnPostorder_Click(object sender, EventArgs e)
        {
            txtAgacKisiler.Clear();
            txtAgacKisiler.Text = GlobalTree.postOrder(GlobalTree.root);
            GlobalTree.postorder = "";
        }

        private void btn90uzeri_Click(object sender, EventArgs e)
        {
            txtdoksanuzeri.Clear();
            txtdoksanuzeri.Text = GlobalTree.GetElementByNotOrtalamasi(GlobalTree.root);
            GlobalTree.notorttemp = "";
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            txtdoksanuzeri.Clear();
            txtingilizceadvanced.Text = GlobalTree.GetElementByIngilizce(GlobalTree.root);
            GlobalTree.ingilizcetemp = "";
        }
    }
}
