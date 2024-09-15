﻿using AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin
{
    public class AutodocLoginCommandHandler : IRequestHandler<AutodocLoginRequest, AutodocLoginResponse>
    {
        private readonly AutodocLoginValidator validator;
        private readonly IUserRepository userRepository;

        public AutodocLoginCommandHandler(AutodocLoginValidator validator,IUserRepository userRepository)
        {
            this.validator = validator;
            this.userRepository = userRepository;
        }

        public async Task<AutodocLoginResponse> Handle(AutodocLoginRequest request, CancellationToken cancellationToken)
        {
            validator.Validate(request);
            var user = await userRepository.GetUserByLoginCredentialsAsync(request.UserName,request.Password);

            return new AutodocLoginResponse
            {
                UserId = user.Id,
                CountryCode = user.CountryCode,
            };
        }
    }
}
