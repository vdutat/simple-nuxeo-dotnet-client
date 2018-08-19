using System;
using System.Threading.Tasks;
using NuxeoClient;
using NuxeoClient.Wrappers;

namespace simple_nuxeo_dotnet_client
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var client = new Client("http://localhost:8080/nuxeo/",
                new Authorization("Administrator", "Administrator")))
            {
                GetDocument(client, "/default-domain/workspaces/ws1");
            }
        }

        private static void GetDocument(Client client, string path)
        {
            Console.WriteLine("<GetDocument> " + path);
            // let's create an async job that doesn't block
            System.Threading.Tasks.Task.Run(async () => {
                // perform an async request
                Document doc = (Document)await client.DocumentFromPath(path).Get();
                Console.WriteLine("* " + doc.Path);
            }).Wait(); // let's wait for the task to complete
        }
    }
}
