using System.Runtime.Serialization;

namespace MyAwesomeResume
{
    [DataContract]
    class Jobs
    {
        #region Public Properties

        [DataMember]
        public Job[] JobList { get; set; }

        #endregion Public Properties
    }
}
