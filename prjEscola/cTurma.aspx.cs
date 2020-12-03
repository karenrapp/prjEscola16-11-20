using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjEscola.BLL;

namespace prjEscola
{
    public partial class cTurma : System.Web.UI.Page
    {

        protected Int32 codigo_turma;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                preencheCboCurso();
                preencheCboInstrutor();
                preencheGridTurma();
            }
        }

        protected void cmdConfirmar_Click(object sender, EventArgs e)
        {
            AdicionarTurma();
            preencheGridTurma();

        }

        private void AdicionarTurma()
        {
            Turma turma = new Turma();

            turma.ID_INSTRUTOR = Convert.ToInt32(cboInstrutor.SelectedItem.Value);
            turma.ID_CURSO = Convert.ToInt32(cboCurso.SelectedItem.Value);
            turma.DATA_INICIO = Convert.ToDateTime(txtData_Inicio.Text);
            turma.DATA_TERMINO = Convert.ToDateTime(txtData_Termino.Text);
            turma.CARGA_HORARIA = Convert.ToInt32(txtCargaHoraria.Text);

            if (cmdConfirmar.Text == "Incluir")
            {
                turma.Inserir();
            }
            else
            {
                turma.Alterar();
                turma.ID_TURMA= Convert.ToInt32(grvTurma.SelectedRow.Cells[0].Text);
           

            }
            LimparCampos();
        }

        void preencheGridTurma()
        {
            grvTurma.DataSource = Turma.PreencheGridTurma();
            grvTurma.DataBind();

        }

        private void LimparCampos()
        {
            cboInstrutor.SelectedIndex = -1;
            cboCurso.SelectedIndex= -1;
            txtData_Inicio.Text = "";
            txtData_Termino.Text = "";
            txtCargaHoraria.Text = "";
            codigo_turma = 0;
            cmdConfirmar.Text = "Incluir";
            cmdExluir.Enabled = false;

        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvTurma, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grvTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDados(grvTurma.SelectedRow.Cells[0].Text);
            cmdConfirmar.Text = "Alterar";
            cmdExluir.Enabled = true;

        }

        void MostrarDados(String cod_turma)
        {
            Turma turma = new Turma();
            turma.MostrarDados_Turmas(int.Parse(cod_turma));
            codigo_turma = turma.ID_TURMA;//variavel recebe o ID_TURMA
            cboInstrutor.Text = Convert.ToString(turma.ID_INSTRUTOR);
            cboCurso.Text = Convert.ToString(turma.ID_CURSO);
            txtData_Inicio.Text = Convert.ToString(turma.DATA_INICIO);
            txtData_Termino.Text = Convert.ToString(turma.DATA_TERMINO);
            txtCargaHoraria.Text = Convert.ToString(turma.CARGA_HORARIA);
        }

        protected void cmdExluir_Click(object sender, EventArgs e)
        {
            Turma turma = new Turma();
            turma.Excluir(Convert.ToInt32(grvTurma.SelectedRow.Cells[0].Text));
            preencheGridTurma();
            LimparCampos();

        }

        protected void cboInstrutor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        void preencheCboCurso()
        {
            cboCurso.DataTextField = "DSC_CURSO";
            cboCurso.DataValueField = "ID_CURSO";
            cboCurso.DataSource = Curso.PreencheCboCurso();
            cboCurso.DataBind();
        }

        void preencheCboInstrutor()
        {
            cboInstrutor.DataTextField = "NOME_INSTRUTOR";
            cboInstrutor.DataValueField = "ID_INSTRUTOR";
            cboInstrutor.DataSource = Instrutor.PreencheCboInstrutor();
            cboInstrutor.DataBind();
        }

        protected void grvTurma_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MostrarDados(e.CommandArgument.ToString()); 
        }
    }

}
