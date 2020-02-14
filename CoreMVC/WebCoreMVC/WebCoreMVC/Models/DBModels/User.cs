using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebCoreMVC.Models.DBModels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
       /// public int CompanyId { get; set; }
        //public Company Company { get; set; }

        //[NotMapped]
        //[JsonIgnore]
        //public User UserNoCompany
        //{ 
        //    get 
        //    {
        //        return new User() { 
        //            Id = this.Id, 
        //            Age = this.Age, 
        //            CompanyId = this.Id, 
        //            Name = this.Name };
        //    } 
        //}
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<User> Users { get; set; }
        public Company()
        {
            Users = new List<User>();
        }
    }


    public enum SortState
    {
        NameAsc,    // по имени по возрастанию
        NameDesc,   // по имени по убыванию
        AgeAsc, // по возрасту по возрастанию
        AgeDesc,    // по возрасту по убыванию
        CompanyAsc, // по компании по возрастанию
        CompanyDesc // по компании по убыванию
    }
}