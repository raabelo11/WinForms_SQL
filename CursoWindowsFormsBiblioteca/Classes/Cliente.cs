using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CursoWindowsFormsBiblioteca;
using Newtonsoft.Json;

namespace Bibliotecas.Classes
{
    public class Cliente
    {
        public class Unit
        {
            //validações pelo DataAnnotations
            [Required(ErrorMessage = "Código do cliente é obrigatório")]  
            [RegularExpression("([0-9]+)", ErrorMessage = "Código do Cliente deve ser numérico")]
            [StringLength(6, MinimumLength = 6, ErrorMessage = "Código do Cliente deve ter 6 digitos")]
            public string Id { get; set; }

            [Required(ErrorMessage = "Nome do cliente é obrigatório")]
            [StringLength(50, ErrorMessage = "Nome do Cliente deve ter no máximo 50 caracteres")]
            public string Nome { get; set; }

            [StringLength(50, ErrorMessage = "Nome do Pai deve ter no máximo 50 caracteres")]
            public string NomePai { get; set; }

            [Required(ErrorMessage = "Nome da Mãe é obrigatório")]
            [StringLength(50, ErrorMessage = "Nome da Mãe deve ter no máximo 50 caracteres")]
            public string NomeMae { get; set; }


            public bool NaoTemPai { get; set; }


            [Required(ErrorMessage = "Campo CPF é obrigatório")]
            [StringLength(11,MinimumLength = 11, ErrorMessage = "O campo CPF deve ter 11 dígitos")]
            [RegularExpression("([0-9]+)", ErrorMessage = "O campo CPF deve ser numérico")]
            public string Cpf { get; set; }

            [Required(ErrorMessage = "Gênero é obrigatório")]
            public int Genero { get; set; }

            [Required(ErrorMessage = "Campo CEP é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "O campo CEP deve ser numérico")]
            [StringLength(8,MinimumLength = 8, ErrorMessage = "O campo CEP deve ter 8 dígitos")]
            public string Cep { get; set; }

            [Required(ErrorMessage = "Campo Logradouro é obrigatório")]
            [StringLength(100, ErrorMessage = "O Logradouro deve ter no máximo 100 caracteres")]
            public string Logradouro { get; set; }

            [Required(ErrorMessage = "Campo Complemento é obrigatório")]
            [StringLength(100, ErrorMessage = "Complemento deve ter no máximo 100 caracteres")]
            public string Complemento { get; set; }

            [Required(ErrorMessage = "Campo Bairro é obrigatório")]
            [StringLength(50, ErrorMessage = "Campo bairro deve ter no máximo 50 caracteres")]
            public string Bairro { get; set; }

            [Required(ErrorMessage = "Campo Cidade é obrigatório")]
            [StringLength(50, ErrorMessage = "Campo Cidade deve ter no máximo 50 caracteres")]
            public string Cidade { get; set; }

            [Required(ErrorMessage = "Campo Estado é obrigatório")]
            [StringLength(50, ErrorMessage = "Campo Estado deve ter no máximo 50 caracteres")]
            public string Estado { get; set; }

            [Required(ErrorMessage = "Campo Telefone é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "O campo Telefone deve ser numérico")]
            public string Telefone { get; set; }


            public string Profissao { get; set; }


            [Required(ErrorMessage = "Campo Renda Familiar é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "O campo Renda Familiar deve ser numérico")]
            [Range(0, double.MaxValue, ErrorMessage = "Renda Familiar deve ser um valor positivo")]
            public double RendaFamiliar { get; set; }


            public void ValidaClasse() //validando exceção de erro para serem tratadas a partir do ValidationException
            {
                ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
                List<ValidationResult> results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(this, context, results, true);

                if (isValid == false)
                {
                    StringBuilder sbrErrors = new StringBuilder();
                    foreach (var validationResult in results)
                    {
                        sbrErrors.AppendLine(validationResult.ErrorMessage);
                    }
                    throw new ValidationException(sbrErrors.ToString());
                }

            }

            public void ValidaComplemento()
            {
                if(this.NomePai == this.NomeMae)
                {
                    throw new Exception("Nome do Pai e da Mãe não podem ser iguais");
                }

                if(this.NaoTemPai == false)
                {
                    if(NomePai == "")
                    {
                        throw new Exception("Nome do Pai não pode estar vazio quando a opção Pai desconhecido não estiver marcada");
                    }
                }

                bool validaCPF = Cls_Uteis.Valida(this.Cpf);
                if(validaCPF == false)
                {
                    throw new Exception("CPF inválido");
                }

            }
        }

        public class List
        {
            public List<Unit> ListUnit { get; set; }
        }

        public static Unit DesSerializedClassUnit(string vJson) //joga o formato json na classe C#.
        {
            return JsonConvert.DeserializeObject<Unit>(vJson);
        }

        public static string SerializedClassUnit(Unit unit) 
        {
            return JsonConvert.SerializeObject(unit);  // transforma classe em json
        }


    }
}
