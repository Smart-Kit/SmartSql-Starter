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
             ITransaction transaction
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
                Pwd = request.Pwd,
                Status = Entitiy.UserStatus.Ok,
                CreationTime = DateTime.Now,
            });
        }



        public int AddExtendData(AddExtendDataRequest request)
        {
            return _userRepository.InsertExtendData(new Entitiy.UserExtendData
            {
                UserId = request.UserId,
                Info = request.Info
            });
        }
        public int UpdateExtendData(UpdateExtendDataRequest request)
        {
            return _userRepository.UpdateExtendData(new Entitiy.UserExtendData
            {
                UserId = request.UserId,
                Info = request.Info
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
