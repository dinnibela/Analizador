
namespace AnalizadorLexico
{
    partial class FAnalizador
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
            this.BAnalizar = new System.Windows.Forms.Button();
            this.DGV_Result = new System.Windows.Forms.DataGridView();
            this.Tresult = new System.Windows.Forms.TextBox();
            this.TCodigo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Result)).BeginInit();
            this.SuspendLayout();
            // 
            // BAnalizar
            // 
            this.BAnalizar.Location = new System.Drawing.Point(353, 188);
            this.BAnalizar.Name = "BAnalizar";
            this.BAnalizar.Size = new System.Drawing.Size(75, 23);
            this.BAnalizar.TabIndex = 1;
            this.BAnalizar.Text = ">>";
            this.BAnalizar.UseVisualStyleBackColor = true;
            this.BAnalizar.Click += new System.EventHandler(this.BAnalizar_Click);
            // 
            // DGV_Result
            // 
            this.DGV_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Result.Location = new System.Drawing.Point(434, 12);
            this.DGV_Result.Name = "DGV_Result";
            this.DGV_Result.Size = new System.Drawing.Size(335, 426);
            this.DGV_Result.TabIndex = 2;
            // 
            // Tresult
            // 
            this.Tresult.Location = new System.Drawing.Point(434, 259);
            this.Tresult.Multiline = true;
            this.Tresult.Name = "Tresult";
            this.Tresult.Size = new System.Drawing.Size(335, 179);
            this.Tresult.TabIndex = 3;
            // 
            // TCodigo
            // 
            this.TCodigo.BackColor = System.Drawing.SystemColors.Window;
            this.TCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TCodigo.ForeColor = System.Drawing.Color.Black;
            this.TCodigo.Location = new System.Drawing.Point(12, 10);
            this.TCodigo.Name = "TCodigo";
            this.TCodigo.Size = new System.Drawing.Size(335, 428);
            this.TCodigo.TabIndex = 4;
            this.TCodigo.Text = "";
            // 
            // FAnalizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TCodigo);
            this.Controls.Add(this.Tresult);
            this.Controls.Add(this.DGV_Result);
            this.Controls.Add(this.BAnalizar);
            this.Name = "FAnalizador";
            this.Text = "Analizador";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BAnalizar;
        private System.Windows.Forms.DataGridView DGV_Result;
        private System.Windows.Forms.TextBox Tresult;
        private System.Windows.Forms.RichTextBox TCodigo;
    }
}

