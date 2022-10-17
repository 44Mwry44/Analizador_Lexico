namespace Analizador_Lexico
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
            this.btnAnalizador = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvError = new System.Windows.Forms.DataGridView();
            this.dgvSimbolos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvTabla = new System.Windows.Forms.DataGridView();
            this.txtToken = new System.Windows.Forms.RichTextBox();
            this.txtFuente = new System.Windows.Forms.TextBox();
            this.txtLinea = new System.Windows.Forms.TextBox();
            this.dgvGramatica = new System.Windows.Forms.DataGridView();
            this.txtDerivacionesSintaxis = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGramatica)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnalizador
            // 
            this.btnAnalizador.Location = new System.Drawing.Point(296, 160);
            this.btnAnalizador.Name = "btnAnalizador";
            this.btnAnalizador.Size = new System.Drawing.Size(65, 38);
            this.btnAnalizador.TabIndex = 0;
            this.btnAnalizador.Text = "Analizar Lexico";
            this.btnAnalizador.UseVisualStyleBackColor = true;
            this.btnAnalizador.Click += new System.EventHandler(this.btnAnalizador_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(296, 256);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(65, 23);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(296, 285);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(65, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvError
            // 
            this.dgvError.AllowUserToAddRows = false;
            this.dgvError.AllowUserToDeleteRows = false;
            this.dgvError.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvError.Location = new System.Drawing.Point(368, 217);
            this.dgvError.Name = "dgvError";
            this.dgvError.ReadOnly = true;
            this.dgvError.RowHeadersWidth = 51;
            this.dgvError.Size = new System.Drawing.Size(379, 150);
            this.dgvError.TabIndex = 5;
            // 
            // dgvSimbolos
            // 
            this.dgvSimbolos.AllowUserToAddRows = false;
            this.dgvSimbolos.AllowUserToDeleteRows = false;
            this.dgvSimbolos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimbolos.Location = new System.Drawing.Point(752, 217);
            this.dgvSimbolos.Name = "dgvSimbolos";
            this.dgvSimbolos.ReadOnly = true;
            this.dgvSimbolos.RowHeadersWidth = 51;
            this.dgvSimbolos.Size = new System.Drawing.Size(379, 150);
            this.dgvSimbolos.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Programa Fuente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(712, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Archivo Tokens";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(531, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Errores";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(888, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tabla de simbolos";
            // 
            // dgvTabla
            // 
            this.dgvTabla.AllowUserToAddRows = false;
            this.dgvTabla.AllowUserToDeleteRows = false;
            this.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabla.Location = new System.Drawing.Point(20, 385);
            this.dgvTabla.Name = "dgvTabla";
            this.dgvTabla.ReadOnly = true;
            this.dgvTabla.RowHeadersWidth = 51;
            this.dgvTabla.Size = new System.Drawing.Size(1112, 206);
            this.dgvTabla.TabIndex = 15;
            // 
            // txtToken
            // 
            this.txtToken.BackColor = System.Drawing.SystemColors.Control;
            this.txtToken.Location = new System.Drawing.Point(410, 47);
            this.txtToken.Name = "txtToken";
            this.txtToken.ReadOnly = true;
            this.txtToken.Size = new System.Drawing.Size(722, 135);
            this.txtToken.TabIndex = 16;
            this.txtToken.Text = "";
            // 
            // txtFuente
            // 
            this.txtFuente.Location = new System.Drawing.Point(12, 47);
            this.txtFuente.Multiline = true;
            this.txtFuente.Name = "txtFuente";
            this.txtFuente.Size = new System.Drawing.Size(278, 321);
            this.txtFuente.TabIndex = 18;
            // 
            // txtLinea
            // 
            this.txtLinea.Location = new System.Drawing.Point(376, 47);
            this.txtLinea.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLinea.Multiline = true;
            this.txtLinea.Name = "txtLinea";
            this.txtLinea.Size = new System.Drawing.Size(29, 135);
            this.txtLinea.TabIndex = 19;
            // 
            // dgvGramatica
            // 
            this.dgvGramatica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGramatica.Location = new System.Drawing.Point(1144, 385);
            this.dgvGramatica.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvGramatica.Name = "dgvGramatica";
            this.dgvGramatica.RowHeadersWidth = 51;
            this.dgvGramatica.RowTemplate.Height = 24;
            this.dgvGramatica.Size = new System.Drawing.Size(280, 206);
            this.dgvGramatica.TabIndex = 20;
            // 
            // txtDerivacionesSintaxis
            // 
            this.txtDerivacionesSintaxis.Location = new System.Drawing.Point(20, 608);
            this.txtDerivacionesSintaxis.Multiline = true;
            this.txtDerivacionesSintaxis.Name = "txtDerivacionesSintaxis";
            this.txtDerivacionesSintaxis.Size = new System.Drawing.Size(466, 190);
            this.txtDerivacionesSintaxis.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 122);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 34);
            this.button1.TabIndex = 22;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(296, 85);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 34);
            this.button2.TabIndex = 23;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 552);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDerivacionesSintaxis);
            this.Controls.Add(this.dgvGramatica);
            this.Controls.Add(this.txtLinea);
            this.Controls.Add(this.txtFuente);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.dgvTabla);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSimbolos);
            this.Controls.Add(this.dgvError);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnAnalizador);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analizador Lexico";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGramatica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnalizador;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvError;
        private System.Windows.Forms.DataGridView dgvSimbolos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvTabla;
        private System.Windows.Forms.RichTextBox txtToken;
        private System.Windows.Forms.TextBox txtFuente;
        private System.Windows.Forms.TextBox txtLinea;
        private System.Windows.Forms.DataGridView dgvGramatica;
        private System.Windows.Forms.TextBox txtDerivacionesSintaxis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

