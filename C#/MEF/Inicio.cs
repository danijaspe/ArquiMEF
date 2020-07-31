using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEF
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new Inicio());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal NuevoJuego = new Principal();
            NuevoJuego.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
