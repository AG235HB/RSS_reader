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

namespace RSS_reader
{
    /// <summary>
    /// Логика взаимодействия для FeedWindow.xaml
    /// </summary>
    public partial class FeedWindow : Window
    {
        FeedSettings fSettings = new FeedSettings();
        public FeedWindow(ref FeedSettings settings)
        {
            InitializeComponent();

            fSettings = settings;
            FillList();
        }

        private void FillList()
        {
            foreach (FeedItem fi in fSettings.Items)
            {
                listView.Items.Add(fi._name);
            }
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            label0.IsEnabled = true;
            label1.IsEnabled = true;
            tb_FeedLink.IsEnabled = true;
            tb_FeedName.IsEnabled = true;
            btn_AddFeed.IsEnabled = true;
            btn_Abort.IsEnabled = true;
        }

        private void btn_AddFeed_Click(object sender, RoutedEventArgs e)
        {
            FeedItem fi = new FeedItem(tb_FeedName.Text, tb_FeedLink.Text);
            fSettings.Items.Add(fi);
            listView.Items.Clear();
            FillList();

            label0.IsEnabled = false;
            label1.IsEnabled = false;
            tb_FeedLink.IsEnabled = false;
            tb_FeedName.IsEnabled = false;
            btn_AddFeed.IsEnabled = false;
            btn_Abort.IsEnabled = false;
        }

        private void btn_Abort_Click(object sender, RoutedEventArgs e)
        {
            label0.IsEnabled = false;
            label1.IsEnabled = false;
            tb_FeedLink.Text = String.Empty;
            tb_FeedName.Text = String.Empty;
            tb_FeedLink.IsEnabled = false;
            tb_FeedName.IsEnabled = false;
            btn_AddFeed.IsEnabled = false;
            btn_Abort.IsEnabled = false;
        }

        private void btn_Del_Click(object sender, RoutedEventArgs e)
        {
            fSettings.Items.Remove(fSettings.Items[listView.SelectedIndex]);
            listView.Items.Clear();
            FillList();
        }
    }
}
