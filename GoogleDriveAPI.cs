using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MimeTypes;
using System.Drawing;

namespace GoogleDriveAPI
{
    class GDrive
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "Drive API .NET Quickstart";

        private static UserCredential Authenticate()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            return credential;
        }

        public string getLogin()
        {
            var email = Authenticate().UserId.ToString();
            return email;
        }

        private static DriveService Service()
        {
            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = Authenticate(),
                ApplicationName = ApplicationName,
            });
            return service;
        }

        public void RequestFiles()
        {
            // Define parameters of request.
            FilesResource.ListRequest listRequest = Service().Files.List();
            FilesResource.GetRequest getRequest;
            listRequest.Q = "mimeType = 'application/vnd.google-apps.folder'";
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            Console.WriteLine("Files:");
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Name.Contains("MinasBKP"))
                    {
                        Console.WriteLine("{0} ({1})", file.Name, file.Id);
                        getRequest = Service().Files.Get(string.Format("{0}",file.Id));
                    }
                }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
        }
    }
}