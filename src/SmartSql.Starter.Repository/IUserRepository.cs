using SmartSql.DyRepository;
using SmartSql.Starter.Entitiy;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SmartSql.Starter.Repository
{
    public interface IUserRepository : IRepository<User, long>
    {
        new long Insert(User entity);
        IEnumerable<T> Query<T>(object reqParams);
        IEnumerable<T> QueryByPage<T>(object reqParams);
        [Statement(Sql = "Select Top 1 T.* From T_User T Where T.Id=@id")]
        User GetById_RealSql(long id);


        int InsertExtendData(UserExtendData extendData);

        int UpdateExtendData(UserExtendData extendData);

        UserExtendData GetExtendData([Param("UserId")]long userId);

    }
}
