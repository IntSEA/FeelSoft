using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Tweetinvi.Models;
using Tweetinvi.Streaming;
using SocialNetworkConnection;

namespace WebScrapperView
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.btSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.tbTweet = new System.Windows.Forms.TextBox();
            this.btBack = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.lbKeyword = new System.Windows.Forms.Label();
            this.lbCharacterCount = new System.Windows.Forms.Label();
            this.lbLoadTweets = new System.Windows.Forms.Label();
            this.lbTotalTweets = new System.Windows.Forms.Label();
            this.tbNums = new System.Windows.Forms.NumericUpDown();
            this.lbTweets = new System.Windows.Forms.Label();
            this.tbStream = new System.Windows.Forms.TextBox();
            this.btAddTrack = new System.Windows.Forms.Button();
            this.tbTrack = new System.Windows.Forms.TextBox();
            this.btBackStream = new System.Windows.Forms.Button();
            this.btNextStream = new System.Windows.Forms.Button();
            this.lbTweetsStream = new System.Windows.Forms.Label();
            this.lbCountCharSTweet = new System.Windows.Forms.Label();
            this.cbTracks = new System.Windows.Forms.ComboBox();
            this.btRemoveTrack = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.chbOnline = new System.Windows.Forms.CheckBox();
            this.rdbTwitter = new System.Windows.Forms.RadioButton();
            this.rdbFacebook = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbNums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(170, 34);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 0;
            this.btSearch.Text = "Buscar";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.BtSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(25, 34);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(100, 20);
            this.tbSearch.TabIndex = 1;
            // 
            // tbTweet
            // 
            this.tbTweet.Location = new System.Drawing.Point(27, 110);
            this.tbTweet.Multiline = true;
            this.tbTweet.Name = "tbTweet";
            this.tbTweet.ReadOnly = true;
            this.tbTweet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTweet.Size = new System.Drawing.Size(220, 102);
            this.tbTweet.TabIndex = 2;
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(25, 218);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(44, 23);
            this.btBack.TabIndex = 3;
            this.btBack.Text = "<--";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.BtBack_Click);
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(75, 218);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(50, 23);
            this.btNext.TabIndex = 4;
            this.btNext.Text = "-->";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.BtNext_Click);
            // 
            // lbKeyword
            // 
            this.lbKeyword.AutoSize = true;
            this.lbKeyword.Location = new System.Drawing.Point(37, 18);
            this.lbKeyword.Name = "lbKeyword";
            this.lbKeyword.Size = new System.Drawing.Size(72, 13);
            this.lbKeyword.TabIndex = 5;
            this.lbKeyword.Text = "Palabra clave";
            // 
            // lbCharacterCount
            // 
            this.lbCharacterCount.AutoSize = true;
            this.lbCharacterCount.Location = new System.Drawing.Point(175, 94);
            this.lbCharacterCount.Name = "lbCharacterCount";
            this.lbCharacterCount.Size = new System.Drawing.Size(70, 13);
            this.lbCharacterCount.TabIndex = 6;
            this.lbCharacterCount.Text = "Caracteres: 0";
            // 
            // lbLoadTweets
            // 
            this.lbLoadTweets.AutoSize = true;
            this.lbLoadTweets.Location = new System.Drawing.Point(27, 93);
            this.lbLoadTweets.Name = "lbLoadTweets";
            this.lbLoadTweets.Size = new System.Drawing.Size(0, 13);
            this.lbLoadTweets.TabIndex = 7;
            // 
            // lbTotalTweets
            // 
            this.lbTotalTweets.AutoSize = true;
            this.lbTotalTweets.Location = new System.Drawing.Point(182, 223);
            this.lbTotalTweets.Name = "lbTotalTweets";
            this.lbTotalTweets.Size = new System.Drawing.Size(65, 13);
            this.lbTotalTweets.TabIndex = 8;
            this.lbTotalTweets.Text = "Total tweets";
            // 
            // tbNums
            // 
            this.tbNums.Location = new System.Drawing.Point(170, 68);
            this.tbNums.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.tbNums.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbNums.Name = "tbNums";
            this.tbNums.Size = new System.Drawing.Size(77, 20);
            this.tbNums.TabIndex = 9;
            this.tbNums.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbTweets
            // 
            this.lbTweets.AutoSize = true;
            this.lbTweets.Location = new System.Drawing.Point(27, 70);
            this.lbTweets.Name = "lbTweets";
            this.lbTweets.Size = new System.Drawing.Size(98, 13);
            this.lbTweets.TabIndex = 10;
            this.lbTweets.Text = "Cantidad de tweets";
            // 
            // tbStream
            // 
            this.tbStream.Location = new System.Drawing.Point(88, 91);
            this.tbStream.Multiline = true;
            this.tbStream.Name = "tbStream";
            this.tbStream.ReadOnly = true;
            this.tbStream.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStream.Size = new System.Drawing.Size(367, 131);
            this.tbStream.TabIndex = 2;
            // 
            // btAddTrack
            // 
            this.btAddTrack.Location = new System.Drawing.Point(305, 15);
            this.btAddTrack.Name = "btAddTrack";
            this.btAddTrack.Size = new System.Drawing.Size(150, 23);
            this.btAddTrack.TabIndex = 12;
            this.btAddTrack.Text = "Añadir track";
            this.btAddTrack.UseVisualStyleBackColor = true;
            // 
            // tbTrack
            // 
            this.tbTrack.Location = new System.Drawing.Point(88, 18);
            this.tbTrack.Name = "tbTrack";
            this.tbTrack.Size = new System.Drawing.Size(162, 20);
            this.tbTrack.TabIndex = 1;
            this.tbTrack.Text = "Track";
            // 
            // btBackStream
            // 
            this.btBackStream.Location = new System.Drawing.Point(88, 225);
            this.btBackStream.Name = "btBackStream";
            this.btBackStream.Size = new System.Drawing.Size(44, 23);
            this.btBackStream.TabIndex = 3;
            this.btBackStream.Text = "<--";
            this.btBackStream.UseVisualStyleBackColor = true;
            // 
            // btNextStream
            // 
            this.btNextStream.Location = new System.Drawing.Point(138, 225);
            this.btNextStream.Name = "btNextStream";
            this.btNextStream.Size = new System.Drawing.Size(50, 23);
            this.btNextStream.TabIndex = 4;
            this.btNextStream.Text = "-->";
            this.btNextStream.UseVisualStyleBackColor = true;
            // 
            // lbTweetsStream
            // 
            this.lbTweetsStream.AutoSize = true;
            this.lbTweetsStream.Location = new System.Drawing.Point(302, 230);
            this.lbTweetsStream.Name = "lbTweetsStream";
            this.lbTweetsStream.Size = new System.Drawing.Size(65, 13);
            this.lbTweetsStream.TabIndex = 8;
            this.lbTweetsStream.Text = "Total tweets";
            // 
            // lbCountCharSTweet
            // 
            this.lbCountCharSTweet.AutoSize = true;
            this.lbCountCharSTweet.Location = new System.Drawing.Point(367, 75);
            this.lbCountCharSTweet.Name = "lbCountCharSTweet";
            this.lbCountCharSTweet.Size = new System.Drawing.Size(70, 13);
            this.lbCountCharSTweet.TabIndex = 6;
            this.lbCountCharSTweet.Text = "Caracteres: 0";
            // 
            // cbTracks
            // 
            this.cbTracks.FormattingEnabled = true;
            this.cbTracks.Location = new System.Drawing.Point(88, 45);
            this.cbTracks.Name = "cbTracks";
            this.cbTracks.Size = new System.Drawing.Size(162, 21);
            this.cbTracks.TabIndex = 13;
            // 
            // btRemoveTrack
            // 
            this.btRemoveTrack.Location = new System.Drawing.Point(305, 45);
            this.btRemoveTrack.Name = "btRemoveTrack";
            this.btRemoveTrack.Size = new System.Drawing.Size(150, 23);
            this.btRemoveTrack.TabIndex = 14;
            this.btRemoveTrack.Text = "Eliminar track";
            this.btRemoveTrack.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Location = new System.Drawing.Point(34, 43);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.btSearch);
            this.splitContainer.Panel1.Controls.Add(this.tbSearch);
            this.splitContainer.Panel1.Controls.Add(this.tbTweet);
            this.splitContainer.Panel1.Controls.Add(this.btBack);
            this.splitContainer.Panel1.Controls.Add(this.btNext);
            this.splitContainer.Panel1.Controls.Add(this.lbTweets);
            this.splitContainer.Panel1.Controls.Add(this.lbKeyword);
            this.splitContainer.Panel1.Controls.Add(this.tbNums);
            this.splitContainer.Panel1.Controls.Add(this.lbCharacterCount);
            this.splitContainer.Panel1.Controls.Add(this.lbLoadTweets);
            this.splitContainer.Panel1.Controls.Add(this.lbTotalTweets);
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.chbOnline);
            this.splitContainer.Panel2.Controls.Add(this.tbTrack);
            this.splitContainer.Panel2.Controls.Add(this.btRemoveTrack);
            this.splitContainer.Panel2.Controls.Add(this.tbStream);
            this.splitContainer.Panel2.Controls.Add(this.cbTracks);
            this.splitContainer.Panel2.Controls.Add(this.btBackStream);
            this.splitContainer.Panel2.Controls.Add(this.btAddTrack);
            this.splitContainer.Panel2.Controls.Add(this.btNextStream);
            this.splitContainer.Panel2.Controls.Add(this.lbCountCharSTweet);
            this.splitContainer.Panel2.Controls.Add(this.lbTweetsStream);
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.Size = new System.Drawing.Size(856, 265);
            this.splitContainer.SplitterDistance = 362;
            this.splitContainer.TabIndex = 15;
            // 
            // chbOnline
            // 
            this.chbOnline.AutoSize = true;
            this.chbOnline.Location = new System.Drawing.Point(399, 228);
            this.chbOnline.Name = "chbOnline";
            this.chbOnline.Size = new System.Drawing.Size(56, 17);
            this.chbOnline.TabIndex = 15;
            this.chbOnline.Text = "Online";
            this.chbOnline.UseVisualStyleBackColor = true;
            // 
            // rdbTwitter
            // 
            this.rdbTwitter.AutoSize = true;
            this.rdbTwitter.Checked = true;
            this.rdbTwitter.Location = new System.Drawing.Point(334, 12);
            this.rdbTwitter.Name = "rdbTwitter";
            this.rdbTwitter.Size = new System.Drawing.Size(57, 17);
            this.rdbTwitter.TabIndex = 16;
            this.rdbTwitter.TabStop = true;
            this.rdbTwitter.Text = "Twitter";
            this.rdbTwitter.UseVisualStyleBackColor = true;
            this.rdbTwitter.CheckedChanged += new System.EventHandler(this.RdbCheckedChanged);
            // 
            // rdbFacebook
            // 
            this.rdbFacebook.AutoSize = true;
            this.rdbFacebook.Location = new System.Drawing.Point(423, 12);
            this.rdbFacebook.Name = "rdbFacebook";
            this.rdbFacebook.Size = new System.Drawing.Size(73, 17);
            this.rdbFacebook.TabIndex = 17;
            this.rdbFacebook.TabStop = true;
            this.rdbFacebook.Text = "Facebook";
            this.rdbFacebook.UseVisualStyleBackColor = true;
            this.rdbFacebook.CheckedChanged += new System.EventHandler(this.RdbCheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 345);
            this.Controls.Add(this.rdbFacebook);
            this.Controls.Add(this.rdbTwitter);
            this.Controls.Add(this.splitContainer);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.tbNums)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private const string KEY_PATH = "..//..//Resources/Keys.ser";
        private System.Windows.Forms.TextBox tbTweet;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btNext;
        public ToolTip tooltip;
        private Label lbKeyword;
        private IList<IPublication> currentTweets;
        private int index;
        private Label lbCharacterCount;
        private Label lbLoadTweets;
        private Label lbTotalTweets;
        public const int DEFAULT_TWEETS_COUNT = 100;
        private NumericUpDown tbNums;
        private Label lbTweets;
        private TextBox tbStream;
        private Button btAddTrack;
        private TextBox tbTrack;
        private List<IPublication> streamTweets;
        private IFilteredStream stream;
        private Thread threadStream;
        private Button btBackStream;
        private Button btNextStream;
        private Label lbTweetsStream;
        private Label lbCountCharSTweet;
        private int streamIndex;
        private ComboBox cbTracks;
        private Button btRemoveTrack;
        private SplitContainer splitContainer;
        private CheckBox chbOnline;
        private RadioButton rdbTwitter;
        private RadioButton rdbFacebook;
    }
}

