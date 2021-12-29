using Accounty.Business.Database.Models;
using Accounty.Business.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dto = Accounty.Api.Models;

namespace Accounty.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var accounts = _accountService.Get();
            var dtoAccounts = _mapper.Map<List<Dto.Account>>(accounts);
            return Ok(dtoAccounts);
        }

        [HttpGet("{id:int}", Name = "GetAccountById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _accountService.GetById(id);
            var dtoAccount = _mapper.Map<Dto.Account>(account);
            return Ok(dtoAccount);
        }

        [HttpPost(Name = "PostAccount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] Dto.Account dtoAccount)
        {
            var account = _mapper.Map<Account>(dtoAccount);
            var createdAccount = await _accountService.Create(account);
            return CreatedAtAction(nameof(Get), _mapper.Map<Dto.Account>(createdAccount));
        }

        [HttpDelete("{id:int}", Name = "DeleteAccount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _accountService.Delete(id);
            return NoContent();
        }
    }
}
