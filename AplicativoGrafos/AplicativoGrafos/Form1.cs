using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicativoGrafos
{
    public partial class Form1 : Form
    {
        int contador =1;  // contador de nodos
        const int botonSize = 30; //tamaño de botón
        char[] letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); // Es para asignar letras ala 1ra Fila y Columna
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e) // Es el boton añadir
        {
            string nodoNombre1 = this.txtNodo1.Text;
            string nodoNombre2 = this.txtNodo2.Text;
            int peso = (int)this.nupArista.Value;

            if (string.IsNullOrWhiteSpace(nodoNombre1) || string.IsNullOrWhiteSpace(nodoNombre2))
            {
                MessageBox.Show("Por favor, ingrese nombres válidos para los nodos.");
                return;
            }

            if (peso <= 1)
            {
                MessageBox.Show("El peso debe ser mayor que 1.");
                return;
            }
            NodoF nodo2 = new NodoF(nodoNombre2, null);
            AristaF aristaConexion = new AristaF(peso, nodo2);
            NodoF nodo1 = new NodoF(nodoNombre1, aristaConexion);
            

            contador++;
            this.lblCont.Text = (contador - 1) + "";
            string resp= $"{nodo1.Nombre} conectado con {nodo2.Nombre}";
            this.lbxRespuestas.Items.Add(resp); 
        }
        /// <summary>
        /// Metodo unicamente para generar las matrices de los Botónes, además tiene ciertos tags registrados por fotones
        /// </summary>
        /// <param name="tamaño"></param>
        private void GenerarMatrizBotones(int tamaño)
        {
            pnlMatriz1.Controls.Clear();
            pnlMatriz2.Controls.Clear();

            Button[,] botonesMatriz1 = new Button[tamaño, tamaño];
            Button[,] botonesMatriz2 = new Button[tamaño, tamaño];

            for (int i = 0; i < tamaño; i++)
            {
                for (int j = 0; j < tamaño; j++)
                {
                    // Crear botón para pnlMatriz1
                    botonesMatriz1[i, j] = new Button();
                    botonesMatriz1[i, j].Size = new Size(botonSize, botonSize);
                    botonesMatriz1[i, j].Location = new Point(j * botonSize, i * botonSize);
                    botonesMatriz1[i, j].Tag = $"({i},{j})";
                    if (i == 0 && j == 0)
                    {
                        botonesMatriz1[i, j].Text = "";
                    }
                    else if (i == 0)
                    {
                        botonesMatriz1[i, j].Text = letras[j - 1].ToString();
                    }
                    else if (j == 0)
                    {
                        botonesMatriz1[i, j].Text = letras[i - 1].ToString();
                    }
                    else
                    {
                        botonesMatriz1[i, j].Text = "";
                    }
                    pnlMatriz1.Controls.Add(botonesMatriz1[i, j]);

                    // Crear botón para pnlMatriz2
                    botonesMatriz2[i, j] = new Button();
                    botonesMatriz2[i, j].Size = new Size(botonSize, botonSize);
                    botonesMatriz2[i, j].Location = new Point(j * botonSize, i * botonSize);
                    botonesMatriz2[i, j].Tag = $"{i}{j}";
                    if (i == 0 && j == 0)
                    {
                        botonesMatriz2[i, j].Text = "";
                    }
                    else if (i == 0)
                    {
                        botonesMatriz2[i, j].Text = letras[j - 1].ToString();
                    }
                    else if (j == 0)
                    {
                        botonesMatriz2[i, j].Text = letras[i - 1].ToString();
                    }
                    else
                    {
                        botonesMatriz2[i, j].Text = "";
                    }
                    pnlMatriz2.Controls.Add(botonesMatriz2[i, j]);
                }
            }
            for (int k = 1; k < tamaño; k++)
            {
                botonesMatriz1[k, k].Text = "-";
                botonesMatriz2[k, k].Text = "-";
            }
        }

        private void btnFloyd_Click(object sender, EventArgs e)
        {
            GenerarMatrizBotones(contador);
        }
    }
}
