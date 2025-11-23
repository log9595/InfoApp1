using System;
using System.Collections.Generic;
using System.Linq;

namespace InfoApp
{
    public class ECPPassGenerator
    {
        private static Dictionary<char, string> TRANS = new Dictionary<char, string> {
            { 'А', "A" }, { 'Б', "B" }, { 'В', "V" }, { 'Г', "G" }, { 'Д', "D" },
            { 'Е', "E" }, { 'Ё', "YO" }, { 'Ж', "ZH" }, { 'З', "Z" }, { 'И', "I" },
            { 'Й', "Y" }, { 'К', "K" }, { 'Л', "L" }, { 'М', "M" }, { 'Н', "N" },
            { 'О', "O" }, { 'П', "P" }, { 'Р', "R" }, { 'С', "S" }, { 'Т', "T" },
            { 'У', "U" }, { 'Ф', "F" }, { 'Х', "KH" }, { 'Ц', "TS" }, { 'Ч', "CH" },
            { 'Ш', "SH" }, { 'Щ', "SHCH" }, { 'Ъ', "" }, { 'Ы', "Y" }, { 'Ь', "" },
            { 'Э', "E" }, { 'Ю', "YU" }, { 'Я', "YA" }
        };

        private static string Transliterate(char c)
        {
            return TRANS[c];
        }

        // text - ожидается "Фамилия Имя Отчество?" клиента
        public static string Process(string text)
        {
            Random rng = new Random();
            string result = string.Empty;

            string[] parts = text.Trim().Split(' ');
            if (parts.Length < 2)
            {
                return null;
            }

            string surname = parts[0];
            string name = parts[1];
            string patronimyc = parts.Length > 2 ? parts[2] : string.Empty;

            result += Transliterate(surname.ToUpper().First()).First();
            result += string.Concat(Enumerable.Range(0, 5).Select(_ => rng.Next(0, 10).ToString()));
            result += Transliterate(name.ToUpper().First()).First();
            result += patronimyc != string.Empty ? Transliterate(patronimyc.ToUpper().First()).First() : '\0';
            result += "*";

            return result;
        }
    }
}
