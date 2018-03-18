using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;
using System.IO;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using System.Threading;
using System.Configuration;
using Tweetinvi.Controllers.Search;
using Tweetinvi.Core.Helpers;
using Tweetinvi.Streaming;
using System.Diagnostics;
using Tweetinvi.Models.Entities;
using Tweetinvi.Models.DTO;
using SocialNetworkConnection;
using Microsoft.VisualBasic;

namespace WebScrapperView
{
    public partial class Main : Form
    {
        private ISocialNetwork facebook;
        private ISocialNetwork twitter;
        private object socialSender;
        private int socialOption;

        public Main()
        {
            InitializeComponent();
            InitializeCredentials();
            //InitializeStreams();

        }

        //private void InitializeStreams()
        //{
        //    streamTweets = new List<IPublication>();
        //    stream = Tweetinvi.Stream.CreateFilteredStream();
        //    ThreadStart processStream = ThreadStream();
        //    threadStream = new Thread(processStream);

        //}

        //public ThreadStart ThreadStream()
        //{
        //    return () => { ThreadListenToStream(); };
        //}

        //public void ThreadListenToStream()
        //{
        //    UpdateTweetCount update = new UpdateTweetCount(UpdateLabelTweetCount);
        //    stream.MatchingTweetReceived += (sender, arguments) =>
        //    {
        //        if (streamTweets.Count <= 1000)
        //        {
        //            streamTweets.Add(arguments.Tweet);
        //            this.Invoke(update, streamIndex);
        //            Thread.Sleep(1000);
        //        }
        //        else
        //        {
        //            Thread.Sleep(100000);
        //        }


        //    };
        //    stream.StartStreamMatchingAllConditions();



        //}

        public delegate void UpdateTweetCount(int count);

        //public void UpdateLabelTweetCount(int count)
        //{
        //    RefreshStreamTweet(count);
        //}

        private void InitializeCredentials()
        {
            string accessFB = Microsoft.VisualBasic.Interaction.InputBox("Ingrese token para facebook");
            facebook = new FacebookConnection.Facebook(accessFB);

            string conk = "3vs8cBTP4ON4xwEZsS6Yvl9xG";
            string conS = "WrGPZdyLy4naOir1RawS1nRc9AjNASNSmFQEtgorlAl3vvCnMh";
            string tk = "974033487266271233-UPAOdI0rPS1TjK5FR5VJMJsD4dBselw";
            string tks = "n0rfufLN4hqgzJ0OimJvM5wYaykQ2wmAyHAjUOoDuNWOc";

            twitter = new TwitterConnection.Twitter(conk,conS,tk,tks);
            ValidateAuthConnection(conk, conS, tk, tks);


        }

        private void ValidateAuthConnection(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
        }

        private void ValidateAuthConnection(object consumerKey, object consumerSecret, object accessToken, object accessTokenSecret)
        {
            throw new NotImplementedException();
        }

        //public void AddTrack(string track)
        //{
        //    if (!String.IsNullOrEmpty(track))
        //    {
        //        if (!threadStream.IsAlive)
        //        {
        //            cbTracks.Items.Add(track);
        //            stream.AddTrack(track);
        //        }
        //        else
        //        {
        //            StopListenToTwitter();
        //            AddTrack(track);
        //            StartListehToTwitter();
        //        }

        //    }
        //}

        //public void RemoveTrack(string track)
        //{
        //    if (!String.IsNullOrEmpty(track))
        //    {
        //        if (!threadStream.IsAlive)
        //        {
        //            cbTracks.Items.Remove(track);
        //            cbTracks.Text = "";
        //            stream.RemoveTrack(track);
        //        }
        //        else
        //        {
        //            StopListenToTwitter();
        //            RemoveTrack(track);
        //            StartListehToTwitter();
        //        }
        //    }
        //}

        //public void StartListehToTwitter()
        //{

        //    if (!threadStream.IsAlive)
        //    {
        //        ThreadStart processStream = ThreadStream();
        //        threadStream = new Thread(processStream);
        //        threadStream.Start();
        //    }

