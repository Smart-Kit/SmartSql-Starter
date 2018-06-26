using SmartSql.Abstractions;
using SmartSql.Starter.API.Message.Request.User;
using SmartSql.Starter.Repository;
using System;

namespace SmartSql.Starter.Service
{
    public class UserService
    {
        private readonly ITransaction _transaction;
        private readonly IUserRepository _userRepository;

        public UserService(
             ITransaction  transaction
            , IUserRepository userRepository)
        {
            _transaction = transaction;
            _userRepository = userRepository;
        }

        public long Add(AddRequest request)
        {
            bool isExist = _userRepository.IsExist(new { EqUserName = request.UserName });
            if (isExist)
            {
                throw new ArgumentException($"{nameof(request.UserName)} has already existed!");
            }
            return _userRepository.Insert(new Entitiy.User
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
                _transaction.BeginTransaction();
                //Biz();
                _transaction.CommitTransaction();
            }
            catch (Exception ex)
            {
                _transaction.RollbackTransaction();
                throw ex;
            }
        }

    }
}
