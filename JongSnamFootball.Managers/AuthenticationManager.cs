using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Constants;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;
using JongSnamFootball.Managers.Extensions;

namespace JongSnamFootball.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AuthenticationManager(IAuthenticationRepository authenticationRepository, IMapper mapper, IUserRepository userRepository, IRepositoryWrapper repositoryWrapper)
        {
            _authenticationRepository = authenticationRepository;
            _repositoryWrapper = repositoryWrapper;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Login(string user, string password)
        {
            var pEncrypted = Encryptions.EncryptString(EncryptionConstants.Key, password);

            var userModel = await _authenticationRepository.GetUser(user, pEncrypted);

            if (userModel == null)
            {
                return null;
            }
            userModel.IsLoggedIn = true;
            userModel.UpdatedDate = DateTime.Now;

            _repositoryWrapper.User.Updete(userModel);

            await _repositoryWrapper.SaveAsync();

            var result = _mapper.Map<UserDto>(userModel);
            result.UserType = userModel.UserTypeId == 1 ? "Owner" : "Customer";

            result.Password = password;

            return result;
        }

        public async Task<bool> Logout(int id)
        {
            var userModel = await _userRepository.GetUserById(id);
            userModel.IsLoggedIn = false;
            userModel.UpdatedDate = DateTime.Now;

            _repositoryWrapper.User.Updete(userModel);

            await _repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<bool> CheckIsLoggedIn(string user, string password)
        {
            var pEncrypted = Encryptions.EncryptString(EncryptionConstants.Key, password);
            var userModel = await _authenticationRepository.GetUser(user, pEncrypted);

            if (userModel == null || userModel.IsLoggedIn.Value == false)
            {
                return false;
            }
            return true;
        }
    }
}
