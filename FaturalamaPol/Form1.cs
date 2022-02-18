using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaturalamaPol
{
    public partial class Form1 : Form
    {
        List<Urun> urunler = new List<Urun>();
        Urun urn = new Urun();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public void ToListViewItem(ListViewItem listViewItem)
        {
            listViewItem.SubItems[0].Text = comboBox1.SelectedItem.ToString();
            listViewItem.SubItems[1].Text = textBox1.Text.ToString();
            listViewItem.SubItems[2].Text = textBox2.Text.ToString();
            listViewItem.SubItems[3].Text = textBox3.Text.ToString();
            listViewItem.SubItems[4].Text = textBox3.Text.ToString();
            listViewItem.SubItems[5].Text = comboBox1.SelectedIndex == 1 ? "0.18" : "0.20";
        }


        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            
            urn.Urun_Adi = textBox1.Text;
            urn.Urun_Fiyati = (float)Convert.ToDouble(textBox2.Text);
            urn.Urun_Miktari = Convert.ToInt32(textBox3.Text);
            urn.Markasi = textBox4.Text;

            urunler.Add(urn);
            listView1.View=(View.Details);

            listView1.Items.Add(new ListViewItem(new string[] {comboBox1.SelectedItem.ToString(), urn.Urun_Adi,urn.Urun_Fiyati.ToString(), urn.Urun_Miktari.ToString(),urn.Markasi,
                comboBox1.SelectedIndex == 1 ? "0.20" : "0.18"}));
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {
                urunler.RemoveAt(eachItem.Index);
                listView1.Items.Remove(eachItem);
            }
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            
            urunler[listView1.SelectedItems[0].Index].Urun_Adi = textBox1.Text;
            urunler[listView1.SelectedItems[0].Index].Urun_Fiyati = (float)Convert.ToDouble(textBox2.Text);
            urunler[listView1.SelectedItems[0].Index].Urun_Miktari = Convert.ToInt32(textBox3.Text);
            urunler[listView1.SelectedItems[0].Index].Markasi = textBox4.Text;

            listView1.View = (View.Details);

            listView1.Items.Add(new ListViewItem(new string[] {comboBox1.SelectedItem.ToString(),urn.Urun_Adi,urn.Urun_Fiyati.ToString(),urn.Urun_Miktari.ToString(),urn.Markasi,
                comboBox1.SelectedIndex == 0 ? "0.20" : "0.18"}));
        }

        private void btn_SatısYap_Click(object sender, EventArgs e)
        {
            int input = Convert.ToInt32(Interaction.InputBox("Bir değer giriniz","Miktar","0",10,10));
            int tempMiktar = Convert.ToInt32(listView1.SelectedItems[0].SubItems[3].Text);

            if (tempMiktar > input)
            {
                int result = tempMiktar - input;

                urunler[listView1.SelectedItems[0].Index].Urun_Miktari = result;
                listView1.SelectedItems[0].SubItems[3].Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Yeteri kadar ürün yok.");
            }
        }
    }
}

