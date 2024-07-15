using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AplicativoGrafos
{
    /// <summary>
    /// Grafo correspondiente al algoritmo de Floyd. 
    /// </summary>
    internal class GFloyd
    {
        static int infinito = 10000;
        private int[,] pesos;
        private NodoF[,] recorridos;
        /// <summary>
        /// Este será la matriz de guardado de todos los nodos 
        /// Que estarán presentes en todo el algoritmo.
        /// </summary>
        private NodoF[] nodos; //Esta propiedad no será publica

        /// <summary>
        /// Matriz bidimensional que guarda los pesos. 
        /// </summary>
        public int[,] Pesos { get => pesos; set => pesos = value; }
        /// <summary>
        /// Matriz bidimensional que guarda las direcciones de memoria de los nodos. 
        /// </summary>
        public NodoF[,] Recorridos { get => recorridos; set => recorridos = value; }
        /// <summary>
        /// Es la variable que representa la cantidad maxima de pesos. 
        /// Será la variable con la que se comparará cumpliendo un papel representativo de Infinito. 
        /// </summary>
        public static int Infinito { get => infinito; set => infinito = value; }

        /// <summary>
        /// Constructor de la clase Grafo correspondiente al algoritmo de Floyd.
        /// </summary>
        /// <param name="nodos">Se envian los nodos que se usarán en el algoritmo en un arreglo</param>
        public GFloyd(NodoF[] nodos)
        {
            this.nodos = nodos;
            pesos = new int[nodos.Length, nodos.Length];
            recorridos = new NodoF[nodos.Length, nodos.Length];

            for (int fl = 0; fl < nodos.Length; fl++)
            {
                for (int cl = 0; cl < nodos.Length; cl++)
                {
                    recorridos[cl, fl] = nodos[fl];
                }
                pesos[fl, fl] = -1;
            }
        }

        /// <summary>
        /// Ejecución del Algoritmo Floyd.
        /// </summary>
        public void BuscarCaminos()
        {
            //--Comentar esto cuando ya no sea necesario.--
            //Reviso como empezaron las matrices
            Console.WriteLine(MatrizRecorridos());
            Console.WriteLine(MatrizPesos());

            //Primero buscamos los que se conectan y los que no
            BuscarConexiones();
            Console.WriteLine("Busqueda de Conexiones terminada:");
            Console.WriteLine(MatrizPesos());

            //Ahora procedemos a evaluar cada nodo.
            EvaluarNodos();
            Console.WriteLine("Resultado de la Evaluación:");
            Console.WriteLine(MatrizPesos());
            Console.WriteLine(MatrizRecorridos());
        }

        /// <summary>
        /// Es la definición de la matriz inicial. 
        /// </summary>
        private void BuscarConexiones()
        {
            //Primero se analiza cada nodo. 
            for (int i = 0; i < nodos.Length; i++)
            {
                //De acuerdo a ese nodo se analizará cada arista
                for (int j = 0; j < nodos[i].Aristas.Count; j++)
                {
                    //Finalmente según las aristas que haya se analiza 
                    //Y se busca cual corresponde al nodo de la arista
                    //Con la que se busca actualmente. 
                    for (int k = 0; k < nodos.Length; k++)
                    {
                        //Primero si el peso es -1 no se hace nada.
                        if (pesos[i, k] == -1) continue;
                        //Luego, como es la primera busqueda sabemos que 
                        //por defecto todo es 0, asi que los que son 0 se pone infinito
                        else if (nodos[k] != nodos[i].Aristas[j].Nodo
                            && pesos[i, k] == 0) pesos[i, k] = infinito;
                        //Solo por esta primera ocasión se reemplaza cualquier valor
                        //a cambio del peso correspondiente a esa arista.
                        //En el caso de que coincida con la que buscamos, claro. 
                        else if (nodos[k] == nodos[i].Aristas[j].Nodo)
                            pesos[i, k] = nodos[i].Aristas[j].Peso;
                    }
                }
            }
        }

        /// <summary>
        /// Es el método que permite evaluar cada nodo y modificar las matrices. 
        /// </summary>
        private void EvaluarNodos()
        {
            /* 
             * Para comprender mejor, uso estos vocablos:
             * Evaluador: Nodo con el que estamos evaluando a los demás nodos
             * Evaluando: Nodo al que se está evaluando comparandose con el Evaluador.
             * Entre otras palabras. El Evaluador es el nodo que evalua al Evaluando,
             * Esto mediante los criterios que se verán más adelante. 
             */
            
            //Primero vamos a buscar el nodo Evaluador
            for (int i = 0; i < nodos.Length; i++)
            {
                for (int j = 0; j < nodos.Length; j++)
                {
                    ///Descartamos todas las posibilidades en que no se deba analizar
                    //Si el Evaluador coincide consigo mismo en la matriz se omite el analisis. 
                    if (i == j) continue;
                    //Si el Evaluador es infinito se omite el analisis.
                    else if (pesos[i, j] == infinito) continue;
                    else
                    {
                        //Recién ahora conseguimos el Evaluador, por lo tanto guardamos en memoria al Evaluador.
                        int pesoSuma = pesos[i, j];
                        for (int k = 0; k < nodos.Length; k++)
                        {
                            ///Ahora procedemos a buscar al Evaluando
                            //Si estamos en la misma fila que el Evaluador, omitimos el analisis.
                            if (k == i) continue;
                            //Si el Evaluando es infinito se omite el analisis
                            else if (pesos[k, i] == infinito) continue;
                            //Si donde se guardará ya es -1, se omite el analisis.
                            else if (pesos[k, j] == -1) continue;
                            //Si la suma de las aristas del evaluador y evaluando dan un resultado inferior
                            //Al que ya se tiene en la matriz se guardará la nueva suma. 
                            else if (pesoSuma + pesos[k, i] < pesos[k, j])
                            {
                                pesos[k, j] = pesoSuma + pesos[k, i];   //Se guarda el resultado
                                recorridos[k, j] = nodos[i];            //Se guarda el nodo Evaluador en la nueva posición.
                            }
                            //Ahora solo se repite el ciclo. 
                        }
                    }
                }
            }
        }

        public string DarCaminos(string nodoOrigen, string nodoBusqueda)
        {
            int primerNodo = IndexOf(nodoOrigen);
            int SegundoNodo = IndexOf(nodoBusqueda);

            if (primerNodo == -1) return "Nodo Origen " + nodoOrigen + " no existe en el grafo";
            if (SegundoNodo == -1) return "Nodo Búsqueda " + nodoBusqueda + " no existe en el grafo";
            if (primerNodo == SegundoNodo) return "El camino es a si mismo";

            int pesoTotal = pesos[primerNodo, SegundoNodo];
            NodoF aux = recorridos[primerNodo, SegundoNodo];
            List<string> nodoPath = new List<string>() { nodoOrigen };
            int temp = SegundoNodo;

            while (aux != nodos[temp])
            {
                temp = IndexOf(aux.Nombre);
                aux = recorridos[primerNodo, temp];
                nodoPath.Add(aux.Nombre);
                pesoTotal += Pesos[primerNodo, temp];
                temp = IndexOf(aux.Nombre);
            }

            nodoPath.Add(nodoBusqueda);

            string caminos = "";

            for (int i = 0; i < nodoPath.Count; i++)
            {
                caminos += nodoPath[i] + ", ";
            }

            return "Caminos: " + caminos.Substring(0, caminos.Length - 2) + ".\n" +
                   "Peso total: " + pesoTotal;
        }

        /// <summary>
        /// Por alguna razón no hay IndexOf en los arreglos. Asi que esta
        /// función se encarga de eso. 
        /// </summary>
        /// <param name="nombreNodo">Usamos el nombre para la busqueda del nodo</param>
        /// <returns></returns>
        private int IndexOf(string nombreNodo)
        {
            int index = 0;
            for (int i = 0; i <= nodos.Length; i++)
            {
                if (i > nodos.Length - 1) return -1;
                if (nodos[i].Nombre == nombreNodo) break;
                index++;
            }

            return index;
        }

        /// <summary>
        /// Regresa la matriz de los recorridos en dato string.
        /// </summary>
        /// <returns></returns>
        public string MatrizRecorridos()
        {
            string matriz = "";

            for (int fl = 0; fl < recorridos.GetLength(0); fl++)
            {
                for (int cl = 0; cl < recorridos.GetLength(1); cl++)
                {
                    matriz += recorridos[fl, cl] + "\t";
                }
                matriz += "\n";
            }

            return matriz;
        }

        /// <summary>
        /// Regresa la matriz de los pesos en dato string.
        /// </summary>
        /// <returns></returns>
        public string MatrizPesos()
        {
            string matriz = "";

            for (int fl = 0; fl < pesos.GetLength(0); fl++)
            {
                for (int cl = 0; cl < pesos.GetLength(1); cl++)
                {
                    if (pesos[fl, cl] == infinito) matriz += "=\t"; //No puedo poner por el momento el simbolo '∞'
                    else if (pesos[fl, cl] == -1) matriz += "-\t";
                    else matriz += pesos[fl, cl] + "\t";
                }
                matriz += "\n";
            }

            return matriz;
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
        public int Peso
        {
            get => peso; set
            {
                if (value > 1) peso = value;
            }
        }
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
