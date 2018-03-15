using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetworkConnection;
using FacebookConnection;
using System.Collections.Generic;

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

        //Stage created for Fajardo
        private void SetupStage1()
        {
            facebook = new Facebook();

            IList<string> words = new List<String>()
            {
                "Sergio Fajardo",
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
            facebook = new Facebook();

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

        [TestMethod]
        public void TestKeyword()
        {
            SetupStage1();
            String message = publication.Message;
            message.Contains("Sergio Fajardo");
            Assert.IsTrue(message.Contains("Sergio Fajardo"));
        }

        [TestMethod]
        public void TestLocation()
        {
            SetupStage1();
            if (publication.Location != Locations.Colombia)
            {
                Assert.Fail();
            }
        }
        //
        [TestMethod]
        public void TestFilter()
        {
        }

        [TestMethod]
        public void TestLanguage()
        {
            SetupStage1();
            if (publication.Language != Languages.Spanish)
            {
                Assert.Fail();
            }
        }
        //
        [TestMethod]
        public void TestSearchType()
        {
            SetupStage1();
        }

        [TestMethod]
        public void TestSinceDate()
        {
            SetupStage1();
            DateTime sinceDate = new DateTime(2018, 06, 12);

            int num = DateTime.Compare(publication.CreateDate, sinceDate);


            if (num < 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestUntilDate()
        {
            SetupStage1();
            SetupStage1();
            DateTime untilDate = new DateTime(2018, 07, 23);
            int num2 = DateTime.Compare(publication.CreateDate, untilDate);
            if (num2 > 0)
            {
                Assert.Fail();
            }
        }
    }
}

