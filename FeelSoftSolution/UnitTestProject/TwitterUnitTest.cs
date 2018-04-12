using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetworkConnection;
using TwitterConnection;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;

namespace UnitTestProject
{
    [TestClass]
    public class TwitterUnitTest
    {
        private IPublication publication;

        private ISocialNetwork twitter;

        private IQueryConfiguration configuration;

        private void SetupStage1()
        {
            twitter = new Twitter();
            string consumerKey = System.Configuration.ConfigurationManager.AppSettings["consumerKey"];
            string consumerSecret = System.Configuration.ConfigurationManager.AppSettings["consumerSecret"]; ;
            string accessToken = System.Configuration.ConfigurationManager.AppSettings["accessToken"];
            string secretToken = System.Configuration.ConfigurationManager.AppSettings["secretToken"];
            Tweetinvi.Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, secretToken);

            IList<string> words = new List<String>()
            {
                "guerrillero",
            };

            configuration = new QueryConfiguration()
            {
                Keywords = words,
                Location = Locations.Colombia,
                Language = Languages.Spanish,
                Filter = Filters.None,
                SearchType = SearchTypes.Mixed,
                SinceDate = new DateTime(2018, 01, 1),
                UntilDate = DateTime.Now.AddDays(1),
                MaxPublicationCount = 100
            };

            IList<IPublication> found = twitter.Search(configuration);
            if (found.Count > 0)
            {
                publication = found[0];
            }

        }

        //Stage created for Petro
        private void SetupStage2()
        {
            twitter = new Twitter();
            string consumerKey = System.Configuration.ConfigurationManager.AppSettings["consumerKey"];
            string consumerSecret = System.Configuration.ConfigurationManager.AppSettings["consumerSecret"]; ;
            string accessToken = System.Configuration.ConfigurationManager.AppSettings["accessToken"];
            string secretToken = System.Configuration.ConfigurationManager.AppSettings["secretToken"];
            Tweetinvi.Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, secretToken);
            IList<string> words = new List<String>()
            {
                "tibio",
            };

            configuration = new QueryConfiguration()
            {
                Keywords = words,
                Location = Locations.Colombia,
                Language = Languages.Spanish,
                Filter = Filters.None,
                SearchType = SearchTypes.Mixed,
                SinceDate = new DateTime(2018, 01, 01),
                UntilDate = DateTime.Now.AddDays(1),
                MaxPublicationCount = 100


            };

            IList<IPublication> found = twitter.Search(configuration);
            if (found.Count > 0)
            {
                publication = found[0];
            }
        }


        public void SetupStage3()
        {
            twitter = new Twitter();
            string consumerKey = System.Configuration.ConfigurationManager.AppSettings["consumerKey"];
            string consumerSecret = System.Configuration.ConfigurationManager.AppSettings["consumerSecret"]; ;
            string accessToken = System.Configuration.ConfigurationManager.AppSettings["accessToken"];
            string secretToken = System.Configuration.ConfigurationManager.AppSettings["secretToken"];
            Tweetinvi.Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, secretToken);

            IList<string> words = new List<String>()
            {
                "Petro",
            };

            configuration = new QueryConfiguration()
            {
                Keywords = words,
                Location = Locations.Colombia,
                Language = Languages.Spanish,
                Filter = Filters.None,
                SearchType = SearchTypes.Mixed,
                SinceDate = new DateTime(2018, 01, 01),
                UntilDate = DateTime.Now.AddDays(1),
                MaxPublicationCount = 10


            };

            IList<IPublication> found = twitter.Search(configuration);
            if (found.Count > 0)
            {
                publication = found[0];
            }
        }

        [TestMethod]
        public void TestKeyWordGuerrillero()
        {
            SetupStage1();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                String wroteBy = publication.WroteBy;
                Assert.IsTrue(!String.IsNullOrEmpty(wroteBy));
            }
        }

        [TestMethod]
        public void TestKeywordTibio()
        {
            SetupStage2();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                String wroteBy = publication.WroteBy;
                Assert.IsTrue(!String.IsNullOrEmpty(wroteBy));
            }
        }

        [TestMethod]
        public void TestKeywordPetro()
        {
            SetupStage3();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                String wroteBy = publication.WroteBy;
                Assert.IsTrue(!String.IsNullOrEmpty(wroteBy));
            }
           
        }

        [TestMethod]
        public void TestLocationGuerrillero()
        {
            SetupStage1();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else if (publication.Location != Locations.Colombia)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestLocationTibio()
        {
            SetupStage2();
            if(publication == null)
            {
                Assert.IsTrue(true);
            }
            else if (publication.Location != Locations.Colombia)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestLocationPetro()
        {
            SetupStage3();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else if (publication.Location != Locations.Colombia)
            {
                Assert.Fail();
            }
        }



        [TestMethod]
        public void TestLanguageGuerrillero()
        {
            SetupStage1();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
           else if (publication.Language != Languages.Spanish)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestLanguageTibio()
        {
            SetupStage1();
            if(publication == null)
            {
                Assert.IsTrue(true);
            }
            else if (publication.Language != Languages.Spanish)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestLanguagePetro()
        {
            SetupStage1();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
           else if (publication.Language != Languages.Spanish)
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void TestSinceDateGuerrillero()
        {
            SetupStage1();
            DateTime sinceDate = new DateTime(2018,01,01);

            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                int num = DateTime.Compare(publication.CreateDate, sinceDate);


                if (num < 0)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestSinceDateTibio()
        {
            SetupStage2();

            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                DateTime sinceDate = new DateTime(2018, 01, 01);

                int num = DateTime.Compare(publication.CreateDate, sinceDate);


                if (num < 0)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestSinceDatePetro()
        {
            SetupStage3();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                DateTime sinceDate = new DateTime(2018, 01, 01);

                int num = DateTime.Compare(publication.CreateDate, sinceDate);


                if (num < 0)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestUntilDateGuerrillero()
        {
            SetupStage1();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                DateTime untilDate = DateTime.Now.AddDays(1);
                int num2 = DateTime.Compare(publication.CreateDate, untilDate);
                if (num2 > 0)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestUntilDateTibio()
        {
            SetupStage2();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                DateTime untilDate = DateTime.Now.AddDays(1);
                int num2 = DateTime.Compare(publication.CreateDate, untilDate);
                if (num2 > 0)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestUntilDatePetro()
        {
            SetupStage3();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                DateTime untilDate = DateTime.Now.AddDays(1);
                int num2 = DateTime.Compare(publication.CreateDate, untilDate);
                if (num2 > 0)
                {
                    Assert.Fail();
                }
            }
        }


    }
}

