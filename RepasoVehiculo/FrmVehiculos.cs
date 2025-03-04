using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepasoVehiculo
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void MtdMostrarVehiculos()
        {
            CD_Vehiculos cd_Vehiculos = new CD_Vehiculos();
            DataTable dtMostrarVehiculos= cd_Vehiculos.MtMostrarVehiculos();
            dgvVehiculos.DataSource = dtMostrarVehiculos;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MtdMostrarVehiculos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CD_Vehiculos cd_Vehiculos= new CD_Vehiculos();

            try
            {
                cd_Vehiculos.CP_mtdAgregarVehiculos(txtMarca.Text,txtModelo.Text, int.Parse(txtAño.Text),decimal.Parse(txtPrecio.Text),cboxEstado.Text);
                MessageBox.Show("El Cliente se agrego con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarVehiculos();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CD_Vehiculos cd_Vehiculos = new CD_Vehiculos();

                int VehiculoID= int.Parse(txtVehiculoID.Text);
                string Marca = txtMarca.Text;
                string Modelo= txtModelo.Text;
                int Año = int.Parse(txtAño.Text);
                decimal Precio = decimal.Parse(txtPrecio.Text);
                string Estado = cboxEstado.Text;

                int vCantidadRegistros = cd_Vehiculos.CP_mtdActualizarVehiculos(VehiculoID, Marca, Modelo, Año, Precio, Estado);

                if (vCantidadRegistros > 0)
                {
                    MessageBox.Show("Registros Actualizado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show("No se encontró codigo!!", "Error actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    MessageBox.Show("Registros Actualizado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                MtdMostrarVehiculos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void mtdLimpiarCampos()
        {
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtVehiculoID.Text = "";
            txtAño.Text = "";
            txtPrecio.Text = "";
            cboxEstado.Text = "";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CD_Vehiculos cd_Vehiculos = new CD_Vehiculos();

            int codigo = int.Parse(txtVehiculoID.Text);
            int vCantidadRegistros = cd_Vehiculos.CP_mtdEliminarVehiculos(codigo);

            if (vCantidadRegistros > 0)
            {
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show("No se encontró codigo!!", "Error eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            MtdMostrarVehiculos();
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVehiculoID.Text = dgvVehiculos.SelectedCells[0].Value.ToString();
            txtMarca.Text = dgvVehiculos.SelectedCells[1].Value.ToString();
            txtModelo.Text = dgvVehiculos.SelectedCells[2].Value.ToString();
            txtAño.Text = dgvVehiculos.SelectedCells[3].Value.ToString();
            txtPrecio.Text = dgvVehiculos.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvVehiculos.SelectedCells[5].Value.ToString();
        }
    }
}
