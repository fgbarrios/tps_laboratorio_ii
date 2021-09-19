using System;
using System.Linq;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            double numero = double.Parse(strNumero);
            this.numero = numero;
        }

        //propiedades
        //La propiedad Numero asignará un valor al atributo número,
        //previa validación.En este lugar será el único en todo el
        //código que llame al método ValidarOperando.
        private string Numero
        {
            set {
                this.numero = ValidarOperando(value);
            }
        }

        // metodos
        public string BinarioDecimal(string binario)
        {
            string resultado = "Valor inválido";

            int intResultado = 0;
            char[] caracterNumero = binario.ToCharArray();
            Array.Reverse(caracterNumero);            

            if (EsBinario(binario))
            {
                for (int i = 0; i < caracterNumero.Length; i++)
                {
                    if (caracterNumero[i] == '1')
                    {
                        // si es 1, sumo 2 elevado al indice
                        intResultado += (int)Math.Pow(2, i);
                    }
                }
                resultado = intResultado.ToString();
            }
            return resultado;
        }

        public string DecimalBinario(double numero)
        {
            int intNumero = (int)Math.Abs(numero);
            string strBinario = "";

            if (intNumero == 0)
            {
                strBinario = "0";
            }
            else
            {
                while (intNumero > 0)
                {
                    strBinario = (int)intNumero % 2 + strBinario;
                    intNumero = (int)intNumero / 2;
                }
            }
            return strBinario;
        }

        public string DecimalBinario(string numero)
        {
            double doubleNumero;

            if (Double.TryParse(numero, out doubleNumero))
            {
                return DecimalBinario(doubleNumero);
            }
            else
            {
                return "Valor Invalido";
            }            
        }

        private bool EsBinario(string binario)
        {
            //El método privado EsBinario validará que la cadena de caracteres
            //esté compuesta SOLAMENTE por caracteres '0' o '1'.
            bool respuesta = true;

            char[] charBinario = binario.ToCharArray();

            foreach (char caracter in charBinario)
            {
                if (!caracter.Equals('0') && !caracter.Equals('1'))
                {
                    respuesta = false;
                    break;
                }
            }
            return respuesta;
        }


        private double ValidarOperando(string strNumero)
        {
            double operando = 0;
            if (strNumero.All(char.IsDigit))
            {
                operando = Convert.ToDouble(strNumero);
            }
            return operando;

        }

        // SOBRECARGA OPERADORES
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

    }

}
