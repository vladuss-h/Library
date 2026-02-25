namespace Library.App
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
            components = new System.ComponentModel.Container();
            dgvBooks = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblAuthor = new Label();
            txtAuthor = new TextBox();
            btnAddBook = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnSaveEdit = new Button();
            btnOpenReaders = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.AccessibleName = "";
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Dock = DockStyle.Bottom;
            dgvBooks.Location = new Point(0, 265);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.Size = new Size(1421, 400);
            dgvBooks.TabIndex = 0;
            dgvBooks.CellContentClick += dgvBooks_CellContentClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(27, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(89, 20);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Názov knihy";
            lblTitle.Click += label1_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(164, 18);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(214, 27);
            txtTitle.TabIndex = 3;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(27, 68);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(46, 20);
            lblAuthor.TabIndex = 4;
            lblAuthor.Text = "Autor";
            lblAuthor.Click += label1_Click_1;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(164, 68);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(214, 27);
            txtAuthor.TabIndex = 5;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(378, 123);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(206, 29);
            btnAddBook.TabIndex = 6;
            btnAddBook.Text = "Pridať knihu";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1315, 220);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Zmazať";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += button1_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(1206, 220);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Upraviť";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSaveEdit
            // 
            btnSaveEdit.Location = new Point(1052, 220);
            btnSaveEdit.Name = "btnSaveEdit";
            btnSaveEdit.Size = new Size(137, 29);
            btnSaveEdit.TabIndex = 9;
            btnSaveEdit.Text = "Uložiť zmeny";
            btnSaveEdit.UseVisualStyleBackColor = true;
            btnSaveEdit.Visible = false;
            btnSaveEdit.Click += btnSaveEdit_Click;
            // 
            // btnOpenReaders
            // 
            btnOpenReaders.Location = new Point(1315, 25);
            btnOpenReaders.Name = "btnOpenReaders";
            btnOpenReaders.Size = new Size(94, 29);
            btnOpenReaders.TabIndex = 10;
            btnOpenReaders.Text = "Čitatelia";
            btnOpenReaders.UseVisualStyleBackColor = true;
            btnOpenReaders.Click += btnOpenReaders_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1421, 665);
            Controls.Add(btnOpenReaders);
            Controls.Add(btnSaveEdit);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnAddBook);
            Controls.Add(txtAuthor);
            Controls.Add(lblAuthor);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Controls.Add(dgvBooks);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBooks;
        private ContextMenuStrip contextMenuStrip1;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblAuthor;
        private TextBox txtAuthor;
        private Button btnAddBook;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnSaveEdit;
        private Button btnOpenReaders;
    }
}
