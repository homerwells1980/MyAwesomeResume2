using System.Runtime.Serialization;

namespace MyAwesomeResume
{
    [DataContract]
    class Education
    {
        #region Public Properties

        [DataMember]
        public Degree[] Degrees { get; set; }

        #endregion Public Properties
    }
}