        //}

        private void StopListenToTwitter()
        {

            try
            {
                stream.StopStream();
                threadStream.Abort();
            }
            catch (Exception e)
            {
                MessageBox.Show("Se detuvo el stream en hilo: " + e.Source);
            }
        }

        //private void RefreshStreamTweet(int index)
        //{
        //    streamIndex = index;
        //    if (streamIndex < streamTweets.Count)
        //    {
        //        ITweet tweet = streamTweets.ElementAt(streamIndex);
        //        if (tweet != null)
        //        {
        //            StreamBoxChange(tweet);
        //        }
        //    }


        //}


        public void StreamBoxChange(ITweet tweet)
        {
            string tweetUser = tweet.CreatedBy != null ? tweet.CreatedBy.Name : "Unknown Author";
            string tweetText = tweet.FullText;
            string tweetPlace = tweet.Place != null ? tweet.Place.FullName : "Unknown Place";
            string retweetCount = tweet.RetweetCount + "";

            int length = tweet.CalculateLength(true);
            lbCountCharSTweet.Text = "Caracteres: " + length;
            lbTweetsStream.Text = "Tweet:" + (streamIndex + 1) + " - " + streamTweets.Count;
            tbStream.Text = "Usuario: " + tweetUser + "\r\n" + tweetText + "\r\n" + "Lugar: " + tweetPlace + "\r\n" +
                "\r\n" + "Retweets: " + retweetCount + "\r\n" + tweet.Id + "\r\n" + tweet.IdStr + "\r\n";

        }

        public void Search(object sender,string query, int maximum)
        {
            IList<string> keywords = new List<string>
            {
                query
            };

            IQueryConfiguration searchParameter = new QueryConfiguration()
            {
                MaxPublicationCount = maximum,
                Keywords = keywords,
                SinceDate = new DateTime(2018, 03, 12),
                UntilDate = new DateTime(2018, 03, 16),
            };

            IList<IQueryConfiguration> queries = new List<IQueryConfiguration>
            {
                searchParameter
               
            };


            if (searchParameter == null)
            {
                MessageBox.Show("configuration == Null");
            }


            IList<IPublication> result = ((ISocialNetwork)sender).Search(queries);
         

            UpdateTextBoxTweets delegateMethod = new UpdateTextBoxTweets(UpdateTweets);
            this.Invoke(delegateMethod, result);

        }

        public delegate void UpdateTextBoxTweets(IList<IPublication> tweets);

        private void UpdateTweets(IList<IPublication> tweets)
        {
            if (tweets != null && tweets.Count() > 0)
            {
                currentTweets = tweets;
                lbTotalTweets.Text = "Tweet: 1 - " + currentTweets.ToArray().Length;
                IPublication currentTweet = currentTweets.ElementAt(index = 0);
                UpdateCurrentTweet(currentTweet);
            }
            else
            {
                MessageBox.Show("No se encontraron Tweets");
            }
        }

        private void UpdateCurrentTweet(IPublication publication)
        {
            string tweetUser = publication.WroteBy ?? "Unknown Author";
            string tweetText = publication.Message;
            string tweetPlace = "Colombia";
           
            lbCharacterCount.Text = "Caracteres: " + tweetText.Length;
            tbTweet.Text = "Usuario: " + tweetUser + "\r\n" + tweetText + "\r\n" + "Lugar: " + tweetPlace + "\r\n";
            lbTotalTweets.Text = "Publication: " + (index + 1) + " - " + currentTweets.ToArray().Length;

        }

        public void PublishTweet(string toTweet)
        {
            var tweet = Tweet.PublishTweet(toTweet);
        }

        private string Decrypt(string encryptString)
        {
            byte[] encrypted = Convert.FromBase64String(encryptString);
            string decryptString = Encoding.Unicode.GetString(encrypted);
            return decryptString.Trim();
        }

