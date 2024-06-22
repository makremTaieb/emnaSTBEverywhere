using AutoMapper;
using clientprospetweb.models;
using clientprospetweb.models.Dto;
using clientprospetweb.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace clientprospetweb.Controllers
{
    public class clientprospetController : Controller
    {
        private readonly IClientProspetService _clientProspetService;
        private readonly IMapper _mapper;
        public clientprospetController(IClientProspetService clientProspetService, IMapper mapper)
        {
            _clientProspetService = clientProspetService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Indexclientprospet()
        {
            List<clientprospetDTO> list = new();
            var response = await _clientProspetService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<clientprospetDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public async Task<IActionResult> Createclientprospet()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Createclientprospet(clientprospetCreateDTO model)
        {
            if(ModelState.IsValid)
            {
                var response = await _clientProspetService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "ClientProspect created successfully";
                    return RedirectToAction(nameof(Indexclientprospet));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        public async Task<IActionResult> Updateclientprospet(int clientprospetId)
        {
            var response = await _clientProspetService.GetAsync<APIResponse>(clientprospetId);
            if (response != null && response.IsSuccess)
            {
                clientprospetDTO model = JsonConvert.DeserializeObject<clientprospetDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<clientprospetUpdateDTO>(model));
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Updateclientprospet(clientprospetUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "ClientProspect updated successfully";
                var response = await _clientProspetService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Indexclientprospet));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        public async Task<IActionResult> Deleteclientprospet(int clientprospetId)
        {
            var response = await _clientProspetService.GetAsync<APIResponse>(clientprospetId);
            if (response != null && response.IsSuccess)
            {
                clientprospetDTO model = JsonConvert.DeserializeObject<clientprospetDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deleteclientprospet(clientprospetDTO model)
        {
                var response = await _clientProspetService.DeleteAsync<APIResponse>(model.Id_client);
                if (response != null && response.IsSuccess)
                {
                TempData["success"] = "ClientProspect deleted successfully";
                return RedirectToAction(nameof(Indexclientprospet));
                }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
    }
}
