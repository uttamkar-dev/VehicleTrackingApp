using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.Enums;
using VehicleTracking.Application.Helper;
using VehicleTracking.Application.Interfaces;
using VehicleTracking.Entity.Entities;

namespace VehicleTracking.Application.CommandQuery.Accounts.Command.CreateAccounts
{
    public class UserAccountCommandHandler : IRequestHandler<UserAccountCommand, Message>
    {
        private readonly IMapper _iMapper;
        private readonly IAccountsRepository _iAccountsRepository;

        public UserAccountCommandHandler(IMapper iMapper, IAccountsRepository iAccountsRepository)
        {
            _iMapper = iMapper;
            _iAccountsRepository = iAccountsRepository;
        }

        public async Task<Message> Handle(UserAccountCommand request, CancellationToken cancellationToken)
        {
            Message message = null;

            using var hmac = new HMACSHA512();
            var user = _iMapper.Map<User>(request);

            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            user.PasswordSalt = hmac.Key;
            user.RoleId = (int)UserRoleEnum.User;
            user.CreatedDate = DateTime.Now;
            try
            {
                var register = await _iAccountsRepository.AddAsync(user);
                if (register.Id > 0)
                {
                    message = new Message()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        StatusMessage = "Data saved successfully"
                    };
                }
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
