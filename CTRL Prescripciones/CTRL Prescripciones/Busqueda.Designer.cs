
namespace CTRL_Prescripciones
{
    partial class Busqueda
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.txtVal0 = new System.Windows.Forms.TextBox();
            this.lblVal0 = new System.Windows.Forms.Label();
            this.cmbCri0 = new System.Windows.Forms.ComboBox();
            this.lblCri0 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(248, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nueva busqueda";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 52);
            this.panel1.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.Controls.Add(this.txtVal0);
            this.pnlBody.Controls.Add(this.lblVal0);
            this.pnlBody.Controls.Add(this.cmbCri0);
            this.pnlBody.Controls.Add(this.lblCri0);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBody.Location = new System.Drawing.Point(0, 52);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(476, 223);
            this.pnlBody.TabIndex = 2;
            // 
            // txtVal0
            // 
            this.txtVal0.Location = new System.Drawing.Point(181, 46);
            this.txtVal0.Name = "txtVal0";
            this.txtVal0.Size = new System.Drawing.Size(275, 20);
            this.txtVal0.TabIndex = 5;
            // 
            // lblVal0
            // 
            this.lblVal0.AutoSize = true;
            this.lblVal0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblVal0.Location = new System.Drawing.Point(130, 46);
            this.lblVal0.Name = "lblVal0";
            this.lblVal0.Size = new System.Drawing.Size(45, 17);
            this.lblVal0.TabIndex = 4;
            this.lblVal0.Text = "Valor:";
            // 
            // cmbCri0
            // 
            this.cmbCri0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCri0.FormattingEnabled = true;
            this.cmbCri0.Location = new System.Drawing.Point(181, 19);
            this.cmbCri0.Name = "cmbCri0";
            this.cmbCri0.Size = new System.Drawing.Size(275, 21);
            this.cmbCri0.TabIndex = 3;
            // 
            // lblCri0
            // 
            this.lblCri0.AutoSize = true;
            this.lblCri0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCri0.Location = new System.Drawing.Point(11, 19);
            this.lblCri0.Name = "lblCri0";
            this.lblCri0.Size = new System.Drawing.Size(164, 17);
            this.lblCri0.TabIndex = 2;
            this.lblCri0.Text = "Criterio de busqueda #1:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnBack);
            this.panel3.Controls.Add(this.btnBuscar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 275);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(644, 46);
            this.panel3.TabIndex = 3;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(482, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Regresar";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(563, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(475, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 223);
            this.panel2.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(7, 194);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(156, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Agregar criterio de busqueda";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Busqueda
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 321);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(660, 1000);
            this.MinimumSize = new System.Drawing.Size(660, 350);
            this.Name = "Busqueda";
            this.Text = "Busqueda";
            this.Load += new System.EventHandler(this.Busqueda_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtVal0;
        private System.Windows.Forms.Label lblVal0;
        private System.Windows.Forms.ComboBox cmbCri0;
        private System.Windows.Forms.Label lblCri0;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdd;
    }
}