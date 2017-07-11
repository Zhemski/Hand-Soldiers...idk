namespace Handoldiers
{
    partial class PreGame
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
            this.rtbInstructions = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radDeck2 = new System.Windows.Forms.RadioButton();
            this.radDeck1 = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbInstructions
            // 
            this.rtbInstructions.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtbInstructions.Location = new System.Drawing.Point(12, 12);
            this.rtbInstructions.Name = "rtbInstructions";
            this.rtbInstructions.ReadOnly = true;
            this.rtbInstructions.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbInstructions.Size = new System.Drawing.Size(260, 33);
            this.rtbInstructions.TabIndex = 0;
            this.rtbInstructions.Text = "Choose a deck to play with. The opponent will use\nthe other deck.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radDeck2);
            this.groupBox1.Controls.Add(this.radDeck1);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Deck";
            // 
            // radDeck2
            // 
            this.radDeck2.AutoSize = true;
            this.radDeck2.Location = new System.Drawing.Point(6, 42);
            this.radDeck2.Name = "radDeck2";
            this.radDeck2.Size = new System.Drawing.Size(124, 17);
            this.radDeck2.TabIndex = 1;
            this.radDeck2.Text = "Wrath of Picklechew";
            this.radDeck2.UseVisualStyleBackColor = true;
            // 
            // radDeck1
            // 
            this.radDeck1.AutoSize = true;
            this.radDeck1.Checked = true;
            this.radDeck1.Location = new System.Drawing.Point(6, 19);
            this.radDeck1.Name = "radDeck1";
            this.radDeck1.Size = new System.Drawing.Size(125, 17);
            this.radDeck1.TabIndex = 0;
            this.radDeck1.TabStop = true;
            this.radDeck1.Text = "Urslav\'s Urban Anger";
            this.radDeck1.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(197, 90);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // PreGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 132);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbInstructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PreGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Deck";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInstructions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radDeck2;
        private System.Windows.Forms.RadioButton radDeck1;
        private System.Windows.Forms.Button btnStart;
    }
}

