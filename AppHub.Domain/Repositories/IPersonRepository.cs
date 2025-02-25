﻿using AppHub.Domain.Common;
using AppHub.Domain.Models;

namespace AppHub.Domain.Repositories;

public interface IPersonRepository : IRepository
{ 
    Task<PersonModel> InsertAsync(PersonModel model);
    Task<PersonModel> UpdateAsync(PersonModel model);
    Task DeleteAsync(PersonModel model);
    Task<PersonModel> GetByIdAsync( int identity );
    Task<PersonModel> GetByEmailAsync( string email);
    Task<bool> IsEmailDuplicated(string email);
}