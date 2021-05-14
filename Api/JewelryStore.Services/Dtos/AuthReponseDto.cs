using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStore.Services.Dtos
{
    public class AuthReponseDto
    {
        public int ExpireIn { get; set; }

        public string AccessToken { get; set; }

        public string UserName { get; set; }

        public string UserRole { get; set; }
    }
}
