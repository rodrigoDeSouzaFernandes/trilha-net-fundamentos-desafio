namespace DesafioFundamentos.Models
{
    public static class LeitorHelper
    {
        public static decimal LerPrecoValido(string mensagem)
        {
            decimal valor = 0;

            Console.WriteLine(mensagem);
            do
            {
                try
                {
                    valor = Convert.ToDecimal(Console.ReadLine());
                    if (valor <= 0)
                        Console.WriteLine("Informe um número positivo maior que zero.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Digite apenas números válidos (use vírgula para decimais).");
                }
            } while (valor <= 0);

            return valor;
        }

        public static int LerHoraValida(string mensagem)
        {
            int horas = 0;

            Console.WriteLine(mensagem);
            do
            {
                try
                {
                    horas = Convert.ToInt32(Console.ReadLine());
                    if (horas <= 0)
                        Console.WriteLine(
                            "Informe uma quantidade de horas válida (maior que zero)."
                        );
                }
                catch (FormatException)
                {
                    Console.WriteLine("Digite apenas números inteiros.");
                }
            } while (horas <= 0);

            return horas;
        }
    }
}
