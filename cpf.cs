using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(validaCPF("911.160.010-12"));
        Console.WriteLine(validaCPF("282.852.80-35"));
        Console.WriteLine(validaCPF("806840844064"));
        Console.WriteLine(validaCPF("845.594.060-30 "));
        Console.WriteLine(validaCPF("  282.852.810-35"));
        Console.WriteLine(validaCPF("   0806.840.440-64"));
        Console.WriteLine(validaCPF("455 566 380 20"));
        Console.WriteLine(validaCPF("       28285281035"));
        Console.WriteLine(validaCPF("25549038080"));
        Console.WriteLine(validaCPF("00000000000"));
        Console.WriteLine(validaCPF("84559406030"));


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

        if (Convert.ToInt64(digito2).ToString("D1") == CPFtratado.Substring(10, 1) &&
           Convert.ToInt64(digito1).ToString("D1") == CPFtratado.Substring(9, 1) &&
           CPFtratado != "00000000000")
        {
            return "CPF válido";
        }
        else
        {
            return "CPF inválido";
        }

    }

    public static int calculaDigito(int n, string CPFaux)
    {
        int digitoAux = 0;

        for (int i = 1; i < (n - 1); i++)
        {
            digitoAux += (n - i) * Int32.Parse(CPFaux.Substring(i - 1, 1));

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
