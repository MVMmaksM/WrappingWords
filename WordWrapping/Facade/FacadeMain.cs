using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWrapping.Core;
using WordWrapping.Services;

namespace WordWrapping.Facade
{
    /// <summary>
    /// класс для инкапсуляции всей логики
    /// </summary>
    public class FacadeMain
    {
        /// <summary>
        /// валидация введенного текста
        /// </summary>     
        public static bool ValidateText(string text)
        {
            //если не продена валидация, то возвращаем результат наверх
            //чтобы закончить дальнейшую работу
            if (!TextValidator.isFillText(text))
                return false;

            if (!TextValidator.isAllowedSymbols(text))
                return false;

            return true;
        }

        /// <summary>
        /// форматирование текста
        /// </summary>   
        public static string FormatText(string text, int widthRow) 
        {
            var textRows = TextFormatter.FormatText(text, widthRow);                   

            var textFormatted = new StringBuilder();

            //составляем строку с преносами 
            for (int i = 0; i < textRows.Count; i++)
            {
                textFormatted.Append(textRows[i] + "\n");
            }

            return textFormatted.ToString();
        } 
    }
}
