using System;
using System.Collections.Generic;
using System.Linq;
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
        /// A pedido de Adrián. Solo es un guardado en cadenas sobre las versiones de la Matriz de Recorridos
        /// </summary>
        public List<string> CambiosMatrizRecorridos = new List<string>();
        /// <summary>
        /// A pedido de Adrián. Solo es un guardado en cadenas sobre las versiones de la Matriz de Pesos
        /// </summary>
        public List<string> CambiosMatrizPesos = new List<string>();

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
            this.nodos = nodos.OrderBy(n => n.Nombre).ToArray();
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
            CambiosMatrizRecorridos.Add(MatrizRecorridos());  //Guardado de la versión
            CambiosMatrizPesos.Add(MatrizPesos());

            //Primero buscamos los que se conectan y los que no
            BuscarConexiones();
            Console.WriteLine("Busqueda de Conexiones terminada:");
            Console.WriteLine(MatrizPesos());
            CambiosMatrizRecorridos.Add(MatrizRecorridos()); //Guardado de la versión
            CambiosMatrizPesos.Add(MatrizPesos());

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
                //Si el nodo no tiene aristas, toda la fila en matriz de pesos se hace infinito. 
                if (nodos[i].Aristas.Count == 0)
                {
                    for (int j = 0; j < nodos.Length; j++) pesos[i, j] = infinito;
                    continue;
                }
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
                            && pesos[i, k] == 0)
                            pesos[i, k] = infinito;
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
                for (int fl = 0; fl < nodos.Length; fl++)
                {
                    ///Descartamos todas las posibilidades en que no se deba analizar
                    //Si el Evaluador coincide consigo mismo en la matriz se omite el analisis. 
                    if (i == fl) continue;
                    //Si el Evaluador es infinito se omite el analisis.
                    else if (pesos[fl, i] == infinito) continue;
                    else
                    {
                        //Recién ahora conseguimos el Evaluador, por lo tanto guardamos en memoria al Evaluador.
                        int pesoSuma = pesos[fl, i];
                        for (int cl = 0; cl < nodos.Length; cl++)
                        {
                            ///Ahora procedemos a buscar al Evaluando
                            //Si estamos en la misma columna que el Evaluador, omitimos el analisis.
                            if (cl == i) continue;
                            //Si el Evaluando es infinito se omite el analisis
                            else if (pesos[i, cl] == infinito) continue;
                            //Si donde se guardará ya es -1, se omite el analisis.
                            else if (pesos[fl, cl] == -1) continue;
                            //Si la suma de las aristas del evaluador y evaluando dan un resultado inferior
                            //Al que ya se tiene en la matriz se guardará la nueva suma. 
                            else if (pesoSuma + pesos[i, cl] < pesos[fl, cl])
                            {
                                pesos[fl, cl] = pesoSuma + pesos[i, cl];   //Se guarda el resultado
                                recorridos[fl, cl] = nodos[i];             //Se guarda el nodo Evaluador en la nueva posición.
                            }
                            //Ahora solo se repite el ciclo. 
                        }
                        //Guardado de la version
                        if (MatrizRecorridos() != CambiosMatrizRecorridos.Last() &&
                            MatrizPesos() != CambiosMatrizPesos.Last())
                        {
                            CambiosMatrizRecorridos.Add(MatrizRecorridos());
                            CambiosMatrizPesos.Add(MatrizPesos());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Algoritmo de Búsqueda de Caminos manualmente. 
        /// *SOLO SE DEBE EJECUTAR DESPUÉS DE HABER BUSCADO LOS CAMINOS*
        /// </summary>
        /// <param name="nodoOrigen">Es el nombre del nodo donde se empieza el camino</param>
        /// <param name="nodoBusqueda">Es el nombre del nodo que se busca</param>
        /// <returns></returns>
        public string DarCaminos(string nodoOrigen, string nodoBusqueda)
        {
            //Para completa exactitud se usan 2 algoritmos de busqueda
            string caminos = "";
            try
            {
                //Si falla uno, inmediatamente se guarda su mensaje y se intenta con el segundo algoritmo
                return ComprobarCamino(
                    PrimerAlgoritmo(nodoOrigen, nodoBusqueda),
                    nodos[IndexOf(nodoOrigen)],
                    nodos[IndexOf(nodoBusqueda)]);
            }
            catch (ErroresFloyd mensaje) { caminos = mensaje.ToString(); }

            try
            {
                //Si este falla ya solo quedaría que mandar el mensaje de error
                return ComprobarCamino(SegundoAlgoritmo(nodoOrigen, nodoBusqueda),
                    nodos[IndexOf(nodoOrigen)],
                    nodos[IndexOf(nodoBusqueda)]);
            }
            catch (ErroresFloyd mensaje) { caminos = mensaje.ToString(); }

            return caminos;
        }

        /// <summary>
        /// El primer algoritmo de busqueda de camino busca por la misma fila del nodo de Origen
        /// </summary>
        /// <param name="nodoOrigen">Es el nodo en el que comienza la busqueda</param>
        /// <param name="nodoBusqueda">Es el nudo que se busca</param>
        /// <returns>Una lista con los posibles caminos</returns>
        /// <exception cref="ErroresFloyd">En caso de error se enviará el mensaje</exception>
        private List<NodoF> PrimerAlgoritmo(string nodoOrigen, string nodoBusqueda)
        {
            //Primer recojo los indices de ambos nodos
            int nodoBuscar = IndexOf(nodoOrigen);
            int nodoBuscando = IndexOf(nodoBusqueda);

            //Ahora descarto las posibilidades. 
            //En el caso de que algún nodo no existiera dentro del grafo regresara un mensaje
            if (nodoBuscar == -1) throw new ErroresFloyd("Nodo Origen " + nodoOrigen + " no existe en el grafo");
            if (nodoBuscando == -1) throw new ErroresFloyd("Nodo Búsqueda " + nodoBusqueda + " no existe en el grafo");
            //En el caso de que sea el mismo nodo que se busca también se descarta. 
            if (nodoBuscar == nodoBuscando) throw new ErroresFloyd("El camino es a si mismo");
            //En el caso de que su correspondiente en la matriz sea infinito significa que no tiene conexiones. 
            if (pesos[nodoBuscar, nodoBuscando] == infinito)
                throw new ErroresFloyd($"El nodo {nodoOrigen} no tiene conexiones hacia {nodoBusqueda}");

            //Creo un Nodo aux para el bucle siguiente
            NodoF aux = recorridos[nodoBuscar, nodoBuscando];
            //Empiezo creando una pila con el valor del nodoOrigen
            Stack<NodoF> nodoPath = new Stack<NodoF>();
            nodoPath.Push(nodos[nodoBuscando]);
            //Creo un indice temporal para el bucle siguiente
            int temp = nodoBuscando;

            /*
             * En el bucle ahora lo que hace es que va a ir de posición
             * en posición dentro de la matriz de recorridos. 
             */
            while (aux != nodos[temp])
            {
                nodoPath.Push(aux); //Primero apilamos el nombre de aux
                temp = IndexOf(aux.Nombre); //Ahora cambiamos el aux por medio del nuevo indice
                aux = recorridos[nodoBuscar, temp]; //Buscamos en la misma fila el siguiente nodo
            }

            //Finalmente ingresamos el nodo Origen dentro de la Pila
            nodoPath.Push(nodos[nodoBuscar]);

            //Ahora solo creamos una string para devolver el mensaje. 
            List<NodoF> caminos = new List<NodoF>();

            //Ahora solo queda convertir esto a una lista para ser devuelto
            while (nodoPath.Count > 0) caminos.Add(nodoPath.Pop());

            return caminos;
        }

        /// <summary>
        /// El segundo algoritmo y mas preciso a la vez, busca intercalando entre filas pero en
        /// la misma columna que se encuentra el nodo de Busqueda
        /// </summary>
        /// <param name="nodoOrigen">Es el nodo con el que se comienza la busqueda</param>
        /// <param name="nodoBusqueda">Es el nodo que se busca</param>
        /// <returns>Una lista con los posibles caminos</returns>
        /// <exception cref="ErroresFloyd">Un mensaje del posible fallo</exception>
        private List<NodoF> SegundoAlgoritmo(string nodoOrigen, string nodoBusqueda)
        {
            //Primer recojo los indices de ambos nodos
            int nodoBuscar = IndexOf(nodoOrigen);
            int nodoBuscando = IndexOf(nodoBusqueda);

            //Ahora descarto las posibilidades. 
            //En el caso de que algún nodo no existiera dentro del grafo regresara un mensaje
            if (nodoBuscar == -1) throw new ErroresFloyd("Nodo Origen " + nodoOrigen + " no existe en el grafo");
            if (nodoBuscando == -1) throw new ErroresFloyd("Nodo Búsqueda " + nodoBusqueda + " no existe en el grafo");
            //En el caso de que sea el mismo nodo que se busca también se descarta. 
            if (nodoBuscar == nodoBuscando) throw new ErroresFloyd("El camino es a si mismo");
            //En caso de que su correspondiente en la matriz de pesos es infinito significa que no tiene conexiones. 
            if (pesos[nodoBuscar, nodoBuscando] == infinito) throw new ErroresFloyd($"El nodo {nodoOrigen} no tiene conexiones hacia {nodoBusqueda}");

            //Creo un Nodo aux para el bucle siguiente
            NodoF aux = recorridos[nodoBuscar, nodoBuscando];
            //Empiezo creando una cola con el valor del nodoOrigen
            Queue<NodoF> nodoPath = new Queue<NodoF>();
            nodoPath.Enqueue(nodos[nodoBuscar]);
            //Creo un indice temporal para el bucle siguiente
            int temp = nodoBuscando;

            /*
             * En el bucle ahora lo que hace es que va a ir de posición
             * en posición dentro de la matriz de recorridos. 
             */
            while (aux != nodos[temp])
            {
                nodoPath.Enqueue(aux); //Primero acolamos el nombre de aux
                temp = IndexOf(aux.Nombre); //Ahora cambiamos el aux por medio del nuevo indice
                aux = recorridos[temp, nodoBuscando]; //a diferencia del primer algoritmo, aqui buscamos por las columnas.
            }

            //En el caso de que el auxiliar no tenga de hijo al de busqueda se descarta el camino actual encontrado. 
            if (!aux.EsNodoHijo(nodos[nodoBuscando]) && aux != nodos[nodoBuscando])
                throw new ErroresFloyd("No hay caminos óptimos del nodo " + nodoOrigen + " al " + nodoBusqueda);

            //En el caso de ser directo ingresamos el nodo Busqueda dentro de la Pila
            if (nodoPath.Count == 1) nodoPath.Enqueue(nodos[nodoBuscando]);

            //Ahora solo creamos una lista para devolver los caminos. 
            List<NodoF> caminos = new List<NodoF>();

            //Queda convertir la cola en una lista y la enviamos de regreso
            while (nodoPath.Count > 0) caminos.Add(nodoPath.Dequeue());

            return caminos;
        }

        /// <summary>
        /// Este algoritmo comprueba que el camino dado llegue realmente al nodo de busuqeda
        /// </summary>
        /// <param name="caminos">La lista de caminos enviada por alguno de los algoritmos anteriores</param>
        /// <param name="nodoOrigen">Es el nodo en el que se comienza la busqueda</param>
        /// <param name="nodoBusqueda">Es el nodo que se busca</param>
        /// <returns>Con un mensaje con su camino comprobado y su peso total.</returns>
        /// <exception cref="ErroresFloyd">En caso de fallar significa que definitivamente no hay caminos</exception>
        private string ComprobarCamino(List<NodoF> caminos, NodoF nodoOrigen, NodoF nodoBusqueda)
        {
            string camino = "";
            NodoF aux = caminos[0];
            int index = 0;

            //Buscará entre todos los hijos y comprobará que entre ellos se encuentren
            //los nodos que están en la lista.
            while (aux != nodoBusqueda && index < caminos.Count - 1)
            {
                if (aux != null) camino += aux.Nombre + ", ";
                aux = caminos[index].BuscarHijo(caminos[++index]);
            }

            //Si no aux no termino siendo el nodoBusqueda es bastante probable que no hay el camino
            if (aux != nodoBusqueda) throw new ErroresFloyd($"No hay caminos optimos de {nodoOrigen.Nombre} a {nodoBusqueda.Nombre}");

            //Regresamos un camino personalizado con el resultado del camino encontrado y comprobado
            return $"{camino}{caminos.Last()}. Con peso total de: {pesos[IndexOf(nodoOrigen.Nombre), IndexOf(nodoBusqueda.Nombre)]}";
        }

        /// <summary>
        /// Bucle que permite la busqueda de todos los caminos de todos los nodos hacia todos los nodos
        /// </summary>
        /// <returns>Un mensaje con todos los caminos en tipo string</returns>
        public string DarTodoslosCaminos()
        {
            string caminos = "";

            //Intercala entre todos los nodos para buscar todos los caminos
            foreach (NodoF primerNodo in nodos)
            {
                foreach (NodoF segundoNodo in nodos)
                {
                    string temp = $"{primerNodo} a {segundoNodo} => {DarCaminos(primerNodo.Nombre, segundoNodo.Nombre)}\n";
                    caminos += temp;
                }
                caminos += "\n";
            }

            return caminos;
        }

        /// <summary>
        /// Por alguna razón no hay IndexOf en los arreglos. Asi que esta
        /// función se encarga de eso. 
        /// </summary>
        /// <param name="nombreNodo">Usamos el nombre para la busqueda del nodo</param>
        /// <returns></returns>
        private int IndexOf(string nombreNodo)
        {
            //Solo aplico una busqueda lineal. El algoritmo mas basico. 
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

        /// <summary>
        /// Comprueba que ese nodo se encuentra entre sus aristas
        /// </summary>
        /// <param name="hijo">Nodo con el que comprueba si es hijo del nodo</param>
        /// <returns>Un boolean indicando si es o no el hijo</returns>
        public bool EsNodoHijo(NodoF hijo)
        {
            //Solo busca de manera lineal si es o no su hijo
            foreach (AristaF arista in aristas)
            {
                if (arista.Nodo == hijo) { return true; }
            }
            //Si termino el bucle es que en definitiva no hubo el hijo
            return false;
        }

        /// <summary>
        /// Busca y regresa el hijo en caso de existir
        /// </summary>
        /// <param name="hijo">Es el nodo que se busca</param>
        /// <returns>Si se encontró se regresa con la dirección de memoria, de lo contrario regresará null</returns>
        public NodoF BuscarHijo(NodoF hijo)
        {
            foreach (AristaF arista in aristas)
            {
                if (arista.Nodo == hijo) { return arista.Nodo; }
            }
            return null;
        }

        /// <summary>
        /// Convierte el nodo a string
        /// </summary>
        /// <returns>Nombre del nodo</returns>
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

        public override string ToString()
        {
            return Message;
        }
    }
}
