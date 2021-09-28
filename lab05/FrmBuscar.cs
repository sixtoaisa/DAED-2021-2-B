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
    public partial class FrmBuscar : Form
    {
       public string procedimiento { get; set; }
       public SqlParameter parametro { get; set; }
       public string valor { get; set; }

        public FrmBuscar()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           if(this.validar())
            {
                int index = cmbCriterio.SelectedIndex;
                this.parametro = new SqlParameter();
                this.parametro.Value = txtValor.Text;
                this.parametro.SqlDbType = SqlDbType.NVarChar;

                switch (index)
                {
                    case 0://CODIGO
                        this.procedimiento = "BuscarPersonaCodigo";
                        this.parametro.ParameterName = "@PersonID";
                        this.parametro.SqlDbType = SqlDbType.Int;
                        break;
                    case 1://NOMBRE
                        this.procedimiento = "BuscarPersonaNombre";
                        this.parametro.ParameterName = "@FirstName";
                        break;
                    case 2://APELLIDO
                        this.procedimiento = "BuscarPersonaApellido";
                        this.parametro.ParameterName = "@LastName";
                        break;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }           
           
        }


        private bool validar()
        {
            bool retorno = true;
            if (this.cmbCriterio.Text == "")
            {
                MessageBox.Show("Debe seleccionar un criterio a Buscar");
                return false;
            }

            if (this.txtValor.Text == "")
            {
                MessageBox.Show("Debe ingresar un Valor para la busqueda");
                return false;
            }

            return retorno;
        }

        private void FrmBuscar_Load(object sender, EventArgs e)
        {
            cmbCriterio.SelectedIndex = 0;
        }
    }
}
