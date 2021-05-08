using Microsoft.Win32;
using SocialNetWork.Model;
using SocialNetWork.Repository;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SocialNetWork.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRepository _repository;
        private BitmapImage _image;
        public object Bitmap { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Users addedUser = new Users
            {
                Name = name.Text,
                Password = password.Password,
                Surname = surname.Text,
                Birthday = birth.SelectedDate.Value,
                Email = mail.Text
            };
            if (_image != null)
            {
                MemoryStream ms = new MemoryStream();
                JpegBitmapEncoder bitmapEncoder = new JpegBitmapEncoder();
                bitmapEncoder.Frames.Add(BitmapFrame.Create(_image));
                bitmapEncoder.Save(ms);
                addedUser.Images = new Model.Images()
                {
                    Date_added = DateTime.Now,
                    Image = ms.ToArray()
                };
                
            }
            _repository.AddUser(addedUser);
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            _repository = new RepositoryIm(new Entities());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG|*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                _image = new BitmapImage(new Uri(openFileDialog.FileName));
            }
       
        }
    }
}
