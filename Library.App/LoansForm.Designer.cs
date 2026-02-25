namespace Library.App
{
    partial class LoansForm
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
            cbReaders = new ComboBox();
            cbBooks = new ComboBox();
            btnBorrow = new Button();
            dgActiveLoans = new DataGridView();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgActiveLoans).BeginInit();
            SuspendLayout();
            // 
            // cbReaders
            // 
            cbReaders.FormattingEnabled = true;
            cbReaders.Location = new Point(25, 30);
            cbReaders.Name = "cbReaders";
            cbReaders.Size = new Size(151, 28);
            cbReaders.TabIndex = 0;
            cbReaders.Text = "ComboBox";
            // 
            // cbBooks
            // 
            cbBooks.FormattingEnabled = true;
            cbBooks.Location = new Point(221, 30);
            cbBooks.Name = "cbBooks";
            cbBooks.Size = new Size(151, 28);
            cbBooks.TabIndex = 1;
            cbBooks.Text = "ComboBox";
            //cbBooks.SelectedIndexChanged += cbBooks_SelectedIndexChanged;
            // 
            // btnBorrow
            // 
            btnBorrow.Location = new Point(278, 81);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Size = new Size(94, 29);
            btnBorrow.TabIndex = 2;
            btnBorrow.Text = "Požičať";
            btnBorrow.UseVisualStyleBackColor = true;
            // 
            // dgActiveLoans
            // 
            dgActiveLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgActiveLoans.Location = new Point(25, 151);
            dgActiveLoans.Name = "dgActiveLoans";
            dgActiveLoans.RowHeadersWidth = 51;
            dgActiveLoans.Size = new Size(1303, 444);
            dgActiveLoans.TabIndex = 3;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(1234, 611);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(94, 29);
            btnReturn.TabIndex = 4;
            btnReturn.Text = "Vrátenie";
            btnReturn.UseVisualStyleBackColor = true;
            //btnReturn.Click += button1_Click;
            // 
            // LoansForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1426, 699);
            Controls.Add(btnReturn);
            Controls.Add(dgActiveLoans);
            Controls.Add(btnBorrow);
            Controls.Add(cbBooks);
            Controls.Add(cbReaders);
            Name = "LoansForm";
            Text = "LoansForm";
            ((System.ComponentModel.ISupportInitialize)dgActiveLoans).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cbReaders;
        private ComboBox cbBooks;
        private Button btnBorrow;
        private DataGridView dgActiveLoans;
        private Button btnReturn;
    }
}