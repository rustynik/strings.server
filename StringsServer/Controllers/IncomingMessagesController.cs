using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StringsServer.Contracts.Models;
using StringsServer.Contracts.Repository;
using StringsServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringsServer.Controllers
{
    [Route("api/secure/[controller]")]
    public class IncomingMessagesController : ApiControllerBase
    {
        public IncomingMessagesController(IRepository<StringMessage> messageRepository) : base(messageRepository) { }

        [HttpPost]
        public async Task PostMessageAsync([FromBody] PostMessageRequest postMessageRequest)
        {
            var message = Mapper.Map<StringMessage>(postMessageRequest);

            await _repository.InsertAsync(message);
        }
    }
}
