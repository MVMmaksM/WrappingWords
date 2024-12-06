using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WordWrapping.Helpers
{
    /// <summary>
    /// класс для упрощения показа сообщений пользователю
    /// </summary>
    public class MessageHelper
    {
        /// <summary>
        /// показывает ошибку
        /// </summary>     
        public static void Error(string textError, 
            MessageBoxButton msgBxBtn = MessageBoxButton.OKCancel)=>MessageBox.Show(textError, "Ошибка", msgBxBtn, MessageBoxImage.Error);        
        /// <summary>
        /// показывает информацию
        /// </summary> 
        public static void Info(string textInfo, 
            MessageBoxButton msgBxBtn = MessageBoxButton.OKCancel)=> MessageBox.Show(textInfo, "Информация", msgBxBtn, MessageBoxImage.Information);        
        /// <summary>
        /// показвает предупреждение
        /// </summary>   
        public static void Warning(string textWarning, 
            MessageBoxButton msgBxBtn = MessageBoxButton.OKCancel)=>MessageBox.Show(textWarning, "Предупреждение", msgBxBtn, MessageBoxImage.Warning);        
    }
}
