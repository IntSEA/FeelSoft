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
    public class FacebookUnitTest
    {
        private IPublication publication;
        
        private ISocialNetwork facebook;
        
        private IQueryConfiguration configuration;
        //CREDENTIAL

        //Stage created for Fajardo
        

        //Stage created for Fajardo
        private void SetupStage1()
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
                MaxPublicationCount = 100

            };

            publication = facebook.Search(configuration)[0];

        }

        //Stage created for Petro
        private void SetupStage2()
        {
            facebook = new Facebook();

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
                MaxPublicationCount = 200


            };

            publication = facebook.Search(configuration)[0];
        }

        //for project facebook's group
        public void SetupStage3()
        {
            facebook = new Facebook();

            IList<string> words = new List<String>()
            {
                "AlvaroUribeVel",
            };

            configuration = new QueryConfiguration()
            {
                Keywords = words,
                Location = Locations.Colombia,
                Language = Languages.Spanish,
                Filter = Filters.None,
                SearchType = SearchTypes.Mixed,
                SinceDate = new DateTime(2018, 03, 18),
                UntilDate = new DateTime(2018, 03, 21),
                MaxPublicationCount = 200


            };

            publication = facebook.Search(configuration)[0];
        }

        // Test facebook page RealidadPoliticaColombiana
        private void SetupStage4()
        {
            facebook = new Facebook();

            IList<string> words = new List<String>()
            {
                "gallup",
            };

            configuration = new QueryConfiguration()
            {
                Keywords = words,
                Location = Locations.USA,
                Language = Languages.English,
                Filter = Filters.None,
                SearchType = SearchTypes.Mixed,
                SinceDate = new DateTime(2018, 03, 18 ),
                UntilDate = new DateTime(2018, 03, 21 ),
                MaxPublicationCount = 40


            };

            publication = facebook.Search(configuration)[0];
        }

        [TestMethod]
        public void TestByWroteFajardo()
        {
            SetupStage1();
            String wroteBy = publication.WroteBy;
            Assert.IsTrue(wroteBy.Contains("Fajardo12415375791"));
        }

        [TestMethod]
        public void TestByWrotePetro()
        {
            SetupStage2();
            String wroteBy = publication.WroteBy;
            Assert.IsTrue(wroteBy.Contains("Gustavo Petro95972290770"));
        }

        [TestMethod]
        public void TestByWroteSemana()
        {
            SetupStage3();
            String wroteBy = publication.WroteBy;
            Assert.IsTrue(wroteBy.Contains("Álvaro Uribe Vélez45242794557"));
        }

        [TestMethod]
        public void TestByWroteRealidadPolitica()
        {
            SetupStage3();
            String wroteBy = publication.WroteBy;
            Assert.IsTrue(wroteBy.Contains("gallup91480005965"));
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
        public void TestLocationSemana()
        {
            SetupStage3();
            if (publication.Location != Locations.Colombia)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestLocationRealidadPolitica()
        {
            SetupStage4();
            if (publication.Location != Locations.USA)
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
            SetupStage2();
            if (publication.Language != Languages.Spanish)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestLanguageSemana()
        {
            SetupStage3();
            if (publication.Language != Languages.Spanish)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestLanguageRealidadPolitica()
        {
            SetupStage4();
            if (publication.Language != Languages.English)
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
        public void TestSinceDateSemana()
        {
            SetupStage3();
            DateTime sinceDate = new DateTime(2018, 03, 18);

            int num = DateTime.Compare(publication.CreateDate, sinceDate);


            if (num < 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestSinceDateRealidadPolitica()
        {
            SetupStage4();
            DateTime sinceDate = new DateTime(2018, 03, 18);

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
        public void TestUntilDateSemana()
        {
            SetupStage3();
            DateTime untilDate = new DateTime(2018, 03, 21);
            int num2 = DateTime.Compare(publication.CreateDate, untilDate);
            if (num2 > 0)
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void TestUntilDateRealidadPolitica()
        {
            SetupStage3();
            DateTime untilDate = new DateTime(2018, 03, 21);
            int num2 = DateTime.Compare(publication.CreateDate, untilDate);
            if (num2 > 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestFoundPublicationsPoliticaSinCensura()
        {
            SetupStage3();
            Assert.IsTrue(publication.Message.Equals("Test graph FB"));


            Assert.IsTrue(publication.CreateDate.CompareTo(new DateTime(2018, 03, 16)) <= 0);

            Assert.IsTrue(publication.WroteBy.Equals("FeelSoft InteiProject116534032517988"));
        }
    }
}

