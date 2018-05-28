using SmartSql.Abstractions;
using SmartSql.Starter.API.Message.Request.User;
using SmartSql.Starter.Repository;
using System;

namespace SmartSql.Starter.Service
{
    public class UserService
    {
        private readonly ISmartSqlMapper _smartSqlMapper;
        private readonly IUserRepository _userRepository;

        public UserService(
             ISmartSqlMapper smartSqlMapper
            , IUserRepository userRepository)
        {
            _smartSqlMapper = smartSqlMapper;
            _userRepository = userRepository;
        }

        public long Add(AddRequest request)
        {
            int existsNum = _userRepository.Exists(new { request.UserName });
            if (existsNum > 0)
            {
                throw new ArgumentException($"{nameof(request.UserName)} has already existed!");
            }
            return _userRepository.Add(new Entitiy.User
            {
                UserName = request.UserName,
                Password = request.Password,
                Status = Entitiy.UserStatus.Ok,
                CreationTime = DateTime.Now,
            });
        }

        public void UseTransaction()
        {
            try
            {
                _smartSqlMapper.BeginTransaction();
                //Biz();
                _smartSqlMapper.CommitTransaction();
            }
            catch (Exception ex)
            {
                _smartSqlMapper.RollbackTransaction();
                throw ex;
            }
        }
    }
}
