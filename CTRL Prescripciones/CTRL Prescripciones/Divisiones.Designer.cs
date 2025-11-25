
namespace CTRL_Prescripciones
{
    partial class Divisiones
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnOrden = new System.Windows.Forms.Button();
            this.btnTurnos = new System.Windows.Forms.Button();
            this.btnEditarRegistros = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.orden1 = new CTRL_Prescripciones.Orden();
            this.turnos1 = new CTRL_Prescripciones.Turno();
            this.editar_Analista1 = new CTRL_Prescripciones.Editar_Analista();
            this.pnlHeader.SuspendLayout();
            this.pnlNavbar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(984, 56);
            this.pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(421, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Analistas";
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.Controls.Add(this.button7);
            this.pnlNavbar.Controls.Add(this.button6);
            this.pnlNavbar.Controls.Add(this.button5);
            this.pnlNavbar.Controls.Add(this.button4);
            this.pnlNavbar.Controls.Add(this.button3);
            this.pnlNavbar.Controls.Add(this.button2);
            this.pnlNavbar.Controls.Add(this.btnOrden);
            this.pnlNavbar.Controls.Add(this.btnTurnos);
            this.pnlNavbar.Controls.Add(this.btnEditarRegistros);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavbar.Location = new System.Drawing.Point(0, 56);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(288, 605);
            this.pnlNavbar.TabIndex = 2;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(0, 217);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(288, 31);
            this.button7.TabIndex = 2;
            this.button7.Text = "Editar registro";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(0, 574);
            this.button6.Margin = new System.Windows.Forms.Padding(10);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(288, 31);
            this.button6.TabIndex = 1;
            this.button6.Text = "Regresar";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button6.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            this.button6.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(0, 186);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(288, 31);
            this.button5.TabIndex = 0;
            this.button5.Text = "Conteo general";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            this.button5.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(0, 155);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(288, 31);
            this.button4.TabIndex = 0;
            this.button4.Text = "Desgloces";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            this.button4.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(0, 124);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(288, 31);
            this.button3.TabIndex = 0;
            this.button3.Text = "Turnados";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            this.button3.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(288, 31);
            this.button2.TabIndex = 0;
            this.button2.Text = "Concluidos";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            this.button2.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnOrden
            // 
            this.btnOrden.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrden.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrden.FlatAppearance.BorderSize = 0;
            this.btnOrden.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrden.Location = new System.Drawing.Point(0, 62);
            this.btnOrden.Name = "btnOrden";
            this.btnOrden.Size = new System.Drawing.Size(288, 31);
            this.btnOrden.TabIndex = 0;
            this.btnOrden.Text = "Orden";
            this.btnOrden.UseVisualStyleBackColor = false;
            this.btnOrden.Click += new System.EventHandler(this.btnOrden_Click);
            this.btnOrden.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            this.btnOrden.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnTurnos
            // 
            this.btnTurnos.BackColor = System.Drawing.Color.White;
            this.btnTurnos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTurnos.FlatAppearance.BorderSize = 0;
            this.btnTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTurnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurnos.ForeColor = System.Drawing.Color.Black;
            this.btnTurnos.Location = new System.Drawing.Point(0, 31);
            this.btnTurnos.Name = "btnTurnos";
            this.btnTurnos.Size = new System.Drawing.Size(288, 31);
            this.btnTurnos.TabIndex = 0;
            this.btnTurnos.Text = "Turnos";
            this.btnTurnos.UseVisualStyleBackColor = false;
            this.btnTurnos.Click += new System.EventHandler(this.btnTurnos_Click);
            this.btnTurnos.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            this.btnTurnos.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnEditarRegistros
            // 
            this.btnEditarRegistros.BackColor = System.Drawing.Color.White;
            this.btnEditarRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditarRegistros.FlatAppearance.BorderSize = 0;
            this.btnEditarRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarRegistros.ForeColor = System.Drawing.Color.Black;
            this.btnEditarRegistros.Location = new System.Drawing.Point(0, 0);
            this.btnEditarRegistros.Name = "btnEditarRegistros";
            this.btnEditarRegistros.Size = new System.Drawing.Size(288, 31);
            this.btnEditarRegistros.TabIndex = 0;
            this.btnEditarRegistros.Text = "Editar registro";
            this.btnEditarRegistros.UseVisualStyleBackColor = false;
            this.btnEditarRegistros.Click += new System.EventHandler(this.btnEditarRegistros_Click);
            this.btnEditarRegistros.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            this.btnEditarRegistros.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.Controls.Add(this.orden1);
            this.pnlBody.Controls.Add(this.turnos1);
            this.pnlBody.Controls.Add(this.editar_Analista1);
            this.pnlBody.Location = new System.Drawing.Point(294, 56);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(690, 605);
            this.pnlBody.TabIndex = 2;
            // 
            // orden1
            // 
            this.orden1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orden1.Location = new System.Drawing.Point(0, 0);
            this.orden1.Name = "orden1";
            this.orden1.Size = new System.Drawing.Size(690, 605);
            this.orden1.TabIndex = 3;
            // 
            // turnos1
            // 
            this.turnos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.turnos1.Location = new System.Drawing.Point(0, 0);
            this.turnos1.MinimumSize = new System.Drawing.Size(690, 605);
            this.turnos1.Name = "turnos1";
            this.turnos1.Size = new System.Drawing.Size(690, 605);
            this.turnos1.TabIndex = 2;
            // 
            // editar_Analista1
            // 
            this.editar_Analista1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editar_Analista1.jefe = false;
            this.editar_Analista1.Location = new System.Drawing.Point(0, 0);
            this.editar_Analista1.Margin = new System.Windows.Forms.Padding(10);
            this.editar_Analista1.MinimumSize = new System.Drawing.Size(690, 605);
            this.editar_Analista1.Name = "editar_Analista1";
            this.editar_Analista1.Size = new System.Drawing.Size(690, 605);
            this.editar_Analista1.TabIndex = 0;
            // 
            // Divisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlNavbar);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "Divisiones";
            this.Text = "Analistas";
            this.Load += new System.EventHandler(this.Divisiones_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlNavbar.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Button btnEditarRegistros;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnOrden;
        private System.Windows.Forms.Button btnTurnos;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel pnlBody;
        private Editar_Analista editar_Analista1;
        private Turno turnos1;
        private System.Windows.Forms.Button button7;
        private Orden orden1;
    }
}