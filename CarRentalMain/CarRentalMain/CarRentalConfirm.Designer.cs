namespace CarRentalProgram
{
    partial class CarRentalConfirm
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
            this.confirmButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.rentalConfirmationTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(12, 352);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(65, 23);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(214, 352);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(65, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // rentalConfirmationTextBox
            // 
            this.rentalConfirmationTextBox.Location = new System.Drawing.Point(12, 12);
            this.rentalConfirmationTextBox.Name = "rentalConfirmationTextBox";
            this.rentalConfirmationTextBox.Size = new System.Drawing.Size(267, 334);
            this.rentalConfirmationTextBox.TabIndex = 2;
            this.rentalConfirmationTextBox.Text = "";
            // 
            // CarRentalConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 387);
            this.Controls.Add(this.rentalConfirmationTextBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.confirmButton);
            this.Name = "CarRentalConfirm";
            this.Text = "Car Rental Confirmation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.RichTextBox rentalConfirmationTextBox;
    }
}