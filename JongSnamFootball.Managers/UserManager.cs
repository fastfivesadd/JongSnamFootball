using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;

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

        public async Task<bool> CreateUser(UserRequest requestDto)
        {
            try
            {
                var userModel = _mapper.Map<UserModel>(requestDto);

                userModel.CreatedDate = DateTime.Now;
                userModel.UpdatedDate = DateTime.Now;

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
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _repositoryWrapper.Dispose();
            }
        } 
    }
}
