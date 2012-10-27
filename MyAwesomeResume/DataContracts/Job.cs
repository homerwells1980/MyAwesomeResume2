using System;
using System.Runtime.Serialization;

namespace MyAwesomeResume
{
    [DataContract]
    class Job
    {
        #region Public Properties

        [DataMember]
        public string Company { get; set; }

        [DataMember]
        public string Team { get; set; }

        [DataMember]
        public DateTime Start { get; set; }

        [DataMember]
        public DateTime? End { get; set; }

        [DataMember]
        public bool Current { get; set; }

        [DataMember]
        public string Position { get; set; }

        [DataMember]
        public string Description { get; set; }

        #endregion Public Properties
    }
}
