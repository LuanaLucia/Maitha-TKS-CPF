using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(validaCPF("36698765484"));
    }

    public static string validaCPF(string CPF)
    {
        string CPFtratado = trataCPF(CPF);

        if (CPFtratado.Length != 11)
        {
            return "CPF inválido";
        }

        int digito1 = calculaDigito(11, CPFtratado);
        int digito2 = calculaDigito(12, CPFtratado);

        //return Convert.ToInt64(digito1).ToString("D1");

        if (Convert.ToInt64(digito1).ToString("D1") == CPFtratado.Substring(9, 1) || Convert.ToInt64(digito2).ToString("D1") == CPFtratado.Substring(10, 1))
        {
            return "CPF Válido";
        }
        else
        {
            return "CPF inválido";
        }


    }

    public static int calculaDigito(int n, string CPFaux)
    {
        int digitoAux = 0;

        for (int i = 1; i < CPFaux.Length - 1; i++)
        {
            digitoAux += (n - i) * Int32.Parse(CPFaux.Substring(i, 1));

        }

        digitoAux = digitoAux % 11;
        digitoAux = digitoAux < 2 ? 0 : 11 - digitoAux;
        return digitoAux;

    }

    public static string trataCPF(string cpf)
    {
        string CPFaux = "";

        for (int i = 0; i < cpf.Length; i++)
        {
            int n;
            if (Int32.TryParse(cpf.Substring(i, 1), out n))
            {
                CPFaux += cpf.Substring(i, 1);
            }

        }
        return CPFaux;
    }

}
