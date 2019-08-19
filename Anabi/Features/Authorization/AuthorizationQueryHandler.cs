﻿using Anabi.Domain;
using Anabi.Features.Authorization.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Anabi.Security;
using System;
using System.Threading;

namespace Anabi.Features.Authorization
{
    public class AuthorizationQueryHandler : BaseHandler, IRequestHandler<AuthenticationRequest, Anabi.Domain.Models.User>
    {
        private readonly IAnabiCrypt _crypt;

        public AuthorizationQueryHandler(BaseHandlerNeeds needs, IAnabiCrypt crypt) : base(needs)
        {
            _crypt = crypt;
        }

        public async Task<Anabi.Domain.Models.User> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            var foundUser = await context.Users
                .SingleOrDefaultAsync(u => u.UserCode == request.Username && u.IsActive == true, cancellationToken);

            if (foundUser == null)
            {
                throw new Exception("Invalid credentials!");
            }
            
            if (_crypt.IsHashCorrespondingToValue(foundUser.Password, request.Password))
            {
                return mapper.Map<Anabi.Domain.Models.User>(foundUser);
            }

            throw new Exception("Invalid credentials!");

        }
    }
}
