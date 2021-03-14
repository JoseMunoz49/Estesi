using Microsoft.EntityFrameworkCore;
using SoporteBot.Common.Models.Qualification;
using SoporteBot.Common.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoporteBot.Data
{
    public interface IDataBaseService 
    {
        DbSet<UserModel> User { get; set; }

        DbSet<QualificationModel> Qualification { get; set; }

        
        Task<bool> SaveAsync();
    }
}
