using StudentSystem.Models;
using System.Collections.Generic;

namespace StudentSystem.Repository
{
    public class DbRepo
    {
        public List<CheckModel> GetAvailableEducations()
        {
            List<CheckModel> educations = new List<CheckModel>()
                {
                new CheckModel() { Id = 1, Name = "10" , Checked = false},
                new CheckModel { Id = 2, Name = "12" , Checked = false},
                new CheckModel { Id = 3, Name = "G" , Checked = false},
               new CheckModel { Id = 4, Name = "PG" , Checked = false}
               };
            return educations;
        }
        public List<KeyPair> GetAvailableCities()
        {
            List<KeyPair> cities = new List<KeyPair>()
            {
                new KeyPair() { Value = 1, Text = "Delhi" },
                new KeyPair { Value = 2, Text = "Mumbai" },
                new KeyPair { Value = 3, Text = "Punjab" }
            };
            return cities;
        }

    }
}