using AutoMapper;
using Database;
using Microsoft.AspNetCore.Identity;

namespace Logic.Helpers
{
    public class DtoProvider
    {
        UserManager<AppUser> userManager;

        public Mapper Mapper { get; }
    }
}
