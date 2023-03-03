using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;


namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<string> Login()
        {
            string Response = "Login";

            var settings = Settings.LoadSettings();

            InitializeGraph(settings);
             
            var user = await GraphHelper.GetUserAsync();

            Response = $"Email: {user.UserPrincipalName}, Display Name: {user.DisplayName}" ?? "usuario";

            return Response;
        }




        void InitializeGraph(Settings settings)
        {
            GraphHelper.InitializeGraphForUserAuth(settings,
                (info, cancel) =>
                { 
                    Console.WriteLine(info.Message);
                    return Task.FromResult(0);
                });
        }

        async Task GreetUserAsync()
        {
            try
            {
                var user = await GraphHelper.GetUserAsync();
                Console.WriteLine($"Hello, {user?.DisplayName}!");
                // For Work/school accounts, email is in Mail property
                // Personal accounts, email is in UserPrincipalName
                Console.WriteLine($"Email: {user?.Mail ?? user?.UserPrincipalName ?? ""}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user: {ex.Message}");
            }
        }

        async Task DisplayAccessTokenAsync()
        {
            try
            {
                var userToken = await GraphHelper.GetUserTokenAsync();
                Console.WriteLine($"User token: {userToken}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user access token: {ex.Message}");
            }
        }

        async Task ListInboxAsync()
        {
            // TODO
        }

        async Task SendMailAsync()
        {
            // TODO
        }

        async Task MakeGraphCallAsync()
        {
            // TODO
        }

    }

}

