using Common.Application;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommand : IBaseCommand
    {
        public EditUserCommand(long userId, string name, string family, string phoneNumber,
            string password, IFormFile? avatar, string email, Gender gender)
        {
            UserId = userId;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Password = password;
            ImageFile = avatar;
            Email = email;
            Gender = gender;
        }

        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public IFormFile? ImageFile { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
    }
}
