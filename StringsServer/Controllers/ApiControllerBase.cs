using Microsoft.AspNetCore.Mvc;
using StringsServer.Contracts.Models;
using StringsServer.Contracts.Repository;
using System;

namespace StringsServer.Controllers
{
    public abstract class ApiControllerBase : Controller
    {
        protected readonly IRepository<StringMessage> _repository;

        public ApiControllerBase(IRepository<StringMessage> messageRepository)
        {
            _repository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
        }
    }
}
