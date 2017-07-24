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
using PlaceholderTextBox;
using Phonebook.Models;
using System.Xml.Serialization;
using System.IO;
using Phonebook.ServiceLayer.Interface;
using Phonebook.ServiceLayer;
using Phonebook.BL;
namespace Phonebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Contacts c { get; set; }
        public Person p { get; set; }
        IXMLhelper helper;
        ISearch search;
        //main
        public MainWindow()
        {
            InitializeComponent();
            search = new Search();
            helper = new XMLhelper();
            //read from file
            c = helper.ReadXml();
            //side bar item source
            list.ItemsSource = c.Persons;
            //main bar item source
            p = c.Persons[0];
            this.DataContext = this;
        }
        //navigate
        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedIndex > -1)
            {
                //change item source of main
                p = c.Persons[list.SelectedIndex];
                //required to update the binding
                BindingExpression bexp = BindingOperations.GetBindingExpression(Contents, ContentControl.ContentProperty);
                bexp.UpdateTarget();
            }
           

           
        }
        //save
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            helper.WriteXml(c);
            list.ItemsSource = c.Persons;
            list.Items.Refresh();
            this.DataContext = this;
        }
        //add contact
        private void Add_contact_Click(object sender, RoutedEventArgs e)
        {
            //add person template
            c.Persons.Add(new Person() {
                Name =new Name { Firstname="new" },
                Phone = new Phone { Type= PhoneType.home},
                Email = new Email { Type=AddressType.home},
                Address = new Address { Type=AddressType.home},
                
            });
            list.ItemsSource = c.Persons;
            list.Items.Refresh();
            list.SelectedIndex = list.Items.Count - 1;
            this.DataContext = this;

            
            // bexp.UpdateTarget();
        }
        //search
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (seachBox.Text == "")
            {
             
                searchlabel.Visibility = Visibility.Visible;
                helper = new XMLhelper();
                c = helper.ReadXml();
                list.ItemsSource = c.Persons;
                list.Items.Refresh();
                this.DataContext = this;

            }
            
            else
            {
                list.ItemsSource= search.Find(seachBox.Text, c).Persons;
                list.Items.Refresh();
                this.DataContext = this;
                searchlabel.Visibility = Visibility.Hidden;
            }
        }

 
    }
}
