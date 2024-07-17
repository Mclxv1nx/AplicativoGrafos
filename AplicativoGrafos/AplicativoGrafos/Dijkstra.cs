using System;
using System.Collections.Generic;

namespace AplicativoGrafos
{
    // Clase NodoD representa un nodo en el grafo
    internal class NodoD
    {
        public string Id { get; set; } // Identificador del nodo
        public List<AristaD> Aristas { get; set; } = new List<AristaD>(); // Lista de aristas (conexiones) desde este nodo

        // Constructor que inicializa el nodo con un identificador
        public NodoD(string id)
        {
            Id = id;
        }

        // Método para agregar una arista (conexión) desde este nodo a otro nodo
        public void AgregarArista(NodoD destino, int peso)
        {
            Aristas.Add(new AristaD(destino, peso));
        }
    }

    // Clase AristaD representa una arista en el grafo
    internal class AristaD
    {
        public NodoD Destino { get; set; } // Nodo de destino de la arista
        public int Peso { get; set; } // Peso de la arista

        // Constructor que inicializa la arista con un nodo destino y un peso
        public AristaD(NodoD destino, int peso)
        {
            Destino = destino;
            Peso = peso;
        }
    }

    // Clase Dijkstra implementa el algoritmo de Dijkstra para encontrar caminos más cortos
    internal class Dijkstra
    {
        public Dictionary<string, NodoD> Nodos { get; set; } = new Dictionary<string, NodoD>(); // Diccionario de nodos en el grafo

        // Método para agregar un nodo al grafo
        public void AgregarNodo(string id)
        {
            Nodos[id] = new NodoD(id);
        }

        // Método para agregar una arista entre dos nodos en el grafo
        public void AgregarArista(string origenId, string destinoId, int peso)
        {
            NodoD origen = Nodos[origenId];
            NodoD destino = Nodos[destinoId];
            origen.AgregarArista(destino, peso);
        }

        // Método que implementa el algoritmo de Dijkstra para encontrar los caminos más cortos desde un nodo de inicio
        public (Dictionary<string, int>, Dictionary<string, string>) GDijkstra(string inicioId)
        {
            var distancias = new Dictionary<string, int>(); // Diccionario para almacenar las distancias más cortas desde el nodo de inicio
            var nodoPredecesor = new Dictionary<string, string>(); // Diccionario para almacenar el predecesor de cada nodo en el camino más corto
            var nodosSinVisitar = new HashSet<string>(); // Conjunto de nodos que aún no han sido visitados

            // Inicializar las distancias y el conjunto de nodos sin visitar
            foreach (var nodo in Nodos.Keys)
            {
                distancias[nodo] = int.MaxValue / 2; // Establecer distancia infinita (aproximada) para cada nodo
                nodosSinVisitar.Add(nodo);
            }

            distancias[inicioId] = 0; // Establecer distancia cero para el nodo de inicio

            // Mientras haya nodos sin visitar
            while (nodosSinVisitar.Count > 0)
            {
                string nodoActual = null;

                // Seleccionar el nodo no visitado con la distancia más corta
                foreach (var nodo in nodosSinVisitar)
                {
                    if (nodoActual == null || distancias[nodo] < distancias[nodoActual])
                    {
                        nodoActual = nodo;
                    }
                }

                nodosSinVisitar.Remove(nodoActual); // Marcar el nodo actual como visitado

                // Actualizar las distancias para los nodos adyacentes al nodo actual
                foreach (var arista in Nodos[nodoActual].Aristas)
                {
                    int nuevaDistancia = distancias[nodoActual] + arista.Peso;

                    // Si se encuentra una distancia más corta, actualizarla
                    if (nuevaDistancia < distancias[arista.Destino.Id])
                    {
                        distancias[arista.Destino.Id] = nuevaDistancia;
                        nodoPredecesor[arista.Destino.Id] = nodoActual;
                    }
                }
            }

            return (distancias, nodoPredecesor); // Devolver las distancias y los predecesores
        }

        // Método para eliminar un nodo y todas sus aristas asociadas del grafo
        public void EliminarNodo(string id)
        {
            if (!Nodos.ContainsKey(id)) return;

            // Eliminar todas las aristas que apuntan al nodo a eliminar
            foreach (var nodo in Nodos.Values)
            {
                nodo.Aristas.RemoveAll(arista => arista.Destino.Id == id);
            }

            // Eliminar el nodo del diccionario de nodos
            Nodos.Remove(id);
        }
    }
}