        private void BtSearch_Click(object sender, EventArgs e)
        {

            int totalTweets = DEFAULT_TWEETS_COUNT;
            try
            {
                totalTweets = Convert.ToInt32(tbNums.Value);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
            Thread threadSearch = new Thread(ThreadSearchTweets(socialSender,totalTweets));
            threadSearch.Start();
        }

        public ThreadStart ThreadSearchTweets(object sender,int maximumTweets)
        {
            return () => { SearchTweets(sender,maximumTweets); };
        }
        public ThreadStart ThreadSearchTweets(object sender, string query, int maximum)
        {
            return () => { Search(sender, query, maximum); };
        }

        internal void SearchTweets(object sender, int maximumTweets)
        {

            string query = tbSearch.Text;
            if (String.IsNullOrEmpty(query))
            {
                tooltip.Show("Primero digite una palabra clave", tbSearch);
            }
            else
            {
                Thread threadSearch = new Thread(ThreadSearchTweets(sender, query, maximumTweets));
                threadSearch.Start();
                int i = 1;
                UpdateLoadLabel delegateMethod = new UpdateLoadLabel(ChangeValueLoadLabel);
                while (threadSearch.IsAlive)
                {
                    this.Invoke(delegateMethod, i);
                    ++i;
                    Thread.Sleep(500);
                    i = i > 3 ? 0 : i;

                }
            }
        }

        public delegate void UpdateLoadLabel(int load);

        internal void ChangeValueLoadLabel(int load)
        {

            lock (this)
            {
                switch (load)
                {
                    case 1:
                        lbLoadTweets.Text = "Cargando.";
                        break;

                    case 2:
                        lbLoadTweets.Text = "Cargando..";
                        break;

                    case 3:
                        lbLoadTweets.Text = "Cargando...";
                        break;
                }
            }
        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            if (index + 1 < currentTweets.ToArray().Length)
            {
                ++index;

                IPublication currentTweet = currentTweets.ElementAt(index);
                UpdateCurrentTweet(currentTweet);
            }
            else
            {
                tooltip.Show("Esta en el ultimo tweet", btNext);
            }

        }

        //private void BtNextStream_Click(object sender, EventArgs e)
        //{
        //    if (streamIndex + 1 < streamTweets.ToArray().Length)
        //    {
        //        ++streamIndex;

        //        UpdateLabelTweetCount(streamIndex);

        //    }
        //    else
        //    {
        //        tooltip.Show("Esta en el ultimo tweet", btNextStream);
        //    }
        //}

        //private void BtBackStream_Click(object sender, EventArgs e)
        //{
        //    if (streamIndex - 1 >= 0)
        //    {
        //        --streamIndex;

        //        UpdateLabelTweetCount(streamIndex);

        //    }
        //    else
        //    {
        //        tooltip.Show("Esta en el primer tweet", btBackStream);
        //    }
        //}

        private void BtBack_Click(object sender, EventArgs e)
        {
            if (index - 1 >= 0)
            {
                --index;

                IPublication currentTweet = currentTweets.ElementAt(index);
                UpdateCurrentTweet(currentTweet);

            }
            else
            {
                tooltip.Show("Esta en el primer tweet", btBack);
            }

        }

        private void RdbCheckedChanged(object sender, EventArgs e)
        {
            if(sender == rdbFacebook)
            {
                socialSender = facebook;

            }
            else
            {
                socialSender = twitter;

            }
        }

       

        //private void BtStream_Click(object sender, EventArgs e)
        //{
        //    string track = tbTrack.Text;
        //    if (!String.IsNullOrEmpty(track))
        //    {
        //        AddTrack(track);

        //    }
        //}

        //private void BtRemoveTrack_Click(object sender, EventArgs e)
        //{
        //    if (cbTracks.SelectedItem != null)
        //    {

        //        string track = cbTracks.SelectedItem.ToString();
        //        RemoveTrack(track);
        //    }
        //}


        //private void ChbOnline_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chbOnline.Checked)
        //    {
        //        StartListehToTwitter();
        //    }
        //    else if (!chbOnline.Checked)
        //    {
        //        StopListenToTwitter();

        //    }
        //}
    }
}