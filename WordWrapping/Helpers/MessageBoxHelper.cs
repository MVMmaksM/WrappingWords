using System.Windows;

namespace WordWrapping.Helpers
{
    /// <summary>
    /// класс для упрощения показа сообщений пользователю
    /// </summary>
    public class MessageBoxHelper : IMessageHelper
    {
        /// <summary>
        /// показывает ошибку
        /// </summary>     
        public void Error(string textError)=>MessageBox.Show(textError, "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Error);        
        /// <summary>
        /// показывает информацию
        /// </summary> 
        public void Info(string textInfo)=> MessageBox.Show(textInfo, "Информация", MessageBoxButton.OKCancel, MessageBoxImage.Information);        
        /// <summary>
        /// показвает предупреждение
        /// </summary>   
        public void Warning(string textWarning)=>MessageBox.Show(textWarning, "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
    }
}
