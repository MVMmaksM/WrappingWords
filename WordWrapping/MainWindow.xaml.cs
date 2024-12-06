using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordWrapping.Facade;
using WordWrapping.Services;

namespace WordWrapping
{    
    public partial class MainWindow : Window
    {    
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnFormatText_Click(object sender, RoutedEventArgs e)
        {
            string text = TxtBxTextInput.Text.Trim();            

            //если валидация не прошла, то ретернимся отсюда,
            //чтобы не продолжать выполнение
            if (!FacadeMain.ValidateText(text))
                return;          

            var res = FacadeMain.FormatText(text, (int)IntgUpDownWidthRowText.Value);
            TxtBxTextResult.Clear();
            TxtBxTextResult.Text = res;                  
        }
    }
}