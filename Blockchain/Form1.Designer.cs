namespace Blockchain
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtTransaction = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNewblock = new System.Windows.Forms.Button();
            this.txtBlockchain = new System.Windows.Forms.TextBox();
            this.txtBlockcount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transcationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transcationhashDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currenthashDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previoushashDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blockcountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbBlockchainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbBlockchainDataSet1 = new Blockchain.dbBlockchainDataSet1();
            this.dbBlockchainTableAdapter = new Blockchain.dbBlockchainDataSet1TableAdapters.dbBlockchainTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBlockchainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBlockchainDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTransaction
            // 
            this.txtTransaction.Location = new System.Drawing.Point(753, 67);
            this.txtTransaction.Multiline = true;
            this.txtTransaction.Name = "txtTransaction";
            this.txtTransaction.Size = new System.Drawing.Size(412, 190);
            this.txtTransaction.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Existing Blockchain";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(753, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Create TX";
            // 
            // btnNewblock
            // 
            this.btnNewblock.Location = new System.Drawing.Point(756, 263);
            this.btnNewblock.Name = "btnNewblock";
            this.btnNewblock.Size = new System.Drawing.Size(159, 54);
            this.btnNewblock.TabIndex = 4;
            this.btnNewblock.Text = "Create new TX";
            this.btnNewblock.UseVisualStyleBackColor = true;
            this.btnNewblock.Click += new System.EventHandler(this.btnNewblock_Click);
            // 
            // txtBlockchain
            // 
            this.txtBlockchain.Location = new System.Drawing.Point(16, 237);
            this.txtBlockchain.Multiline = true;
            this.txtBlockchain.Name = "txtBlockchain";
            this.txtBlockchain.ReadOnly = true;
            this.txtBlockchain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBlockchain.Size = new System.Drawing.Size(694, 411);
            this.txtBlockchain.TabIndex = 6;
            // 
            // txtBlockcount
            // 
            this.txtBlockcount.Location = new System.Drawing.Point(921, 282);
            this.txtBlockcount.Name = "txtBlockcount";
            this.txtBlockcount.ReadOnly = true;
            this.txtBlockcount.Size = new System.Drawing.Size(100, 20);
            this.txtBlockcount.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(921, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "BlockCount";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.transcationDataGridViewTextBoxColumn,
            this.transcationhashDataGridViewTextBoxColumn,
            this.currenthashDataGridViewTextBoxColumn,
            this.previoushashDataGridViewTextBoxColumn,
            this.blockcountDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dbBlockchainBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(660, 150);
            this.dataGridView1.TabIndex = 9;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transcationDataGridViewTextBoxColumn
            // 
            this.transcationDataGridViewTextBoxColumn.DataPropertyName = "transcation";
            this.transcationDataGridViewTextBoxColumn.HeaderText = "transcation";
            this.transcationDataGridViewTextBoxColumn.Name = "transcationDataGridViewTextBoxColumn";
            // 
            // transcationhashDataGridViewTextBoxColumn
            // 
            this.transcationhashDataGridViewTextBoxColumn.DataPropertyName = "transcationhash";
            this.transcationhashDataGridViewTextBoxColumn.HeaderText = "transcationhash";
            this.transcationhashDataGridViewTextBoxColumn.Name = "transcationhashDataGridViewTextBoxColumn";
            // 
            // currenthashDataGridViewTextBoxColumn
            // 
            this.currenthashDataGridViewTextBoxColumn.DataPropertyName = "currenthash";
            this.currenthashDataGridViewTextBoxColumn.HeaderText = "currenthash";
            this.currenthashDataGridViewTextBoxColumn.Name = "currenthashDataGridViewTextBoxColumn";
            // 
            // previoushashDataGridViewTextBoxColumn
            // 
            this.previoushashDataGridViewTextBoxColumn.DataPropertyName = "previoushash";
            this.previoushashDataGridViewTextBoxColumn.HeaderText = "previoushash";
            this.previoushashDataGridViewTextBoxColumn.Name = "previoushashDataGridViewTextBoxColumn";
            // 
            // blockcountDataGridViewTextBoxColumn
            // 
            this.blockcountDataGridViewTextBoxColumn.DataPropertyName = "blockcount";
            this.blockcountDataGridViewTextBoxColumn.HeaderText = "blockcount";
            this.blockcountDataGridViewTextBoxColumn.Name = "blockcountDataGridViewTextBoxColumn";
            // 
            // dbBlockchainBindingSource
            // 
            this.dbBlockchainBindingSource.DataMember = "dbBlockchain";
            this.dbBlockchainBindingSource.DataSource = this.dbBlockchainDataSet1;
            // 
            // dbBlockchainDataSet1
            // 
            this.dbBlockchainDataSet1.DataSetName = "dbBlockchainDataSet1";
            this.dbBlockchainDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbBlockchainTableAdapter
            // 
            this.dbBlockchainTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 721);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBlockcount);
            this.Controls.Add(this.txtBlockchain);
            this.Controls.Add(this.btnNewblock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTransaction);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBlockchainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBlockchainDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTransaction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNewblock;
        private System.Windows.Forms.TextBox txtBlockchain;
        private System.Windows.Forms.TextBox txtBlockcount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dbBlockchainDataSet1 dbBlockchainDataSet1;
        private System.Windows.Forms.BindingSource dbBlockchainBindingSource;
        private dbBlockchainDataSet1TableAdapters.dbBlockchainTableAdapter dbBlockchainTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transcationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transcationhashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currenthashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn previoushashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn blockcountDataGridViewTextBoxColumn;
    }
}

