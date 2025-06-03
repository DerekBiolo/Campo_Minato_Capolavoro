namespace CampoMinato2
{
    partial class FCarica
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
            dgv_Lista = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_Lista).BeginInit();
            SuspendLayout();
            // 
            // dgv_Lista
            // 
            dgv_Lista.BorderStyle = BorderStyle.None;
            dgv_Lista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Lista.Location = new Point(0, 0);
            dgv_Lista.Name = "dgv_Lista";
            dgv_Lista.RowHeadersWidth = 51;
            dgv_Lista.RowTemplate.Height = 29;
            dgv_Lista.Size = new Size(801, 458);
            dgv_Lista.TabIndex = 0;
            // 
            // FCarica
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_Lista);
            Name = "FCarica";
            Text = "FCarica";
            ((System.ComponentModel.ISupportInitialize)dgv_Lista).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Lista;
    }
}