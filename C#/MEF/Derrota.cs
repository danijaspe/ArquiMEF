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
    public partial class Derrota : Form
    {
        private Form actualGame;
        public Derrota(Form juegoAnt)
        {
            InitializeComponent();
            actualGame = juegoAnt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualGame.Hide();
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
