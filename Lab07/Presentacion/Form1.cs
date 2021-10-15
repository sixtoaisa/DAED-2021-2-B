﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            ClsNegPerson np = new ClsNegPerson();
            dt = np.GetAll();

            dgDatos.DataSource = dt;
            dgDatos.Refresh();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.validar())
            {
                
                DataTable dt = new DataTable();
                ClsNegPerson np = new ClsNegPerson();
                dt = np.GETByValue(txtValor.Text);

                dgDatos.DataSource = dt;
                dgDatos.Refresh();

            }
        }

        private bool validar()
        {
            bool retorno = true;           

            if (this.txtValor.Text == "")
            {
                MessageBox.Show("Debe ingresar un Valor para la busqueda");
                return false;
            }

            return retorno;
        }
    }
}
