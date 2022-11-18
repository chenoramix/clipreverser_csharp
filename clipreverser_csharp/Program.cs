using System;
using System.Windows.Forms;

namespace clipreverser_csharp
{
    internal class Program
    {
        // reverse a string
        static string strReverse(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);

            return new string(array);
        }

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            IDataObject iData = Clipboard.GetDataObject();

            if(iData == null || !iData.GetDataPresent(DataFormats.Text))
            {
                Console.WriteLine("No text data in clipboard");
                return;
            }

            string text = (String)iData.GetData(DataFormats.Text);
            string reversedText = strReverse(text);

            Clipboard.SetText(reversedText);

            Console.WriteLine("Text copied to clipboard");
        }
    }
}
