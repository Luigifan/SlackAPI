using SlackAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SlackApi
{
    class BotRTMTest
    {
        private SlackSocketClient BotSocket;

        public BotRTMTest(string token)
        {
            BotSocket = new SlackSocketClient(token);
        }

        public void Start()
        {
            BotSocket.OnMessageReceived += (e) =>
            {
                Console.WriteLine($"[-- Messaged received from {e.user} in {e.channel}: {e.text}");
            };

            BotSocket.Connect((loginResponse) =>
            {
                Console.WriteLine($"Logged in! {loginResponse.self.name}");

            }, 
            () =>
            {
                Console.WriteLine("Socket supposedly connected.");
            });
        }

        public void Stop()
        {
            BotSocket.CloseSocket();
            BotSocket = null;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            new BotRTMTest(System.IO.File.ReadAllText("token.txt")).Start();
            Console.ReadLine();

            //try
            //{
            //    var clientId = "PUT CLIENT ID FROM SLACK APPLICATION REGISTATION HERE";
            //    var clientSecret = "PUT CLIENT SECRET FROM SLACK APPLICATION REGISTATION HERE";
            //    var redirectUri = "PUT REDIRECT FROM SLACK APPLICATION REGISTATION HERE";

            //    Console.WriteLine("------------------------------------------------------------------");
            //    Console.WriteLine("This app will open your web browser pointing at an authentication");
            //    Console.WriteLine("page. When you complete authentication, you'll be sent back to ");
            //    Console.WriteLine("whatever 'redirectUri' is above, plus some query-string values. ");
            //    Console.WriteLine("Paste the URI into the console window when prompted.");
            //    Console.WriteLine();
            //    Console.WriteLine("In a proper web application, the user experience will obviously");
            //    Console.WriteLine("be more sensible...");
            //    Console.WriteLine("------------------------------------------------------------------");

            //    // start...
            //    var state = Guid.NewGuid().ToString();
            //    var uri = SlackClient.GetAuthorizeUri(clientId, SlackScope.Identify | SlackScope.Read | SlackScope.Post, redirectUri, state, "socialsaleslounge");
            //    Console.WriteLine("Directing to: " + uri);
            //    Process.Start(uri.ToString());

            //    // read the result -- in a web application you can pick this up directly, here we're fudging it...
            //    Console.WriteLine("Paste in the URL of the authentication result...");
            //    var asString = Console.ReadLine();
            //    var index = asString.IndexOf('?');
            //    if (index != -1)
            //        asString = asString.Substring(index + 1);

            //    // parse... 
            //    var qs = HttpUtility.ParseQueryString(asString);
            //    var code = qs["code"];
            //    var newState = qs["state"];

            //    // validate the state. this isn't required, but it's makes sure the request and response line up...
            //    if (state != newState)
            //        throw new InvalidOperationException("State mismatch.");

            //    // then get the token...
            //    Console.WriteLine("Requesting access token...");
            //    SlackClient.GetAccessToken((response) => 
            //        {
            //            var accessToken = response.access_token;
            //            Console.WriteLine("Got access token '{0}'...", accessToken);

            //            // post...
            //            var client = new SlackClient(accessToken);
            //            client.PostMessage(null, "#registrations", "Test", "Jo the Robot");

            //        }, clientId, clientSecret, redirectUri, code);

            //    // finished...
            //    Console.WriteLine("Done.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //finally
            //{
            //    Console.ReadLine();
            //}
        }
    }
}
