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
            ///FINES DE DEVELOPING. SE PUEDE COMENTAR SI LE ESTORBA
            //Creo mis nodos desde codigo desde un inicio
            //con el fin de programar mas rapido
            
            //Primer grafo
            /*NodoF A = new NodoF("A");
            NodoF B = new NodoF("B");
            NodoF D = new NodoF("D");
            NodoF C = new NodoF("C");

            //Creo las aristas
            AristaF A1 = new AristaF(3, B);
            AristaF A2 = new AristaF(4, C);
            AristaF B1 = new AristaF(5, D);
            AristaF D1 = new AristaF(8, A);
            AristaF C1 = new AristaF(3, D);

            //Conecto con los nodos
            A.Aristas.Add(A1);
            A.Aristas.Add(A2);
            B.Aristas.Add(B1);
            C.Aristas.Add(C1);
            D.Aristas.Add(D1);

            //Agrego los nodos al grado. 
            GFloyd floyd = new GFloyd(new NodoF[]
            {
                A, B, C, D
            });
            
            //Ejecuto el algoritmo
            floyd.BuscarCaminos(); */

            //Segundo grafo
            /*NodoF v1 = new NodoF("V1");
            NodoF v2 = new NodoF("V2");
            NodoF v3 = new NodoF("V3");
            NodoF v4 = new NodoF("V4");
            NodoF v5 = new NodoF("V5");
            NodoF v6 = new NodoF("V6");
            NodoF v7 = new NodoF("V7");

            AristaF v1_1 = new AristaF(2, v2);
            AristaF v1_2 = new AristaF(1, v4);
            AristaF v4_1 = new AristaF(2, v3);
            AristaF v4_2 = new AristaF(8, v6);
            AristaF v4_3 = new AristaF(4, v7);
            AristaF v4_4 = new AristaF(2, v5);
            AristaF v2_1 = new AristaF(1, v4);
            AristaF v2_2 = new AristaF(3, v5);
            AristaF v3_1 = new AristaF(4, v1);
            AristaF v3_2 = new AristaF(5, v6);
            AristaF v5_1 = new AristaF(6, v7);
            AristaF v7_1 = new AristaF(1, v6);

            v1.Aristas.Add(v1_1);
            v1.Aristas.Add(v1_2);
            v4.Aristas.Add(v4_1);
            v4.Aristas.Add(v4_2);
            v4.Aristas.Add(v4_3);
            v4.Aristas.Add(v4_4);
            v2.Aristas.Add(v2_1);
            v2.Aristas.Add(v2_2);
            v3.Aristas.Add(v3_1);
            v3.Aristas.Add(v3_2);
            v5.Aristas.Add(v5_1);
            v7.Aristas.Add(v7_1);

            GFloyd floyd = new GFloyd(new NodoF[]
            {
                v1, v2, v3, v4, v5, v6, v7
            });
            floyd.BuscarCaminos();*/
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

            if (peso < 1)
            {
                MessageBox.Show("El peso debe ser mayor o igual que 1.");
                return;
            }
            NodoF nodo2 = new NodoF(nodoNombre2);
            AristaF aristaConexion = new AristaF(peso, nodo2);
            NodoF nodo1 = new NodoF(nodoNombre1, aristaConexion);


            this.lbxRespuestas.Items.Clear(); //Es necesario primero siempre limpiar la lista.
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
