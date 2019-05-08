using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
using System.Globalization;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using NBitcoin;

namespace Blockchain
{
    /// <summary>
    /// Will not work activate the functions before
    /// After that it will not work and the window will freeze :D
    /// </summary>
    public partial class Form1 : Form
    {
        //Variables
        List<float[,,,]> Blockchain = new List<float[,,,]>();
        string PreviousHash = "0";
        string CurrentHash;
        string Amount;
        string AmountHash;
        string GenesisBlockHash = "c423b0dcb3697b21d846dbf01f6f2438fbc973078bd8fc671551f5b98e8af0f0";
        int BlockCount = 0;
        int nounce = 0;
        long Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        string test;
        string PrivateKey = "";
        string PublicKey = "";
        string MiningReward = "";
        string MiniRewardAddress = "";
        string ToAddress = "";
        string FromAddress = "";
        int difficulty = 2;
        string MinedBlock;


        SqlConnection connection;
        string connectionString;

        public Form1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Blockchain.Properties.Settings.dbBlockchainConnectionString"].ConnectionString;
            Key privateKey = new Key();
            PubKey publicKey = privateKey.PubKey;
            var publicKeyHash = publicKey.Hash;
            txtKey.Text += Convert.ToString(publicKeyHash) + "\r\n";
            var mainNetAddress = publicKeyHash.GetAddress(Network.Main);
            var testNetAddress = publicKeyHash.GetAddress(Network.TestNet);
            txtKey.Text += Convert.ToString(mainNetAddress) + "\r\n";
            txtKey.Text += Convert.ToString(testNetAddress) + "\r\n";
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
                Amount = "Das ist ein Test";   //First TX
                BlockCount = 0;                    //No Previous Block          //GenesisBlock = 0
                CurrentHash = ComputeSha256Hash(Amount);
                AmountHash = CurrentHash;

                //Check if Hardcoded is equal Block 0 at new Start.
                if (GenesisBlockHash != CurrentHash)
                {
                    MessageBox.Show("Wrong GenesisBlockHash. The Hardcoded hash is " + GenesisBlockHash + " and the new generated is " + CurrentHash + " please change the GenesisBlock in your Sourcecode!");
                    return;
                }
            }

            // Generate new Block (non GenesisBlock)
            else if (BlockCount != 0)
            {
                Amount = txtTransaction.Text;
                AmountHash = ComputeSha256Hash(Amount);
                ToAddress = txtToAddress.Text;
                FromAddress = PublicKey;
                long Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                //CurrentHash = MineBlock(difficulty);
                //Hash is to short/long
                if (CurrentHash.Length != 64)
                {
                    MessageBox.Show("Block: " + BlockCount + " is corupted. Wrong Hash: " + CurrentHash);
                }
            }

            else
            {
                MessageBox.Show("Error! Blockchain is corrupted. Can't create Block lower than 0 and higher than endless.");    //It sounds scary :D
            }

            txtBlockcount.Text = Convert.ToString(BlockCount);
            txtBlockchain.Text += CurrentHash.ToString() + "\r\n";
            txtTxHash.Text += test + "\r\n";
            //write_db();
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

        /// <summary>
        /// How?!?!?!?!?!?!?!?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ////string MineBlock(int difficulty)
        ////{

        ////    var NewHash = (AmountHash + PreviousHash + Convert.ToString(nounce) + Convert.ToString(Timestamp) + ToAddress + FromAddress);
        ////    object[] array = { difficulty + 1 }; /*array[difficulty + 1]*/
        ////    string s1 = string.Join("0", array);
        ////    while (NewHash.Substring(0, difficulty) != s1)
        ////    {
        ////        nounce++;
        ////        NewHash = (AmountHash + PreviousHash + Convert.ToString(nounce) + Convert.ToString(Timestamp) + ToAddress + FromAddress);

        ////       // Create a SHA256
        ////        using (SHA256 sha256Hash = SHA256.Create())
        ////        {
        ////           // ComputeHash - returns byte array
        ////            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(NewHash));

        ////           // Convert byte array to a string
        ////           StringBuilder builder = new StringBuilder();
        ////            for (int i = 0; i < bytes.Length; i++)
        ////            {
        ////                builder.Append(bytes[i].ToString("x2"));
        ////            }
        ////            MinedBlock = builder.ToString();
        ////        }
        ////    }
        ////    return MinedBlock;
        ////}

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "dbBlockchainDataSet1.dbBlockchain". Sie können sie bei Bedarf verschieben oder entfernen.
            this.dbBlockchainTableAdapter.Fill(this.dbBlockchainDataSet1.dbBlockchain);
            //Get latest Id from db
            getInfo_db();
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
                    cmd.Parameters["@Transcation"].Value = Amount;
                    cmd.Parameters["@Transcationhash"].Value = AmountHash;
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
        /// Recives the latest ID from Blockchain to generate the following Block
        /// Recives the latest hash from Blockchain to generate the following Block
        /// </summary>
        private void getInfo_db()
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

        private void BtnKey_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider rSA = new RSACryptoServiceProvider();
            var privateKey = rSA.ToXmlString(true);
            var publicKey = rSA.ToXmlString(false);

            var EncodedPrivateKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(privateKey));
            var EncodedPublicKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(publicKey));

        }

    }
}
