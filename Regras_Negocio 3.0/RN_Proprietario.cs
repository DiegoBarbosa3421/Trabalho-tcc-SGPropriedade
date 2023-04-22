using System;
using System.Data;

namespace RegrasNegocio
{
    public class RN_Proprietario

    {
        Database.Proprietario Proprietario;
        DataTable listarTabela;

        private void Validar_Logim(string nome, string senha)
        {

            if (nome.Trim().Length == 0)
            {
                throw new Exception("O campo nome não pode ser vazio !! Por favor digite o nome de usuario");
            }
            if (senha.Trim().Length == 0)
            {
                throw new Exception("O campo senha não pode ser vazio!! Por favor digite sua senha");
            }
        }
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void Cadastrar(string nome, string senha, string cpf)
        {

            Proprietario = new Database.Proprietario();
            listarTabela = new DataTable();

            Validar_Logim(nome, senha);



            if (ValidarCpf(cpf) == true)
            {
                Proprietario.salvarProprietario(nome, senha, cpf);
            }

            else if (ValidarCpf(cpf) == false)
            {
                throw new Exception("O CPF informado não e um CPF valido!! Por favor insira um CPF valido para continuar");
            }

        }
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public DataTable Logim(string nome, string senha)
        {


            Proprietario = new Database.Proprietario();
            listarTabela = new DataTable();

            Validar_Logim(nome, senha);

            listarTabela = Proprietario.logimProprietario(nome, senha);

            return listarTabela;

        }
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public string CompararUsuarios(string nome)
        {
            listarTabela = new DataTable();

            Proprietario = new Database.Proprietario();

            listarTabela = RetornarProprietario();

            string comparação = null;

            for (int i = 0; i < listarTabela.Rows.Count; i++)

            {
                if (listarTabela.Rows[i]["nomeProprieatrio"].ToString() == nome)
                {
                    comparação = nome;
                    break;
                }

            }

            return comparação;

        }

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public DataTable RetornarProprietario()
        {
            Proprietario = new Database.Proprietario();

            listarTabela = new DataTable();

            listarTabela = Proprietario.RetornarProprietario();

            return listarTabela;
        }
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//Analisa se ha algum registro de proprietario/Usuario no banco de dados
        public  bool Analisar_Tabela()
        {

            listarTabela = new DataTable();

            bool resultado = false;

            listarTabela = RetornarProprietario();

            if (Convert.ToString(listarTabela.Rows[0]["nomeProprieatrio"].ToString()) == null)
            {
                resultado =  false;
            }

            else if ((Convert.ToString(listarTabela.Rows[0]["nomeProprieatrio"].ToString()) != null)){

                resultado = true;
            }

            return resultado;
        }
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static bool ValidarCpf(string cpf)
        {
            int[] multiplicadores1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "").Replace(",", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}

