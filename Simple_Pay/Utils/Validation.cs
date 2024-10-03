using Newtonsoft.Json;
using Simple_Pay.Models;
namespace Simple_Pay.Utils;
internal class Validation
{
    public string TypeIdentifier(string NIdentifier)
    {
        if (NIdentifier.Length == 11)
        {
            return "PF";
        }

        if (NIdentifier.Length == 14)
        {

            return "PJ";
        }
        return "ND";
    }
    public bool checkCpf(string NIdentifier)
    {
        if (Data.GetClientById(NIdentifier) == null)
        {
            string verificador = NIdentifier.Substring(9, 2);
            int multiplicador = 10;
            int startOfRange = 0;
            int endOfrange = 9;

            foreach (char digit in verificador)
            {
                int verificado = 0;

                foreach (char c in NIdentifier.Substring(startOfRange, endOfrange))
                {
                    int cpfDigit = CharToInt(c);
                    verificado += cpfDigit * multiplicador;

                    --multiplicador;
                }

                int resultadoDivisao = verificado % 11;
                int digitoVerificado = 11 - resultadoDivisao;

                if (digitoVerificado >= 10)
                {
                    digitoVerificado = 0;
                }

                if (digitoVerificado != CharToInt(digit))
                {
                    Console.WriteLine("CPF Invalido");
                    return false;

                }

                multiplicador = 11;
                startOfRange = 9;
                endOfrange = 2;
            }
        }
        else
        {
            Console.WriteLine("Cpf Já cadastrado");
            Console.ReadKey();
            return false;
        }
        return true;
    }
    public bool checkCnpj(string NIdentifier)
    {
        string verificador = NIdentifier.Substring(12, 2);
        int multiplicador = 5;
        int startOfRange = 0;
        int endOfrange = 4;
        bool checkSecondDigit = false;

        foreach (char digit in verificador)
        {
            int verificado = 0;
            foreach (char c in NIdentifier.Substring(startOfRange, endOfrange))
            {
                int cnpjDigit = CharToInt(c);
                verificado += cnpjDigit * multiplicador;
                --multiplicador;
            }

            multiplicador = 9;
            if (!checkSecondDigit)
            {
                startOfRange = 4;
                endOfrange = 8;
            }
            else
            {
                startOfRange = 5;
                endOfrange = 8;
            }


            foreach (char c in NIdentifier.Substring(startOfRange, endOfrange))
            {
                int cToInteger = CharToInt(c);
                verificado += cToInteger * multiplicador;
                --multiplicador;
            }

            int resultadoDivisao = verificado % 11;
            int digitoVerificado = 11 - resultadoDivisao;
            if (digitoVerificado >= 10)
            {
                digitoVerificado = 0;
            }

            if (digitoVerificado != CharToInt(digit))
            {
                return false;

            }

            multiplicador = 6;
            startOfRange = 0;
            endOfrange = 5;
            checkSecondDigit = true;

        }
        return true;
    }
    public int CharToInt(char c)
    {
        return c - '0';
    }
    public bool Access (string NIdentifier, int pass)
    {
        Client client = Data.GetClientById(NIdentifier);
        if (client.UserPassword == pass)
        {
            Console.WriteLine($"SEnha no banco{client.UserPassword}");
            Console.WriteLine($"senha digitada{pass}");
            return true;
        }
        Console.WriteLine("Usuário ou senha icorreto");
        return false;
    }
    public bool ValidationTypeOfUser(string typeOfUser)
    {
        if (typeOfUser == "PF")
        {
            return true;
        }
        return false;
    }

    public bool EmailIsUnique(string email)
    {
        string desserializedJson = File.ReadAllText("dbContas.json");
        List<Client> listAccounts = JsonConvert.DeserializeObject<List<Client>>(desserializedJson);

        if (listAccounts != null)
        {
            for (int i = 0; i < listAccounts.Count; i++)
            {
                Client client = listAccounts[i];

                if (email == client.Email)
                {
                    Console.WriteLine("Email já cadastrado");
                    return false;

                }

            }
        }
        return true;
    }
}

