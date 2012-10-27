using System.IO;
using System.Text;
using System.Xml;

namespace MyAwesomeResume
{
    class SerializationHelper
    {
        #region Public Methods

        public static void ToXml(Resume resume, Stream output)
        {
            XmlWriter writer = XmlWriter.Create(output, new XmlWriterSettings()
                {
                    Encoding = Encoding.UTF8,
                    Indent = true,
                });

            writer.WriteStartDocument();

            ToXmlFragment(resume, writer);

            writer.WriteEndDocument();

            writer.Close();
        }

        public static void ToXml(PersonalData personalData, Stream output)
        {
            XmlWriter writer = XmlWriter.Create(output, new XmlWriterSettings()
            {
                Encoding = Encoding.UTF8,
                Indent = true,
            });

            writer.WriteStartDocument();

            ToXmlFragment(personalData, writer);

            writer.WriteEndDocument();

            writer.Close();
        }

        public static void ToXml(Jobs jobs, Stream output)
        {
            XmlWriter writer = XmlWriter.Create(output, new XmlWriterSettings()
            {
                Encoding = Encoding.UTF8,
                Indent = true,
            });

            writer.WriteStartDocument();

            ToXmlFragment(jobs, writer);

            writer.WriteEndDocument();

            writer.Close();
        }

        public static void ToXml(Education education, Stream output)
        {
            XmlWriter writer = XmlWriter.Create(output, new XmlWriterSettings()
            {
                Encoding = Encoding.UTF8,
                Indent = true,
            });

            writer.WriteStartDocument();

            ToXmlFragment(education, writer);

            writer.WriteEndDocument();

            writer.Close();
        }

        #endregion Public Methods

        #region Private Methods

        private static void ToXmlFragment(Resume resume, XmlWriter writer)
        {
            writer.WriteStartElement("resume");

            ToXmlFragment(resume.PersonalData, writer);

            ToXmlFragment(resume.Jobs, writer);

            ToXmlFragment(resume.Education, writer);

            writer.WriteEndElement();
        }

        private static void ToXmlFragment(PersonalData personalData, XmlWriter writer)
        {
            writer.WriteStartElement("personalData");

            writer.WriteStartElement("name");
            writer.WriteValue(personalData.Name);
            writer.WriteEndElement();
            writer.WriteStartElement("address");
            writer.WriteValue(personalData.Address);
            writer.WriteEndElement();
            writer.WriteStartElement("email");
            writer.WriteValue(personalData.Email);
            writer.WriteEndElement();
            writer.WriteStartElement("phone");
            writer.WriteValue(personalData.Phone);
            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        private static void ToXmlFragment(Jobs jobs, XmlWriter writer)
        {
            writer.WriteStartElement("jobs");

            foreach (Job job in jobs.JobList)
            {
                writer.WriteStartElement("job");

                writer.WriteStartElement("company");
                writer.WriteValue(job.Company);
                writer.WriteEndElement();
                writer.WriteStartElement("team");
                writer.WriteValue(job.Team);
                writer.WriteEndElement();
                writer.WriteStartElement("position");
                writer.WriteValue(job.Position);
                writer.WriteEndElement();
                writer.WriteStartElement("current");
                writer.WriteValue(job.Current);
                writer.WriteEndElement();
                writer.WriteStartElement("start");
                writer.WriteValue(job.Start);
                writer.WriteEndElement();
                if (!job.Current)
                {
                    writer.WriteStartElement("end");
                    writer.WriteValue(job.End);
                    writer.WriteEndElement();
                }
                writer.WriteStartElement("description");
                writer.WriteValue(job.Description);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        private static void ToXmlFragment(Education education, XmlWriter writer)
        {
            writer.WriteStartElement("education");

            foreach (Degree degree in education.Degrees)
            {
                writer.WriteStartElement("degree");

                writer.WriteStartElement("name");
                writer.WriteValue(degree.Name);
                writer.WriteEndElement();
                writer.WriteStartElement("university");
                writer.WriteValue(degree.University);
                writer.WriteEndElement();
                writer.WriteStartElement("start");
                writer.WriteValue(degree.Start);
                writer.WriteEndElement();
                writer.WriteStartElement("end");
                writer.WriteValue(degree.End);
                writer.WriteEndElement();
                writer.WriteStartElement("description");
                writer.WriteValue(degree.Description);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        #endregion Private Methods
    }
}
