using System;
using System.Runtime.Serialization;

namespace MyAwesomeResume
{
    [DataContract]
    class Degree
    {
        #region Public Properties

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime Start { get; set; }

        [DataMember]
        public DateTime End { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string University { get; set; }

        #endregion Public Properties
    }
}
