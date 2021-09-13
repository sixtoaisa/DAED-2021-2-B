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

namespace lab03
{
    public partial class Login : Form
    {
        SqlConnection conn;
        public Login(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (validarUsuario(txtUsuario.Text, txtPassword.Text))
            {
                MessageBox.Show("Sesión iniciada correctamente");
            }
            else
            {
                MessageBox.Show("Usuario o Clave incorrecta");
                txtUsuario.Focus();
            }
        }

        private Boolean validarUsuario(String usuario, String clave)
        {           

            String sql = "SELECT * FROM tbl_usuario WHERE usuario_nombre=@Usuario and usuario_password=@Password ";
            SqlCommand cmd = new SqlCommand(sql, this.conn);

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

            reader.Close();

            return retorno;
        }
    }
}
