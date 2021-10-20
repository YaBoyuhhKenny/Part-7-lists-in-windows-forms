using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part_7_lists_in_windows_forms
{
    public partial class Form1 : Form
    {
        List<int> numbers = new List<int>();
        List<string> heroes = new List<string>();
        Random generator = new Random();

        public Form1()
        {
            InitializeComponent();
            
            for (int i = 0; i < 20; i++)
            {
                numbers.Add(generator.Next(100));
            }

            lstNumbers.DataSource = numbers;

        }

        private void btnSortNumbers_Click(object sender, EventArgs e)
        {
            numbers.Sort();
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = ("Status:Numbers sorted;");
        }

        private void btnSortHeroes_Click(object sender, EventArgs e)
        {
            heroes.Sort();
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = ("Status:Heroes sorted;");
        }

        private void btnNewNumbers_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            lstNumbers.DataSource = null;
            for (int i = 0; i < 20; i++)
            {
                numbers.Add(generator.Next(100));
            }

            lstNumbers.DataSource = numbers;

            lblStatus.Text = ("Status:New numbers");
        }

        private void btnNewHeroes_Click(object sender, EventArgs e)
        {
            heroes.Clear();
            lstHeroes.DataSource = null;

            heroes.Add("SUPERMAN");
            heroes.Add("BATMAN");

            lstHeroes.DataSource = heroes;

            lblStatus.Text = ("Status:New Heroes");
        }

        private void btnRemoveNumber_Click(object sender, EventArgs e)
        {
            if (lstNumbers.SelectedIndex >= 0)
            {
                lblStatus.Text = $"Status: {(Int32)lstNumbers.SelectedItem} has been removed";
                numbers.RemoveAt(lstNumbers.SelectedIndex);
                lstNumbers.DataSource = null;
                lstNumbers.DataSource = numbers;
            }    
        }

        private void btnRemoveAllNumbers_Click(object sender, EventArgs e)
        {
            numbers.Clear();

            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;

            lblStatus.Text = $"Status: all numbers cleared";

        }

        private void btnRemoveHero_Click(object sender, EventArgs e)
        {
            if (heroes.Remove(txtRemoveHero.Text.ToUpper().Trim()))
            {
                lblStatus.Text = $"Status: removed {txtRemoveHero.Text.ToUpper().Trim()}";
            }

            else
            {
                lblStatus.Text = $"Status: {txtRemoveHero.Text.ToUpper().Trim()} isnt in the list";
            }
            
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            
        }

        private void btnAddHero_Click(object sender, EventArgs e)
        {            
            if (txtAddHero.Text.Trim() != "")
            {
                heroes.Add(txtAddHero.Text.ToUpper().Trim());
                lstHeroes.DataSource = null;
                lstHeroes.DataSource = heroes;
                lblStatus.Text = $"Status: added {txtAddHero.Text.ToUpper().Trim()}";
            }
            
            else
            {
                lblStatus.Text = "Status: no hero name entered";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
