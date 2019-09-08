using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD {
    public partial class RelatorioFrm : Form {

        SqlConnection sqlCon = null;
        private string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CRUD;Data Source=DESKTOP-7QMRULV";
        private string strSql = string.Empty;

        public RelatorioFrm() {
            InitializeComponent();
            Carregar();


        }

        public void Carregar() {

            try {

                strSql = "SELECT * FROM FUNCIONARIOS";
                sqlCon = new SqlConnection(strCon);
                SqlCommand comando = new SqlCommand(strSql, sqlCon);
                sqlCon.Open();
                //comando.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dtTable = new DataTable();
                da.Fill(dtTable);
                dtgFunc.DataSource = dtTable;



            } catch (Exception Ex) {

                MessageBox.Show(Ex.Message);

            } finally {

                sqlCon.Close();
            }
        }
    }
}
