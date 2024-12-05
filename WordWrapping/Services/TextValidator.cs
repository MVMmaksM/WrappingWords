using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WordWrapping.Helpers;

namespace WordWrapping.Services
{
    /// <summary>
    /// валидатор вводимого текста
    /// </summary>
    public class TextValidator
    {
        public static bool isFillText(string text) 
        {
            //проверяем, что текст введен
            if (string.IsNullOrWhiteSpace(text)) 
            {
                MessageHelper.Error("Для форматирования необходимо заполнить текст");
                return false;
            }

            return true;
        }

        public static bool isAllowedSymbols(string text) 
        {
            //символы кириллицы
            var cirillics = Enumerable
                .Range(1024, 256)
                .Select(ch => (char)ch);
            //другие символы, такие как пробелы цифры и т.д.
            var allowedSymbols = Enumerable
                .Range(32, 33)
                .Select(ch => (char)ch)
                .ToList();
            //сивол тире
            allowedSymbols.Add(Convert.ToChar(8211));
            allowedSymbols.Add(Convert.ToChar(8212));
            //кавычки
            allowedSymbols.Add(Convert.ToChar(171));
            allowedSymbols.Add(Convert.ToChar(187));
            //возврат каретки
            allowedSymbols.Add(Convert.ToChar(13));
            //перевод строки
            allowedSymbols.Add(Convert.ToChar(10));
            

            foreach (var ch in text) 
            {
                if (!allowedSymbols.Contains(ch) && !cirillics.Contains(ch)) 
                {
                    MessageHelper.Error($"Текст должен быть на русском языке {Convert.ToInt32(ch)}");
                    return false;
                }                    
            }

            return true;
        }
    }
}
