namespace AplicativoGrafos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFloyd = new System.Windows.Forms.Button();
            this.btnDijkstra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNodo1 = new System.Windows.Forms.TextBox();
            this.txtNodo2 = new System.Windows.Forms.TextBox();
            this.lblInd1 = new System.Windows.Forms.Label();
            this.lblInd2 = new System.Windows.Forms.Label();
            this.lblNodo1 = new System.Windows.Forms.Label();
            this.lblNomNodo2 = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.nupArista = new System.Windows.Forms.NumericUpDown();
            this.lblContNodo = new System.Windows.Forms.Label();
            this.lblCont = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.lblPond = new System.Windows.Forms.Label();
            this.lblReco = new System.Windows.Forms.Label();
            this.lbxRespuestas = new System.Windows.Forms.ListBox();
            this.lbxPonderaciones = new System.Windows.Forms.ListBox();
            this.lbxRecorridos = new System.Windows.Forms.ListBox();
            this.lbxDijsktra = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNodoInicio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lbxFloyd = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nupArista)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFloyd
            // 
            this.btnFloyd.Location = new System.Drawing.Point(731, 69);
            this.btnFloyd.Name = "btnFloyd";
            this.btnFloyd.Size = new System.Drawing.Size(105, 44);
            this.btnFloyd.TabIndex = 0;
            this.btnFloyd.Text = "Floyd";
            this.btnFloyd.UseVisualStyleBackColor = true;
            this.btnFloyd.Click += new System.EventHandler(this.btnFloyd_Click);
            // 
            // btnDijkstra
            // 
            this.btnDijkstra.Location = new System.Drawing.Point(145, 279);
            this.btnDijkstra.Name = "btnDijkstra";
            this.btnDijkstra.Size = new System.Drawing.Size(105, 59);
            this.btnDijkstra.TabIndex = 1;
            this.btnDijkstra.Text = "Dijkstra";
            this.btnDijkstra.UseVisualStyleBackColor = true;
            this.btnDijkstra.Click += new System.EventHandler(this.btnDijkstra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Realizado por: Urresta Adrian, Arteaga Kevin, Puentestar Carlos";
            // 
            // txtNodo1
            // 
            this.txtNodo1.Location = new System.Drawing.Point(144, 94);
            this.txtNodo1.Name = "txtNodo1";
            this.txtNodo1.Size = new System.Drawing.Size(100, 22);
            this.txtNodo1.TabIndex = 3;
            // 
            // txtNodo2
            // 
            this.txtNodo2.Location = new System.Drawing.Point(145, 165);
            this.txtNodo2.Name = "txtNodo2";
            this.txtNodo2.Size = new System.Drawing.Size(100, 22);
            this.txtNodo2.TabIndex = 5;
            // 
            // lblInd1
            // 
            this.lblInd1.AutoSize = true;
            this.lblInd1.Location = new System.Drawing.Point(73, 61);
            this.lblInd1.Name = "lblInd1";
            this.lblInd1.Size = new System.Drawing.Size(133, 16);
            this.lblInd1.TabIndex = 6;
            this.lblInd1.Text = "Ingrese el Nodo Raiz";
            // 
            // lblInd2
            // 
            this.lblInd2.AutoSize = true;
            this.lblInd2.Location = new System.Drawing.Point(50, 135);
            this.lblInd2.Name = "lblInd2";
            this.lblInd2.Size = new System.Drawing.Size(171, 16);
            this.lblInd2.TabIndex = 7;
            this.lblInd2.Text = "Ingrese el Nodo a Conectar";
            // 
            // lblNodo1
            // 
            this.lblNodo1.AutoSize = true;
            this.lblNodo1.Location = new System.Drawing.Point(23, 97);
            this.lblNodo1.Name = "lblNodo1";
            this.lblNodo1.Size = new System.Drawing.Size(112, 16);
            this.lblNodo1.TabIndex = 8;
            this.lblNodo1.Text = "Nombre de Nodo";
            // 
            // lblNomNodo2
            // 
            this.lblNomNodo2.AutoSize = true;
            this.lblNomNodo2.Location = new System.Drawing.Point(22, 171);
            this.lblNomNodo2.Name = "lblNomNodo2";
            this.lblNomNodo2.Size = new System.Drawing.Size(112, 16);
            this.lblNomNodo2.TabIndex = 10;
            this.lblNomNodo2.Text = "Nombre de Nodo";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(40, 205);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(76, 16);
            this.lblPeso.TabIndex = 11;
            this.lblPeso.Text = "Peso Arista";
            // 
            // nupArista
            // 
            this.nupArista.Location = new System.Drawing.Point(157, 203);
            this.nupArista.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupArista.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupArista.Name = "nupArista";
            this.nupArista.Size = new System.Drawing.Size(76, 22);
            this.nupArista.TabIndex = 12;
            this.nupArista.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblContNodo
            // 
            this.lblContNodo.AutoSize = true;
            this.lblContNodo.Location = new System.Drawing.Point(294, 61);
            this.lblContNodo.Name = "lblContNodo";
            this.lblContNodo.Size = new System.Drawing.Size(109, 16);
            this.lblContNodo.TabIndex = 13;
            this.lblContNodo.Text = "Contador Nodos:";
            // 
            // lblCont
            // 
            this.lblCont.AutoSize = true;
            this.lblCont.Location = new System.Drawing.Point(406, 61);
            this.lblCont.Name = "lblCont";
            this.lblCont.Size = new System.Drawing.Size(14, 16);
            this.lblCont.TabIndex = 14;
            this.lblCont.Text = "0";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(250, 128);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 16;
            this.btnConectar.Text = "Añadir";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // lblPond
            // 
            this.lblPond.AutoSize = true;
            this.lblPond.Location = new System.Drawing.Point(515, 100);
            this.lblPond.Name = "lblPond";
            this.lblPond.Size = new System.Drawing.Size(124, 16);
            this.lblPond.TabIndex = 17;
            this.lblPond.Text = "PONDERACIONES";
            // 
            // lblReco
            // 
            this.lblReco.AutoSize = true;
            this.lblReco.Location = new System.Drawing.Point(943, 100);
            this.lblReco.Name = "lblReco";
            this.lblReco.Size = new System.Drawing.Size(97, 16);
            this.lblReco.TabIndex = 18;
            this.lblReco.Text = "RECORRIDOS";
            // 
            // lbxRespuestas
            // 
            this.lbxRespuestas.FormattingEnabled = true;
            this.lbxRespuestas.HorizontalScrollbar = true;
            this.lbxRespuestas.ItemHeight = 16;
            this.lbxRespuestas.Location = new System.Drawing.Point(367, 369);
            this.lbxRespuestas.Name = "lbxRespuestas";
            this.lbxRespuestas.Size = new System.Drawing.Size(441, 212);
            this.lbxRespuestas.TabIndex = 19;
            // 
            // lbxPonderaciones
            // 
            this.lbxPonderaciones.FormattingEnabled = true;
            this.lbxPonderaciones.HorizontalScrollbar = true;
            this.lbxPonderaciones.ItemHeight = 16;
            this.lbxPonderaciones.Location = new System.Drawing.Point(367, 119);
            this.lbxPonderaciones.Name = "lbxPonderaciones";
            this.lbxPonderaciones.Size = new System.Drawing.Size(441, 228);
            this.lbxPonderaciones.TabIndex = 20;
            // 
            // lbxRecorridos
            // 
            this.lbxRecorridos.FormattingEnabled = true;
            this.lbxRecorridos.HorizontalScrollbar = true;
            this.lbxRecorridos.ItemHeight = 16;
            this.lbxRecorridos.Location = new System.Drawing.Point(814, 119);
            this.lbxRecorridos.Name = "lbxRecorridos";
            this.lbxRecorridos.Size = new System.Drawing.Size(406, 228);
            this.lbxRecorridos.TabIndex = 21;
            // 
            // lbxDijsktra
            // 
            this.lbxDijsktra.FormattingEnabled = true;
            this.lbxDijsktra.HorizontalScrollbar = true;
            this.lbxDijsktra.ItemHeight = 16;
            this.lbxDijsktra.Location = new System.Drawing.Point(2, 433);
            this.lbxDijsktra.Name = "lbxDijsktra";
            this.lbxDijsktra.Size = new System.Drawing.Size(359, 148);
            this.lbxDijsktra.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Resultados Dijkstra";
            // 
            // txtNodoInicio
            // 
            this.txtNodoInicio.Location = new System.Drawing.Point(250, 357);
            this.txtNodoInicio.Name = "txtNodoInicio";
            this.txtNodoInicio.Size = new System.Drawing.Size(100, 22);
            this.txtNodoInicio.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Ingrese el Nodo Buscar Caminos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(515, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Conexiones ";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1065, 599);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(105, 44);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(951, 599);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(105, 44);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lbxFloyd
            // 
            this.lbxFloyd.FormattingEnabled = true;
            this.lbxFloyd.HorizontalScrollbar = true;
            this.lbxFloyd.ItemHeight = 16;
            this.lbxFloyd.Location = new System.Drawing.Point(814, 369);
            this.lbxFloyd.Name = "lbxFloyd";
            this.lbxFloyd.Size = new System.Drawing.Size(406, 212);
            this.lbxFloyd.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(943, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Resultados Floyd";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1232, 676);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbxFloyd);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNodoInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbxDijsktra);
            this.Controls.Add(this.lbxRecorridos);
            this.Controls.Add(this.lbxPonderaciones);
            this.Controls.Add(this.lbxRespuestas);
            this.Controls.Add(this.lblReco);
            this.Controls.Add(this.lblPond);
            this.Controls.Add(this.btnFloyd);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.lblCont);
            this.Controls.Add(this.lblContNodo);
            this.Controls.Add(this.nupArista);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.lblNomNodo2);
            this.Controls.Add(this.lblNodo1);
            this.Controls.Add(this.lblInd2);
            this.Controls.Add(this.lblInd1);
            this.Controls.Add(this.txtNodo2);
            this.Controls.Add(this.txtNodo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDijkstra);
            this.Name = "Form1";
            this.Text = "Aplicativo Grafos";
            ((System.ComponentModel.ISupportInitialize)(this.nupArista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFloyd;
        private System.Windows.Forms.Button btnDijkstra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNodo1;
        private System.Windows.Forms.TextBox txtNodo2;
        private System.Windows.Forms.Label lblInd1;
        private System.Windows.Forms.Label lblInd2;
        private System.Windows.Forms.Label lblNodo1;
        private System.Windows.Forms.Label lblNomNodo2;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.NumericUpDown nupArista;
        private System.Windows.Forms.Label lblContNodo;
        private System.Windows.Forms.Label lblCont;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label lblPond;
        private System.Windows.Forms.Label lblReco;
        private System.Windows.Forms.ListBox lbxRespuestas;
        private System.Windows.Forms.ListBox lbxPonderaciones;
        private System.Windows.Forms.ListBox lbxRecorridos;
        private System.Windows.Forms.ListBox lbxDijsktra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNodoInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ListBox lbxFloyd;
        private System.Windows.Forms.Label label5;
    }
}

