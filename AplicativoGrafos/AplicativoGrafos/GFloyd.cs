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
        public NodoF[,] Recorridos { get => recorridos; set => recorridos = value; }

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
        private List<AristaF> aristas = new List<AristaF>();
        private string nombre;

        /// <summary>
        /// Lista de Aristas salientes del nodo. 
        /// </summary>
        internal List<AristaF> Aristas { get => aristas; set => aristas = value; }
        /// <summary>
        /// El nombre con que se identifica el Nodo. Es recomendable que sea único.
        /// </summary>
        public string Nombre { get => nombre; set => nombre = value; }
        
        /// <summary>
        /// Constructor para crear un nodo con su primer arista correspondiente.
        /// </summary>
        /// <param name="nombre">Nombre del nodo</param>
        /// <param name="arista">Primer arista de la lista.</param>
        public NodoF(string nombre, AristaF arista)
        {
            aristas.Add(arista);
            this.nombre = nombre;
        }
        /// <summary>
        /// Solo para Asignar Nombre de Nodos que no se conecten
        /// </summary>
        /// <param name="nombre"></param>
        public NodoF(string nombre)
        { 
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
            if (peso >= 1) this.peso = peso;
            else throw new ErroresFloyd("Número inválido: el peso debe ser mayor que 1.");
            this.nodo = nodo;
        }

        /// <summary>
        /// Constructor Vacío solo para inicializar la clase.
        /// </summary>
        public AristaF()
        {
        }
    }

    /// <summary>
    /// Son excepciones / errores personalizados 
    /// </summary>
    [Serializable]
    internal class ErroresFloyd : Exception
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
