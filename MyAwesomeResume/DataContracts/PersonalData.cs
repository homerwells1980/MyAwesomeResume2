using System.Runtime.Serialization;

namespace MyAwesomeResume
{
    [DataContract]
    class PersonalData
    {
        #region Public Properties

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Email { get; set; }

        #endregion Public Properties
    }
}
