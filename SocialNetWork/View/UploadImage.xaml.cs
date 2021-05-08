using Microsoft.Win32;
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
using System.Windows.Shapes;
using SocialNetWork.Repository;
using System.IO;
using SocialNetWork.Model;

namespace SocialNetWork.View
{
    /// <summary>
    /// Логика взаимодействия для UploadImage.xaml
    /// </summary>
    public partial class UploadImage : Window
    {
        //private IRepository _repository;
        private BitmapImage _image;
        public object Bitmap { get; private set; }

        public UploadImage()
        {
            InitializeComponent();
            var newImages = GetNewImages();
            if (newImages.Count > 0)
                ListViewImages.ItemsSource = newImages;
        }

        private List<NewImage> GetNewImages()
        {
            return new List<NewImage>()
            {
                new NewImage("Image 1", "C:/Users/Gelya/Desktop/Not_deep_learning/SocialNetWork/SocialNetWork/Images/im1.jpg"),
                new NewImage("Image 2", "C:/Users/Gelya/Desktop/Not_deep_learning/SocialNetWork/SocialNetWork/Images/im2.jpg"),
                new NewImage("Image 3", "C:/Users/Gelya/Desktop/Not_deep_learning/SocialNetWork/SocialNetWork/Images/im3.jpg"),
                new NewImage("Image 4", "C:/Users/Gelya/Desktop/Not_deep_learning/SocialNetWork/SocialNetWork/Images/im4.jpg"),
                new NewImage("Image 5", "C:/Users/Gelya/Desktop/Not_deep_learning/SocialNetWork/SocialNetWork/Images/im5.jpg"),
                new NewImage("Image 6", "C:/Users/Gelya/Desktop/Not_deep_learning/SocialNetWork/SocialNetWork/Images/im6.jpg"),
                new NewImage("Image 7", "C:/Users/Gelya/Desktop/Not_deep_learning/SocialNetWork/SocialNetWork/Images/im7.jpg"),
            };
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG|*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                _image = new BitmapImage(new Uri(openFileDialog.FileName));
                UploadedImage.Source = _image;
            }

            if (_image != null)
            {
                //Users currentUser = IRepository.GetUsersById();
                MemoryStream ms = new MemoryStream();
                JpegBitmapEncoder bitmapEncoder = new JpegBitmapEncoder();
                bitmapEncoder.Frames.Add(BitmapFrame.Create(_image));
                bitmapEncoder.Save(ms);
                /*currentUser.Images = new Model.Images()
                {
                    Date_added = DateTime.Now,
                    Image = ms.ToArray()
                };*/

            }
        }
    }
}
