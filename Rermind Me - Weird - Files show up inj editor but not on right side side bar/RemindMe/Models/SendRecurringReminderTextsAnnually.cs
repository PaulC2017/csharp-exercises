using System;
using System.Linq;
using System.Threading.Tasks;
using Bandwidth.Net;
using Bandwidth.Net.Api;

namespace RemindMe.Models
{
  /*  
    public class SendRecurringReminderTextsAnnually
    {
        // Replace with your phone number
        private const string YOUR_PHONE_NUMBER = "9084299388";
        // Replace with your bandwidth number
        private const string BANDWIDTH_PHONE_NUMBER = "16312403668";
        private const string UserId = "{{u-ta243h2cvc3vpchzjfks4zy}}";  //{user_id}
        private const string Token = "{{t-tdz5uhrzxd7ojztxehojmrq}}"; //{token}
        private const string Secret = "{{5qhmw3oajgxmhg6vnp6zgxpwgtouytoi6wms3tq}}"; //{secret}

        public static void Main(string[] args)
        {
            try
            {
                SendMessage().Wait();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        private static async Task SendMessage()
        {
            var data = new Bandwidth.Net.Api.MessageData
            {
                To = "9084299388", // number getting text essage
                From = "16312403668", //bandwidth number
                Text = "Hi from C#"
            };
            var client = new Client(UserId, Token, Secret);


            var message = await client.Message.SendAsync(data);
            Console.WriteLine(message);

            var messages = client.Message.List();
            Console.WriteLine(messages.First().Text);
        }
        
    }
    */
}
    

