using System;
using System.Data.Entity;
using System.Windows;

namespace RSS_reader
{
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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(URL_textBox.Text))
                {
                    //listView.Items.Clear();
                    currentFeed = new RssFeed(URL_textBox.Text);
                    if (currentFeed.items.Count > 0)
                        foreach (RssItem feedItem in currentFeed.items)
                        {
                            //ListViewItem lvItem = new ListViewItem();
                            //lvItem.Name = feedItem.title.ToString();
                            //listView.Items.Add(lvItem);

                            Post _post = new Post();
                            _post.Title = feedItem.title;
                            _post.Description = feedItem.description;
                            _post.Link = feedItem.link;

                            db.Posts.Add(_post);
                            db.SaveChanges();
                            //postList.Items.Add(_post);
                        }
                    else MessageBox.Show("Feed is empty.");
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
