using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordWrapping.Core
{
    public class TextFormatter
    {       
        public static string FormatText(string text, int lengthRow) 
        {
            //сплитим текст на слова по пробелам
            var words = text.Split(' ').ToList();
            var strResult = new StringBuilder();

            for (int i = 0; i < words.Count; i++)
            {
                //если длина формируемой строки становится больше
                //указанной длины строки, то делим слово
                if (strResult.Length + words[i].Length > lengthRow)
                {
                    //todo wrapeWords
                }
                else 
                {
                    //просто всталяем слово в строку
                    strResult.Append(words[i] + " ");   
                }
            }

            return strResult.ToString();
        }

        /*private string WrapeWord(string word) 
        {
            var consonants = Consonants.GetConsonants();

            Regex regex = new Regex(@"\b[m]\w+");
                        
        }*/
    }
}
