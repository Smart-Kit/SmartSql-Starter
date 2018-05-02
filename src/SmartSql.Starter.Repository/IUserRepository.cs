using SmartSql.DyRepository;
using SmartSql.Starter.Entitiy;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SmartSql.Starter.Repository
{
    public interface IUserRepository
    {
        long Add(User entity);
        int Remove(User entity);
        int Update(User entity);
        int DyUpdate(object reqParams);
        IEnumerable<User> Query(object reqParams);
        IEnumerable<T> Query<T>(object reqParams);
        IEnumerable<User> QueryByPage(object reqParams);
        IEnumerable<T> QueryByPage<T>(object reqParams);
        [Statement(Execute = ExecuteBehavior.ExecuteScalar)]
        int GetRecord(object reqParams);
        [Statement(Execute = ExecuteBehavior.ExecuteScalar)]
        int Exists(object reqParams);
    }
}
