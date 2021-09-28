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

namespace lab05
{
    public partial class FrmPerson : Form
    {
        SqlConnection con;
        public FrmPerson()
        {
            InitializeComponent();
        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            String str = "Server=DESKTOP-FK8R0OS\\LOCAL;DataBase=School;Integrated Security=true;";
            con = new SqlConnection(str);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sql = "SELECT * from Person";
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dgvListado.DataSource = dt;
            dgvListado.Refresh();
            con.Close();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "InsertPerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (this.validar())
            {
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
                cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Value);

                int codigo = Convert.ToInt32(cmd.ExecuteScalar());
                MessageBox.Show("Se ha registrado nueva persona con el codigo: " + codigo);
            }
            
            con.Close();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "UpdatePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (this.validar())
            {
                cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Text);
                cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Text);

                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    MessageBox.Show("Se ha modificado el registro correctamente");
                    btnListar.PerformClick();
                }

            }

            con.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                String sp = "DeletePerson";
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);

                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    MessageBox.Show("Se ha eliminado el registro correctamente");
                    btnListar.PerformClick();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count>0)
            {
                txtPersonID.Text = dgvListado.SelectedRows[0].Cells[0].Value.ToString();
                txtFirstName.Text = dgvListado.SelectedRows[0].Cells[1].Value.ToString();
                txtLastName.Text = dgvListado.SelectedRows[0].Cells[2].Value.ToString();
                txtHireDate.Text = dgvListado.SelectedRows[0].Cells[3].Value.ToString();                
                txtEnrollmentDate.Text = dgvListado.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //se llama a otro formulario para recoger datos de la busqueda
            FrmBuscar frmBuscar = new FrmBuscar();
            if (frmBuscar.ShowDialog()==DialogResult.OK)
            {
                
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = frmBuscar.procedimiento;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add(frmBuscar.parametro);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                dgvListado.DataSource = dt;
                dgvListado.Refresh();
                con.Close();

            }
        }

        private bool validar()
        {
            bool retorno = true;

            if (this.txtPersonID.Text=="")
            {
                MessageBox.Show("Debe ingresar un ID");
                return false;
            }

            if (this.txtFirstName.Text == "")
            {
                MessageBox.Show("Debe ingresar un Nombre");
                return false;
            }
            if (this.txtLastName.Text == "")
            {
                MessageBox.Show("Debe ingresar un Apellido");
                return false;
            }
            if (this.txtHireDate.Value == null)
            {
                MessageBox.Show("Debe ingresar una Fecha de Contrato");
                return false;
            }

            if (this.txtEnrollmentDate.Value == null)
            {
                MessageBox.Show("Debe ingresar una Fecha de Inscripción");
                return false;
            }

            return retorno;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtPersonID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtHireDate.Text = "";
            txtEnrollmentDate.Text = "";
        }
    }


    

}
