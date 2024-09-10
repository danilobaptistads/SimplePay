namespace Simple_Pay.Utils;

public class Identifier
{

    public string NIdentifier;
    public Identifier(string identifier)
    {
        NIdentifier = identifier;
    }

    public string CheckTypeIdentifier()
    {
        if (NIdentifier.Length == 11)
        {

                return "PF";
         }

        if (NIdentifier.Length == 14)
        {
                return "PJ";
        }

        return "Cpf ou Cnpj inválido, por favor tete novamente";
        Console.ReadKey();
    }


    public bool checkCpf()
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
                return false;
            }

            multiplicador = 11;
            startOfRange = 9;
            endOfrange = 2;
        }

        return true;
    }
    public bool checkCnpj()
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
                Console.WriteLine("cnpj invalido");
                return false;
            }

            multiplicador = 6;
            startOfRange = 0;
            endOfrange = 5;
            checkSecondDigit = true;

        }
        return true;
    }
    int CharToInt(char c)
    {
        return c - '0';
    }
}