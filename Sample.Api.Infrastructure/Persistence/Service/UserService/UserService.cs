using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sample.Api.Application.Command;
using Sample.Api.Application.Common;
using Sample.Api.Application.Query;
using Sample.Api.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Api.Infrastructure.Persistence
{
    [Injectable]
    public class UserService : IUserservice
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserService(IApplicationDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<bool> RegisterUser(UserCreateDto createDto)
        {
            if (await IsuserExists(createDto.Name))
                throw new InvalidOperationException($"user {createDto.Name} is already exists");
            var user = new User
            {
                Name = createDto.Name,
                PasswordHash = createDto.PasswordHash,
                PasswordSalt = createDto.PasswordSalt,
                Role = createDto.Role
            };
            await _dbContext.Users.AddAsync(user);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }
        private async Task<bool> IsuserExists(string name)
            => await _dbContext.Users.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        public async Task<UserGetDto> Login(LoginRequsetDto requsetDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Name.ToLower() == requsetDto.UserName.ToLower());
            if (user is null) throw new InvalidOperationException($"user {requsetDto.UserName} doen't registerd");
            return _mapper.Map<UserGetDto>(user);
        }
    }
}
