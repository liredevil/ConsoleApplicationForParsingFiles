using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHSMarkitTask
{
    class TextTranslator
    {
        public static string TranslateFromRuToEn(string text)
        {
            string translitedText = "";

            string[] rus = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й",
                             "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф",
                             "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", " " };

            string[] eng = { "A", "B", "V", "G", "D", "E", "YO", "ZH", "Z", "I", "J",
                             "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F",
                             "H", "C", "CH", "SH", "SHH", null, "Y", null, "JE", "YU", "YA", "_" };

            for (int i = 0; i < text.Length; i++)
            {
                bool flag = false;

                for (int j = 0; j < rus.Length; j++)
                {
                    if (text[i].ToString() == rus[j].ToLower())
                    {
                        translitedText += eng[j].ToLower();
                        flag = true;

                        break;
                    }
                    else if (text[i].ToString() == rus[j])
                    {
                        translitedText += eng[j].ToLower();
                        flag = true;

                        break;
                    }
                }

                if (!flag)
                {
                    translitedText += text[i];
                }
            }

            return translitedText;
        }
    }
}
