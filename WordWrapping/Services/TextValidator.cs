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
        /// <summary>
        /// проверяет, что текст не пустой
        /// </summary>
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

        /// <summary>
        /// проверяет, что текст не содержит английские буквы 
        /// </summary>  
        public static bool isAllowedSymbols(string text) 
        {          
            //английские буквы
            var notAllowed = Enumerable.Range(65, 25).Concat(Enumerable.Range(97, 25));

            //если в тексте есть английская буква, то выдает ошибку
            if (text.Where(ch => notAllowed.Contains(ch)).Count() > 0)
            {
                MessageHelper.Error("Текст должен быть на русском языке");
                return false;
            }    

            return true;
        }
    }
}
