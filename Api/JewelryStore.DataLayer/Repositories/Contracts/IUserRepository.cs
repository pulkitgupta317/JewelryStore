using JewelryStore.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.DataLayer.Repositories.Contracts
{
    public interface IUserRepository
    {
        User GetUser(string userName);
    }
}
