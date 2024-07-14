using System;
using System.Collections.Generic;

namespace AplicativoGrafos
{
    /// <summary>
    /// Representa un nodo en el grafo. Contiene un identificador y una lista de aristas (conexiones) a otros nodos.
    /// </summary>
    internal class NodoD
    {
        // Propiedad para almacenar el identificador del nodo
        public string Id { get; set; }

        // Lista de aristas (conexiones) que parten desde este nodo
        public List<AristaD> Aristas { get; set; } = new List<AristaD>();

        /// <summary>
        /// Constructor que inicializa el nodo con un identificador.
        /// </summary>
        /// <param name="id">Identificador del nodo</param>
        public NodoD(string id)
        {
            // Asigna el identificador pasado como parametro a la propiedad Id
            Id = id;
        }

        /// <summary>
        /// Agrega una arista desde este nodo a un nodo de destino con un peso especifico.
        /// </summary>
        /// <param name="destino">Nodo al que apunta la arista</param>
        /// <param name="peso">Peso de la arista</param>
        public void AgregarArista(NodoD destino, int peso)
        {
            // Crea una nueva arista y la agrega a la lista de aristas
            Aristas.Add(new AristaD(destino, peso));
        }
    }

    /// <summary>
    /// Representa una arista en el grafo, que es una conexion entre dos nodos con un peso asociado.
    /// </summary>
    internal class AristaD
    {
        // Propiedad para almacenar el nodo de destino de la arista
        public NodoD Destino { get; set; }

        // Propiedad para almacenar el peso de la arista
        public int Peso { get; set; }

        /// <summary>
        /// Constructor que inicializa la arista con un nodo de destino y un peso.
        /// </summary>
        /// <param name="destino">Nodo de destino de la arista</param>
        /// <param name="peso">Peso de la arista</param>
        public AristaD(NodoD destino, int peso)
        {
            // Asigna el nodo de destino pasado como parametro a la propiedad Destino
            Destino = destino;

            // Asigna el peso pasado como parametro a la propiedad Peso
            Peso = peso;
        }
    }

    /// <summary>
    /// Implementa el algoritmo de Dijkstra para encontrar las distancias mas cortas desde un nodo de inicio a todos los demas nodos en un grafo.
    /// </summary>
    internal class Dijkstra
    {
        // Diccionario para almacenar los nodos del grafo, identificados por su ID
        public Dictionary<string, NodoD> Nodos { get; set; } = new Dictionary<string, NodoD>();

        /// <summary>
        /// Agrega un nodo al grafo.
        /// </summary>
        /// <param name="id">Identificador del nodo</param>
        public void AgregarNodo(string id)
        {
            // Crea un nuevo nodo y lo agrega al diccionario de nodos
            Nodos[id] = new NodoD(id);
        }

        /// <summary>
        /// Agrega una arista entre dos nodos en el grafo.
        /// </summary>
        /// <param name="origenId">ID del nodo de origen</param>
        /// <param name="destinoId">ID del nodo de destino</param>
        /// <param name="peso">Peso de la arista</param>
        public void AgregarArista(string origenId, string destinoId, int peso)
        {
            // Obtiene el nodo de origen a partir de su ID
            NodoD origen = Nodos[origenId];

            // Obtiene el nodo de destino a partir de su ID
            NodoD destino = Nodos[destinoId];

            // Agrega una arista desde el nodo de origen al nodo de destino con el peso especificado
            origen.AgregarArista(destino, peso);
        }

        /// <summary>
        /// Aplica el algoritmo de Dijkstra para calcular las distancias mas cortas desde un nodo de inicio a todos los demas nodos.
        /// </summary>
        /// <param name="inicioId">ID del nodo de inicio</param>
        /// <returns>Diccionario con las distancias mas cortas desde el nodo de inicio a cada nodo</returns>
        public Dictionary<string, int> Dijkstra(string inicioId)
        {
            // Diccionario para almacenar las distancias mas cortas desde el nodo de inicio a cada nodo
            var distancias = new Dictionary<string, int>();

            // Diccionario para almacenar el nodo predecesor de cada nodo en el camino mas corto
            var nodoPredecesor = new Dictionary<string, string>();

            // Conjunto para almacenar los nodos que aun no han sido visitados
            var nodosSinVisitar = new HashSet<string>();

            // Inicializa las distancias a infinito y el conjunto de nodos sin visitar
            foreach (var nodo in Nodos.Keys)
            {
                // Establece la distancia inicial a cada nodo como infinito (representado por int.MaxValue)
                distancias[nodo] = int.MaxValue;

                // Agrega el nodo al conjunto de nodos sin visitar
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
                    // Si nodoActual es nulo o la distancia al nodo actual es menor que la distancia al nodo almacenado en nodoActual
                    if (nodoActual == null || distancias[nodo] < distancias[nodoActual])
                    {
                        // Actualiza nodoActual al nodo con la menor distancia conocida
                        nodoActual = nodo;
                    }
                }

                // Marca el nodo actual como visitado, eliminandolo del conjunto de nodos sin visitar
                nodosSinVisitar.Remove(nodoActual);

                // Actualiza las distancias a los nodos vecinos
                foreach (var arista in Nodos[nodoActual].Aristas)
                {
                    // Calcula la nueva distancia desde el nodo de inicio al nodo de destino de la arista actual
                    int nuevaDistancia = distancias[nodoActual] + arista.Peso;

                    // Si la nueva distancia es menor que la distancia almacenada actualmente para el nodo de destino
                    if (nuevaDistancia < distancias[arista.Destino.Id])
                    {
                        // Actualiza la distancia al nodo de destino con la nueva distancia calculada
                        distancias[arista.Destino.Id] = nuevaDistancia;

                        // Almacena el nodo actual como predecesor del nodo de destino
                        nodoPredecesor[arista.Destino.Id] = nodoActual;
                    }
                }
            }

            // Retorna el diccionario de distancias mas cortas desde el nodo de inicio a cada nodo
            return distancias;
        }
    }

    /// <summary>
    /// Esta clase contiene el metodo Main, el cual es el punto de entrada del programa.
    /// En este metodo se crea un grafo, se agregan nodos y aristas, y se ejecuta el algoritmo de Dijkstra.
    /// </summary>
    /*class ProgramDjk
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
            grafo.AgregarArista("v2", "v4", 3);
            grafo.AgregarArista("v2", "v5", 10);
            grafo.AgregarArista("v3", "v1", 4);
            grafo.AgregarArista("v3", "v6", 5);
            grafo.AgregarArista("v4", "v3", 2);
            grafo.AgregarArista("v4", "v5", 2);
            grafo.AgregarArista("v4", "v6", 8);
            grafo.AgregarArista("v4", "v7", 4);
            grafo.AgregarArista("v5", "v7", 6);
            grafo.AgregarArista("v7", "v6", 1);

            // Calcula las distancias mas cortas desde el nodo "v1" a todos los demas nodos
            var distancias = grafo.Dijkstra("v1");

            // Imprime las distancias calculadas
            foreach (var distancia in distancias)
            {
                Console.WriteLine($"Distancia desde v1 a {distancia.Key}: {distancia.Value}");
            }
        }
    }*/
}
