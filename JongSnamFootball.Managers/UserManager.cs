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
            var userMembers = await _userRepository.GetAll();
            var result = _mapper.Map<List<UserDto>>(userMembers);
            return result;
        }

        public async Task<bool> CreateUser(UserRequest requestDto)
        {
            try
            {
                var userModel = _mapper.Map<UserMemberModel>(requestDto);

                await _repositoryWrapper.BeginTransaction();

                await _repositoryWrapper.User.CreateAsync(userModel);

                await _repositoryWrapper.SaveAsync();

                await _repositoryWrapper.Commit();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }
    }
}
