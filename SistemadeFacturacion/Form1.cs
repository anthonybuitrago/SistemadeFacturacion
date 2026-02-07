using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemadeFacturacion
{
    public partial class Form1 : Form
    {
        CN_Facturas businessObject = new CN_Facturas();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadData()
        {
            CN_Facturas obj = new CN_Facturas();
            dgvFacturas.DataSource = obj.MostrarFacturas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNumFactura.Text == "" || txtMonto.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                businessObject.GuardarFactura(txtNumFactura.Text, txtCliente.Text, txtMonto.Text);

                MessageBox.Show("Invoice Saved Successfully!");

                LoadData(); 
                ClearForm(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtNumFactura.Text = "";
            txtCliente.Text = "";
            txtMonto.Text = "";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNumFactura.Text == "")
            {
                LoadData();
            }
            else
            {
                DataTable dt = (DataTable)dgvFacturas.DataSource;
                dt.DefaultView.RowFilter = $"NumFactura LIKE '%{txtNumFactura.Text}%'";
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count > 0)
            {
                string numero = dgvFacturas.CurrentRow.Cells["NumFactura"].Value.ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to void invoice " + numero + "?", "Confirm", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        businessObject.AnularFactura(numero);
                        MessageBox.Show("Invoice Voided!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the entire row by clicking the triangle on the left.");
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (txtNumFactura.Text == "")
            {
                LoadData();
            }
            else
            {
                (dgvFacturas.DataSource as System.Data.DataTable).DefaultView.RowFilter =
                    $"NumFactura LIKE '%{txtNumFactura.Text}%'";
            }
        }

        private void btnAnular_Click_1(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count > 0)
            {
                string numero = dgvFacturas.CurrentRow.Cells["NumFactura"].Value.ToString();
                businessObject.AnularFactura(numero);
                MessageBox.Show("Invoice Voided!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Select a row first.");
            }
        }
    }
}