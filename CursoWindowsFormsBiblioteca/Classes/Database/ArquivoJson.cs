using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bibliotecas.Classes.Database
{
    public class ArquivoJson
    {

        public string diretorio;
        public string mensagem;
        public bool status;
        public ArquivoJson(string Diretorio)
        {
            status = true;
            try
            {
                if (!(Directory.Exists(Diretorio)))
                {
                    Directory.CreateDirectory(Diretorio);
                    mensagem = "Conexão criada com sucesso !";
                }

                this.diretorio = Diretorio;
                mensagem = "Formulário armazenado ao diretório " + this.diretorio + " já existente";

            }

            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão falhou ! Erro: " + ex.Message;
            }

        }

        public void Incluir(string id, string jsonUnit)
        {
            status = true;
            try
            {
                if (File.Exists(diretorio + "\\" + id + ".json"))
                {
                    status = false;
                    mensagem = "Inclusão não permitida, pois o ID " + id + " já existe !";
                }
                else
                {
                    File.WriteAllText(diretorio + "\\" + id + ".json", jsonUnit);
                    status = true;
                    mensagem = "Inclusão efetuada com sucesso, ID: " + id;
                }
            }
            catch(Exception ex)
            {
                status = false;
                mensagem = "Inclusão falhou ! Erro: " + ex.Message;
            }
            
            
        }
    }
}
