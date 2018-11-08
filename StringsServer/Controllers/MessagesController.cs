using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StringsServer.Contracts.Models;
using StringsServer.Contracts.Repository;
using AutoMapper;
using StringsServer.Models;
using System.Collections.Generic;

namespace StringsServer.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : ApiControllerBase
    {
        public MessagesController(IRepository<StringMessage> messageRepository) : base(messageRepository) { }

        [HttpGet("Index")]
        public async Task<StringMessagesListResponse> ReadAllAsync()
        {
            var messages = await _repository.ReadAllAsync();

            return new StringMessagesListResponse
            {
                Success = true,
                Items = Mapper.Map<IEnumerable<StringMessageModel>>(messages)
            };
        }
    }
}