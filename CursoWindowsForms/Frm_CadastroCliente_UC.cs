using System;
using System.Windows.Forms;
using Bibliotecas.Classes;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using CursoWindowsFormsBiblioteca;
using Bibliotecas.Classes.Database;

namespace CursoWindowsForms
{
    public partial class Frm_CadastroCliente_UC : UserControl
    {
        public Frm_CadastroCliente_UC()
        {
            InitializeComponent();
            Grp_Codigo.Text = "Código";
            Grp_DadosPessoais.Text = "Dados Pessoais";
            Grp_Endereco.Text = "Endereço";
            Grp_Outros.Text = "Outros";
            Lbl_Bairro.Text = "Bairro";
            Lbl_CEP.Text = "CEP";
            Lbl_Complemento.Text = "Complemento";
            Lbl_CPF.Text = "CPF";
            Lbl_Estado.Text = "Estado";
            Lbl_Logradouro.Text = "Logradouro";
            Lbl_NomeCliente.Text = "Nome";
            Lbl_NomeMae.Text = "Nome da Mãe";
            Lbl_NomePai.Text = "Nome do Pai";
            Lbl_Profissao.Text = "Profissão";
            Lbl_RendaFamiliar.Text = "Renda Familiar";
            Lbl_Telefone.Text = "Telefone";
            Lbl_Cidade.Text = "Cidade";
            Chk_TemPai.Text = "Pai desconhecido";
            Rdb_Masculino.Text = "Masculino";
            Rdb_Feminino.Text = "Feminino";
            Rdb_Indefinido.Text = "Indefinido";
            Grp_Genero.Text = "Genero";

            Cmb_Estados.Items.Clear();
            Cmb_Estados.Items.Add("Acre (AC)");
            Cmb_Estados.Items.Add("Alagoas(AL)");
            Cmb_Estados.Items.Add("Amapá(AP)");
            Cmb_Estados.Items.Add("Amazonas(AM)");
            Cmb_Estados.Items.Add("Bahia(BA)");
            Cmb_Estados.Items.Add("Ceará(CE)");
            Cmb_Estados.Items.Add("Distrito Federal(DF)");
            Cmb_Estados.Items.Add("Espírito Santo(ES)");
            Cmb_Estados.Items.Add("Goiás(GO)");
            Cmb_Estados.Items.Add("Maranhão(MA)");
            Cmb_Estados.Items.Add("Mato Grosso(MT)");
            Cmb_Estados.Items.Add("Mato Grosso do Sul(MS)");
            Cmb_Estados.Items.Add("Minas Gerais(MG)");
            Cmb_Estados.Items.Add("Pará(PA)");
            Cmb_Estados.Items.Add("Paraíba(PB)");
            Cmb_Estados.Items.Add("Paraná(PR)");
            Cmb_Estados.Items.Add("Pernambuco(PE)");
            Cmb_Estados.Items.Add("Piauí(PI)");
            Cmb_Estados.Items.Add("Rio de Janeiro(RJ)");
            Cmb_Estados.Items.Add("Rio Grande do Norte(RN)");
            Cmb_Estados.Items.Add("Rio Grande do Sul(RS)");
            Cmb_Estados.Items.Add("Rondônia(RO)");
            Cmb_Estados.Items.Add("Roraima(RR)");
            Cmb_Estados.Items.Add("Santa Catarina(SC)");
            Cmb_Estados.Items.Add("São Paulo(SP)");
            Cmb_Estados.Items.Add("Sergipe(SE)");
            Cmb_Estados.Items.Add("Tocantins(TO)");

            Tls_Principal.Items[0].ToolTipText = "Incluir na base de dados um novo cliente";
            Tls_Principal.Items[1].ToolTipText = "Capturar um cliente já cadastrado na base";
            Tls_Principal.Items[2].ToolTipText = "Atualize o cliente já existente";
            Tls_Principal.Items[3].ToolTipText = "Apaga o cliente selecionado";
            Tls_Principal.Items[4].ToolTipText = "Limpa dados da tela de entrada de dados";


        }

        private void LimparFormulario()
        {
            Txt_Codigo.Text = "";
            Txt_CEP.Text = "";
            Txt_Bairro.Text = "";
            Txt_Complemento.Text = "";
            Txt_CPF.Text = "";
            Cmb_Estados.SelectedIndex = -1;
            Txt_Logradouro.Text = "";
            Txt_NomeCliente.Text = "";
            Txt_NomeMae.Text = "";
            Txt_NomePai.Text = "";
            Txt_Profissao.Text = "";
            Txt_RendaFamiliar.Text = "";
            Txt_Telefone.Text = "";
            Txt_Cidade.Text = "";
            Chk_TemPai.Checked = false;
            Rdb_Masculino.Checked = true;
        }

