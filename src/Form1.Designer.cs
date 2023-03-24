namespace WinFormsApp1
{
    partial class Form1
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
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label3 = new Label();
            button2 = new Button();
            label4 = new Label();
            checkBox1 = new CheckBox();
            label5 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            panel1 = new Panel();
            label12 = new Label();
            label11 = new Label();
            button3 = new Button();
            trackBar1 = new TrackBar();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(315, 486);
            button1.Name = "button1";
            button1.Size = new Size(135, 36);
            button1.TabIndex = 1;
            button1.Text = "Create Map";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = Color.LightGray;
            textBox1.Location = new Point(315, 457);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Enter File Path..";
            textBox1.Size = new Size(559, 27);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(315, 21);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 3;
            label1.Text = "Map";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(456, 494);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.Enabled = false;
            dataGridView1.Location = new Point(315, 44);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(559, 407);
            dataGridView1.TabIndex = 5;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(34, 40);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(54, 24);
            radioButton1.TabIndex = 6;
            radioButton1.TabStop = true;
            radioButton1.Text = "BFS";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.Checked = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(34, 70);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(56, 24);
            radioButton2.TabIndex = 7;
            radioButton2.TabStop = true;
            radioButton2.Text = "DFS";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 17);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 9;
            label3.Text = "Search Method :";
            // 
            // button2
            // 
            button2.Location = new Point(79, 130);
            button2.Name = "button2";
            button2.Size = new Size(126, 36);
            button2.TabIndex = 10;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 189);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 11;
            label4.Text = "Output :";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(34, 100);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(55, 24);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "TSP";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 307);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 13;
            label5.Text = "Route :";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBox2.BackColor = SystemColors.ControlLight;
            textBox2.Location = new Point(32, 331);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(237, 90);
            textBox2.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 218);
            label6.Name = "label6";
            label6.Size = new Size(59, 20);
            label6.TabIndex = 15;
            label6.Text = "Nodes :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(54, 238);
            label7.Name = "label7";
            label7.Size = new Size(15, 20);
            label7.TabIndex = 16;
            label7.Text = "-";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(34, 258);
            label8.Name = "label8";
            label8.Size = new Size(52, 20);
            label8.TabIndex = 17;
            label8.Text = "Steps :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(54, 278);
            label9.Name = "label9";
            label9.Size = new Size(15, 20);
            label9.TabIndex = 18;
            label9.Text = "-";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Location = new Point(844, 534);
            label10.Name = "label10";
            label10.Size = new Size(40, 20);
            label10.TabIndex = 19;
            label10.Text = "0 ticks";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(trackBar1);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(0, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(288, 567);
            panel1.TabIndex = 20;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 169);
            label12.Name = "label12";
            label12.Size = new Size(58, 20);
            label12.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(7, 538);
            label11.Name = "label11";
            label11.Size = new Size(58, 20);
            label11.TabIndex = 20;
            // 
            // button3
            // 
            button3.Location = new Point(79, 436);
            button3.Name = "button3";
            button3.Size = new Size(126, 36);
            button3.TabIndex = 19;
            button3.Text = "Simulate Search";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBar1.AutoSize = false;
            trackBar1.Location = new Point(16, 479);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(253, 26);
            trackBar1.TabIndex = 21;
            // The Maximum property sets the value of the track bar when
            // the slider is all the way to the right.
            trackBar1.Maximum = 99;
            trackBar1.Minimum = 0;
            
            // The TickFrequency property establishes how many positions
            // are between each tick-mark.
            trackBar1.TickFrequency = 1;

            // The LargeChange property sets how many positions to move
            // if the bar is clicked on either side of the slider.
            trackBar1.LargeChange = 50;

            // The SmallChange property sets how many positions to move
            // if the keyboard arrows are used to move the slider.
            trackBar1.SmallChange = 20;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Image.FromFile("./resource/2468760.gif");
            pictureBox1.Location = new Point(209, 265);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(79, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            //
            //design purpose
            //
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
            originalTextBox1Size = new Rectangle(textBox1.Location.X, textBox1.Location.Y, textBox1.Size.Width, textBox1.Size.Height);
            originalButton1Size = new Rectangle(button1.Location.X, button1.Location.Y, button1.Size.Width, button1.Size.Height);
            originalButton3Size = new Rectangle(button3.Location.X, button3.Location.Y, button3.Size.Width, button3.Size.Height);
            originalLabel2Size = new Rectangle(label2.Location.X, label2.Location.Y, label2.Size.Width, label2.Size.Height);
            originalLabel11Size = new Rectangle(label11.Location.X, label11.Location.Y, label11.Size.Width, label11.Size.Height);
            originalTrackBarSize = new Rectangle(trackBar1.Location.X, trackBar1.Location.Y, trackBar1.Size.Width, trackBar1.Size.Height);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(896, 563);
            panel1.Controls.Add(pictureBox1);
            Controls.Add(textBox2);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(label10);
            MinimumSize = new Size(879, 570);
            Name = "Form1";
            Text = "Treasure Finder";
            Load += Form1_Load;
            Resize += Form1_Resize;
            this.Icon = new Icon("./resource/Anime.ico");
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label3;
        private Button button2;
        private Label label4;
        private CheckBox checkBox1;
        private Label label5;
        private TextBox textBox2;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Panel panel1;
        private TrackBar trackBar1;
        private Label label12;
        private Label label11;
        private Button button3;
        private PictureBox pictureBox1;
        private Rectangle originalFormSize;
        private Rectangle originalTextBox1Size;
        private Rectangle originalButton1Size;
        private Rectangle originalButton3Size;
        private Rectangle originalLabel2Size;
        private Rectangle originalLabel11Size;
        private Rectangle originalTrackBarSize;
    }
}