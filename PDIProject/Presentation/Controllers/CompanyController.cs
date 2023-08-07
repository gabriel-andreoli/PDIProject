﻿using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Services;
using System.Net;

namespace PDIProject.Presentation.Controllers
{
    [ApiController]
    [Route("v1/company")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var result = _companyService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _companyService.GetBydId(id);
            if (result == null)
                return NotFound("The id not exists or not found");

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateCompany(Company company)
        {
            if (company == null)
                return BadRequest("Data is null");

            _companyService.CreateCompany(company);
            return StatusCode(201);
        }
    }
}
