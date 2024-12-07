using WordWrapping.Helpers;

namespace WordWrapping.Services
{
    /// <summary>
    /// валидатор вводимого текста
    /// </summary>
    public class TextValidator : ITextValidator
    {
        private IMessageHelper _messageHelper;
        public TextValidator(IMessageHelper messageHelper)
        {
            _messageHelper = messageHelper;
        }

        /// <summary>
        /// проверяет, что текст не пустой
        /// </summary>
        public bool isFillText(string text) 
        {            
            //проверяем, что текст введен
            if (string.IsNullOrWhiteSpace(text)) 
            {
                _messageHelper.Error("Для форматирования необходимо заполнить текст");
                return false;
            }

            return true;
        }

        /// <summary>
        /// проверяет, что текст не содержит английские буквы 
        /// </summary>  
        public bool isAllowedSymbols(string text) 
        {          
            //английские буквы
            var notAllowed = Enumerable.Range(65, 25).Concat(Enumerable.Range(97, 25));

            //если в тексте есть английская буква, то выдает ошибку
            if (text.Where(ch => notAllowed.Contains(ch)).Count() > 0)
            {
                _messageHelper.Error("Текст должен быть на русском языке");
                return false;
            }    

            return true;
        }
    }
}
