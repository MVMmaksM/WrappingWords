using System.Windows;
using WordWrapping.Facade;

namespace WordWrapping
{    
    public partial class MainWindow : Window
    {
        private FacadeMain _facadeMain;
        public MainWindow()
        {
            InitializeComponent();
            _facadeMain = new FacadeMain();
        }

        private void BtnFormatText_Click(object sender, RoutedEventArgs e)
        {
            string text = TxtBxTextInput.Text.Trim();            

            //если валидация не прошла, то ретернимся отсюда,
            //чтобы не продолжать выполнение
            if (!_facadeMain.ValidateText(text))
                return;          

            var res = _facadeMain.FormatText(text, (int)IntgUpDownWidthRowText.Value);
            TxtBxTextResult.Clear();
            TxtBxTextResult.Text = res;                  
        }
    }
}