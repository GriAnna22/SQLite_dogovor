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
using BDLite.Model;
using BDLite.View;

namespace BDLite
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dgAgreement.ItemsSource = Agreement.GetList();
            dgPerson.ItemsSource = Person.GetList();
            dgStatusAgreement.ItemsSource = StatusAgreement.GetList();
            dgTypeAgreement.ItemsSource = TypeAgreement.GetList();
        }

        void Agreement_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowAgreement();
            window.ShowDialog();
            dgAgreement.ItemsSource = Agreement.GetList();
        }

        void Agreement_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var agreement = dgAgreement.SelectedItem as Agreement;
            if (agreement != null)
            {
                var window = new WindowAgreement(agreement);
                window.ShowDialog();
                dgAgreement.ItemsSource = Agreement.GetList();
            }
        }

        void Agreement_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var agreement = dgAgreement.SelectedItem as Agreement;
            if (agreement != null)
            {
                var dialog = MessageBox.Show("Удалить данные?", "Необходимо подтвердить", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (dialog == MessageBoxResult.Yes)
                {
                    Agreement.Delete(agreement);
                    dgAgreement.ItemsSource = Agreement.GetList();
                }
            }
        }

        void Person_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowPerson();
            window.ShowDialog();
            dgPerson.ItemsSource = Person.GetList();
        }

        void Person_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var person = dgPerson.SelectedItem as Person;
            if (person != null)
            {
                var window = new WindowPerson(person);
                window.ShowDialog();
                dgPerson.ItemsSource = Person.GetList();
            }
        }

        void Person_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var person = dgPerson.SelectedItem as Person;
            if (person != null)
            {
                var dialog = MessageBox.Show("Удалить данные?", "Необходимо подтвердить", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (dialog == MessageBoxResult.Yes)
                {
                    Person.Delete(person);
                    dgPerson.ItemsSource = Person.GetList();
                }
            }
        }

        void StatusAgreement_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowStatusAgreement();
            window.ShowDialog();
            dgStatusAgreement.ItemsSource = StatusAgreement.GetList();
        }

        void StatusAgreement_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var statusAgreement = dgStatusAgreement.SelectedItem as StatusAgreement;
            if (statusAgreement != null)
            {
                var window = new WindowStatusAgreement(statusAgreement);
                window.ShowDialog();
                dgStatusAgreement.ItemsSource = StatusAgreement.GetList();
            }
        }

        void StatusAgreement_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var territory = dgStatusAgreement.SelectedItem as StatusAgreement;
            if (territory != null)
            {
                var dialog = MessageBox.Show("Удалить данные?", "Необходимо подтвердить", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (dialog == MessageBoxResult.Yes)
                {
                    StatusAgreement.Delete(territory);
                    dgStatusAgreement.ItemsSource = StatusAgreement.GetList();
                }
            }
        }

        void TypeAgreement_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowTypeAgreement();
            window.ShowDialog();
            dgTypeAgreement.ItemsSource = TypeAgreement.GetList();
        }

        void TypeAgreement_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var typeAgreement = dgTypeAgreement.SelectedItem as TypeAgreement;
            if (typeAgreement != null)
            {
                var window = new WindowTypeAgreement(typeAgreement);
                window.ShowDialog();
                dgTypeAgreement.ItemsSource = TypeAgreement.GetList();
            }
        }

        void TypeAgreement_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var typeAgreement = dgTypeAgreement.SelectedItem as TypeAgreement;
            if (typeAgreement != null)
            {
                var dialog = MessageBox.Show("Удалить данные?", "Необходимо подтвердить", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (dialog == MessageBoxResult.Yes)
                {
                    TypeAgreement.Delete(typeAgreement);
                    dgTypeAgreement.ItemsSource = TypeAgreement.GetList();
                }
            }
        }

    }
}
