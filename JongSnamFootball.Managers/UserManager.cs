using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Constants;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;
using JongSnamFootball.Managers.Extensions;

namespace JongSnamFootball.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public UserManager(IUserRepository userRepository, IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var userMembers = await _userRepository.GetAllUser();
            var result = _mapper.Map<List<UserDto>>(userMembers);
            return result;
        }
        public async Task<UserDto> GetUserById(int id)
        {
            var userMembers = await _userRepository.GetUserById(id);
            var result = _mapper.Map<UserDto>(userMembers);
            return result;
        }

        public async Task<bool> CreateUser(UserRequest requestDto)
        {
            try
            {
                var userModel = _mapper.Map<UserModel>(requestDto);
                userModel.CreatedDate = DateTime.Now;
                userModel.UpdatedDate = DateTime.Now;
                userModel.IsLoggedIn = false;
                var encryptedString = Encryptions.EncryptString(EncryptionConstants.Key, userModel.Password);
                userModel.Password = encryptedString;
                await _repositoryWrapper.User.CreateAsync(userModel);
                await _repositoryWrapper.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ChangePassword(int id, ChangePasswordRequest request)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);

                await _repositoryWrapper.BeginTransactionAsync();

                if (user.Password == request.OldPassword)
                {
                    user.Password = request.NewPassword;
                }
                else
                {
                    return false;
                }
                _repositoryWrapper.User.Updete(user);

                await _repositoryWrapper.SaveAsync();

                await _repositoryWrapper.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _repositoryWrapper.Dispose();
            }
        }

        public async Task<bool> Login(string emailrequest, string passwordrequest)
        {
            var user = await _userRepository.GetPasswordByEmail(emailrequest);

            var password = Encryptions.DecryptString(EncryptionConstants.Key, user.Password);

            if (passwordrequest != password)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateUser(int id, UpdateUserRequest request)
        {
            try
            {
                var userModel = await _userRepository.GetUserById(id);
                userModel.Email = request.Email;
                userModel.FirstName = request.FirstName;
                userModel.LastName = request.LastName;
                userModel.ContactMobile = request.ContactMobile;
                userModel.Address = request.Address;
                userModel.ImageProfile = request.ImageProfile;
                userModel.UpdatedDate = DateTime.Now;

                _repositoryWrapper.User.Updete(userModel);

                await _repositoryWrapper.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
