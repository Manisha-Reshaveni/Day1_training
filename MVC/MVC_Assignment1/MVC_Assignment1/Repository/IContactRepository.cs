﻿using MVC_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Assignment1.Repository
{
   public interface IContactRepository
    {

            Task<List<Contact>> GetAllAsync();
            Task CreateAsync(Contact contact);
            Task DeleteAsync(long Id);

        
    }
}
