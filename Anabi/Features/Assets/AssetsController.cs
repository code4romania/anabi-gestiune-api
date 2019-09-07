﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Anabi.Features.Assets.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Anabi.Controllers;
using Anabi.Domain.Asset.Commands;
using Anabi.Middleware;
using Anabi.Common.ViewModels;
using Anabi.Domain.Core.Asset.Commands;
using AutoMapper;
using Anabi.Infrastructure;
using Anabi.Common.Cache;

namespace Anabi.Features.Assets
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/assets")]
    public class AssetsController : CacheableController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public AssetsController(IMediator _mediator, IMapper _mapper, AnabiCacheManager cache) 
            : base(cache)
        {
            mediator = _mediator;
            mapper = _mapper;
        }

        /// <summary>
        /// Returns a list of assets
        /// </summary>
        /// <response code="200">The list of assets</response>
        /// <returns>The list of assets</returns>
        [ProducesResponseType(typeof(IEnumerable<AssetSummary>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await mediator.Send(new SearchAsset());

            return Ok(results);
        }



        // GET: api/Assets/5
        /// <summary>
        /// Returns the minimal asset for the supplied id
        /// </summary>
        /// <response code="200">The asset for the supplied id</response>
        /// <response code="400">The asset is not found</response>
        /// <response code="500">Server error</response>
        /// <param name="id">Must be greater than or equal to 0</param>
        /// <returns>Minimal asset details</returns>
        [ProducesResponseType(typeof(MinimalAssetViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await mediator.Send(new GetAssetDetails { Id = id });

            return Ok(model);
        }


        /// <summary>
        /// Adds a new asset with minimal required details
        /// </summary>
        /// <remarks>
        /// <para>
        /// Returns the id of the newly added asset
        /// Validation Errors:
        /// NAME_NOT_EMPTY
        /// NAME_MAX_LENGTH_100 
        /// IDENTIFIER_MAX_LENGTH_100
        /// INVALID_CATEGORY_ID -- if CategoryId lower than or equal to zero, or the category does not exist
        /// INVALID_STAGE_ID -- if StageId lower than or equal to zero, or the stage id does not exist
        /// MEASUREUNIT_MAX_LENGTH_10 -- measure unit max 10 characters
        /// ESTIMATED_AMT_CURRENCY_THREE_CHARS -- currency must have 3 characters (if not empty) (USD, RON, EUR)
        /// </para>
        /// </remarks>
        /// <response code="201">The id of the new asset</response>
        /// <response code="400">In case of validation errors</response>
        /// <response code="500">Server error</response>
        /// <param name="minimalAsset">The details of the new asset to be added</param>
        /// <returns>The id of the new asset</returns>
        [ProducesResponseType(typeof(MinimalAssetViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("addminimalasset")]
        public async Task<IActionResult> AddMinimalAsset([FromBody]AddMinimalAsset minimalAsset)
        {
            var id = await mediator.Send(minimalAsset);
            return Created("api/assets", id);
        }
        
        /// <summary>
        /// Adds a new asset with minimal required details
        /// </summary>
        /// <remarks>
        /// <para>
        /// Returns the id of the newly added asset
        /// Validation Errors:
        /// NAME_NOT_EMPTY
        /// NAME_MAX_LENGTH_100 
        /// IDENTIFIER_MAX_LENGTH_100
        /// INVALID_CATEGORY_ID -- if CategoryId lower than or equal to zero, or the category does not exist
        /// INVALID_STAGE_ID -- if StageId lower than or equal to zero, or the stage id does not exist
        /// MEASUREUNIT_MAX_LENGTH_10 -- measure unit max 10 characters
        /// ESTIMATED_AMT_CURRENCY_THREE_CHARS -- currency must have 3 characters (if not empty) (USD, RON, EUR)
        /// </para>
        /// </remarks>
        /// <response code="201">The id of the modified asset</response>
        /// <response code="400">In case of validation errors</response>
        /// <response code="500">Server error</response>
        /// <param name="minimalAsset">The details of the existing asset to be modified</param>
        /// <param name="id">The id of the existing asset to be modified</param>
        /// <returns>The id of the modified asset</returns>
        [ProducesResponseType(typeof(MinimalAssetViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPut("{id}/minimalasset")]
        public async Task<IActionResult> ModifyMinimalAsset(int id, [FromBody] ModifyMinimalAssetRequest minimalAsset)
        {
            var modifyMinimalAssetObj = new ModifyMinimalAssetModel {Id = id, ModifyMinimalAsset = minimalAsset};
            var viewModel = await mediator.Send(modifyMinimalAssetObj);
            return Ok(viewModel);
        }


        /// <summary>
        /// Gets the possible stages for an asset
        /// </summary>
        /// <response code="200">The list of stages</response>
        /// <response code="400"></response>
        /// <response code="500">Server error</response>
        /// <returns>The possible stages</returns>
        [ProducesResponseType(typeof(List<StageViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("stages")]
        public async Task<IActionResult> GetStages()
        {
            var models = await mediator.Send(new GetStages());
            return Ok(models);
        }

        /// <summary>
        /// Gets the parent categories
        /// </summary>
        /// <response code="200">The list of parent categories</response>
        /// <response code="400"></response>
        /// <response code="500">Server error</response>
        /// <returns>The parent categories</returns>
        [ProducesResponseType(typeof(List<CategoryViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("parentcategories")]
        public async Task<IActionResult> GetParentCategories()
        {
            var models = await this.GetOrSetFromCacheAsync(
                key: CacheKeys.AssetParentCategories,
                size: 10,
                deleg: () => mediator.Send(new GetCategories() { ParentsOnly = true })
                );

            return Ok(models);
        }


        /// <summary>
        /// Gets the children categories for a Parent Id
        /// </summary>
        /// <remarks>
        /// <para>
        /// Returns the children categories for a Parent Id
        /// Validation Errors:
        /// INVALID_ID
        /// </para>
        /// </remarks>
        /// <response code="200">The list of subcategories</response>
        /// <response code="400"></response>
        /// <response code="500">Server error</response>
        /// <returns>The subcategories</returns>
        [ProducesResponseType(typeof(List<CategoryViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("subcategories/{parentId:int}")]
        public async Task<IActionResult> GetSubCategories(int parentId)
        {
            var models = await this.GetOrSetFromCacheAsync(
                key: CacheKeys.AssetSubcategories,
                size: 10,
                deleg: () => mediator.Send(new GetCategories() { ParentsOnly = false, ParentId = parentId })
                );

            return Ok(models);
        }

        [ProducesResponseType(typeof(AddressViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("{assetId}/address")]
        public async Task<IActionResult> AddAssetAddress(int assetId, [FromBody] AddAssetAddressRequest request)
        {
            var message = new AddAssetAddress(assetId, request.CountyId, request.Street, request.City, request.Building, request.Description);

            var model = await mediator.Send(message);

            return Created("api/address", model);
        }
        
        [ProducesResponseType(typeof(AddressViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpPut("{assetId}/address")]
        public async Task<IActionResult> ModifyAssetAddress(int assetId, [FromBody] ModifyAssetAddressRequest assetAddress)
        {
            var modifyAssetAddressObj = new ModifyAssetAddressModel {AssetId = assetId, ModifyAssetAddress = assetAddress};
            var viewModel = await mediator.Send(modifyAssetAddressObj);
            return Ok(viewModel);
        }

        [ProducesResponseType(typeof(AddressViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AnabiExceptionResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{assetId}/address")]
        public async Task<IActionResult> GetAssetAddress(int assetId)
        {
            var request = new GetAssetAddress(assetId);
            var viewmodel = await mediator.Send(request);
            return Ok(viewmodel);
        }
    }
}
