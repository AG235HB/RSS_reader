using System;
using System.Collections;
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

namespace RSS_reader
{
    /// <summary>
    /// Логика взаимодействия для PostWindow.xaml
    /// </summary>
    public partial class PostWindow : Window
    {
        public Post _post { get; private set; }
        Hashtable _data = new Hashtable();

        public PostWindow(Post post)
        {
            InitializeComponent();
            this.DataContext = post;
            _post = post;

            //RichTextBox rtBox0 = new RichTextBox();
            //rtBox0.AppendText(_post.Description);
            //Image img = Image.
            //rtBox0.AppendText
            ////tBox0.Width = this.Width;

            //tBox0. = _post.Description;
            //TextBlock tBox1 = new TextBlock();
            //tBox1.Text = "dos";
            //TextBlock tBox2 = new TextBlock();
            //tBox2.Text = "tres";
            //STK_panel.Children.Add(tBox0);
            //STK_panel.Children.Add(tBox1);
            //STK_panel.Children.Add(tBox2);
        }
    }
}
