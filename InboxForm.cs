using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication2
{
    public partial class InboxForm : Form
    {
        public InboxForm()
        {
            InitializeComponent();
        }

        private void InboxForm_Load(object sender, EventArgs e)
        {
            ViewInbox();
        }

        public void ViewInbox()
        {
            string MyConnectionString;
            string mySQLQuery;
            OleDbCommand myCommand;
            OleDbConnection myConnection;
            OleDbDataAdapter myDataAdapter;
            DataTable myDataTable;

            try
            {

                MyConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb;";
                myConnection = new OleDbConnection(MyConnectionString);
                mySQLQuery = "SELECT [messagelog].[ID] as [Message ID], [description] as [Message Description], [sender/recepient] as [Mobile Number], [contacts].[GROUP] as [Area], [message] as [Text Message], [time] as [Message Time] FROM [messagelog] LEFT JOIN [contacts] ON [contacts].[CONTACT NUMBER]=[messagelog].[sender/recepient] WHERE [messagetype] = 'Received' AND NOT [sender/recepient] = '+639106715113' AND NOT [sender/recepient] = '+639664022159' ORDER BY [messagelog].[time] DESC";
                myCommand = new OleDbCommand(mySQLQuery, myConnection);
                myConnection.Open();
                myDataAdapter = new OleDbDataAdapter(myCommand);
                myDataAdapter.Fill(myDataTable = new DataTable());
                dataGridView1.DataSource = myDataTable;
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewInbox();
        }


    }
}
