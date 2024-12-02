using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WordWrapping.Helpers
{
    /// <summary>
    /// класс для упрощени яработы с сообщениями
    /// </summary>
    public class MessageHelper
    {
        public static void Error(string textError, 
            MessageBoxButton msgBxBtn = MessageBoxButton.OKCancel, 
            MessageBoxImage msgImg = MessageBoxImage.Error)=>MessageBox.Show(textError, "Ошибка", msgBxBtn, msgImg);
        

        public static void Info(string textInfo, 
            MessageBoxButton msgBxBtn = MessageBoxButton.OKCancel,
            MessageBoxImage msgImg = MessageBoxImage.Error)=> MessageBox.Show(textInfo, "Информация", msgBxBtn, msgImg);
        

        public static void Warning(string textWarning, 
            MessageBoxButton msgBxBtn = MessageBoxButton.OKCancel, 
            MessageBoxImage msgImg = MessageBoxImage.Error)=>MessageBox.Show(textWarning, "Предупреждение", msgBxBtn, msgImg);
        
    }
}
