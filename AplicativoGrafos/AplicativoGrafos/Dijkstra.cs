using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoGrafos
{
    internal class NodoD
    {
        public string Id { get; set; }
        public List<AristaD> Aristas { get; set; } = new List<AristaD>();

        public NodoD(string id)
        {
            Id = id;
        }

        public void AgregarArista(NodoD destino, int peso)
        {
            Aristas.Add(new AristaD(destino, peso));
        }
    }

    internal class AristaD
    {
        public NodoD Destino { get; set; }
        public int Peso { get; set; }

        public AristaD(NodoD destino, int peso)
        {
            Destino = destino;
            Peso = peso;
        }
    }

    internal class Dijkstra
    {
        public Dictionary<string, NodoD> Nodos { get; set; } = new Dictionary<string, NodoD>();

        public void AgregarNodo(string id)
        {
            Nodos[id] = new NodoD(id);
        }

        public void AgregarArista(string origenId, string destinoId, int peso)
        {
            NodoD origen = Nodos[origenId];
            NodoD destino = Nodos[destinoId];
            origen.AgregarArista(destino, peso);
        }

        public Dictionary<string, int> Dijkstra(string inicioId)
        {
            var distancias = new Dictionary<string, int>();
            var nodoPredecesor = new Dictionary<string, string>();
            var nodosSinVisitar = new HashSet<string>();

            foreach (var nodo in Nodos.Keys)
            {
                distancias[nodo] = int.MaxValue;
                nodosSinVisitar.Add(nodo);
            }

            distancias[inicioId] = 0;

            while (nodosSinVisitar.Count > 0)
            {
                string nodoActual = null;
                foreach (var nodo in nodosSinVisitar)
                {
                    if (nodoActual == null || distancias[nodo] < distancias[nodoActual])
                    {
                        nodoActual = nodo;
                    }
                }

                nodosSinVisitar.Remove(nodoActual);

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

    class ProgramDjk
    {
        static void Main(string[] args)
        {
            Dijkstra grafo = new Grafo();

            grafo.AgregarNodo("v1");
            grafo.AgregarNodo("v2");
            grafo.AgregarNodo("v3");
            grafo.AgregarNodo("v4");
            grafo.AgregarNodo("v5");
            grafo.AgregarNodo("v6");
            grafo.AgregarNodo("v7");

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

            var distancias = grafo.Dijkstra("v1");

            foreach (var distancia in distancias)
            {
                Console.WriteLine($"Distancia desde v1 a {distancia.Key}: {distancia.Value}");
            }
        }
    }

}