using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Business.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public UserModel()
        {

        }

        public UserModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
