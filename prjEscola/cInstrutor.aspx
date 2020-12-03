<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="cInstrutor.aspx.cs" Inherits="prjEscola.cInstrutor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="featured">
        <div class="containerCentral">

            <%--<h3 style="background: #dff0d8; margin: 0; padding: 5px; border: 1px solid #387030; font-size: 12pt; color: #387030">Cadastro de Pontos</h3>--%>
            <h3 class="h3">Cadastro de Instrutor</h3>
            <div style="float: left; width: 100%;">
                <fieldset>
                    <div>
                        <div class="form-group">

                            <div>
                                <label for="nome">
                                    Nome do Instrutor</label>
                                <asp:TextBox ID="txtNome" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <label for="nome">
                                        E-MAIL</label>
                                    <asp:TextBox ID="txtEmail" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="nome">
                                        Valor-Hora
                                    </label>
                                    <asp:TextBox ID="txtValorHora" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                                </div>

                                <div class="col-md-4">
                                    <label for="nome">
                                        Certificado 
                                    </label>
                                    <asp:TextBox ID="txtCertificado" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                                </div>
                            </div>
                            <div>
                            </div>
                            
                        </div>
                    </div>


                </fieldset>
                <div class="form-group">
                    <div class="form-group row">
                        <div class="col-md-3">
                            <asp:Button ID="cmdConfirmar" runat="server" Font-Bold="True"
                                Text="Incluir" CssClass="btn btn-success" Width="100%" OnClick="cmdConfirmar_Click1" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdExluir" runat="server" Font-Bold="True"
                                Text="Excluir" CssClass="btn btn-success" Width="100%" Enabled="False" OnClick="cmdExluir_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdLimpar" runat="server" Font-Bold="True"
                                Text="Limpar" CssClass="btn btn-success" Width="100%" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdSair" runat="server" Font-Bold="True"
                                Text="Sair" CssClass="btn btn-success" Width="100%" />
                        </div>
                    </div>
                </div>

                <fieldset>

                    <div>
                        <h4>Instrutores Cadastrados</h4>
                    </div>
                    <div>
                        <asp:DataGrid ID="dgInstrutores" runat="server" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="0px"
                            CellPadding="4" CellSpacing="1" HorizontalAlign="Left" Style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid; background-color: black"
                            Width="80%" AllowPaging="True" TabIndex="1" OnSelectedIndexChanged="dgInstrutores_SelectedIndexChanged">
                            <FooterStyle BackColor="White" CssClass="dgFooterStyle" Font-Bold="False" Font-Italic="False"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"
                                ForeColor="#333333" />
                            <SelectedItemStyle BackColor="#339966" CssClass="dgSelectedItemStyle" Font-Bold="True"
                                ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Bold="True" Font-Italic="False" Font-Names="Arial"
                                Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False"
                                ForeColor="Black" HorizontalAlign="Center" Mode="NumericPages" NextPageText=""
                                PrevPageText="" />
                            <AlternatingItemStyle CssClass="dgAlternatingItemStyle" />
                            <ItemStyle BackColor="White" CssClass="dgItemStyle" Font-Bold="False" Font-Italic="False"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#333333"
                                HorizontalAlign="Left" />
                            <HeaderStyle BackColor="#387030" CssClass="dgHeaderStyle" Font-Bold="True" Font-Italic="False"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White"
                                HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundColumn DataField="ID_INSTRUTOR" Visible="False"></asp:BoundColumn>
                                <asp:ButtonColumn CommandName="SELECT" DataTextField="NOME_INSTRUTOR" HeaderText="NOME"></asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="Select" DataTextField="VALOR_HORA"
                                    HeaderText="VALOR_HORA">
                                    <HeaderStyle Width="70%" />
                                </asp:ButtonColumn>
                                <asp:ButtonColumn
                                    HeaderText="CERTIFICADOS" DataTextField="CERTIFICADOS"></asp:ButtonColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>


                </fieldset>


            </div>
        </div>
    </section>
</asp:Content>
