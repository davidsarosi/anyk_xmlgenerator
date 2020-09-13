namespace Szamlakezeles
{
    partial class Form1
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
            this.ExcelLoadButton = new System.Windows.Forms.Button();
            this.XMLLoadButton = new System.Windows.Forms.Button();
            this.ExcelTextbox = new System.Windows.Forms.TextBox();
            this.XMLTextbox = new System.Windows.Forms.TextBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BevallasiIdoszakTol = new System.Windows.Forms.TextBox();
            this.BevallasiIdoszakIg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExcelLoadButton
            // 
            this.ExcelLoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExcelLoadButton.Location = new System.Drawing.Point(346, 127);
            this.ExcelLoadButton.Name = "ExcelLoadButton";
            this.ExcelLoadButton.Size = new System.Drawing.Size(104, 32);
            this.ExcelLoadButton.TabIndex = 0;
            this.ExcelLoadButton.Text = "Excel";
            this.ExcelLoadButton.UseVisualStyleBackColor = true;
            this.ExcelLoadButton.Click += new System.EventHandler(this.ExcelLoadButton_Click);
            // 
            // XMLLoadButton
            // 
            this.XMLLoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.XMLLoadButton.Location = new System.Drawing.Point(346, 177);
            this.XMLLoadButton.Name = "XMLLoadButton";
            this.XMLLoadButton.Size = new System.Drawing.Size(104, 32);
            this.XMLLoadButton.TabIndex = 1;
            this.XMLLoadButton.Text = "XML";
            this.XMLLoadButton.UseVisualStyleBackColor = true;
            this.XMLLoadButton.Click += new System.EventHandler(this.XMLLoadButton_Click);
            // 
            // ExcelTextbox
            // 
            this.ExcelTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExcelTextbox.Location = new System.Drawing.Point(28, 130);
            this.ExcelTextbox.Name = "ExcelTextbox";
            this.ExcelTextbox.Size = new System.Drawing.Size(286, 26);
            this.ExcelTextbox.TabIndex = 2;
            // 
            // XMLTextbox
            // 
            this.XMLTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.XMLTextbox.Location = new System.Drawing.Point(28, 180);
            this.XMLTextbox.Name = "XMLTextbox";
            this.XMLTextbox.Size = new System.Drawing.Size(286, 26);
            this.XMLTextbox.TabIndex = 3;
            // 
            // ExportButton
            // 
            this.ExportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExportButton.Location = new System.Drawing.Point(28, 246);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(422, 69);
            this.ExportButton.TabIndex = 4;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bevallási idõszak";
            // 
            // BevallasiIdoszakTol
            // 
            this.BevallasiIdoszakTol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BevallasiIdoszakTol.Location = new System.Drawing.Point(28, 56);
            this.BevallasiIdoszakTol.Name = "BevallasiIdoszakTol";
            this.BevallasiIdoszakTol.Size = new System.Drawing.Size(125, 26);
            this.BevallasiIdoszakTol.TabIndex = 6;
            this.BevallasiIdoszakTol.Text = "éééé-hh-nn";
            this.BevallasiIdoszakTol.Click += new System.EventHandler(this.BevallasiIdoszakTol_Click);
            this.BevallasiIdoszakTol.TextChanged += new System.EventHandler(this.BevallasiIdoszakTol_TextChanged);
            // 
            // BevallasiIdoszakIg
            // 
            this.BevallasiIdoszakIg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BevallasiIdoszakIg.Location = new System.Drawing.Point(213, 59);
            this.BevallasiIdoszakIg.Name = "BevallasiIdoszakIg";
            this.BevallasiIdoszakIg.Size = new System.Drawing.Size(125, 26);
            this.BevallasiIdoszakIg.TabIndex = 7;
            this.BevallasiIdoszakIg.Text = "éééé-hh-nn";
            this.BevallasiIdoszakIg.Click += new System.EventHandler(this.BevallasiIdoszakIg_Click);
            this.BevallasiIdoszakIg.TextChanged += new System.EventHandler(this.BevallasiIdoszakIg_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(159, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "-tól";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(344, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "-ig";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 333);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BevallasiIdoszakIg);
            this.Controls.Add(this.BevallasiIdoszakTol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.XMLTextbox);
            this.Controls.Add(this.ExcelTextbox);
            this.Controls.Add(this.XMLLoadButton);
            this.Controls.Add(this.ExcelLoadButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Számlakezelés";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExcelLoadButton;
        private System.Windows.Forms.Button XMLLoadButton;
        private System.Windows.Forms.TextBox ExcelTextbox;
        private System.Windows.Forms.TextBox XMLTextbox;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BevallasiIdoszakTol;
        private System.Windows.Forms.TextBox BevallasiIdoszakIg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

