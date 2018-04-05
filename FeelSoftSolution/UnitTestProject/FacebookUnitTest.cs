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
                "Fajardo",
                "Sergio Fajardo"
            };

            configuration = new QueryConfiguration()
            {
                Keywords = words,
                Location = Locations.Colombia,
                Language = Languages.Spanish,
                Filter = Filters.None,
                SearchType = SearchTypes.Mixed,
                SinceDate = new DateTime(2018, 1, 1),
                UntilDate = DateTime.Now.AddDays(1),
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
                //"Petro",
                 "GustavoPetro"
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
                MaxPublicationCount = 200

            };


            IList<IPublication> found = facebook.Search(configuration);
            if (found.Count > 0)
            {
                publication = found[0];
            }
        }

        //for project facebook's group
        public void SetupStage3()
        {
            facebook = new Facebook();

            IList<string> words = new List<String>()
            {
                "Uribe",
                "Uribe Velez"
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
                MaxPublicationCount = 200
            };

            IList<IPublication> found = facebook.Search(configuration);
            if (found.Count > 0)
            {
                publication = found[0];
            }
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
                SinceDate = new DateTime(2018, 03, 18),
                UntilDate = DateTime.Now.AddDays(1),
                MaxPublicationCount = 40
            };

            IList<IPublication> found = facebook.Search(configuration);
            if (found.Count > 0)
            {
                publication = found[0];
            }
        }

        [TestMethod]
        public void TestByWroteFajardo()
        {
            SetupStage1();
            string message = publication.Message;
            bool containsFajardo = message.Contains("Fajardo");
            bool containsSergioFajardo = message.Contains("Sergio Fajardo");

            Assert.IsTrue(containsFajardo || containsSergioFajardo);

        }

        [TestMethod]
        public void TestByWrotePetro()
        {
            SetupStage2();
            string message = publication.Message;
            bool containsPetro = message.Contains("Petro");
            bool containsGustavoPetro = message.Contains("GustavoPetro");
            Assert.IsTrue(containsGustavoPetro || containsPetro);
        }

        [TestMethod]
        public void TestByWroteSemana()
        {
            SetupStage3();
            string message = publication.Message;
            bool containsUribe = message.Contains("Uribe");
            bool containsUribeVelez = message.Contains("Uribe Velez");
            Assert.IsTrue(containsUribe || containsUribeVelez);
        }

        [TestMethod]
        public void TestByWroteRealidadPolitica()
        {
            SetupStage3();
            if (publication != null)
            {
                string message = publication.Message;

                Assert.IsTrue(!String.IsNullOrEmpty(message));
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestLocationFajardo()
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
        public void TestLocationPetro()
        {
            SetupStage2();
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
        public void TestLocationSemana()
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
        public void TestLocationRealidadPolitica()
        {
            SetupStage4();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else if (publication.Location != Locations.USA)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestLanguageFajardo()
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
        public void TestLanguagePetro()
        {
            SetupStage2();
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
        public void TestLanguageSemana()
        {
            SetupStage3();
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
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                DateTime sinceDate = new DateTime(2018, 03, 11);

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
            SetupStage2();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                DateTime sinceDate = new DateTime(2018, 03, 11);

                int num = DateTime.Compare(publication.CreateDate, sinceDate);


                if (num < 0)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestSinceDateSemana()
        {
            SetupStage3();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                DateTime sinceDate = DateTime.Now.AddDays(1);

                int num = DateTime.Compare(publication.CreateDate, sinceDate);


                if (num < 0)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestSinceDateRealidadPolitica()
        {
            SetupStage4();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {

                DateTime sinceDate = DateTime.Now.AddDays(1);

                int num = DateTime.Compare(publication.CreateDate, sinceDate);

                if (num < 0)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestUntilDateFajardo()
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
        public void TestUntilDatePetro()
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
        public void TestUntilDateSemana()
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


        [TestMethod]
        public void TestUntilDateRealidadPolitica()
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

        [TestMethod]
        public void TestFoundPublicationsPoliticaSinCensura()
        {
            SetupStage3();
            if (publication == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(publication.Message.Equals("Test graph FB"));


                Assert.IsTrue(publication.CreateDate.CompareTo(new DateTime(2018, 01, 01)) <= 0);

                Assert.IsTrue(publication.WroteBy.Equals("FeelSoft InteiProject116534032517988"));
            }
        }
    }
}

