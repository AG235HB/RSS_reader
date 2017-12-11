using System;
using System.Data.Entity;
using System.IO;
using System.Windows;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.Json;
//using System.Collections.Generic;
using Newtonsoft.Json;

namespace RSS_reader
{
    class FeedSettings
    {
        public FeedItem[] Items { get; set; }
    }
    class FeedItem
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

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.Posts.Load();
            this.DataContext = db.Posts.Local.ToBindingList();

            FeedSettings settings = new FeedSettings();
            settings.Items = new FeedItem[2];
            settings.Items[0] = new FeedItem("UNO", "uno");
            settings.Items[1] = new FeedItem("DOS", "dos");
            using (FileStream fs = new FileStream("feedsettings.json", FileMode.OpenOrCreate))
            {
                string serialized = JsonConvert.SerializeObject(settings);
                //fs.
                MessageBox.Show(serialized);
            }

            using (FileStream fs = new FileStream("feedsettings.json", FileMode.Open))
            {
                byte[] bArray = new byte[fs.Length];
                fs.Read(bArray, 0, bArray.Length);
                string tmp = System.Text.Encoding.Default.GetString(bArray);
                FeedSettings fSettings = JsonConvert.DeserializeObject<FeedSettings>(tmp);
                foreach (FeedItem fi in fSettings.Items)
                    MessageBox.Show("Name: " + fi._name + " Link: " + fi._link);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(URL_textBox.Text))
                {
                    currentFeed = new RssFeed(URL_textBox.Text);
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
                    else MessageBox.Show("Feed is empty.");
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void postList_MouseDoubleClick_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //MessageBox.Show("CLICK");
            Post _post = postList.SelectedItem as Post;
            PostWindow _pWindow = new PostWindow(_post);
            _pWindow.ShowDialog();
        }
    }
}
