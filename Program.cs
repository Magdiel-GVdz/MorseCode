using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CodigoMorse{
    internal class Program{
        /// <summary>
        /// Verifica si una cadena de texto es código Morse válido.
        /// </summary>
        /// <param name="code">La cadena de texto a verificar.</param>
        /// <returns>Verdadero si la cadena de texto es código Morse válido, de lo contrario, falso.</returns>
        public static Boolean isMorseCode(String code)
        {
            // Crea una expresión regular que debe coincidir con cualquier cadena que contenga solo puntos, espacios en blanco y guiones.
            Regex regex = new Regex("^[.\\s-]*$");

            return regex.IsMatch(code);
        }

        /// <summary>
        /// Verifica si una cadena de texto contiene solo letras, números y espacios.
        /// </summary>
        /// <param name="text">La cadena de texto a verificar.</param>
        /// <returns>Verdadero si la cadena de texto contiene solo letras, números y espacios, de lo contrario, falso.</returns>
        public static Boolean onlyNumbersAndLetters(String text)
        {
            // Crea una expresión regular que debe coincidir con cualquier cadena que contenga solo letras, números y espacios.
            Regex regex = new Regex("^[a-zA-Z0-9\\s]*$");

            return regex.IsMatch(text);

        }

        /// <summary>
        /// Traduce un texto a código Morse.
        /// </summary>
        /// <param name="text">El texto a traducir.</param>
        /// <param name="alphabet">El diccionario que mapea los caracteres a su representación en código Morse.</param>
        /// <returns>El texto traducido a código Morse.</returns>
        public static string translateToMorseCode(String text, Dictionary<string, string> alphabet)
        {
            text = text.ToLower();
            string[] words = text.Split(' ');
            List<string> morseCode = new List<string>();

            foreach (string word in words)
            {
                char[] letters = word.ToCharArray();

                foreach (char letter in letters)
                {
                    morseCode.Add(alphabet[letter.ToString()]);
                    morseCode.Add(" ");
                }
                morseCode.Add("  ");
            }
            return string.Join("", morseCode);
        }

        /// <summary>
        /// Traduce un código Morse a texto.
        /// </summary>
        /// <param name="code">El código Morse a traducir.</param>
        /// <param name="alphabet">El diccionario que mapea los caracteres a su representación en código Morse.</param>
        /// <returns>El texto traducido.</returns>
        public static string translateToText(String code, Dictionary<string, string> alphabet)
        { 
            string key = "";
            string[] words = Regex.Split(code, "  ");
            List<string> text = new List<string>();
            foreach (string word in words)
            {
                string[] letters = Regex.Split(word, " ");
                foreach (string letter in letters)
                {
                    key = alphabet.FirstOrDefault(x => x.Value == letter).Key;
                    text.Add(key);
                }
                text.Add(" ");
            }
            return string.Join("", text);
        }



        static void Main(string[] args)
        {
            Dictionary<string,string> alphabet = new Dictionary<string,string>();
            alphabet.Add("a", ".-");
            alphabet.Add("b", "-...");
            alphabet.Add("c", "-.-.");
            alphabet.Add("d", "-..");
            alphabet.Add("e", ".");
            alphabet.Add("f", "..-.");
            alphabet.Add("g", "--.");
            alphabet.Add("h", "....");
            alphabet.Add("i", "..");
            alphabet.Add("j", ".---");
            alphabet.Add("k", "-.-");
            alphabet.Add("l", ".-..");
            alphabet.Add("m", "--");
            alphabet.Add("n", "-.");
            alphabet.Add("o", "---");
            alphabet.Add("p", ".--.");
            alphabet.Add("q", "--.-");
            alphabet.Add("r", ".-.");
            alphabet.Add("s", "...");
            alphabet.Add("t", "-");
            alphabet.Add("u", "..-");
            alphabet.Add("v", "...-");
            alphabet.Add("w", ".--");
            alphabet.Add("x", "-..-");
            alphabet.Add("y", "-.--");
            alphabet.Add("z", "--..");
            alphabet.Add("0", "-----");
            alphabet.Add("1", ".----");
            alphabet.Add("2", "..---");
            alphabet.Add("3", "...--");
            alphabet.Add("4", "....-");
            alphabet.Add("5", ".....");
            alphabet.Add("6", "-....");
            alphabet.Add("7", "--...");
            alphabet.Add("8", "---..");
            alphabet.Add("9", "----.");

            string newText;
            string text;
            do
            {
                Console.WriteLine("Enter text or morse code. Leave the field empty to finish: ");
                text = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Translation: ");
                
                if (isMorseCode(text))
                {
                    newText = translateToText(text, alphabet);
                    Console.WriteLine("Morse code: " + text);
                    Console.WriteLine("Text: " + newText);
                }
                else if (onlyNumbersAndLetters(text))
                {
                    newText = translateToMorseCode(text, alphabet);
                    Console.WriteLine("Text: " + text);
                    Console.WriteLine("Morse code: " + newText);
                }
                else { Console.WriteLine("Invalid input"); }
                Console.WriteLine("");

            } while (text != "");

        }
    }
}
