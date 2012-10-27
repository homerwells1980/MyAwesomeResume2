using System;
using System.Configuration;
using System.Net;
using System.Threading;

namespace MyAwesomeResume
{
    /// <summary>
    /// This class fakes an http connection service to allow for verification of the service without needing to install IIS.
    /// </summary>
    class FakeHttpServer
    {
        #region Private Fields

        private HttpListener listener;
        private string[] endpoints;
        private bool shutDown;
        private MyAwesomeResumeService myAwesomeResumeService;

        #endregion Private Fields

        #region Constructor

        public FakeHttpServer()
        {
            // Creating the listener for incoming http requests
            this.listener = new HttpListener();

            // Registering all endpoints to be served by this listener
            this.endpoints = ConfigurationSettings.AppSettings["endpoints"].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string endpoint in this.endpoints)
            {
                this.listener.Prefixes.Add(endpoint);
            }

            this.myAwesomeResumeService = new MyAwesomeResumeService();
        }

        #endregion Constructor

        #region Public Methods

        public void Start()
        {
            this.listener.Start();

            Console.WriteLine("Listening ... connect to the following endpoints:");
            foreach (var endpoint in this.endpoints)
            {
                Console.WriteLine("-" + endpoint);
            }

            // Starting a thread to process incoming requests
            ThreadPool.QueueUserWorkItem(new WaitCallback(Listen));
        }

        public void Stop()
        {
            this.shutDown = true;
        }

        #endregion Public Methods

        #region Private Methods

        private void Listen(object state)
        {
            this.shutDown = false;

            while (!this.shutDown)
            {
                // Accept the next connection
                HttpListenerContext context = listener.GetContext();

                // Route the request for processing
                RouteRequest(context.Request, context.Response);
            }

            this.listener.Stop();
        }

        private void RouteRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (request.HttpMethod != "GET")
            {
                // Only GET requests are supported in this service
                response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            string[] segments = request.RawUrl.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length == 0)
            {
                // Request must have at least one segment
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }

            if (segments[0].ToLowerInvariant() != "myawesomeresume")
            {
                // First segment must be name of service
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }

            try
            {
                if (segments.Length == 1)
                {
                    this.myAwesomeResumeService.GetResume(response);
                }
                else
                {
                    switch (segments[1].ToLowerInvariant())
                    {
                        case "jobs":
                            this.myAwesomeResumeService.GetJobs(response);
                            break;
                        case "education":
                            this.myAwesomeResumeService.GetEducation(response);
                            break;
                        case "personaldata":
                            this.myAwesomeResumeService.GetPersonalData(response);
                            break;
                        case "heresroger":
                            this.myAwesomeResumeService.HeresRoger(response);
                            break;
                        default:
                            response.StatusCode = (int)HttpStatusCode.NotFound;
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("An exception occurred: " + exception.ToString());
            }
        }

        private string[] ReadEndpoints()
        {
            this.listener = new HttpListener();

            return ConfigurationSettings.AppSettings["endpoints"].Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
        }

        #endregion Private Methods
    }
}
