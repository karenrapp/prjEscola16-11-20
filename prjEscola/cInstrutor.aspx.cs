using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using prjEscola.App_Code.DAL;
using prjEscola.BLL;

namespace prjEscola
{
    public partial class cInstrutor : System.Web.UI.Page
    {
        protected Int32 codigo_instrutor;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                preencheGridInstrutor();
            }
        }

        void preencheGridInstrutor()
        {
            dgInstrutores.DataSource = Instrutor.PreencheGridInstrutor();
            dgInstrutores.DataBind();
        }

        protected void cmdConfirmar_Click1(object sender, EventArgs e)
        {
            adicionarInstrutor();
        }

        private void adicionarInstrutor()
        {
            Instrutor instrutor = new Instrutor();
            instrutor.NOME_INSTRUTOR = txtNome.Text.ToString().Trim();            
            instrutor.EMAIL = txtEmail.Text.ToString().Trim();
            instrutor.VALOR_HORA = Convert.ToDouble(txtValorHora.Text);
            instrutor.CERTIFICADOS = txtCertificado.Text.ToString().Trim();

            if (cmdConfirmar.Text == "Incluir")
            {
                instrutor.Inserir();
            }
            else
            {
                instrutor.Id_instrutor = Convert.ToInt32(dgInstrutores.SelectedItem.Cells[0].Text);
                instrutor.Alterar();

            }
            LimparCampos();
            preencheGridInstrutor();
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtValorHora.Text = "";
            txtCertificado.Text = "";
            codigo_instrutor = 0;
            cmdConfirmar.Text = "Incluir";
            cmdExluir.Enabled = false;

        }

        protected void dgInstrutores_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDados(dgInstrutores.SelectedItem.Cells[0].Text);
            cmdConfirmar.Text = "Alterar";
            cmdExluir.Enabled = true;

        }

        void MostrarDados(String cod_instrutor)
        {
            Instrutor instrutor = new Instrutor();
            instrutor.MostrarDados_Instrutor(int.Parse(cod_instrutor));
            codigo_instrutor = instrutor.Id_instrutor;//variavel recebe o Id_instrutor
            txtNome.Text = instrutor.NOME_INSTRUTOR;
            txtEmail.Text = instrutor.EMAIL;
            txtValorHora.Text = Convert.ToString(instrutor.VALOR_HORA);
            txtCertificado.Text = instrutor.CERTIFICADOS;

        }

        protected void cmdExluir_Click(object sender, EventArgs e)
        {
            Instrutor instrutor = new Instrutor();
            instrutor.Excluir(Convert.ToInt32(dgInstrutores.SelectedItem.Cells[0].Text));
            preencheGridInstrutor();
            LimparCampos();

        }
    }
}