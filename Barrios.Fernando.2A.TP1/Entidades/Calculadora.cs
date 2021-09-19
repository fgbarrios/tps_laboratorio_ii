using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Calculadora
    {        
        public static double Operar(Operando num1, Operando num2, char operador) 
        {
            double resultado = 0;

            if (operador != ' ')
            {
                switch (ValidarOperador(operador))
                {
                    case '-':
                        resultado = num1 - num2;
                        break;
                    case '*':
                        resultado = num1 * num2;
                        break;
                    case '/':
                        resultado = num1 / num2;
                        break;
                    default:
                        resultado = num1 + num2;
                        break;
                }
                return resultado;
            }
            else
            {
                return resultado;
            }
        }

        private static char ValidarOperador(char operador)
        {
            char operadorDefault = '+';
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                operadorDefault = operador;
            }
            return operadorDefault;
        }
    }
}
