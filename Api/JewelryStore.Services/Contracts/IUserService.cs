using JewelryStore.DataLayer.Models;
using JewelryStore.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Services.Contracts
{
    public interface IUserService
    {
        AuthReponseDto AuthenticateUser(AuthRequestDto authRequest);
    }
}
