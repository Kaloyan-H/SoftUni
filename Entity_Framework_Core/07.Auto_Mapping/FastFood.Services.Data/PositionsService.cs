﻿using AutoMapper;
using FastFood.Web.ViewModels.Positions;
using FastFood.Data;
using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace FastFood.Services.Data
{
    public class PositionsService : IPositionsService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public PositionsService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task CreateAsync(CreatePositionInputModel inputModel)
        {
            Position position = this.mapper.Map<Position>(inputModel);

            await this.context.Positions.AddAsync(position);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PositionsAllViewModel>> GetAllAsync()
            => await this.context.Positions
                .ProjectTo<PositionsAllViewModel>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();
    }
}