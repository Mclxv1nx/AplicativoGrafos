using System;
using System.Collections.Generic;

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

        public (Dictionary<string, int>, Dictionary<string, string>) GDijkstra(string inicioId)
        {
            var distancias = new Dictionary<string, int>();
            var nodoPredecesor = new Dictionary<string, string>();
            var nodosSinVisitar = new HashSet<string>();

            foreach (var nodo in Nodos.Keys)
            {
                distancias[nodo] = int.MaxValue / 2;
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

            return (distancias, nodoPredecesor);
        }
    }
}
