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
using HardwareInventory.AuthService;
using HardwareInventoryDAO;

namespace HardwareInventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AuthServiceClient client = new AuthServiceClient();
            var x = client.Authorize(3, 5);
            this.tekst.Text = x.ToString();
            //this.tekst.Text = "asd";
            MessageBox.Show(x.ToString());

            client.Close();

            HardwareInventoryEntities context = new HardwareInventoryEntities();
            context.User.Add(new User() { id = 1, login = "test2", password="haslo" });
            context.SaveChanges();
        }
    }
}
