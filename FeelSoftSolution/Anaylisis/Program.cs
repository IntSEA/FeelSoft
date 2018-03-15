using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkConnection;
using FacebookConnection;

namespace Anaylisis
{
    class Program
    {
        static void Main(string[] args)
        {
            ISocialNetwork social = new Facebook();
            IList<string> words = new List<String>()
            {
                "SergioFajardoV",
            };
            IQueryConfiguration query = new QueryConfiguration()
            {

                Keywords = words,
                Location = Locations.Colombia,
                Language = Languages.Spanish,
                Filter = Filters.None,
                SearchType = SearchTypes.Mixed,
                //Facebook al parecer da la fecha con un dia de adelanto
                SinceDate = new DateTime(2018, 03, 12),
                UntilDate = new DateTime(2018, 03, 15),
                MaxPublicationCount = 20


            };
            IList<IPublication> list = social.Search(query);
            foreach (var item in list)
            {
                Console.WriteLine("Publication");
                Console.WriteLine(item.Message);
                Console.WriteLine(item.CreateDate.ToString());
            }

            Console.ReadKey();
        }
    }
}
