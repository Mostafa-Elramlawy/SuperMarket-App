namespace Military
{
    partial class SellForm
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
            this.components = new System.ComponentModel.Container();
            this.Addbtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.militaryDBDataSet1 = new Military.MilitaryDBDataSet1();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.domainUpDown2 = new System.Windows.Forms.DomainUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.saleTableAdapter = new Military.MilitaryDBDataSet1TableAdapters.SaleTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.militaryDBDataSet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Addbtn
            // 
            this.Addbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Addbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Addbtn.Location = new System.Drawing.Point(279, 312);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(114, 76);
            this.Addbtn.TabIndex = 0;
            this.Addbtn.Text = "تقريشه";
            this.Addbtn.UseVisualStyleBackColor = false;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(84, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(436, 28);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(84, 62);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(442, 28);
            this.comboBox2.TabIndex = 3;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.Yellow;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.saleBindingSource;
            this.dataGridView3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dataGridView3.Location = new System.Drawing.Point(229, 182);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView3.RowHeadersWidth = 62;
            this.dataGridView3.RowTemplate.Height = 28;
            this.dataGridView3.Size = new System.Drawing.Size(560, 513);
            this.dataGridView3.TabIndex = 4;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            this.dataGridView3.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costDataGridViewTextBoxColumn.DataPropertyName = "cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "cost";
            this.costDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            this.costDataGridViewTextBoxColumn.ReadOnly = true;
            this.costDataGridViewTextBoxColumn.Width = 110;
            // 
            // saleBindingSource
            // 
            this.saleBindingSource.DataMember = "Sale";
            this.saleBindingSource.DataSource = this.militaryDBDataSet1;
            // 
            // militaryDBDataSet1
            // 
            this.militaryDBDataSet1.DataSetName = "MilitaryDBDataSet1";
            this.militaryDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(108, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 76);
            this.button1.TabIndex = 5;
            this.button1.Text = "حذف";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(532, 62);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = ": الاسم";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(526, 128);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = ": الصنف";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1382, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 54);
            this.button3.TabIndex = 9;
            this.button3.Text = "⇒";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // domainUpDown2
            // 
            this.domainUpDown2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.domainUpDown2.Items.Add("1");
            this.domainUpDown2.Items.Add("2");
            this.domainUpDown2.Items.Add("3");
            this.domainUpDown2.Items.Add("4");
            this.domainUpDown2.Items.Add("5");
            this.domainUpDown2.Items.Add("6");
            this.domainUpDown2.Items.Add("7");
            this.domainUpDown2.Items.Add("8");
            this.domainUpDown2.Items.Add("9");
            this.domainUpDown2.Items.Add("10");
            this.domainUpDown2.Items.Add("11");
            this.domainUpDown2.Items.Add("12");
            this.domainUpDown2.Items.Add("13");
            this.domainUpDown2.Items.Add("14");
            this.domainUpDown2.Items.Add("15");
            this.domainUpDown2.Items.Add("16");
            this.domainUpDown2.Items.Add("17");
            this.domainUpDown2.Items.Add("18");
            this.domainUpDown2.Items.Add("19");
            this.domainUpDown2.Items.Add("20");
            this.domainUpDown2.Items.Add("21");
            this.domainUpDown2.Items.Add("22");
            this.domainUpDown2.Items.Add("23");
            this.domainUpDown2.Items.Add("24");
            this.domainUpDown2.Items.Add("25");
            this.domainUpDown2.Items.Add("26");
            this.domainUpDown2.Items.Add("27");
            this.domainUpDown2.Items.Add("28");
            this.domainUpDown2.Items.Add("29");
            this.domainUpDown2.Items.Add("30");
            this.domainUpDown2.Items.Add("31");
            this.domainUpDown2.Items.Add("32");
            this.domainUpDown2.Items.Add("33");
            this.domainUpDown2.Items.Add("34");
            this.domainUpDown2.Items.Add("35");
            this.domainUpDown2.Items.Add("36");
            this.domainUpDown2.Items.Add("37");
            this.domainUpDown2.Items.Add("38");
            this.domainUpDown2.Items.Add("39");
            this.domainUpDown2.Items.Add("40");
            this.domainUpDown2.Items.Add("41");
            this.domainUpDown2.Items.Add("42");
            this.domainUpDown2.Items.Add("43");
            this.domainUpDown2.Items.Add("44");
            this.domainUpDown2.Items.Add("45");
            this.domainUpDown2.Items.Add("46");
            this.domainUpDown2.Items.Add("47");
            this.domainUpDown2.Items.Add("48");
            this.domainUpDown2.Items.Add("49");
            this.domainUpDown2.Items.Add("50");
            this.domainUpDown2.Items.Add("51");
            this.domainUpDown2.Items.Add("52");
            this.domainUpDown2.Items.Add("53");
            this.domainUpDown2.Items.Add("54");
            this.domainUpDown2.Items.Add("55");
            this.domainUpDown2.Items.Add("56");
            this.domainUpDown2.Items.Add("57");
            this.domainUpDown2.Items.Add("58");
            this.domainUpDown2.Items.Add("59");
            this.domainUpDown2.Items.Add("60");
            this.domainUpDown2.Items.Add("61");
            this.domainUpDown2.Items.Add("62");
            this.domainUpDown2.Items.Add("63");
            this.domainUpDown2.Items.Add("64");
            this.domainUpDown2.Items.Add("65");
            this.domainUpDown2.Items.Add("66");
            this.domainUpDown2.Items.Add("67");
            this.domainUpDown2.Items.Add("68");
            this.domainUpDown2.Items.Add("69");
            this.domainUpDown2.Items.Add("70");
            this.domainUpDown2.Items.Add("71");
            this.domainUpDown2.Items.Add("72");
            this.domainUpDown2.Items.Add("73");
            this.domainUpDown2.Items.Add("74");
            this.domainUpDown2.Items.Add("75");
            this.domainUpDown2.Items.Add("76");
            this.domainUpDown2.Items.Add("77");
            this.domainUpDown2.Items.Add("78");
            this.domainUpDown2.Items.Add("79");
            this.domainUpDown2.Items.Add("80");
            this.domainUpDown2.Items.Add("81");
            this.domainUpDown2.Items.Add("82");
            this.domainUpDown2.Items.Add("83");
            this.domainUpDown2.Items.Add("84");
            this.domainUpDown2.Items.Add("85");
            this.domainUpDown2.Items.Add("86");
            this.domainUpDown2.Items.Add("87");
            this.domainUpDown2.Items.Add("88");
            this.domainUpDown2.Items.Add("89");
            this.domainUpDown2.Items.Add("90");
            this.domainUpDown2.Items.Add("91");
            this.domainUpDown2.Items.Add("92");
            this.domainUpDown2.Items.Add("93");
            this.domainUpDown2.Items.Add("94");
            this.domainUpDown2.Items.Add("95");
            this.domainUpDown2.Items.Add("96");
            this.domainUpDown2.Items.Add("97");
            this.domainUpDown2.Items.Add("98");
            this.domainUpDown2.Items.Add("99");
            this.domainUpDown2.Items.Add("100");
            this.domainUpDown2.Items.Add("101");
            this.domainUpDown2.Items.Add("102");
            this.domainUpDown2.Items.Add("103");
            this.domainUpDown2.Items.Add("104");
            this.domainUpDown2.Items.Add("105");
            this.domainUpDown2.Items.Add("106");
            this.domainUpDown2.Items.Add("107");
            this.domainUpDown2.Items.Add("108");
            this.domainUpDown2.Items.Add("109");
            this.domainUpDown2.Items.Add("110");
            this.domainUpDown2.Items.Add("111");
            this.domainUpDown2.Items.Add("112");
            this.domainUpDown2.Items.Add("113");
            this.domainUpDown2.Items.Add("114");
            this.domainUpDown2.Items.Add("115");
            this.domainUpDown2.Items.Add("116");
            this.domainUpDown2.Items.Add("117");
            this.domainUpDown2.Items.Add("118");
            this.domainUpDown2.Items.Add("119");
            this.domainUpDown2.Items.Add("120");
            this.domainUpDown2.Items.Add("121");
            this.domainUpDown2.Items.Add("122");
            this.domainUpDown2.Items.Add("123");
            this.domainUpDown2.Items.Add("124");
            this.domainUpDown2.Items.Add("125");
            this.domainUpDown2.Items.Add("126");
            this.domainUpDown2.Items.Add("127");
            this.domainUpDown2.Items.Add("128");
            this.domainUpDown2.Items.Add("129");
            this.domainUpDown2.Items.Add("130");
            this.domainUpDown2.Items.Add("131");
            this.domainUpDown2.Items.Add("132");
            this.domainUpDown2.Items.Add("133");
            this.domainUpDown2.Items.Add("134");
            this.domainUpDown2.Items.Add("135");
            this.domainUpDown2.Items.Add("136");
            this.domainUpDown2.Items.Add("137");
            this.domainUpDown2.Items.Add("138");
            this.domainUpDown2.Items.Add("139");
            this.domainUpDown2.Items.Add("140");
            this.domainUpDown2.Items.Add("141");
            this.domainUpDown2.Items.Add("142");
            this.domainUpDown2.Items.Add("143");
            this.domainUpDown2.Items.Add("144");
            this.domainUpDown2.Items.Add("145");
            this.domainUpDown2.Items.Add("146");
            this.domainUpDown2.Items.Add("147");
            this.domainUpDown2.Items.Add("148");
            this.domainUpDown2.Items.Add("149");
            this.domainUpDown2.Items.Add("150");
            this.domainUpDown2.Items.Add("151");
            this.domainUpDown2.Items.Add("152");
            this.domainUpDown2.Items.Add("153");
            this.domainUpDown2.Items.Add("154");
            this.domainUpDown2.Items.Add("155");
            this.domainUpDown2.Items.Add("156");
            this.domainUpDown2.Items.Add("157");
            this.domainUpDown2.Items.Add("158");
            this.domainUpDown2.Items.Add("159");
            this.domainUpDown2.Items.Add("160");
            this.domainUpDown2.Items.Add("161");
            this.domainUpDown2.Items.Add("162");
            this.domainUpDown2.Items.Add("163");
            this.domainUpDown2.Items.Add("164");
            this.domainUpDown2.Items.Add("165");
            this.domainUpDown2.Items.Add("166");
            this.domainUpDown2.Items.Add("167");
            this.domainUpDown2.Items.Add("168");
            this.domainUpDown2.Items.Add("169");
            this.domainUpDown2.Items.Add("170");
            this.domainUpDown2.Items.Add("171");
            this.domainUpDown2.Items.Add("172");
            this.domainUpDown2.Items.Add("173");
            this.domainUpDown2.Items.Add("174");
            this.domainUpDown2.Items.Add("175");
            this.domainUpDown2.Items.Add("176");
            this.domainUpDown2.Items.Add("177");
            this.domainUpDown2.Items.Add("178");
            this.domainUpDown2.Items.Add("179");
            this.domainUpDown2.Items.Add("180");
            this.domainUpDown2.Items.Add("181");
            this.domainUpDown2.Items.Add("182");
            this.domainUpDown2.Items.Add("183");
            this.domainUpDown2.Items.Add("184");
            this.domainUpDown2.Items.Add("185");
            this.domainUpDown2.Items.Add("186");
            this.domainUpDown2.Items.Add("187");
            this.domainUpDown2.Items.Add("188");
            this.domainUpDown2.Items.Add("189");
            this.domainUpDown2.Items.Add("190");
            this.domainUpDown2.Items.Add("191");
            this.domainUpDown2.Items.Add("192");
            this.domainUpDown2.Items.Add("193");
            this.domainUpDown2.Items.Add("194");
            this.domainUpDown2.Items.Add("195");
            this.domainUpDown2.Items.Add("196");
            this.domainUpDown2.Items.Add("197");
            this.domainUpDown2.Items.Add("198");
            this.domainUpDown2.Items.Add("199");
            this.domainUpDown2.Items.Add("200");
            this.domainUpDown2.Location = new System.Drawing.Point(295, 193);
            this.domainUpDown2.MaximumSize = new System.Drawing.Size(1000, 0);
            this.domainUpDown2.Name = "domainUpDown2";
            this.domainUpDown2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.domainUpDown2.Size = new System.Drawing.Size(206, 26);
            this.domainUpDown2.TabIndex = 23;
            this.domainUpDown2.Text = "1";
            this.domainUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainUpDown2.Wrap = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(526, 202);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = ": الكميه";
            // 
            // saleTableAdapter
            // 
            this.saleTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Green;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(445, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 76);
            this.button2.TabIndex = 25;
            this.button2.Text = "كاش";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(645, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 37);
            this.label4.TabIndex = 26;
            this.label4.Text = "الكتيبة الثانية مراكز عقدية";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.Addbtn);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.domainUpDown2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(817, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(608, 495);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيع";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(421, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 22);
            this.label5.TabIndex = 28;
            this.label5.Text = "label5";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Military.Properties.Resources.download;
            this.pictureBox1.Location = new System.Drawing.Point(-7, -11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 195);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1164, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 22);
            this.label6.TabIndex = 30;
            this.label6.Text = "label6";
            // 
            // SellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1437, 737);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView3);
            this.Name = "SellForm";
            this.Text = "بيع";
            this.Load += new System.EventHandler(this.SellForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.militaryDBDataSet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DomainUpDown domainUpDown2;
        private System.Windows.Forms.Label label3;
        private MilitaryDBDataSet1 militaryDBDataSet1;
        private System.Windows.Forms.BindingSource saleBindingSource;
        private MilitaryDBDataSet1TableAdapters.SaleTableAdapter saleTableAdapter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
    }
}

