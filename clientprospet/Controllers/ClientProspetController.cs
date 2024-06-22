using clientprospet.models;
using clientprospet.Data;
using clientprospet.models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using clientprospet.Models;
using Azure;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using clientprospet.Repository.IRepository;
using System.Net;
using System.Net.Sockets;


namespace clientprospet.Controllers
{
    [Route("api/ClientProspet")]
    [ApiController]
    public class ClientProspetController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IClientProspetRepository _dbClient;
        private readonly IMapper _mapper;

        public ClientProspetController(IClientProspetRepository dbClient, IMapper mapper)
        {
            _dbClient = dbClient;
            _mapper = mapper;
            this._response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetClientProspets()
        {
            try
            {
                IEnumerable<ClientProspet> clientprospetList = await _dbClient.GetAllAsync();
                _response.Result = _mapper.Map<List<ClientProspetDTO>>(clientprospetList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetClientProspet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetClientProspet(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var client_prospet = await _dbClient.GetAsync(u => u.Id_client == id);
                if (client_prospet == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ClientProspetDTO>(client_prospet);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteClientProspet")]
        public async Task<ActionResult<APIResponse>> DeleteClientProspet(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var client_prospet = await _dbClient.GetAsync(u => u.Id_client == id);
                if (client_prospet == null)
                {
                    return NotFound();
                }
                await _dbClient.RemoveAsync(client_prospet);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        //[HttpPut("{id:int}", Name = "UpdateClientProspet")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<APIResponse>> UpdateClientProspet(int id, [FromBody] ClientProspetUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.Id_client)
        //        {
        //            return BadRequest();
        //        }
        //        ClientProspet model = _mapper.Map<ClientProspet>(updateDTO);

        //        await _dbClient.UpdateAsync(model);
        //        _response.StatusCode = HttpStatusCode.NoContent;
        //        _response.IsSuccess = true;
        //        return Ok(_response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //    }
        //    return _response;
        //}
        [HttpPatch("{id:int}", Name = "UpdateClientProspet")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialClientProspet(int id, JsonPatchDocument<ClientProspetUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var client_prospet = await _dbClient.GetAsync(u => u.Id_client == id, tracked: false);
            ClientProspetUpdateDTO clientprospetDTO = _mapper.Map<ClientProspetUpdateDTO>(client_prospet);

            if (client_prospet == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(clientprospetDTO, ModelState);
            ClientProspet model = _mapper.Map<ClientProspet>(clientprospetDTO);

            await _dbClient.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
        // patite postttt 
        [Route("Identification")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateClientProspet([FromBody] ClientProspetStep1CreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    return BadRequest("Invalid data");
                }

                var existingClientProspect = await _dbClient.GetByEmailAsync(createDTO.Email);
                if (existingClientProspect != null)
                {
                    return BadRequest($"Un client prospet avec l'email '{createDTO.Email}' existe déjà.");
                }

                var clientProspect = _mapper.Map<ClientProspet>(createDTO);

                await _dbClient.CreateAsync(clientProspect);

                var responseDTO = new ClientProspetDTO
                {
                    Id_client = clientProspect.Id_client,
                    Nom = clientProspect.Nom,
                    Prenom = clientProspect.Prenom,
                    Email = clientProspect.Email,
                    Civilite = clientProspect.Civilite,
                    Mobile = clientProspect.Mobile,
                    PaysDeNaissance = clientProspect.PaysDeNaissance,
                    DateDeNaissance = clientProspect.DateDeNaissance
                };

                return CreatedAtRoute("GetClientProspet", new { id = clientProspect.Id_client }, responseDTO);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }


        }
        [HttpPost("{clientId}/add-address")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> AddAddressToClientProspect(int clientId, [FromBody] AdresseDTO addressDTO)
        {
            try
            {
                // Vérifiez si le client prospect existe
                var clientProspect = await _dbClient.GetByIdAsync(clientId);
                if (clientProspect == null)
                {
                    return NotFound("Client prospect not found.");
                }

                // Créez une nouvelle adresse et liez-la au client prospect
                var newAddress = new Adresse
                {
                    Gouvernorat = addressDTO.Gouvernorat,
                    Pays = addressDTO.Pays,
                    Ville = addressDTO.Ville,
                    CodePostal = (int) addressDTO.CodePostal,
                    ClientId = clientProspect.Id_client,
                    Rue = addressDTO.Rue,
                    Numéro = addressDTO.Numéro
                };

                // Ajoutez l'adresse au client prospect
                await _dbClient.AddAdresseToClientProspect(clientProspect.Id_client, newAddress);

                // Retournez une réponse réussie
                return CreatedAtAction(nameof(GetClientProspet), new { id = clientProspect.Id_client}, new { message = "Address added successfully." });
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
                return _response;
            }
        }
        [HttpPost("{clientId}/add-MobileClient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> AddMobileClientToClientProspect(int clientId, [FromBody] MobileClientDTO mobileclientdto)
        {
            try
            {
                // Vérifiez si le client prospect existe
                var clientProspect = await _dbClient.GetByIdAsync(clientId);
                if (clientProspect == null)
                {
                    return NotFound("Client prospect not found.");
                }

                // Créez un nouveau mobileclient et liez-la au client prospect
                var newMobileClient = new MobileClient
                {
                    Numérotéléphone = mobileclientdto.Numérotéléphone,
                    Default = mobileclientdto.Default,
                    Qualification = mobileclientdto.Qualification,
                    Statut = mobileclientdto.Statut,
                    ClientId = clientProspect.Id_client,
                    
                };

                // Ajoutez l'adresse au client prospect
                await _dbClient.AddMobileClientToClientProspect(clientProspect.Id_client, newMobileClient);

                // Retournez une réponse réussie
                return CreatedAtAction(nameof(GetClientProspet), new { id = clientProspect.Id_client }, new { message = "MobileClient added successfully." });
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
                return _response;
            }
        }
        [HttpPost("{clientId}/add-Documents")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> AddDocumentsToClientProspect(int clientId, [FromBody] DocumentDTO documentsdto)
        {
            try
            {
                // Vérifiez si le client prospect existe
                var clientProspect = await _dbClient.GetByIdAsync(clientId);
                if (clientProspect == null)
                {
                    return NotFound("Client prospect not found.");
                }

                // Créez un nouveau mobileclient et liez-la au client prospect
                var newDocuments = new Documents
                {
                    Convention = documentsdto.Convention,
                    Contrat = documentsdto.Contrat,
                    Type = documentsdto.Type,
                    Numéro = documentsdto.Numéro,
                    ClientId = clientProspect.Id_client,
                    Path = documentsdto.Path,

                };

                // Ajoutez l'adresse au client prospect
                await _dbClient.AddDocumentsToClientProspect(clientProspect.Id_client, newDocuments);

                // Retournez une réponse réussie
                return CreatedAtAction(nameof(GetClientProspet), new { id = clientProspect.Id_client }, new { message = "Documents added successfully." });
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
                return _response;
            }
        }
       
        [HttpPost("{clientId}/add-MailClient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> AddMailClientToClientProspect(int clientId, [FromBody] MailClientDTO mailclientdto)
        {
            try
            {
                // Vérifiez si le client prospect existe
                var clientProspect = await _dbClient.GetByIdAsync(clientId);
                if (clientProspect == null)
                {
                    return NotFound("Client prospect not found.");
                }

                // Créez un nouveau mobileclient et liez-la au client prospect
                var newMailClient = new MailClient
                {
                    Email = mailclientdto.Email,
                    Default = mailclientdto.Default,
                    Statut = mailclientdto.Statut,
                    Qualification = mailclientdto.Qualification,
                    ClientId = clientProspect.Id_client,

                };

                // Ajoutez l'adresse au client prospect
                await _dbClient.AddMailClientToClientProspect(clientProspect.Id_client, newMailClient);

                // Retournez une réponse réussie
                return CreatedAtAction(nameof(GetClientProspet), new { id = clientProspect.Id_client }, new { message = "MailClient added successfully." });
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
                return _response;
            }
        }
        [HttpPost("{clientId}/add-FATCA")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> AddFATCAToClientProspect(int clientId, [FromBody] FATCADTO fatcadto)
        {
            try
            {
                // Vérifiez si le client prospect existe
                var clientProspect = await _dbClient.GetByIdAsync(clientId);
                if (clientProspect == null)
                {
                    return NotFound("Client prospect not found.");
                }

                // Créez un nouveau mobileclient et liez-la au client prospect
                var newFATCA = new FATCA
                {
                    PDPUSA = fatcadto.PDPUSA,
                    VPVCEtatsUnis = fatcadto.VPVCEtatsUnis,
                    TelUS = fatcadto.TelUS,
                    GreenCard = fatcadto.GreenCard,
                    AdresseUS = fatcadto.AdresseUS,
                    ClientId = clientProspect.Id_client,

                };

                // Ajoutez l'adresse au client prospect
                await _dbClient.AddFATCAToClientProspect(clientProspect.Id_client, newFATCA);

                // Retournez une réponse réussie
                return CreatedAtAction(nameof(GetClientProspet), new { id = clientProspect.Id_client }, new { message = "FATCA added successfully." });
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
                return _response;
            }
        }
        [HttpPost("{clientId}/add-CIN")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> AddCINToClientProspect(int clientId, [FromBody] CINDTO cindto)
        {
            try
            {
                // Vérifiez si le client prospect existe
                var clientProspect = await _dbClient.GetByIdAsync(clientId);
                if (clientProspect == null)
                {
                    return NotFound("Client prospect not found.");
                }

                // Créez un nouveau mobileclient et liez-la au client prospect
                var newCIN = new CIN
                {
                    NuméroCIN= cindto.NuméroCIN,
                    Nom = cindto.Nom,
                    Prénom = cindto.Prénom,
                    DateDeNaissance = cindto.DateDeNaissance,
                    LieuDeNaissance = cindto.LieuDeNaissance,
                    NomEtPrénomDeMére = cindto.NomEtPrénomDeMére,
                    Emploi = cindto.Emploi,
                    Adresse = cindto.Adresse,
                    DateDeDélivrance = cindto.DateDeDélivrance,
                    Image = cindto.Image,
                    ClientId = clientProspect.Id_client,

                };

                // Ajoutez l'adresse au client prospect
                await _dbClient.AddCINToClientProspect(clientProspect.Id_client, newCIN);

                // Retournez une réponse réussie
                return CreatedAtAction(nameof(GetClientProspet), new { id = clientProspect.Id_client }, new { message = "CIN added successfully." });
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
                return _response;
            }
        }
        [Route("{id}/MieuxVousConnaitre")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateStep1ClientProspet(int id, [FromBody] ClientProspetStep2UpdateDTO updateDTO)
        {
            try
            {
                var existingClientProspect = await _dbClient.GetAsync(c => c.Id_client == id);

                if (existingClientProspect == null)
                {
                    return NotFound();
                }

                existingClientProspect.Motif = updateDTO.Motif;
                
                existingClientProspect.Résident = updateDTO.Résident;
                

                await _dbClient.UpdateAsync(existingClientProspect);

                var responseDTO = _mapper.Map<ClientProspetDTO>(existingClientProspect);

                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }
        }
        [HttpPut("{id}/InformationsComplementaires")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateStep2ClientProspet(int id, [FromBody] ClientProspetStep3UpdateDTO updateDTO)
        {
            try
            {
                var existingClientProspect = await _dbClient.GetAsync(c => c.Id_client == id);

                if (existingClientProspect == null)
                {
                    return NotFound();
                }

                existingClientProspect.NationalitéPrincipale = updateDTO.NationalitéPrincipale;
                existingClientProspect.AutreNationalité = updateDTO.AutreNationalité;
                existingClientProspect.EtatCivil = updateDTO.EtatCivil;
                existingClientProspect.BénéficiaireEffectif = updateDTO.BénéficiaireEffectif;
                await _dbClient.UpdateAsync(existingClientProspect);

                var responseDTO = _mapper.Map<ClientProspetDTO>(existingClientProspect);

                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }
        }





        [HttpPut("{id}/InformationsFinancieres")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateStep4ClientProspet(int id, [FromBody] ClientProspetStep4UpdateDTO updateDTO)
        {
            try
            {
                var existingClientProspect = await _dbClient.GetAsync(c => c.Id_client == id);

                if (existingClientProspect == null)
                {
                    return NotFound();
                }

                existingClientProspect.StatutProfessionnel = updateDTO.StatutProfessionnel;
                existingClientProspect.RevenuNetMensuel = updateDTO.RevenuNetMensuel;
                
                existingClientProspect.NatureDeActivité = updateDTO.NatureDeActivité;
                existingClientProspect.Profession = updateDTO.Profession;
                existingClientProspect.RNE = updateDTO.RNE;
                existingClientProspect.AutreSourceRevenu = updateDTO.AutreSourceRevenu;
                await _dbClient.UpdateAsync(existingClientProspect);

                var responseDTO = _mapper.Map<ClientProspetDTO>(existingClientProspect);

                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }
        }

        [HttpPut("{id}/AutresInformations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateStep5ClientProspet(int id, [FromBody] ClientProspetStep5UpdateDTO updateDTO)
        {
            try
            {
                var existingClientProspect = await _dbClient.GetAsync(c => c.Id_client == id);

                if (existingClientProspect == null)
                {
                    return NotFound();
                }

              


                await _dbClient.UpdateAsync(existingClientProspect);

                var responseDTO = _mapper.Map<ClientProspetDTO>(existingClientProspect);

                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }
        }


        //[HttpPut("{id}/PiecesIdentite")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<APIResponse>> UpdateStep6ClientProspet(int id, [FromBody] ClientProspetStep6UpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        var existingClientProspect = await _dbClient.GetAsync(c => c.Id_client == id);

        //        if (existingClientProspect == null)
        //        {
        //            return NotFound();
        //        }

        //        //existingClientProspect.CIN = updateDTO.CIN;
        //        //existingClientProspect.ImageCINRecto = updateDTO.ImageCINRecto;
        //        //existingClientProspect.ImageCINVerso = updateDTO.ImageCINVerso;
        //        //existingClientProspect.ImageSelfie = updateDTO.ImageSelfie;
        //        //existingClientProspect.DateDeDélivrance = updateDTO.DateDeDélivrance;
        //        //existingClientProspect.TauxCorrespondance = updateDTO.TauxCorrespondance;


        //        await _dbClient.UpdateAsync(existingClientProspect);

        //        var responseDTO = _mapper.Map<ClientProspetDTO>(existingClientProspect);

        //        return Ok(responseDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //        return _response;
        //    }
        //}





        [HttpPut("{id}/ChoixAgence")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateStep7ClientProspet(int id, [FromBody] ClientProspetStep7UpdateDTO updateDTO)
        {
            try
            {
                var existingClientProspect = await _dbClient.GetAsync(c => c.Id_client == id);

                if (existingClientProspect == null)
                {
                    return NotFound();
                }

                existingClientProspect.Agence = updateDTO.Agence;
                existingClientProspect.CodeDR = updateDTO.CodeDR;
                existingClientProspect.DR = updateDTO.DR;
                existingClientProspect.Adresse_key = updateDTO.Adresse_key;
                existingClientProspect.Lattitude = updateDTO.Lattitude;
                existingClientProspect.Longitude = updateDTO.Longitude;
                existingClientProspect.Code_gov = updateDTO.Code_gov;
                existingClientProspect.Code_postal = updateDTO.Code_postal;
                existingClientProspect.Gouvernorat = updateDTO.Gouvernorat;
                existingClientProspect.Adresse_mail = updateDTO.Adresse_mail;
                existingClientProspect.Matricule_chefagence = updateDTO.Matricule_chefagence;
                existingClientProspect.Tel1 = updateDTO.Tel1;
                existingClientProspect.Tel2 = updateDTO.Tel2;
                existingClientProspect.Fax = updateDTO.Fax;
                existingClientProspect.GSM = updateDTO.GSM;
                existingClientProspect.Adresse = updateDTO.Adresse;
                existingClientProspect.Localisation = updateDTO.Localisation;
                

                await _dbClient.UpdateAsync(existingClientProspect);

                var responseDTO = _mapper.Map<ClientProspetDTO>(existingClientProspect);

                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }
        }

    }
}
