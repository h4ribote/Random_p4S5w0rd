using System.Windows;
namespace Random_p4S5w0rd
{
    public class RandomString
    {
        private static readonly char[] Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_____".ToCharArray();
        private static readonly Random Random = new Random();

        public static string Generate(int length)
        {
            if (length < 1)
                throw new ArgumentException("Length must be greater than zero.", nameof(length));

            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = Characters[Random.Next(Characters.Length)];
            }
            return new string(result);
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = true;
        }

        private bool IsInt(string text)
        {
            if (int.TryParse(text, out var intValue))
            {
                return string.Equals(text, intValue.ToString());
            }
            return false;
        }

        private void GenButton_Click(object sender, RoutedEventArgs e)
        {
            int GenTextLength;
            string GeneratedText;

            if (IsInt(LengthInput.Text) == false)
            {
                return;
            }

            GenTextLength = int.Parse(LengthInput.Text);
            GeneratedText = RandomString.Generate(GenTextLength);

            MainTextBox.Text = GeneratedText;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(MainTextBox.Text);
        }
    }
}
