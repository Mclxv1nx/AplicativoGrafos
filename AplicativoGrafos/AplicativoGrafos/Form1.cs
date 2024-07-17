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
            this.lbxPonderaciones.Items.Clear();

            for (int i = 0; i < floyd.CambiosMatrizRecorridos.Count; i++)
            {
                this.lbxRecorridos.Items.Add($"Versión {i + 1}:");
                this.lbxRecorridos.Items.AddRange(ConvertirMatrizAStringArray(floyd.CambiosMatrizRecorridos[i]));

                this.lbxPonderaciones.Items.Add($"Versión {i + 1}:");
                this.lbxPonderaciones.Items.AddRange(ConvertirMatrizAStringArray(floyd.CambiosMatrizPesos[i]));
            }

            this.lbxFloyd.Items.Clear();
            this.lbxFloyd.Items.Add("Caminos más cortos entre todos los nodos:");

            foreach (var nodo1 in nodosExistentes)
            {
                foreach (var nodo2 in nodosExistentes)
                {
                    if (nodo1 != nodo2)
                    {
                        try
                        {
                            var camino = floyd.DarCaminos(nodo1.Nombre, nodo2.Nombre);
                            this.lbxFloyd.Items.Add($"Camino de {nodo1.Nombre} a {nodo2.Nombre}: {camino}");
                        }
                        catch (ErroresFloyd ex)
                        {
                            this.lbxFloyd.Items.Add($"Camino de {nodo1.Nombre} a {nodo2.Nombre}: {ex.Message}");
                        }
                    }
                }
            }
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

            var (distancias, predecesores) = dijkstra.GDijkstra(nodoInicio);

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
                    string camino = ReconstruirCamino(predecesores, nodoInicio, distancia.Key);
                    this.lbxDijsktra.Items.Add($"Distancia desde {nodoInicio} a {distancia.Key}: {distancia.Value} ({camino})");
                }
            }
        }

        private string ReconstruirCamino(Dictionary<string, string> predecesores, string inicio, string fin)
        {
            Stack<string> camino = new Stack<string>();
            string actual = fin;

            while (actual != inicio)
            {
                camino.Push(actual);
                actual = predecesores[actual];
            }

            camino.Push(inicio);

            return string.Join(" ---> ", camino);
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
            this.lbxFloyd.Items.Clear();
            this.nupArista.Value = 1;
            this.txtNodo1.Text = "";
            this.txtNodo2.Text = "";
            this.txtNodoInicio.Text = "";

            GC.Collect();
        }
    }
}
