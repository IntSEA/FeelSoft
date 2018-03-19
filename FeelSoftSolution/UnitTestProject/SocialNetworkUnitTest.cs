using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetworkConnection;
using FacebookConnection;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;

namespace UnitTestProject
{
    [TestClass]
    public class SocialNetworkUnitTest
    {
        private IPublication publication;
        //Esto se es una variable de tipo Twitter dado que no esta implementada aun la pongo como facebook para que no me lance error, cuando ya este implementada hay que cambiarla a tipo Twitter
        private ISocialNetwork facebook;
        //Lo mismo aca, hay que cambiarlo por el analogo pero en twitter que debe heredar de queryconfiguration
        private IQueryConfiguration configuration;
        private const string key = "EAACEdEose0cBAPzjHb7jfahDP0ZB7TaPer2qOC4os4aflj9cjF72tuZBtuz81zIMLwUUYDAOscuZCw4V8LX4pNG5wMdfkRnSdRddvY7xx2iT2ZBIKEV6TeqPub8ZBjfsfYAGmPi4AVzm8V41rgLK4uBN6vupbOeWaPte7bItmCL5xwjFlerZBgFdB9RL3UBEfwSmHybquRk5ZA3b8LZCEQPJ";
        //Stage created for Fajardo
        private void SetupStage1()
        {
            facebook = new Facebook(key);

            IList<string> words = new List<String>()
            {
                "SergioFajardoV",
            };

            configuration = new QueryConfiguration()
            {
                Keywords = words,
                Location = Locations.Colombia,
                Language = Languages.Spanish,
                Filter = Filters.None,
                SearchType = SearchTypes.Mixed,
                SinceDate = new DateTime(2018, 03, 12),
                UntilDate = new DateTime(2018, 03, 15),
                MaxPublicationCount = 10


            };

            publication = facebook.Search(configuration)[0];

        }

        //Stage created for Petro
        private void SetupStage2()
        {
            facebook = new Facebook(key);

            IList<string> words = new List<String>()
            {
                "GustavoPetroUrrego",
            };

            configuration = new QueryConfiguration()
            {
                Keywords = words,
                Location = Locations.Colombia,
                Language = Languages.Spanish,
                Filter = Filters.None,
                SearchType = SearchTypes.Mixed,
                SinceDate = new DateTime(2018, 03, 12),
                UntilDate = new DateTime(2018, 03, 15),
                MaxPublicationCount = 10


            };

            publication = facebook.Search(configuration)[0];
        }

        //for project facebook's perfil
        public void SetupStage3()
        {
            facebook = new Facebook(key);

            IList<string> words = new List<String>()
            {
                "me",
            };

            configuration = new QueryConfiguration()
            {
                Keywords = words,
                Location = Locations.Colombia,
                Language = Languages.Spanish,
                Filter = Filters.None,
                SearchType = SearchTypes.Mixed,
                SinceDate = new DateTime(2018, 03, 12),
                UntilDate = new DateTime(2018, 03, 16),
                MaxPublicationCount = 10


            };

            publication = facebook.Search(configuration)[0];
        }

        [TestMethod]
        public void TestKeywordFajardo()
        {
            SetupStage1();
            String wroteBy = publication.WroteBy;
            Assert.IsTrue(wroteBy.Contains("Fajardo12415375791"));
        }

        [TestMethod]
        public void TestKeywordPetro()
        {
            SetupStage2();
            String wroteBy = publication.WroteBy;
            Assert.IsTrue(wroteBy.Contains("Gustavo Petro95972290770"));
        }

        [TestMethod]
        public void TestKeywordFeelSoft()
        {
            SetupStage3();
            String wroteBy = publication.WroteBy;
            Assert.IsTrue(wroteBy.Contains("FeelSoft InteiProject116534032517988"));
        }

        [TestMethod]
        public void TestLocationFajardo()
        {
            SetupStage1();
            if (publication.Location != Locations.Colombia)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestLocationPetro()
        {
            SetupStage2();
            if (publication.Location != Locations.Colombia)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestLocationFeelSoft()
        {
            SetupStage3();
            if (publication.Location != Locations.Colombia)
            {
                Assert.Fail();
            }
        }



        [TestMethod]
        public void TestLanguageFajardo()
        {
            SetupStage1();
            if (publication.Language != Languages.Spanish)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestLanguagePetro()
        {
            SetupStage1();
            if (publication.Language != Languages.Spanish)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestLanguageFeelSoft()
        {
            SetupStage1();
            if (publication.Language != Languages.Spanish)
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void TestSinceDateFajardo()
        {
            SetupStage1();
            DateTime sinceDate = new DateTime(2018, 03, 11);

            int num = DateTime.Compare(publication.CreateDate, sinceDate);


            if (num < 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestSinceDatePetro()
        {
            SetupStage2();
            DateTime sinceDate = new DateTime(2018, 03, 11);

            int num = DateTime.Compare(publication.CreateDate, sinceDate);


            if (num < 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestSinceDateFeelSoft()
        {
            SetupStage3();
            DateTime sinceDate = new DateTime(2018, 03, 11);

            int num = DateTime.Compare(publication.CreateDate, sinceDate);


            if (num < 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestUntilDateFajardo()
        {
            SetupStage1();
            DateTime untilDate = new DateTime(2018, 03, 15);
            int num2 = DateTime.Compare(publication.CreateDate, untilDate);
            if (num2 > 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestUntilDatePetro()
        {
            SetupStage2();
            DateTime untilDate = new DateTime(2018, 03, 15);
            int num2 = DateTime.Compare(publication.CreateDate, untilDate);
            if (num2 > 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestUntilDateFeelSoft()
        {
            SetupStage3();
            DateTime untilDate = new DateTime(2018, 03, 16);
            int num2 = DateTime.Compare(publication.CreateDate, untilDate);
            if (num2 > 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestFoundPublicationsFeelSoft()
        {
            SetupStage3();
            Assert.IsTrue(publication.Message.Equals("Test graph FB"));


            Assert.IsTrue(publication.CreateDate.CompareTo(new DateTime(2018, 03, 16)) <= 0);

            Assert.IsTrue(publication.WroteBy.Equals("FeelSoft InteiProject116534032517988"));
        }
    }
}

