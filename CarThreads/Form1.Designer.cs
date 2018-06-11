namespace CarThreads
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
            this.garages = new System.Windows.Forms.TableLayoutPanel();
            this.queue = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxGarageNumber = new System.Windows.Forms.TextBox();
            this.textBoxCarAmount = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTimeInGarage = new System.Windows.Forms.TextBox();
            this.textBoxTimeInQueue = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // garages
            // 
            this.garages.AutoSize = true;
            this.garages.ColumnCount = 1;
            this.garages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.garages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.garages.Location = new System.Drawing.Point(3, 3);
            this.garages.Name = "garages";
            this.garages.RowCount = 2;
            this.garages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.garages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.garages.Size = new System.Drawing.Size(180, 540);
            this.garages.TabIndex = 0;
            // 
            // queue
            // 
            this.queue.AutoSize = true;
            this.queue.ColumnCount = 1;
            this.queue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.queue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.queue.Location = new System.Drawing.Point(3, 3);
            this.queue.Name = "queue";
            this.queue.RowCount = 2;
            this.queue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.queue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.queue.Size = new System.Drawing.Size(250, 561);
            this.queue.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.queue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(528, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(100, 560);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 561);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "How many garages";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "How many possible cars";
            // 
            // textBoxGarageNumber
            // 
            this.textBoxGarageNumber.Location = new System.Drawing.Point(209, 26);
            this.textBoxGarageNumber.Name = "textBoxGarageNumber";
            this.textBoxGarageNumber.Size = new System.Drawing.Size(160, 20);
            this.textBoxGarageNumber.TabIndex = 3;
            // 
            // textBoxCarAmount
            // 
            this.textBoxCarAmount.Location = new System.Drawing.Point(206, 71);
            this.textBoxCarAmount.Name = "textBoxCarAmount";
            this.textBoxCarAmount.Size = new System.Drawing.Size(160, 20);
            this.textBoxCarAmount.TabIndex = 5;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(206, 97);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 10;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelError.Location = new System.Drawing.Point(206, 123);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 25);
            this.labelError.TabIndex = 6;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(294, 97);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 11;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Time in garage [ms]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Time to next try [ms]";
            // 
            // textBoxTimeInGarage
            // 
            this.textBoxTimeInGarage.Location = new System.Drawing.Point(395, 26);
            this.textBoxTimeInGarage.Name = "textBoxTimeInGarage";
            this.textBoxTimeInGarage.Size = new System.Drawing.Size(100, 20);
            this.textBoxTimeInGarage.TabIndex = 4;
            // 
            // textBoxTimeInQueue
            // 
            this.textBoxTimeInQueue.Location = new System.Drawing.Point(395, 70);
            this.textBoxTimeInQueue.Name = "textBoxTimeInQueue";
            this.textBoxTimeInQueue.Size = new System.Drawing.Size(100, 20);
            this.textBoxTimeInQueue.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.garages);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.MinimumSize = new System.Drawing.Size(200, 560);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 561);
            this.panel2.TabIndex = 12;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(206, 313);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(316, 50);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "Czasy podane w polach wyrażone są w ms, a do ich wartości zostanie dodana losowa " +
    "wartość z przedziało <0, 2999>, aby wątki nie działały w wielokrotnościach pewne" +
    "j ilości czasu.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBoxTimeInQueue);
            this.Controls.Add(this.textBoxTimeInGarage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.textBoxCarAmount);
            this.Controls.Add(this.textBoxGarageNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LateInitialize()
        {
            this.garages = new System.Windows.Forms.TableLayoutPanel();
            this.queue = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            // 
            // garages
            // 
            this.garages.ColumnCount = 1;
            this.garages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.garages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.garages.Dock = System.Windows.Forms.DockStyle.Left;
            this.garages.Location = new System.Drawing.Point(0, 0);
            this.garages.Name = "garages";
            this.garages.RowCount = 2;
            this.garages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.garages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.garages.Size = new System.Drawing.Size(200, 561);
            this.garages.TabIndex = 0;
            // 
            // queue
            // 
            this.queue.AutoSize = true;
            this.queue.ColumnCount = 1;
            this.queue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.queue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.queue.Location = new System.Drawing.Point(3, 3);
            this.queue.Name = "queue";
            this.queue.RowCount = 2;
            this.queue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.queue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.queue.Size = new System.Drawing.Size(250, 561);
            this.queue.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.queue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(528, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(100, 560);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 561);
            this.panel1.TabIndex = 0;
            // 
            // Form1
            // 

            this.Controls.Add(this.panel1);
            this.Controls.Add(this.garages);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel garages;
        private System.Windows.Forms.TableLayoutPanel queue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxGarageNumber;
        private System.Windows.Forms.TextBox textBoxCarAmount;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTimeInGarage;
        private System.Windows.Forms.TextBox textBoxTimeInQueue;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

