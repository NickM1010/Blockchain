using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Configuration;

namespace Blockchain
{
    public partial class Form1 : Form
    {
        //Variables
        List<float[,,,]> Blockchain = new List<float[,,,]>();
        string PreviousHash = "0";
        string CurrentHash;
        string Transaktion;
        string TransaktionHash;
        string GenesisBlockHash = "c423b0dcb3697b21d846dbf01f6f2438fbc973078bd8fc671551f5b98e8af0f0";
        int BlockCount = 0;

        SqlConnection connection;
        string connectionString;

        public Form1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Blockchain.Properties.Settings.dbBlockchainConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Creates a new Block depends on Prevoius BlockHash and TxHash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewblock_Click(object sender, EventArgs e)
        {

            //GenesisBlock generate block
            if (BlockCount == 0)
            {
                Transaktion = "Das ist ein Test";   //First TX
                BlockCount = 0;                    //No Previous Block          //GenesisBlock = 0
                CurrentHash = ComputeSha256Hash(Transaktion);
                TransaktionHash = CurrentHash;

                //Check if Hardcoded is equal Block 0 at new Start.
                if (GenesisBlockHash != CurrentHash)
                {
                    MessageBox.Show("Wrong GenesisBlockHash. The Hardcoded hash is " + GenesisBlockHash + " and the new generated is " + CurrentHash);
                    return;
                }
            }

            // Generate new Block (non GenesisBlock)
            else if (BlockCount != 0)
            {
                Transaktion = txtTransaction.Text;
                TransaktionHash = ComputeSha256Hash(Transaktion);
                var NewHash = TransaktionHash + PreviousHash;
                CurrentHash = ComputeSha256Hash(NewHash);
                //Hash is to short/long
                if (CurrentHash.Length != 64)
                {
                    MessageBox.Show("Block: " + BlockCount + " is corupted. Wrong Hash: " + CurrentHash);
                }
            }

            txtBlockcount.Text = Convert.ToString(BlockCount);
            txtBlockchain.Text += CurrentHash.ToString() + "\r\n";
            write_db();
            this.dbBlockchainTableAdapter.Fill(this.dbBlockchainDataSet1.dbBlockchain);
            BlockCount++;
            PreviousHash = CurrentHash;

        }

        string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "dbBlockchainDataSet1.dbBlockchain". Sie können sie bei Bedarf verschieben oder entfernen.
            this.dbBlockchainTableAdapter.Fill(this.dbBlockchainDataSet1.dbBlockchain);
            //Load db in GridViewList
            //get_db();
            //Get latest Id from db
            getLatestID_db();
            // MessageBox.Show(latestID);
        }

        /// <summary>
        /// Writes the whole Block to the DB 
        /// </summary>
        private void write_db()
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbBlockchain (transcation, transcationhash, currenthash, previoushash, blockcount) VALUES(@Transcation,@Transcationhash,@Currenthash,@Previoushash,@Blockcount)", connection))
                {
                    // create your parameters
                    cmd.Parameters.Add("@Transcation", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Transcationhash", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Currenthash", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Previoushash", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Blockcount", System.Data.SqlDbType.NVarChar);

                    //Cmd.Parameters["@CustomerID"].Value = Convert.ToInt32(textbox1.Text);
                    cmd.Parameters["@Transcation"].Value = Transaktion;
                    cmd.Parameters["@Transcationhash"].Value = TransaktionHash;
                    cmd.Parameters["@Currenthash"].Value = CurrentHash;
                    cmd.Parameters["@Previoushash"].Value = PreviousHash;
                    cmd.Parameters["@Blockcount"].Value = Convert.ToString(BlockCount);
                    int rows = cmd.ExecuteNonQuery();
                    //MessageBox.Show("Row inserted !! ");
                    //MessageBox.Show(Convert.ToString(rows));
                    //get_db();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Test function
        /// Is for tests
        /// </summary>
        //private void get_db()
        //{
        //    using (connection = new SqlConnection(connectionString))
        //    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbBlockchain", connection))
        //    {
        //        DataTable serverTable = new DataTable();
        //        adapter.Fill(serverTable);

        //        lstExplorer.DisplayMember = "Currenthash";
        //        lstExplorer.ValueMember = "Id";
        //        lstExplorer.DataSource = serverTable;
        //    }
        //}


        /// <summary>
        /// Recives the latest ID from Blockchain to generate the following Block
        /// Recives the latest hash from Blockchain to generate the following Block
        /// </summary>
        private void getLatestID_db()
        {
            using (connection = new SqlConnection(connectionString))
            {
                string query = "select top 1 * from dbBlockchain  order by ID desc";
                var _test = new object[6];
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var _latestID = (reader.GetValue(i));

                                _test[i] = _latestID;
                            }
                        }
                    }
                    BlockCount = Convert.ToInt32(_test[5]) + 1;
                    PreviousHash = Convert.ToString(_test[3]);    //Latest hash from db
                    connection.Close();
                }
            }
        }

        //private void getLastHash_db()
        //{
        //    using (connection = new SqlConnection(connectionString))
        //    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbBlockchain WHERE id = @latestID", connection))
        //    {
        //        connection.Open();
        //        cmd.Parameters.Add("@latestID", System.Data.SqlDbType.NVarChar);
        //        cmd.Parameters["@latestID"].Value = latestID;

        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                for (int i = 0; i < 1; i++)
        //                {
        //                    var _latestHash = (reader.GetValue(i));
        //                    MessageBox.Show(Convert.ToString(_latestHash));
        //                }
        //            }
        //        }

        //        connection.Close();
        //    }
        //}

    }
}
