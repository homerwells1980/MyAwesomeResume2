using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;

namespace MyAwesomeResume
{
    class MyAwesomeResumeService : IMyAwesomeResumeService
    {
        #region Private Fields

        private const string TextXml = "text/xml";
        private const string ImagePng = "image/png";

        private Resume resume;
        private byte[] roger;

        #endregion Private Fields

        #region Constructor

        public MyAwesomeResumeService()
        {
            LoadResume();
            LoadRoger();
        }

        #endregion Constructor

        #region Public Methods

        public void GetResume(HttpListenerResponse response)
        {
            SerializationHelper.ToXml(this.resume, response.OutputStream);
            FinalizeRespose(response, TextXml);
        }

        public void GetJobs(HttpListenerResponse response)
        {
            SerializationHelper.ToXml(this.resume.Jobs, response.OutputStream);
            FinalizeRespose(response, TextXml);
        }

        public void GetEducation(HttpListenerResponse response)
        {
            SerializationHelper.ToXml(this.resume.Education, response.OutputStream);
            FinalizeRespose(response, TextXml);
        }

        public void GetPersonalData(HttpListenerResponse response)
        {
            SerializationHelper.ToXml(this.resume.PersonalData, response.OutputStream);
            FinalizeRespose(response, TextXml);
        }

        public void HeresRoger(HttpListenerResponse response)
        {
            response.OutputStream.Write(this.roger, 0, this.roger.Length);
            FinalizeRespose(response, ImagePng);
        }

        #endregion Public Methods

        #region Private Methods

        private void FinalizeRespose(HttpListenerResponse response, string contentType)
        {
            response.OutputStream.Close();
            response.ContentType = contentType;
            response.StatusCode = (int)HttpStatusCode.OK;
        }

        private void LoadResume()
        {
            string resumeFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Data\\Resume.xml");

            // Read resume from storage
            using (FileStream fileStream = new FileStream(resumeFilePath, FileMode.Open, FileAccess.Read))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Resume));
                this.resume = (Resume)serializer.ReadObject(fileStream);
            }
        }

        private void LoadRoger()
        {
            string rogerFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Data\\roger-looking-up.png");

            // Read resume from storage
            using (FileStream fileStream = new FileStream(rogerFilePath, FileMode.Open, FileAccess.Read))
            {
                this.roger = new byte[(int)fileStream.Length];
                fileStream.Read(this.roger, 0, this.roger.Length);
            }
        }

        #endregion Private Methods
    }
}
