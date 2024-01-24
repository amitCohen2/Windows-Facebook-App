using System;
using System.IO;
using System.Xml.Serialization;

namespace FacebookLogic
{
    public sealed class UserDetails
    {
        private const string k_FileName = "userDetails.xml";
        private static readonly string sr_FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, k_FileName);
        private static readonly object sr_LockObject = new object();
        private static UserDetails s_UserDetailsInstance = null;

        public string UserToken { get; set; }

        public static UserDetails UserDetailsInstance
        {
            get
            {
                if (s_UserDetailsInstance == null)
                {
                    lock (sr_LockObject)
                    {
                        if (s_UserDetailsInstance == null)
                        {
                            s_UserDetailsInstance = new UserDetails();
                        }
                    }
                }
                return s_UserDetailsInstance;
            }
        }
          
        private UserDetails()
        {
            UserToken = null;
        }

        public void LoadFromFile()
        {
            try
            {
                using (Stream stream = new FileStream(sr_FilePath, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(UserDetails));
                    s_UserDetailsInstance = serializer.Deserialize(stream) as UserDetails;
                }
            }
            catch (Exception)
            {
                s_UserDetailsInstance = null;
            }
        }

        public void SaveToFile()
        {
            FileMode mode = File.Exists(sr_FilePath) ?
                FileMode.Truncate : FileMode.Create;
            using (Stream stream = new FileStream(sr_FilePath, mode))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }
    }
}
