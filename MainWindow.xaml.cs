using System;
using System.Data.Entity;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RSS_reader
{
    public class FeedSettings
    {
        public List<FeedItem> Items { get; set; }
    }
    public class FeedItem
    {
        public string _name { get; set; }
        public string _link { get; set; }

        public FeedItem(string name, string link)
        {
            _name = name;
            _link = link;
        }
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        RssFeed currentFeed;
        public FeedSettings fSettings = new FeedSettings();

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.Posts.Load();
            this.DataContext = db.Posts.Local.ToBindingList();

            using (FileStream fs = new FileStream("feedsettings.json", FileMode.Open))
            {
                byte[] bArray = new byte[fs.Length];
                fs.Read(bArray, 0, bArray.Length);
                string tmp = System.Text.Encoding.Default.GetString(bArray);
                fSettings = JsonConvert.DeserializeObject<FeedSettings>(tmp);
                FillComboBox();
            }

            
        }

        private void FillComboBox()
        {
            foreach (FeedItem fi in fSettings.Items)
            {
                //MessageBox.Show("Name: " + fi._name + " Link: " + fi._link);
                chBox_RSS.Items.Add(fi._name);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentFeed = new RssFeed(fSettings.Items[chBox_RSS.SelectedIndex]._link);
                if (currentFeed.items.Count > 0)
                    foreach (RssItem feedItem in currentFeed.items)
                    {
                        Post _post = new Post();
                        _post.Title = feedItem.title;
                        _post.Description = feedItem.description;
                        _post.Link = feedItem.link;

                        db.Posts.Add(_post);
                        db.SaveChanges();
                    }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void postList_MouseDoubleClick_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Post _post = postList.SelectedItem as Post;
            PostWindow _pWindow = new PostWindow(_post);
            _pWindow.ShowDialog();
        }

        private void bFeedSettings_Click(object sender, RoutedEventArgs e)
        {
            FeedWindow fWindow = new FeedWindow(ref fSettings);
            fWindow.ShowDialog();
            //if (fWindow.ShowDialog() == true)
            
        }

        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            chBox_RSS.Items.Clear();
            FillComboBox();
            using (FileStream fs = new FileStream("feedsettings.json", FileMode.Truncate))
            {
                string tmp = JsonConvert.SerializeObject(fSettings);
                byte[] bArray = System.Text.Encoding.Default.GetBytes(tmp);
                fs.Write(bArray, 0, bArray.Length);
            }
        }
    }
}
