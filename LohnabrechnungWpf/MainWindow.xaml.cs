using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace LohnabrechnungWpf
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            // A4-Dokument erstellen und Testtext ausgeben
            A4Document a4Document = new A4Document();
            a4Document.AddText("Test", 16, 30, 12, "Arial");

            // Dokument als PDF speichern und gleich anzeigen
            string tmpFilepath = System.IO.Path.GetTempFileName() + ".pdf";
            a4Document.SaveFile(tmpFilepath, true);
        }

        private void BtnShowThirdPartyContent_Click(object sender, RoutedEventArgs e)
        {
            new winThirdPartyStuff().ShowDialog();
        }
    }
}
