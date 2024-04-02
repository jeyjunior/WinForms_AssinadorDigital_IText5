using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_AssinadorDigital_IText5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAssinarPades_Click(object sender, EventArgs e)
        {
            C2_01_SignHelloWorld c2_01_SignHelloWorld = new C2_01_SignHelloWorld();
            c2_01_SignHelloWorld.SignTest();
        }
    }
}
