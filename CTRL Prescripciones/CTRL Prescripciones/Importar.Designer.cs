namespace CTRL_Prescripciones
{
    partial class Importar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImpAnalistas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdImportar = new System.Windows.Forms.OpenFileDialog();
            this.pgbProgreso = new System.Windows.Forms.ProgressBar();
            this.btnEstatus = new System.Windows.Forms.Button();
            this.btnClasificaciones = new System.Windows.Forms.Button();
            this.btnTipos = new System.Windows.Forms.Button();
            this.btnOrigenes = new System.Windows.Forms.Button();
            this.btnSIDEC = new System.Windows.Forms.Button();
            this.btnSANC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImpAnalistas
            // 
            this.btnImpAnalistas.Location = new System.Drawing.Point(12, 64);
            this.btnImpAnalistas.Name = "btnImpAnalistas";
            this.btnImpAnalistas.Size = new System.Drawing.Size(283, 23);
            this.btnImpAnalistas.TabIndex = 0;
            this.btnImpAnalistas.Text = "Importar Analistas";
            this.btnImpAnalistas.UseVisualStyleBackColor = true;
            this.btnImpAnalistas.Click += new System.EventHandler(this.btnImpAnalistas_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Importar información";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ofdImportar
            // 
            this.ofdImportar.FileName = "openFileDialog1";
            this.ofdImportar.Filter = "Excle files (*.xlsx)|*.xlsx,.xls|All files (*.*)|*.*";
            // 
            // pgbProgreso
            // 
            this.pgbProgreso.Location = new System.Drawing.Point(12, 363);
            this.pgbProgreso.Name = "pgbProgreso";
            this.pgbProgreso.Size = new System.Drawing.Size(284, 23);
            this.pgbProgreso.TabIndex = 2;
            // 
            // btnEstatus
            // 
            this.btnEstatus.Location = new System.Drawing.Point(12, 93);
            this.btnEstatus.Name = "btnEstatus";
            this.btnEstatus.Size = new System.Drawing.Size(283, 23);
            this.btnEstatus.TabIndex = 3;
            this.btnEstatus.Text = "Importar Estatus";
            this.btnEstatus.UseVisualStyleBackColor = true;
            this.btnEstatus.Click += new System.EventHandler(this.btnEstatus_Click);
            // 
            // btnClasificaciones
            // 
            this.btnClasificaciones.Location = new System.Drawing.Point(12, 122);
            this.btnClasificaciones.Name = "btnClasificaciones";
            this.btnClasificaciones.Size = new System.Drawing.Size(283, 23);
            this.btnClasificaciones.TabIndex = 4;
            this.btnClasificaciones.Text = "Importar Clasificaciones";
            this.btnClasificaciones.UseVisualStyleBackColor = true;
            this.btnClasificaciones.Click += new System.EventHandler(this.btnClasificaciones_Click);
            // 
            // btnTipos
            // 
            this.btnTipos.Location = new System.Drawing.Point(13, 151);
            this.btnTipos.Name = "btnTipos";
            this.btnTipos.Size = new System.Drawing.Size(283, 23);
            this.btnTipos.TabIndex = 5;
            this.btnTipos.Text = "Importar Tipos";
            this.btnTipos.UseVisualStyleBackColor = true;
            this.btnTipos.Click += new System.EventHandler(this.btnTipos_Click);
            // 
            // btnOrigenes
            // 
            this.btnOrigenes.Location = new System.Drawing.Point(12, 180);
            this.btnOrigenes.Name = "btnOrigenes";
            this.btnOrigenes.Size = new System.Drawing.Size(283, 23);
            this.btnOrigenes.TabIndex = 6;
            this.btnOrigenes.Text = "Importar Origenes";
            this.btnOrigenes.UseVisualStyleBackColor = true;
            this.btnOrigenes.Click += new System.EventHandler(this.btnOrigenes_Click);
            // 
            // btnSIDEC
            // 
            this.btnSIDEC.Location = new System.Drawing.Point(13, 209);
            this.btnSIDEC.Name = "btnSIDEC";
            this.btnSIDEC.Size = new System.Drawing.Size(283, 23);
            this.btnSIDEC.TabIndex = 7;
            this.btnSIDEC.Text = "Importar Registros SIDEC";
            this.btnSIDEC.UseVisualStyleBackColor = true;
            this.btnSIDEC.Click += new System.EventHandler(this.btnSIDEC_Click);
            // 
            // btnSANC
            // 
            this.btnSANC.Location = new System.Drawing.Point(12, 238);
            this.btnSANC.Name = "btnSANC";
            this.btnSANC.Size = new System.Drawing.Size(283, 23);
            this.btnSANC.TabIndex = 8;
            this.btnSANC.Text = "Importar Registros SANC";
            this.btnSANC.UseVisualStyleBackColor = true;
            // 
            // Importar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 398);
            this.Controls.Add(this.btnSANC);
            this.Controls.Add(this.btnSIDEC);
            this.Controls.Add(this.btnOrigenes);
            this.Controls.Add(this.btnTipos);
            this.Controls.Add(this.btnClasificaciones);
            this.Controls.Add(this.btnEstatus);
            this.Controls.Add(this.pgbProgreso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImpAnalistas);
            this.MaximumSize = new System.Drawing.Size(323, 437);
            this.MinimumSize = new System.Drawing.Size(323, 437);
            this.Name = "Importar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Importar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImpAnalistas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdImportar;
        private System.Windows.Forms.ProgressBar pgbProgreso;
        private System.Windows.Forms.Button btnEstatus;
        private System.Windows.Forms.Button btnClasificaciones;
        private System.Windows.Forms.Button btnTipos;
        private System.Windows.Forms.Button btnOrigenes;
        private System.Windows.Forms.Button btnSIDEC;
        private System.Windows.Forms.Button btnSANC;
    }
}