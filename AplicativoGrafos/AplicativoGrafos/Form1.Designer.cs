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
            ((System.ComponentModel.ISupportInitialize)(this.nupArista)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFloyd
            // 
            this.btnFloyd.Location = new System.Drawing.Point(176, 301);
            this.btnFloyd.Name = "btnFloyd";
            this.btnFloyd.Size = new System.Drawing.Size(105, 59);
            this.btnFloyd.TabIndex = 0;
            this.btnFloyd.Text = "Floyd";
            this.btnFloyd.UseVisualStyleBackColor = true;
            this.btnFloyd.Click += new System.EventHandler(this.btnFloyd_Click);
            // 
            // btnDijkstra
            // 
            this.btnDijkstra.Location = new System.Drawing.Point(43, 301);
            this.btnDijkstra.Name = "btnDijkstra";
            this.btnDijkstra.Size = new System.Drawing.Size(105, 59);
            this.btnDijkstra.TabIndex = 1;
            this.btnDijkstra.Text = "Dijkstra";
            this.btnDijkstra.UseVisualStyleBackColor = true;
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
            this.lblPond.Location = new System.Drawing.Point(450, 75);
            this.lblPond.Name = "lblPond";
            this.lblPond.Size = new System.Drawing.Size(124, 16);
            this.lblPond.TabIndex = 17;
            this.lblPond.Text = "PONDERACIONES";
            // 
            // lblReco
            // 
            this.lblReco.AutoSize = true;
            this.lblReco.Location = new System.Drawing.Point(884, 75);
            this.lblReco.Name = "lblReco";
            this.lblReco.Size = new System.Drawing.Size(97, 16);
            this.lblReco.TabIndex = 18;
            this.lblReco.Text = "RECORRIDOS";
            // 
            // lbxRespuestas
            // 
            this.lbxRespuestas.FormattingEnabled = true;
            this.lbxRespuestas.ItemHeight = 16;
            this.lbxRespuestas.Location = new System.Drawing.Point(542, 424);
            this.lbxRespuestas.Name = "lbxRespuestas";
            this.lbxRespuestas.Size = new System.Drawing.Size(352, 148);
            this.lbxRespuestas.TabIndex = 19;
            // 
            // lbxPonderaciones
            // 
            this.lbxPonderaciones.FormattingEnabled = true;
            this.lbxPonderaciones.ItemHeight = 16;
            this.lbxPonderaciones.Location = new System.Drawing.Point(388, 94);
            this.lbxPonderaciones.Name = "lbxPonderaciones";
            this.lbxPonderaciones.Size = new System.Drawing.Size(352, 148);
            this.lbxPonderaciones.TabIndex = 20;
            // 
            // lbxRecorridos
            // 
            this.lbxRecorridos.FormattingEnabled = true;
            this.lbxRecorridos.ItemHeight = 16;
            this.lbxRecorridos.Location = new System.Drawing.Point(771, 94);
            this.lbxRecorridos.Name = "lbxRecorridos";
            this.lbxRecorridos.Size = new System.Drawing.Size(352, 148);
            this.lbxRecorridos.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1206, 594);
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
    }
}

