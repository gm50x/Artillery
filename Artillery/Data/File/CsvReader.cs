using Artillery.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;

namespace Artillery.Data.File
{
    public class CsvReader
    {
        private readonly string _filepath;

        public CsvReader(string filepath)
        {
            _filepath = filepath;
        }

        public List<User> ReadFile()
        {
            var importedData = new List<User>();

            using (StreamReader data = new StreamReader(_filepath))
            {
                string ln = data.ReadLine();
                while ((ln = data.ReadLine()) != null)
                {
                    var split = ln.Split(',');
                    importedData.Add(new User
                    {
                        Name = split[0],
                        UserName = split[1],
                        Email = split[2]
                    });
                }
            }

            return importedData;
        }

        public void CleanUp()
        {
            System.IO.File.Delete(_filepath);
        }
    }
}
