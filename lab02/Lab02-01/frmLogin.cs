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


namespace Lab02_01
{
    public partial class frmLogin : Form
    {

        SqlConnection conn;

        public frmLogin()
        {
            InitializeComponent();
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
           

            if (validarUsuario(txtUsuario.Text,txtPassword.Text))
            {
                PrincipalMDI principal = new PrincipalMDI();
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Clave incorrecta");
                txtUsuario.Focus();
            }

           
        }

        private void conectar()
        {
            String bd = "db_lab03";
            String user = "sa";
            String pwd = "123456";
            String servidor = "DESKTOP-FK8R0OS\\LOCAL";
            String str = "Server=" + servidor + ";DataBase=" + bd + ";User Id=" + user + ";Password=" + pwd + ";";

            conn = new SqlConnection(str);
            conn.Open();
        }

        private void desconectar()
        {
            if (this.conn.State!=ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        private Boolean validarUsuario(String usuario,String clave)
        {
            conectar();

            String sql = "SELECT * FROM tbl_usuario WHERE usuario_nombre=@Usuario and usuario_password=@Password ";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Usuario";
            param1.Value = usuario;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@Password";
            param2.Value = clave;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);

            SqlDataReader reader = cmd.ExecuteReader();

            bool retorno = false;
            while (reader.Read())
            {
                retorno = true;
            }
            desconectar();

            return retorno;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
