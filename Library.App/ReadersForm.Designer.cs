namespace Library.App
{
    partial class ReadersForm
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
            dgvReaders = new DataGridView();
            txtIdNumber = new TextBox();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            btnAddReader = new Button();
            btnDeleteReader = new Button();
            btnEditReader = new Button();
            button1 = new Button();
            btnSaveReader = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReaders).BeginInit();
            SuspendLayout();
            // 
            // dgvReaders
            // 
            dgvReaders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReaders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReaders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReaders.Location = new Point(22, 277);
            dgvReaders.Name = "dgvReaders";
            dgvReaders.RowHeadersWidth = 51;
            dgvReaders.Size = new Size(1364, 385);
            dgvReaders.TabIndex = 0;
            dgvReaders.CellClick += dgvReaders_CellClick;
            // 
            // txtIdNumber
            // 
            txtIdNumber.Location = new Point(22, 27);
            txtIdNumber.Name = "txtIdNumber";
            txtIdNumber.Size = new Size(125, 27);
            txtIdNumber.TabIndex = 1;
            txtIdNumber.Text = "Číslo OP";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(22, 72);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 2;
            txtFirstName.Text = "Meno";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(22, 119);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 3;
            txtLastName.Text = "Priezvisko";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Location = new Point(22, 166);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(250, 27);
            dtpDateOfBirth.TabIndex = 4;
            // 
            // btnAddReader
            // 
            btnAddReader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddReader.Location = new Point(1174, 167);
            btnAddReader.Name = "btnAddReader";
            btnAddReader.Size = new Size(94, 29);
            btnAddReader.TabIndex = 5;
            btnAddReader.Text = "Pridať";
            btnAddReader.UseVisualStyleBackColor = true;
            btnAddReader.Click += btnAddReader_Click;
            // 
            // btnDeleteReader
            // 
            btnDeleteReader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteReader.Location = new Point(1292, 167);
            btnDeleteReader.Name = "btnDeleteReader";
            btnDeleteReader.Size = new Size(94, 29);
            btnDeleteReader.TabIndex = 6;
            btnDeleteReader.Text = "Zmazať";
            btnDeleteReader.UseVisualStyleBackColor = true;
            btnDeleteReader.Click += btnDeleteReader_Click;
            // 
            // btnEditReader
            // 
            btnEditReader.Location = new Point(1292, 211);
            btnEditReader.Name = "btnEditReader";
            btnEditReader.Size = new Size(94, 29);
            btnEditReader.TabIndex = 7;
            btnEditReader.Text = "Upraviť";
            btnEditReader.UseVisualStyleBackColor = true;
            btnEditReader.Click += btnEditReader_Click;
            // 
            // button1
            // 
            button1.Location = new Point(793, 154);
            button1.Name = "button1";
            button1.Size = new Size(8, 8);
            button1.TabIndex = 8;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnSaveReader
            // 
            btnSaveReader.Location = new Point(1130, 211);
            btnSaveReader.Name = "btnSaveReader";
            btnSaveReader.Size = new Size(138, 29);
            btnSaveReader.TabIndex = 9;
            btnSaveReader.Text = "Uložiť zmeny";
            btnSaveReader.UseVisualStyleBackColor = true;
            btnSaveReader.Visible = false;
            btnSaveReader.Click += btnSaveReader_Click;
            // 
            // ReadersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1414, 674);
            Controls.Add(btnSaveReader);
            Controls.Add(button1);
            Controls.Add(btnEditReader);
            Controls.Add(btnDeleteReader);
            Controls.Add(btnAddReader);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(txtIdNumber);
            Controls.Add(dgvReaders);
            Name = "ReadersForm";
            Text = "ReadersForm";
            ((System.ComponentModel.ISupportInitialize)dgvReaders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReaders;
        private TextBox txtIdNumber;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private DateTimePicker dtpDateOfBirth;
        private Button btnAddReader;
        private Button btnDeleteReader;
        private Button btnEditReader;
        private Button button1;
        private Button btnSaveReader;
    }
}