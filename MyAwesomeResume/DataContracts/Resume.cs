using System.Runtime.Serialization;

namespace MyAwesomeResume
{
    [DataContract]
    class Resume
    {
        #region Public Properties

        [DataMember]
        public PersonalData PersonalData { get; set; }

        [DataMember]
        public Jobs Jobs { get; set; }

        [DataMember]
        public Education Education { get; set; }

        #endregion Public Properties
    }
}
