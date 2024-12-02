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
            var str = TxtBxText.Text.Split(' ').ToList();            
            var patterVolwels = @"\.*[бвгджзйклмнпрстфхцчшщ][ауоиэыяюеё][ауоиэыяюеё]\w.*";
            var patterConsonants = @"\.*[ауоиэыяюеё][бвгджзйклмнпрстфхцчшщ][бвгджзйклмнпрстфхцчшщ]^\s[ауоиэыяюеё].*";

            //TxtBxText.Text = Regex.IsMatch(str[0].ToLower(), patterVolwels).ToString();
            TxtBxText.Text = Regex.IsMatch(str[0].ToLower(), patterConsonants).ToString();

            /*string text = TxtBxText.Text;

            //если валидация не прошла, то ретернимся отсюда,
            //чтобы не продолжать выполнение
            if (!FacadeMain.ValidateText(text))
                return;

            TxtBxText.Text = FacadeMain.FormatText(text);*/
        }
    }
}