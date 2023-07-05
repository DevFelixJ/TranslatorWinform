namespace Traductor
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.cmbInputLanguage = new System.Windows.Forms.ComboBox();
            this.cmbOutputLanguage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(50, 35);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(699, 142);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(50, 243);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(699, 142);
            this.txtOutput.TabIndex = 1;
            // 
            // btnTranslate
            // 
            this.btnTranslate.Location = new System.Drawing.Point(279, 183);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(164, 54);
            this.btnTranslate.TabIndex = 4;
            this.btnTranslate.Text = "TRADUCIR";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // cmbInputLanguage
            // 
            this.cmbInputLanguage.FormattingEnabled = true;
            this.cmbInputLanguage.Location = new System.Drawing.Point(50, 13);
            this.cmbInputLanguage.Name = "cmbInputLanguage";
            this.cmbInputLanguage.Size = new System.Drawing.Size(121, 21);
            this.cmbInputLanguage.TabIndex = 5;
            // 
            // cmbOutputLanguage
            // 
            this.cmbOutputLanguage.FormattingEnabled = true;
            this.cmbOutputLanguage.Location = new System.Drawing.Point(50, 216);
            this.cmbOutputLanguage.Name = "cmbOutputLanguage";
            this.cmbOutputLanguage.Size = new System.Drawing.Size(121, 21);
            this.cmbOutputLanguage.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbOutputLanguage);
            this.Controls.Add(this.cmbInputLanguage);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Name = "Form1";
            this.Text = "Traductor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.ComboBox cmbInputLanguage;
        private System.Windows.Forms.ComboBox cmbOutputLanguage;
    }
}

