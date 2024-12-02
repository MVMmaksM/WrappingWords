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

        public static string FormatText(string text) => TextFormatter.FormatText(text, 1000);
    }
}
