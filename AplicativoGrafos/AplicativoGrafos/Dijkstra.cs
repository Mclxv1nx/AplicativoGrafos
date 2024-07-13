using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoGrafos
{
    /// <summary>
    /// Representa un nodo en el grafo. Contiene un identificador y una lista de aristas (conexiones) a otros nodos.
    /// </summary>
    internal class NodoD
    {
        public string Id { get; set; }
        public List<AristaD> Aristas { get; set; } = new List<AristaD>();

        /// <summary>
        /// Constructor que inicializa el nodo con un identificador.
        /// </summary>
        public NodoD(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Agrega una arista desde este nodo a un nodo de destino con un peso específico.
        /// </summary>
        public void AgregarArista(NodoD destino, int peso)
        {
            Aristas.Add(new AristaD(destino, peso));
        }
    }

    /// <summary>
    /// Representa una arista en el grafo, que es una conexión entre dos nodos con un peso asociado.
    /// </summary>
    internal class AristaD
    {
        public NodoD Destino { get; set; }
        public int Peso { get; set; }

        /// <summary>
        /// Constructor que inicializa la arista con un nodo de destino y un peso.
        /// </summary>
        public AristaD(NodoD destino, int peso)
        {
            Destino = destino;
            Peso = peso;
        }
    }

    /// <summary>
    /// Implementa el algoritmo de Dijkstra para encontrar las distancias más cortas desde un nodo de inicio a todos los demás nodos en un grafo.
    /// </summary>
    internal class Dijkstra
    {
        public Dictionary<string, NodoD> Nodos { get; set; } = new Dictionary<string, NodoD>();

        /// <summary>
        /// Agrega un nodo al grafo.
        /// </summary>
        public void AgregarNodo(string id)
        {
            Nodos[id] = new NodoD(id);
        }

        /// <summary>
        /// Agrega una arista entre dos nodos en el grafo.
        /// </summary>
        public void AgregarArista(string origenId, string destinoId, int peso)
        {
            NodoD origen = Nodos[origenId];
            NodoD destino = Nodos[destinoId];
            origen.AgregarArista(destino, peso);
        }

        /// <summary>
        /// Aplica el algoritmo de Dijkstra para calcular las distancias más cortas desde un nodo de inicio a todos los demás nodos.
        /// </summary>
        public Dictionary<string, int> Dijkstra(string inicioId)
        {
            var distancias = new Dictionary<string, int>();
            var nodoPredecesor = new Dictionary<string, string>();
            var nodosSinVisitar = new HashSet<string>();

            // Inicializa las distancias a infinito y el conjunto de nodos sin visitar
            foreach (var nodo in Nodos.Keys)
            {
                distancias[nodo] = int.MaxValue;
                nodosSinVisitar.Add(nodo);
            }

            // La distancia al nodo de inicio es 0
            distancias[inicioId] = 0;

            // Mientras haya nodos sin visitar
            while (nodosSinVisitar.Count > 0)
            {
                string nodoActual = null;

                // Encuentra el nodo no visitado con la menor distancia conocida
                foreach (var nodo in nodosSinVisitar)
                {
                    if (nodoActual == null || distancias[nodo] < distancias[nodoActual])
                    {
                        nodoActual = nodo;
                    }
                }

                // Marca el nodo actual como visitado
                nodosSinVisitar.Remove(nodoActual);

                // Actualiza las distancias a los nodos vecinos
                foreach (var arista in Nodos[nodoActual].Aristas)
                {
                    int nuevaDistancia = distancias[nodoActual] + arista.Peso;
                    if (nuevaDistancia < distancias[arista.Destino.Id])
                    {
                        distancias[arista.Destino.Id] = nuevaDistancia;
                        nodoPredecesor[arista.Destino.Id] = nodoActual;
                    }
                }
            }

            return distancias;
        }
    }

    /// <summary>
    /// Esta clase contiene el método Main, el cual es el punto de entrada del programa.
    /// En este método se crea un grafo, se agregan nodos y aristas, y se ejecuta el algoritmo de Dijkstra.
    /// </summary>
    class ProgramDjk
    {
        static void Main(string[] args)
        {
            // Crea una instancia de la clase Dijkstra
            Dijkstra grafo = new Dijkstra();

            // Agrega nodos al grafo
            grafo.AgregarNodo("v1");
            grafo.AgregarNodo("v2");
            grafo.AgregarNodo("v3");
            grafo.AgregarNodo("v4");
            grafo.AgregarNodo("v5");
            grafo.AgregarNodo("v6");
            grafo.AgregarNodo("v7");

            // Agrega aristas entre los nodos
            grafo.AgregarArista("v1", "v2", 2);
            grafo.AgregarArista("v1", "v4", 1);
            grafo.AgregarArista("v1", "v3", 4);
            grafo.AgregarArista("v2", "v5", 10);
            grafo.AgregarArista("v2", "v4", 3);
            grafo.AgregarArista("v3", "v4", 2);
            grafo.AgregarArista("v3", "v6", 5);
            grafo.AgregarArista("v4", "v5", 2);
            grafo.AgregarArista("v4", "v6", 8);
            grafo.AgregarArista("v4", "v7", 4);
            grafo.AgregarArista("v6", "v7", 1);
            grafo.AgregarArista("v7", "v5", 6);

            // Calcula las distancias más cortas desde el nodo "v1" a todos los demás nodos
            var distancias = grafo.Dijkstra("v1");

            // Imprime las distancias calculadas
            foreach (var distancia in distancias)
            {
                Console.WriteLine($"Distancia desde v1 a {distancia.Key}: {distancia.Value}");
            }
        }
    }
}
