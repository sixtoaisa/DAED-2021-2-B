using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab06
{
    public partial class FrmBuscar : Form
    {

        public string campo { get; set; }
        public string valor { get; set; }

        public FrmBuscar()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.validar())
            {
                this.valor = txtValor.Text;
                int index = cmbCriterio.SelectedIndex;
                switch (index)
                {
                    case 0://CODIGO
                        this.campo = "PersonID";                       
                        break;
                    case 1://NOMBRE
                        this.campo = "FirstName";
                        break;
                    case 2://APELLIDO
                        this.campo = "LastName";
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

