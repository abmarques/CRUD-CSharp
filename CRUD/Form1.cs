using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            
        }
         
        SqlConnection sqlCon = null;
        private string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CRUD;Data Source=DESKTOP-7QMRULV";
        private string strSql = string.Empty;

        private void TsbSalvar_Click(object sender, EventArgs e) {

            strSql = "INSERT INTO FUNCIONARIOS (Id, Nome, Endereco, CEP, Bairro, Cidade, UF, Telefone, Celular)" +
                "VALUES  (@Id, @Nome, @Endereco, @CEP, @Bairro, @Cidade, @UF, @Telefone, @Celular)";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@Id", SqlDbType.Int).Value = txtId.Text;
            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = mskCEP.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = txtUF.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = mskTelefone.Text;
            comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = mskCelular.Text;

            try {

                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!");

                //LIMPA TELA
                txtId.Clear();
                tstIdBuscar.Clear();
                txtNome.Clear();
                txtEndereco.Clear();
                mskCEP.Clear();
                txtBairro.Clear();
                txtCidade.Clear();
                txtUF.Clear();
                mskTelefone.Clear();
                mskCelular.Clear();


            } catch (Exception Err) {

                MessageBox.Show(Err.Message);
            } finally {
                sqlCon.Close();
            }
        }

        private void TsbBuscar_Click(object sender, EventArgs e) {

            strSql = "SELECT * FROM FUNCIONARIOS WHERE Id=@Id";
            sqlCon = new SqlConnection(strCon);  
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@Id", SqlDbType.Int).Value = tstIdBuscar.Text;

            try {

                if (tstIdBuscar.Text == string.Empty) {

                    throw new Exception("Você precisa digitar um Id!");

                }
                
                sqlCon.Open();
                SqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows == false) {

                    throw new Exception("Id não cadastrado!");
                }

                dr.Read();

                txtId.Text = Convert.ToString(dr["Id"]);
                txtNome.Text = Convert.ToString(dr["Nome"]);
                txtEndereco.Text = Convert.ToString(dr["Endereco"]);
                mskCEP.Text = Convert.ToString(dr["CEP"]);
                txtBairro.Text = Convert.ToString(dr["Bairro"]);
                txtCidade.Text = Convert.ToString(dr["Cidade"]);
                txtUF.Text = Convert.ToString(dr["UF"]);
                mskTelefone.Text = Convert.ToString(dr["Telefone"]);
                mskCelular.Text = Convert.ToString(dr["Celular"]);

            } catch (Exception ex) {

                MessageBox.Show(ex.Message);

            } finally {

                sqlCon.Close();
            }
        }

        private void TsbAlterar_Click(object sender, EventArgs e) {

            strSql = "UPDATE FUNCIONARIOS SET Id = @Id, Nome = @Nome, Endereco = @Endereco, CEP = @CEP, Bairro = @Bairro, Cidade = @Cidade, UF = @UF, Telefone = @Telefone, Celular = @Celular WHERE Id = @IdBuscar";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@IdBuscar", SqlDbType.Int).Value = tstIdBuscar.Text;

            comando.Parameters.Add("@Id", SqlDbType.Int).Value = txtId.Text;
            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = mskCEP.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = txtUF.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = mskTelefone.Text;
            comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = mskCelular.Text;

            try {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro atualizado com sucesso!");

                //LIMPA TELA
                ScreenClear();

            } catch (Exception Ex) {

                MessageBox.Show(Ex.Message);

            } finally {

                sqlCon.Close();
            }
        }

        private void TsbExcluir_Click(object sender, EventArgs e) {

            if (MessageBox.Show("Deseja realmente excluir este funcionário?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) {

                MessageBox.Show("Operação Cancelada!");

            } else {

                strSql = "DELETE FROM FUNCIONARIOS WHERE Id = @Id";
                sqlCon = new SqlConnection(strCon);
                SqlCommand comando = new SqlCommand(strSql, sqlCon);

                comando.Parameters.Add("@Id", SqlDbType.Int).Value = tstIdBuscar.Text;

                try {

                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Funcionário deletado com sucesso!");

                    //LIMPA TELA
                    ScreenClear();
                    
                } catch (Exception Ex) {

                    MessageBox.Show(Ex.Message);
                    
                } finally {

                    sqlCon.Close();
                }

            }            
        }

        private void TsbNovo_Click(object sender, EventArgs e) {

            tsbNovo.Enabled = false;
            tsbSalvar.Enabled = true;
            tsbAlterar.Enabled = false;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = false;
            tstIdBuscar.Enabled = false;
            tsbBuscar.Enabled = false;
            txtId.Enabled = true;
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            mskCEP.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUF.Enabled = true;
            mskTelefone.Enabled = true;
            mskCelular.Enabled = true;
                        
        }

        private void TsbCancelar_Click(object sender, EventArgs e) {

            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbAlterar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tstIdBuscar.Enabled = true;
            tsbBuscar.Enabled = true;
            txtId.Enabled = false;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            mskCEP.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            mskTelefone.Enabled = false;
            mskCelular.Enabled = false;
                
            //LIMPA TELA
            ScreenClear();

        }

        //LIMPA TELA
        public void ScreenClear() {

            txtId.Clear();
            tstIdBuscar.Clear();
            txtNome.Clear();
            txtEndereco.Clear();
            mskCEP.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtUF.Clear();
            mskTelefone.Clear();
            mskCelular.Clear();
        }

        private void Form1_Load(object sender, EventArgs e) {

            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbAlterar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tstIdBuscar.Enabled = true;
            tsbBuscar.Enabled = true;
            txtId.Enabled = false;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            mskCEP.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            mskTelefone.Enabled = false;
            mskCelular.Enabled = false;
        }

        private void TsbEmitirRel_Click(object sender, EventArgs e) {
            RelatorioFrm frmRelatorio = new RelatorioFrm();
            frmRelatorio.Show();
        }
    }
}