using System.Net;

namespace MyAwesomeResume
{
    interface IMyAwesomeResumeService
    {
        void GetResume(HttpListenerResponse response);

        void GetJobs(HttpListenerResponse response);

        void GetEducation(HttpListenerResponse response);

        void GetPersonalData(HttpListenerResponse response);

        void HeresRoger(HttpListenerResponse response);
    }
}
