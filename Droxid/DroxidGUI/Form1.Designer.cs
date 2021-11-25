
namespace DroxidGUI
{
    partial class frmDroxid
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstGlobalMessages = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessageToSend = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstGlobalMessages
            // 
            this.lstGlobalMessages.FormattingEnabled = true;
            this.lstGlobalMessages.ItemHeight = 15;
            this.lstGlobalMessages.Location = new System.Drawing.Point(355, 62);
            this.lstGlobalMessages.Name = "lstGlobalMessages";
            this.lstGlobalMessages.Size = new System.Drawing.Size(376, 319);
            this.lstGlobalMessages.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(131, 220);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Envoyer";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // txtMessageToSend
            // 
            this.txtMessageToSend.Location = new System.Drawing.Point(60, 132);
            this.txtMessageToSend.Name = "txtMessageToSend";
            this.txtMessageToSend.Size = new System.Drawing.Size(212, 23);
            this.txtMessageToSend.TabIndex = 2;
            // 
            // frmDroxid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMessageToSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lstGlobalMessages);
            this.Name = "frmDroxid";
            this.Text = "Droxid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstGlobalMessages;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessageToSend;
    }
}

