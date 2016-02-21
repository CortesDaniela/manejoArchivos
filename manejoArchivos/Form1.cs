using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace manejoArchivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Enabled = false;
        }

        TextWriter archivo;
        String ruta, rutal;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                FolderBrowserDialog fod = new FolderBrowserDialog();
                fod.Description = "Seleccione la ruta para almacenar el documento";
                fod.RootFolder = Environment.SpecialFolder.Desktop;
                if (fod.ShowDialog() == DialogResult.OK)
                {
                    ruta = fod.SelectedPath;
                    String mensaje;
                    mensaje = richTextBox1.Text;
                    archivo = new StreamWriter(ruta + "\\" + textBox1.Text + ".txt");
                    archivo.Write(mensaje);
                    archivo.Close();
                    MessageBox.Show("correcto");
                }
            }
            else MessageBox.Show("No has escrito el nombre del archivo ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = " Archivos txt(*.txt)|*.txt";
            open.Title = "Archivos .txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                rutal = open.FileName;
                textBox2.Text = rutal;
                StreamReader file = new StreamReader(rutal);
                while (file.Peek() != -1)
                {
                    richTextBox1.Text += file.ReadLine() + "\n";
                }
                file.Close();
            }
            open.Dispose();                       

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text=rutal;

           String mensaje;
           mensaje = richTextBox1.Text;
           archivo = new StreamWriter(rutal);
           archivo.Write(mensaje);
           archivo.Close();
           MessageBox.Show("perfecto");
        }
        }
    

        
    }

