using AutoMapper;
using clientprospetweb.models;
using clientprospetweb.models.Dto;
using clientprospetweb.Models;
using clientprospetweb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace clientprospetweb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientProspetService _clientProspetService;
        private readonly IMapper _mapper;
        public HomeController(IClientProspetService clientProspetService, IMapper mapper)
        {
            _clientProspetService = clientProspetService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<clientprospetDTO> list = new();
            var response = await _clientProspetService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<clientprospetDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