        private void Chk_TemPai_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_TemPai.Checked)
            {
                Txt_NomePai.Text = "";
                Txt_NomePai.Enabled = false;
            }
            else
            {
                Txt_NomePai.Enabled = true;
            }
        }

        private void novoToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {

                Cliente.Unit CU = new Cliente.Unit();
                CU = LeituraFormulario();
                CU.ValidaClasse();
                CU.ValidaComplemento();
                string clienteJson = Cliente.SerializedClassUnit(CU);
                ArquivoJson AJ = new ArquivoJson("C:\\Users\\Guilherme\\Pictures\\WinForms_SQL\\ArquivosJson");  //cria um diretório para guardar o arquivo json que salva o formulário
                if (AJ.status)
                {
                    AJ.Incluir(CU.Id, clienteJson);
                    MessageBox.Show("OK: " + AJ.mensagem);
                }
                else
                {
                    MessageBox.Show("ERROR: " + AJ.mensagem);
                }
                
            }
            catch(ValidationException Ex)
            {
                MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Efetuei um clique sobre o botão ABRIR");
        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Efetuei um clique sobre o botão SALVAR");
        }

        private void ApagatoolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Efetuei um clique sobre o botão EXCLUIR");
        }

        private void LimpartoolStripButton_Click(object sender, EventArgs e)
        {
            LimparFormulario();
            MessageBox.Show("Formulário limpo");
        }

        Cliente.Unit LeituraFormulario()
        {
            Cliente.Unit CU = new Cliente.Unit();
            CU.Id = Txt_Codigo.Text;
            CU.Nome = Txt_NomeCliente.Text;
            CU.NomeMae = Txt_NomeMae.Text;
            CU.NomePai = Txt_NomePai.Text;

            if (Chk_TemPai.Checked)
            {
                CU.NaoTemPai = true;
            }
            else
            {
                CU.NaoTemPai = false;
            }

            if (Rdb_Masculino.Checked)
            {
                CU.Genero = 0;
            }

            if (Rdb_Feminino.Checked)
            {
                CU.Genero = 1;
            }

            if (Rdb_Indefinido.Checked)
            {
                CU.Genero = 2;
            }

            CU.Cpf = Txt_CPF.Text;
            CU.Cep = Txt_CEP.Text;
            CU.Logradouro = Txt_Logradouro.Text;
            CU.Complemento = Txt_Complemento.Text;
            CU.Cidade = Txt_Cidade.Text;
            CU.Bairro = Txt_Bairro.Text;

            if(Cmb_Estados.SelectedIndex < 0) //Elemento selecionado no combo-box = 0. (vazio)
            {
                CU.Estado = "";
            }
            else
            {
                CU.Estado = Cmb_Estados.Items[Cmb_Estados.SelectedIndex].ToString();   //Pega o elemento que foi selecionado no combo-box - Selected Index
            }

            CU.Telefone = Txt_Telefone.Text;
            CU.Profissao = Txt_Profissao.Text;

            if (Information.IsNumeric(Txt_RendaFamiliar.Text))
            {
                double rendaF = Convert.ToDouble(Txt_RendaFamiliar.Text);
                if(rendaF < 0)
                {
                    CU.RendaFamiliar = 0;
                }
                else
                {
                    CU.RendaFamiliar = rendaF;
                }
            }        




            return CU;
        }




        private void Txt_Codigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tls_Principal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Txt_CEP_Leave(object sender, EventArgs e)
        {
            
            string vCep = Txt_CEP.Text;
            if(vCep != "")
            {
                if(vCep.Length == 8)
                {
                    if (Information.IsNumeric(vCep))
                    {
                        var vJson = Cls_Uteis.GeraJSONCEP(vCep); // pega json do site transforma em string e armazena na variavel vJson.
                        Cep.Unit CEP = new Cep.Unit();
                        CEP = Cep.DesSerializedClassUnit(vJson); //joga o json para classe criada com os objetos iguais do json.
                                                                 //desserializado pelo JsonConvert
                        Txt_Logradouro.Text = CEP.logradouro;
                        Txt_Bairro.Text = CEP.bairro;
                        Txt_Cidade.Text = CEP.localidade;
                        Cmb_Estados.SelectedIndex = -1;
                        for (int i = 0; i <= Cmb_Estados.Items.Count -1; i++) //-1 pois a collection começa no 0.
                            // for percorre todos os itens da collection em busca da concatenação abaixo da variavel verPos.
                        {
                            var verPos = Strings.InStr(Cmb_Estados.Items[i].ToString(), "(" + CEP.uf + ")");
                            if(verPos > 0)
                            {
                                Cmb_Estados.SelectedIndex = i; //seleciona o I que foi encontrado no formulário.
                            }
                        }

                    }
                    
                }
            }
           


            
        }
    }
}
