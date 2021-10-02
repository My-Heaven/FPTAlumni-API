﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAlumni.Business.Services.MajorSrv;
using UniAlumni.DataTier.Common.Enum;
using UniAlumni.DataTier.Common.PaginationModel;
using UniAlumni.DataTier.Models;
using UniAlumni.DataTier.Object;
using UniAlumni.DataTier.ViewModels.Major;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniAlumni.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/majors")]
    public class MajorController : ControllerBase
    {
        private readonly IMajorService _majorService;
        public MajorController(IMajorService service)
        {
            _majorService = service;
        }
        
        [HttpGet]
        public IActionResult GetMajors([FromQuery] SearchMajorModel searchMajorModel, [FromQuery] PagingParam<MajorEnum.MajorSortCriteria> paginationModel)
        {
            var majors = _majorService.GetMajors(paginationModel, searchMajorModel);
            return Ok(majors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMajor(int id)
        {
            var major = await _majorService.GetMajorById(id);
            return Ok(major);
        }

        [HttpPost]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<IActionResult> PostMajor([FromBody] MajorCreateRequest item)
        {
            MajorViewModel majorModel = await _majorService.CreateMajor(item);
            return Created(string.Empty, majorModel);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<IActionResult> UpdateMajor(int id, [FromBody] MajorUpdateRequest item)
        {
            MajorViewModel majorModel = await _majorService.UpdateMajor(id, item);
            return Ok(majorModel);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<IActionResult> DeleteMajor([FromRoute] int id)
        {
            await _majorService.DeleteMajor(id);
            return NoContent();
        }
    }
}
