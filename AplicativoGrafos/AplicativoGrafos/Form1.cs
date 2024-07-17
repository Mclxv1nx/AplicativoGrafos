using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AplicativoGrafos
{
    public partial class Form1 : Form
    {
        int contador = 0;  // contador de nodos
        List<NodoF> nodosExistentes = new List<NodoF>(); // Lista para mantener los nodos existentes
        GFloyd floyd;
        Dijkstra dijkstra;

        public Form1()
        {
            InitializeComponent();
            dijkstra = new Dijkstra();

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
            floyd.BuscarCaminos();
            Console.WriteLine(floyd.DarTodoslosCaminos());
            Console.WriteLine(floyd.CambiosMatrizPesos);
            Console.WriteLine(floyd.CambiosMatrizRecorridos);*/
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
            AristaF v2_1 = new AristaF(3, v4);
            AristaF v2_2 = new AristaF(10, v5);
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
            floyd.BuscarCaminos();
            Console.WriteLine(floyd.DarTodoslosCaminos());*/
        }

        private void btnConectar_Click(object sender, EventArgs e) // Es el botón añadir
        {
            string nodoNombre1 = this.txtNodo1.Text.Trim();
            string nodoNombre2 = this.txtNodo2.Text.Trim();
            int peso = (int)this.nupArista.Value;

            // Validar los campos de entrada
            if (string.IsNullOrWhiteSpace(nodoNombre1) || string.IsNullOrWhiteSpace(nodoNombre2))
            {
                MessageBox.Show("Por favor, ingrese nombres válidos para los nodos.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(this.nupArista.Value.ToString(), out peso) || peso < 1)
            {
                MessageBox.Show("El peso debe ser un número entero mayor o igual que 1.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nodoNombre1.Equals(nodoNombre2, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Los nombres de los nodos no pueden ser iguales.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar nodos existentes
            NodoF nodo1 = nodosExistentes.FirstOrDefault(n => n.Nombre.Equals(nodoNombre1, StringComparison.OrdinalIgnoreCase));
            NodoF nodo2 = nodosExistentes.FirstOrDefault(n => n.Nombre.Equals(nodoNombre2, StringComparison.OrdinalIgnoreCase));

            // Si el nodo no existe, crearlo y agregarlo a la lista
            if (nodo1 == null)
            {
                nodo1 = new NodoF(nodoNombre1);
                nodosExistentes.Add(nodo1);
                dijkstra.AgregarNodo(nodoNombre1);
                contador++;
            }

            if (nodo2 == null)
            {
                nodo2 = new NodoF(nodoNombre2);
                nodosExistentes.Add(nodo2);
                dijkstra.AgregarNodo(nodoNombre2);
                contador++;
            }

            // Crear y agregar la arista
            AristaF aristaConexion = new AristaF(peso, nodo2);
            nodo1.Aristas.Add(aristaConexion);
            dijkstra.AgregarArista(nodoNombre1, nodoNombre2, peso);

            // Actualizar la interfaz de usuario
            this.lbxRespuestas.Items.Clear(); // Es necesario primero siempre limpiar la lista.
            this.lblCont.Text = contador.ToString();
            string resp = $"{nodo1.Nombre} conectado con {nodo2.Nombre} con peso {peso}";
            this.lbxRespuestas.Items.Add(resp);

            // Mostrar la estructura actual del grafo en el ListBox
            MostrarEstructuraGrafo();
        }

        private void MostrarEstructuraGrafo()
        {
            this.lbxRespuestas.Items.Add("Estructura actual del grafo:");
            foreach (var nodo in nodosExistentes)
            {
                foreach (var arista in nodo.Aristas)
                {
                    string conexion = $"{nodo.Nombre} ---{arista.Peso}---> {arista.Nodo.Nombre}";
                    this.lbxRespuestas.Items.Add(conexion);
                }
            }
        }

        private void btnFloyd_Click(object sender, EventArgs e)
        {
            if (nodosExistentes.Count == 0)
            {
                MessageBox.Show("No hay nodos en el grafo para ejecutar el algoritmo de Floyd.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            floyd = new GFloyd(nodosExistentes.ToArray());
            floyd.BuscarCaminos();

            this.lbxRecorridos.Items.Clear();
            this.lbxRecorridos.Items.Add("Matriz de recorridos:");
            this.lbxRecorridos.Items.AddRange(ConvertirMatrizAStringArray(floyd.MatrizRecorridos()));

            this.lbxPonderaciones.Items.Clear();
            this.lbxPonderaciones.Items.Add("Matriz de Ponderaciones:");
            this.lbxPonderaciones.Items.AddRange(ConvertirMatrizAStringArray(floyd.MatrizPesos()));
        }

        private string[] ConvertirMatrizAStringArray(string matriz)
        {
            return matriz.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void btnDijkstra_Click(object sender, EventArgs e)
        {
            string nodoInicio = this.txtNodoInicio.Text.Trim();

            if (string.IsNullOrWhiteSpace(nodoInicio))
            {
                MessageBox.Show("Por favor, ingrese un nodo de inicio válido.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!nodosExistentes.Any(n => n.Nombre.Equals(nodoInicio, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("El nodo de inicio no existe en el grafo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var distancias = dijkstra.GDijkstra(nodoInicio);

            this.lbxDijsktra.Items.Clear();
            this.lbxDijsktra.Items.Add($"Caminos más cortos desde el nodo {nodoInicio}:");

            foreach (var distancia in distancias)
            {
                if (distancia.Value == int.MaxValue / 2)
                {
                    this.lbxDijsktra.Items.Add($"No hay camino desde {nodoInicio} a {distancia.Key}");
                }
                else
                {
                    this.lbxDijsktra.Items.Add($"Distancia desde {nodoInicio} a {distancia.Key}: {distancia.Value}");
                }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            contador = 0;
            nodosExistentes.Clear();
            this.lblCont.Text = contador.ToString();
            this.lbxDijsktra.Items.Clear();
            this.lbxRecorridos.Items.Clear();
            this.lbxRespuestas.Items.Clear();
            this.lbxPonderaciones.Items.Clear();
            this.nupArista.Value = 1;
            this.txtNodo1.Text = "";
            this.txtNodo2.Text = "";
            this.txtNodoInicio.Text = "";
            GC.Collect();
        }
    }
}