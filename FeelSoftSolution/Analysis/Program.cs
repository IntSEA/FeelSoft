using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkConnection;
using FacebookConnection;

namespace Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            ISocialNetwork social = new Facebook();
            List<string> list = new List<string>
            {
                "me"
            };

            IQueryConfiguration query = new QueryConfiguration()
            {
                Keywords = list,
                MaxPublicationCount = 2         

            };

            IList<IPublication> found = social.Search(query);
            foreach (var item in found)
            {
                Console.WriteLine(item.Message);
                Console.WriteLine(item.CreateDate.ToString());
            }

            Console.ReadKey();

        }
    }
}
