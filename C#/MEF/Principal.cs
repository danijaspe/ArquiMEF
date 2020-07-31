using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using MEF.Properties;

namespace MEF
{
    
    public class Principal : Form
    {
        private MainMenu mainMenu1;
        private MenuItem menuItem1;
        private MenuItem mnuSalir;
        private MenuItem menuItem3;
        private MenuItem mnuInicio;
        private MenuItem mnuParo;
        private Timer timer1;
        private IContainer components;

        // Creamos un objeto para la maquina de estados finitos
        private CMaquina heroe = new CMaquina();

        // Objetos necesarios
        public S_objeto[] Monstruos = new S_objeto[10];
        public PictureBox[] PbMonstruo = new PictureBox[10];
        private MenuItem menuItem2;
        private PictureBox pictureBox1;
        private Label labelEstatus;
        private PictureBox pictureBox2;
        private Label labelHealth;
        public S_objeto Vida;


        public Principal()
        {
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();

            //
            // TODO: agregar código de constructor después de llamar a InitializeComponent
            //

            // Inicializamos los objetos

            // Cremos un objeto para tener valores aleatorios
            Random random = new Random();

            // Recorremos todos los objetos
            for (int n = 0; n < 10; n++)
            {
                // Agregando monstruos
                Monstruos[n].x = random.Next(50, 620);
                Monstruos[n].y = random.Next(50, 420);

                // Lo indicamos activo
                Monstruos[n].activo = true;
            }
            // Agregando vida
            Vida.x = random.Next(50, 430);
            Vida.y = random.Next(50, 430);
            Vida.activo = true;
            heroe.Inicializa(ref Monstruos, Vida);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        #region Código generado por el Diseñador de Windows Forms
        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuInicio = new System.Windows.Forms.MenuItem();
            this.mnuParo = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelEstatus = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelHealth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem1});
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuInicio,
            this.mnuParo});
            this.menuItem3.Text = "Aplicacion";
            // 
            // mnuInicio
            // 
            this.mnuInicio.Index = 0;
            this.mnuInicio.Text = "Iniciar";
            this.mnuInicio.Click += new System.EventHandler(this.mnuInicio_Click);
            // 
            // mnuParo
            // 
            this.mnuParo.Index = 1;
            this.mnuParo.Text = "Pausar";
            this.mnuParo.Click += new System.EventHandler(this.mnuParo_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.mnuSalir});
            this.menuItem1.Text = "Opciones";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Reiniciar";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Index = 1;
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-34, -65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(496, 193);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // labelEstatus
            // 
            this.labelEstatus.AutoSize = true;
            this.labelEstatus.BackColor = System.Drawing.Color.SaddleBrown;
            this.labelEstatus.Font = new System.Drawing.Font("Matura MT Script Capitals", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstatus.Location = new System.Drawing.Point(49, 9);
            this.labelEstatus.Name = "labelEstatus";
            this.labelEstatus.Size = new System.Drawing.Size(270, 37);
            this.labelEstatus.TabIndex = 4;
            this.labelEstatus.Text = "Esperando a empezar";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::MEF.Properties.Resources.health;
            this.pictureBox2.Location = new System.Drawing.Point(1, 58);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 112);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // labelHealth
            // 
            this.labelHealth.AutoSize = true;
            this.labelHealth.BackColor = System.Drawing.Color.Green;
            this.labelHealth.Font = new System.Drawing.Font("Matura MT Script Capitals", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHealth.Location = new System.Drawing.Point(35, 96);
            this.labelHealth.Name = "labelHealth";
            this.labelHealth.Size = new System.Drawing.Size(58, 32);
            this.labelHealth.TabIndex = 6;
            this.labelHealth.Text = "800";
            this.labelHealth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Principal
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackgroundImage = global::MEF.Properties.Resources.map;
            this.ClientSize = new System.Drawing.Size(762, 523);
            this.Controls.Add(this.labelHealth);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelEstatus);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(780, 570);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(780, 570);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maquina de estados finitos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>


        private void mnuSalir_Click(object sender, System.EventArgs e)
        {
            // Cerramos la ventana y finalizamos la aplicacion
            Application.Exit();
        }

        private void mnuInicio_Click(object sender, System.EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void mnuParo_Click(object sender, System.EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            // Esta funcion es el handler del timer
            // Aqui tendremos la logica para actualizar nuestra maquina de estados

            // Actualizamos a la maquina
            heroe.Control();

            // Mandamos a redibujar la pantalla
            this.Invalidate();

            if (heroe.EstadoM == (int)CMaquina.estados.MUERTO)
            {
                timer1.Enabled = false;
                Derrota muerte = new Derrota(this);
                muerte.Show();
            }
            else if (heroe.EstadoM == (int)CMaquina.estados.ALEATORIO)
            {
                timer1.Enabled = false;
                Victoria exito = new Victoria(this);
                exito.Show();
            }
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Creamos la fuente y la brocha para el texto
            Font fuente = new Font("Arial", 16);
            SolidBrush brocha = new SolidBrush(Color.Black);
            Image warrior = Resources.warriorg;
            Image monster = Resources.devil;
            Image life = Resources.lifeg;
            Image dead = Resources.deadg;


            // Dibujamos el robot
            if (heroe.EstadoM == (int)CMaquina.estados.MUERTO)
                e.Graphics.DrawImage(dead, heroe.CoordX - 4, heroe.CoordY - 4, 50, 50);
            else
                e.Graphics.DrawImage(warrior, heroe.CoordX - 4, heroe.CoordY - 4, 60, 60);
            // Dibujamos los objetos
            for (int n = 0; n < 10; n++)
                if (Monstruos[n].activo == true)
                    e.Graphics.DrawImage(monster, Monstruos[n].x - 4, Monstruos[n].y - 4, 50, 50);

            // Dibujamos la bateria
                e.Graphics.DrawImage(life, Vida.x - 4, Vida.y - 4, 35, 35);
            // Indicamos el estado en que se encuentra la maquina
            labelEstatus.Text = heroe.EstadoStr;
            labelHealth.Text = heroe.VidaRestante.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal reinicio = new Principal();
            reinicio.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

    }
}
