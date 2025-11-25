
namespace CTRL_Prescripciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Body = new System.Windows.Forms.Panel();
            this.pnlAanalistas = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNewAnalista = new System.Windows.Forms.Button();
            this.pnlSANC = new System.Windows.Forms.TableLayoutPanel();
            this.btnEditarSANC = new System.Windows.Forms.Button();
            this.btnSearchSANC = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvSANC = new System.Windows.Forms.DataGridView();
            this.btnViewSANC = new System.Windows.Forms.Button();
            this.btnNewSANC = new System.Windows.Forms.Button();
            this.pnlSIDEC = new System.Windows.Forms.TableLayoutPanel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSIDEC = new System.Windows.Forms.DataGridView();
            this.btnNewSIDEC = new System.Windows.Forms.Button();
            this.btnViewSIDEC = new System.Windows.Forms.Button();
            this.btnSearchSIDEC = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.Header.SuspendLayout();
            this.Body.SuspendLayout();
            this.pnlAanalistas.SuspendLayout();
            this.pnlSANC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSANC)).BeginInit();
            this.pnlSIDEC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSIDEC)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Header.Controls.Add(this.label1);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1172, 58);
            this.Header.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(395, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Control de Prescripciones";
            // 
            // Body
            // 
            this.Body.AutoScroll = true;
            this.Body.Controls.Add(this.pnlAanalistas);
            this.Body.Controls.Add(this.pnlSANC);
            this.Body.Controls.Add(this.pnlSIDEC);
            this.Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Body.Location = new System.Drawing.Point(0, 58);
            this.Body.Name = "Body";
            this.Body.Size = new System.Drawing.Size(1172, 781);
            this.Body.TabIndex = 2;
            // 
            // pnlAanalistas
            // 
            this.pnlAanalistas.ColumnCount = 2;
            this.pnlAanalistas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlAanalistas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlAanalistas.Controls.Add(this.label4, 0, 0);
            this.pnlAanalistas.Controls.Add(this.button1, 0, 2);
            this.pnlAanalistas.Controls.Add(this.btnNewAnalista, 1, 2);
            this.pnlAanalistas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAanalistas.Location = new System.Drawing.Point(0, 1562);
            this.pnlAanalistas.Name = "pnlAanalistas";
            this.pnlAanalistas.RowCount = 3;
            this.pnlAanalistas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlAanalistas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlAanalistas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.pnlAanalistas.Size = new System.Drawing.Size(1155, 616);
            this.pnlAanalistas.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.pnlAanalistas.SetColumnSpan(this.label4, 2);
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(510, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "Analistas";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 584);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(571, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNewAnalista
            // 
            this.btnNewAnalista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewAnalista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAnalista.Location = new System.Drawing.Point(580, 584);
            this.btnNewAnalista.Name = "btnNewAnalista";
            this.btnNewAnalista.Size = new System.Drawing.Size(572, 29);
            this.btnNewAnalista.TabIndex = 7;
            this.btnNewAnalista.Text = "Nuevo registro";
            this.btnNewAnalista.UseVisualStyleBackColor = true;
            this.btnNewAnalista.Click += new System.EventHandler(this.btnNewAnalista_Click);
            // 
            // pnlSANC
            // 
            this.pnlSANC.ColumnCount = 4;
            this.pnlSANC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSANC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSANC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSANC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSANC.Controls.Add(this.btnEditarSANC, 0, 2);
            this.pnlSANC.Controls.Add(this.btnSearchSANC, 0, 2);
            this.pnlSANC.Controls.Add(this.label3, 0, 0);
            this.pnlSANC.Controls.Add(this.dgvSANC, 0, 1);
            this.pnlSANC.Controls.Add(this.btnViewSANC, 0, 2);
            this.pnlSANC.Controls.Add(this.btnNewSANC, 3, 2);
            this.pnlSANC.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSANC.Location = new System.Drawing.Point(0, 781);
            this.pnlSANC.Name = "pnlSANC";
            this.pnlSANC.RowCount = 3;
            this.pnlSANC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlSANC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSANC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.pnlSANC.Size = new System.Drawing.Size(1155, 781);
            this.pnlSANC.TabIndex = 1;
            // 
            // btnEditarSANC
            // 
            this.btnEditarSANC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditarSANC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarSANC.Location = new System.Drawing.Point(579, 749);
            this.btnEditarSANC.Name = "btnEditarSANC";
            this.btnEditarSANC.Size = new System.Drawing.Size(282, 29);
            this.btnEditarSANC.TabIndex = 5;
            this.btnEditarSANC.Text = "Editar registro";
            this.btnEditarSANC.UseVisualStyleBackColor = true;
            this.btnEditarSANC.Click += new System.EventHandler(this.btnEditarSANC_Click);
            // 
            // btnSearchSANC
            // 
            this.btnSearchSANC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchSANC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSANC.Location = new System.Drawing.Point(291, 749);
            this.btnSearchSANC.Name = "btnSearchSANC";
            this.btnSearchSANC.Size = new System.Drawing.Size(282, 29);
            this.btnSearchSANC.TabIndex = 3;
            this.btnSearchSANC.Text = "Buscqueda rápida";
            this.btnSearchSANC.UseVisualStyleBackColor = true;
            this.btnSearchSANC.Click += new System.EventHandler(this.btnSearchSANC_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.pnlSANC.SetColumnSpan(this.label3, 4);
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(530, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "SANC";
            // 
            // dgvSANC
            // 
            this.dgvSANC.AllowUserToAddRows = false;
            this.dgvSANC.AllowUserToDeleteRows = false;
            this.dgvSANC.AllowUserToResizeColumns = false;
            this.dgvSANC.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSANC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSANC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pnlSANC.SetColumnSpan(this.dgvSANC, 4);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSANC.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSANC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSANC.Location = new System.Drawing.Point(3, 53);
            this.dgvSANC.Name = "dgvSANC";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSANC.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSANC.Size = new System.Drawing.Size(1149, 690);
            this.dgvSANC.TabIndex = 1;
            // 
            // btnViewSANC
            // 
            this.btnViewSANC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnViewSANC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSANC.Location = new System.Drawing.Point(3, 749);
            this.btnViewSANC.Name = "btnViewSANC";
            this.btnViewSANC.Size = new System.Drawing.Size(282, 29);
            this.btnViewSANC.TabIndex = 2;
            this.btnViewSANC.Text = "Ver";
            this.btnViewSANC.UseVisualStyleBackColor = true;
            // 
            // btnNewSANC
            // 
            this.btnNewSANC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewSANC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewSANC.Location = new System.Drawing.Point(867, 749);
            this.btnNewSANC.Name = "btnNewSANC";
            this.btnNewSANC.Size = new System.Drawing.Size(285, 29);
            this.btnNewSANC.TabIndex = 4;
            this.btnNewSANC.Text = "Nuevo registro";
            this.btnNewSANC.UseVisualStyleBackColor = true;
            this.btnNewSANC.Click += new System.EventHandler(this.btnNewSANC_Click);
            // 
            // pnlSIDEC
            // 
            this.pnlSIDEC.ColumnCount = 4;
            this.pnlSIDEC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSIDEC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSIDEC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSIDEC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSIDEC.Controls.Add(this.btnImprimir, 0, 2);
            this.pnlSIDEC.Controls.Add(this.label2, 0, 0);
            this.pnlSIDEC.Controls.Add(this.dgvSIDEC, 0, 1);
            this.pnlSIDEC.Controls.Add(this.btnNewSIDEC, 3, 2);
            this.pnlSIDEC.Controls.Add(this.btnViewSIDEC, 2, 2);
            this.pnlSIDEC.Controls.Add(this.btnSearchSIDEC, 1, 2);
            this.pnlSIDEC.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSIDEC.Location = new System.Drawing.Point(0, 0);
            this.pnlSIDEC.Name = "pnlSIDEC";
            this.pnlSIDEC.RowCount = 3;
            this.pnlSIDEC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlSIDEC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSIDEC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.pnlSIDEC.Size = new System.Drawing.Size(1155, 781);
            this.pnlSIDEC.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(3, 749);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(282, 29);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Imprimir acuse";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.pnlSIDEC.SetColumnSpan(this.label2, 4);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(526, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "SIDEC";
            // 
            // dgvSIDEC
            // 
            this.dgvSIDEC.AllowUserToAddRows = false;
            this.dgvSIDEC.AllowUserToDeleteRows = false;
            this.dgvSIDEC.AllowUserToResizeColumns = false;
            this.dgvSIDEC.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSIDEC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSIDEC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pnlSIDEC.SetColumnSpan(this.dgvSIDEC, 4);
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSIDEC.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSIDEC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSIDEC.Location = new System.Drawing.Point(3, 53);
            this.dgvSIDEC.Name = "dgvSIDEC";
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSIDEC.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSIDEC.Size = new System.Drawing.Size(1149, 690);
            this.dgvSIDEC.TabIndex = 1;
            // 
            // btnNewSIDEC
            // 
            this.btnNewSIDEC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewSIDEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewSIDEC.Location = new System.Drawing.Point(867, 749);
            this.btnNewSIDEC.Name = "btnNewSIDEC";
            this.btnNewSIDEC.Size = new System.Drawing.Size(285, 29);
            this.btnNewSIDEC.TabIndex = 2;
            this.btnNewSIDEC.Text = "Nuevo registro";
            this.btnNewSIDEC.UseVisualStyleBackColor = true;
            this.btnNewSIDEC.Click += new System.EventHandler(this.btnNewSIDEC_Click);
            // 
            // btnViewSIDEC
            // 
            this.btnViewSIDEC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnViewSIDEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSIDEC.Location = new System.Drawing.Point(579, 749);
            this.btnViewSIDEC.Name = "btnViewSIDEC";
            this.btnViewSIDEC.Size = new System.Drawing.Size(282, 29);
            this.btnViewSIDEC.TabIndex = 4;
            this.btnViewSIDEC.Text = "Editar registro";
            this.btnViewSIDEC.UseVisualStyleBackColor = true;
            this.btnViewSIDEC.Click += new System.EventHandler(this.btnViewSIDEC_Click);
            // 
            // btnSearchSIDEC
            // 
            this.btnSearchSIDEC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchSIDEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSIDEC.Location = new System.Drawing.Point(291, 749);
            this.btnSearchSIDEC.Name = "btnSearchSIDEC";
            this.btnSearchSIDEC.Size = new System.Drawing.Size(282, 29);
            this.btnSearchSIDEC.TabIndex = 3;
            this.btnSearchSIDEC.Text = "Busqueda rápida";
            this.btnSearchSIDEC.UseVisualStyleBackColor = true;
            this.btnSearchSIDEC.Click += new System.EventHandler(this.btnSearchSIDEC_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 839);
            this.Controls.Add(this.Body);
            this.Controls.Add(this.Header);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(970, 850);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de prescripciones";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            this.Body.ResumeLayout(false);
            this.pnlAanalistas.ResumeLayout(false);
            this.pnlAanalistas.PerformLayout();
            this.pnlSANC.ResumeLayout(false);
            this.pnlSANC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSANC)).EndInit();
            this.pnlSIDEC.ResumeLayout(false);
            this.pnlSIDEC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSIDEC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Body;
        private System.Windows.Forms.TableLayoutPanel pnlSANC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvSANC;
        private System.Windows.Forms.Button btnViewSANC;
        private System.Windows.Forms.TableLayoutPanel pnlSIDEC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSIDEC;
        private System.Windows.Forms.Button btnSearchSIDEC;
        private System.Windows.Forms.Button btnSearchSANC;
        private System.Windows.Forms.Button btnNewSANC;
        private System.Windows.Forms.Button btnViewSIDEC;
        private System.Windows.Forms.TableLayoutPanel pnlAanalistas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNewAnalista;
        private System.Windows.Forms.Button btnImprimir;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button btnEditarSANC;
        private System.Windows.Forms.Button btnNewSIDEC;
    }
}

