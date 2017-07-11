namespace Handoldiers
{
    partial class PlayOrder
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPlayOrderTails = new System.Windows.Forms.Button();
            this.btnPlayOrderHeads = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSecond = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.pbPlayOrderCoin = new System.Windows.Forms.PictureBox();
            this.rtbPlayOrder = new System.Windows.Forms.RichTextBox();
            this.btnPlayOrderContinue = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayOrderCoin)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(266, 35);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Choose Heads or Tails. If you guess correctly, choose to go first or second.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPlayOrderTails);
            this.groupBox1.Controls.Add(this.btnPlayOrderHeads);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Heads or Tails";
            // 
            // btnPlayOrderTails
            // 
            this.btnPlayOrderTails.Location = new System.Drawing.Point(6, 48);
            this.btnPlayOrderTails.Name = "btnPlayOrderTails";
            this.btnPlayOrderTails.Size = new System.Drawing.Size(77, 23);
            this.btnPlayOrderTails.TabIndex = 7;
            this.btnPlayOrderTails.Text = "Tails";
            this.btnPlayOrderTails.UseVisualStyleBackColor = true;
            this.btnPlayOrderTails.Click += new System.EventHandler(this.btnPlayOrderTails_Click);
            // 
            // btnPlayOrderHeads
            // 
            this.btnPlayOrderHeads.Location = new System.Drawing.Point(6, 19);
            this.btnPlayOrderHeads.Name = "btnPlayOrderHeads";
            this.btnPlayOrderHeads.Size = new System.Drawing.Size(77, 23);
            this.btnPlayOrderHeads.TabIndex = 6;
            this.btnPlayOrderHeads.Text = "Heads";
            this.btnPlayOrderHeads.UseVisualStyleBackColor = true;
            this.btnPlayOrderHeads.Click += new System.EventHandler(this.btnPlayOrderHeads_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSecond);
            this.groupBox2.Controls.Add(this.btnFirst);
            this.groupBox2.Location = new System.Drawing.Point(189, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(89, 78);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1st or 2nd";
            // 
            // btnSecond
            // 
            this.btnSecond.Enabled = false;
            this.btnSecond.Location = new System.Drawing.Point(6, 48);
            this.btnSecond.Name = "btnSecond";
            this.btnSecond.Size = new System.Drawing.Size(77, 23);
            this.btnSecond.TabIndex = 7;
            this.btnSecond.Text = "Second";
            this.btnSecond.UseVisualStyleBackColor = true;
            this.btnSecond.Click += new System.EventHandler(this.btnSecond_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.Location = new System.Drawing.Point(6, 19);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(77, 23);
            this.btnFirst.TabIndex = 6;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // pbPlayOrderCoin
            // 
            this.pbPlayOrderCoin.Location = new System.Drawing.Point(107, 53);
            this.pbPlayOrderCoin.Name = "pbPlayOrderCoin";
            this.pbPlayOrderCoin.Size = new System.Drawing.Size(76, 78);
            this.pbPlayOrderCoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayOrderCoin.TabIndex = 3;
            this.pbPlayOrderCoin.TabStop = false;
            // 
            // rtbPlayOrder
            // 
            this.rtbPlayOrder.BackColor = System.Drawing.SystemColors.Control;
            this.rtbPlayOrder.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtbPlayOrder.Location = new System.Drawing.Point(18, 142);
            this.rtbPlayOrder.Name = "rtbPlayOrder";
            this.rtbPlayOrder.ReadOnly = true;
            this.rtbPlayOrder.Size = new System.Drawing.Size(179, 23);
            this.rtbPlayOrder.TabIndex = 4;
            this.rtbPlayOrder.Text = "";
            // 
            // btnPlayOrderContinue
            // 
            this.btnPlayOrderContinue.Enabled = false;
            this.btnPlayOrderContinue.Location = new System.Drawing.Point(203, 140);
            this.btnPlayOrderContinue.Name = "btnPlayOrderContinue";
            this.btnPlayOrderContinue.Size = new System.Drawing.Size(75, 23);
            this.btnPlayOrderContinue.TabIndex = 5;
            this.btnPlayOrderContinue.Text = "Continue";
            this.btnPlayOrderContinue.UseVisualStyleBackColor = true;
            this.btnPlayOrderContinue.Click += new System.EventHandler(this.btnPlayOrderContinue_Click);
            // 
            // PlayOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 177);
            this.Controls.Add(this.btnPlayOrderContinue);
            this.Controls.Add(this.rtbPlayOrder);
            this.Controls.Add(this.pbPlayOrderCoin);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PlayOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayOrder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayOrderCoin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPlayOrderTails;
        private System.Windows.Forms.Button btnPlayOrderHeads;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSecond;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.PictureBox pbPlayOrderCoin;
        private System.Windows.Forms.RichTextBox rtbPlayOrder;
        private System.Windows.Forms.Button btnPlayOrderContinue;
    }
}