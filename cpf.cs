using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(validaCPF("54545"));
    }

    public static int validaCPF(string cpf)
    {
        string CPFtratado = "";
        int digito1 = 0;
        int digito2 = 0;


        for (int i = 0; i < cpf.Length; i++)
        {
            int n;
            if (Int32.TryParse(cpf.Substring(i, 1), out n))
            {
                CPFtratado += cpf.Substring(i, 1);
            }

        }

        if (CPFtratado.Length != 11)
        {
            return 0;
        }

        for (int i = 1; i < CPFtratado.Length - 1; i++)
        {
            digito1 += (11 - i) * Int32.Parse(CPFtratado.Substring(i, 1));
            digito2 += (12 - i) * Int32.Parse(CPFtratado.Substring(i, 1));

        }

        digito1 = digito1 % 11;

        digito1 = digito1 < 2 ? 0 : 11 - digito1;

        digito2 = digito2 % 11;

        digito2 = digito2 < 2 ? 0 : 11 - digito2;


        return digito2;
    }

}

