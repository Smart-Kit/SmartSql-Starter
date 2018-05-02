using SmartSql.Abstractions;
using SmartSql.Starter.API.Message.Request.User;
using SmartSql.Starter.Repository;
using System;

namespace SmartSql.Starter.Service
{
    public class UserService
    {
        private readonly ISmartSqlMapper smartSqlMapper;
        private readonly IUserRepository userRepository;

        public UserService(
             ISmartSqlMapper smartSqlMapper
            , IUserRepository userRepository)
        {
            this.smartSqlMapper = smartSqlMapper;
            this.userRepository = userRepository;
        }

        public long Add(AddRequest request)
        {
            int existsNum = userRepository.Exists(new { request.UserName });
            if (existsNum > 0)
            {
                throw new ArgumentException($"{nameof(request.UserName)} has already existed!");
            }
            return userRepository.Add(new Entitiy.User
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
                smartSqlMapper.BeginTransaction();
                //Biz();
                smartSqlMapper.CommitTransaction();
            }
            catch (Exception ex)
            {
                smartSqlMapper.RollbackTransaction();
                throw ex;
            }
        }

    }
}
