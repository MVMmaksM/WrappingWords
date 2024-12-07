using System.Text;
using WordWrapping.Core;
using WordWrapping.Helpers;
using WordWrapping.Services;

namespace WordWrapping.Facade
{
    /// <summary>
    /// класс для инкапсуляции всей логики
    /// </summary>
    public class FacadeMain
    {
        private IMessageHelper _messageHelper;
        private ITextValidator _textValidator;
        public FacadeMain()
        {
            _messageHelper = new MessageBoxHelper();
            _textValidator = new TextValidator(_messageHelper);
        }

        /// <summary>
        /// валидация введенного текста
        /// </summary>     
        public bool ValidateText(string text)
        {
            //если не продена валидация, то возвращаем результат наверх
            //чтобы закончить дальнейшую работу
            if (!_textValidator.isFillText(text))
                return false;

            if (!_textValidator.isAllowedSymbols(text))
                return false;

            return true;
        }

        /// <summary>
        /// форматирование текста
        /// </summary>   
        public string FormatText(string text, int widthRow) 
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
