using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSql.Starter.API.Message;
using SmartSql.Starter.API.Message.Request.User;
using SmartSql.Starter.API.Message.Response.User;
using SmartSql.Starter.Entitiy;
using SmartSql.Starter.Repository;
using SmartSql.Starter.Service;

namespace SmartSql.Starter.API.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly IUserRepository _userRepository;

        public UserController(UserService userService, IUserRepository userRepository)
        {
            this._userService = userService;
            this._userRepository = userRepository;
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseMessageWraper<long> Add([FromBody]AddRequest request)
        {
            var userId = _userService.Add(request);
            return new ResponseMessageWraper<long>
            {
                Body = userId
            };
        }
        /// <summary>
        /// Query
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseMessageWraper<QueryResponse<Item>> Query([FromBody]QueryRequest request)
        {
            var list = _userRepository.Query<Item>(request);
            return new ResponseMessageWraper<QueryResponse<Item>>
            {
                Body = new QueryResponse<Item>
                {
                    List = list
                }
            };
        }
        /// <summary>
        /// QueryByPage
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseMessageWraper<QueryByPageResponse<Item>> QueryByPage([FromBody] Message.Request.User.QueryByPageRequest request)
        {
            var list = _userRepository.QueryByPage<Item>(request);
            var total = _userRepository.GetRecord(request);
            return new ResponseMessageWraper<QueryByPageResponse<Item>>
            {
                Body = new QueryByPageResponse<Item>
                {
                    List = list,
                    Total = total
                }
            };
        }
        [HttpPost]
        public ResponseMessageWraper<User> GetById([FromBody]GetByIdRequest reqMsg)
        {
            return new ResponseMessageWraper<User>
            {
                Body = _userRepository.GetById(reqMsg.Id)
            };
        }
    }
}
