using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoGrafos
{
    /// <summary>
    /// Grafo correspondiente al algoritmo de Floyd. 
    /// </summary>
    internal class GFloyd
    {
        private int[,] pesos;
        private NodoF[,] recorridos;

        /// <summary>
        /// Matriz bidimensional que guarda los pesos. 
        /// </summary>
        public int[,] Pesos { get => pesos; set => pesos = value; }
        /// <summary>
        /// Matriz bidimensional que guarda las direcciones de memoria de los nodos. 
        /// </summary>
        internal NodoF[,] Recorridos { get => recorridos; set => recorridos = value; }

        /// <summary>
        /// Constructor de la clase Grafo correspondiente al algoritmo de Floyd.
        /// </summary>
        /// <param name="nodos">Se envian los nodos que se usarán en el algoritmo en un arreglo</param>
        public GFloyd(NodoF[] nodos)
        {
            pesos = new int[nodos.Length, nodos.Length];
            recorridos = new NodoF[nodos.Length, nodos.Length];

            for(int fl = 0; fl < nodos.Length; fl++)
            {
                for(int cl = 0; cl<nodos.Length; cl++)
                {
                    recorridos[fl, cl] = nodos[fl];
                }
                pesos[fl, fl] = -1;
            }
        }


    }

    /// <summary>
    /// Objeto nodo, unidad minima parte del grafo. 
    /// </summary>
    internal class NodoF
    {
        private AristaF arista;
        private string nombre;

        /// <summary>
        /// Es el enlace que une este nodo con un nodo designado en la Arista.
        /// </summary>
        internal AristaF Arista { get => arista; set => arista = value; }
        /// <summary>
        /// El nombre con que se identifica el Nodo. Es recomendable que sea único.
        /// </summary>
        public string Nombre { get => nombre; set => nombre = value; }

        /// <summary>
        /// Constructor con ambos parámetros en caso de querer designarlos.
        /// </summary>
        /// <param name="nombre">El nombre con que se identifica el Nodo. Es recomendable que sea único.</param>
        /// <param name="arista">Es el enlace que une este nodo con un nodo designado en la Arista.</param>
        public NodoF(string nombre, AristaF arista)
        {
            this.arista = arista;
            this.nombre = nombre;
        }

        /// <summary>
        /// Constructor vacío necesario para inicializar la clase.
        /// </summary>
        public NodoF()
        {
        }

        public override string ToString()
        {
            return nombre;
        }
    }

    /// <summary>
    /// Es el objeto que se encarga de unir un nodo con otro. 
    /// </summary>
    internal class AristaF
    {
        private int peso;
        private NodoF nodo;

        /// <summary>
        /// Es la unidad que designa el peso. Solo se admiten enteros positivos.
        /// </summary>
        public int Peso { get => peso; set {
                if (value > 1) peso = value;
            } }
        /// <summary>
        /// Es el nodo que le precede. 
        /// </summary>
        internal NodoF Nodo { get => nodo; set => nodo = value; }

        /// <summary>
        /// Constructor con ambos parámetros en caso de querer asignarlos desde el constructor.
        /// </summary>
        /// <param name="peso">Es la unidad que designa el peso. Solo se admiten enteros positivos.</param>
        /// <param name="nodo">Es el nodo que le precede</param>
        public AristaF(int peso, NodoF nodo)
        {
            if (peso > 1) this.peso = peso;
            else throw new ErroresFloyd("Número inválido: el peso debe ser mayor que 1.");
            this.nodo = nodo;
        }

        /// <summary>
        /// Constructor Vacío solo para inicializar la clase.
        /// </summary>
        public AristaF()
        {
        }

        /// <summary>
        /// Son excepciones / errores personalizados 
        /// </summary>
        [Serializable]
        private class ErroresFloyd : Exception
        {
            public ErroresFloyd()
            {
            }

            public ErroresFloyd(string message) : base(message)
            {
            }

            public ErroresFloyd(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected ErroresFloyd(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
