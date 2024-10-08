﻿using AutoMapper;
using RecipeSharingPlatform.Application.Common.Interfaces;
using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Application.Services.Interfaces;
using RecipeSharingPlatform.Domain.Entities;
using System.Collections.Generic;

namespace RecipeSharingPlatform.Infrastructure.Implementations
{
    public class RecipeLabelService : IRecipeLabelService
    {
        // inject IUnitOfWork
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecipeLabelService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #region Get Labels
        public async Task<IEnumerable<LabelDTO>> GetAllLabelsAsync()
        {
            try
            {
                return _mapper.Map<IEnumerable<LabelDTO>>(_unitOfWork.RecipeLabel.GetAll(includeProperties: "Recipes"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RecipeDTO>> GetLabelRecipesAsync(Guid labelId)
        {
            var labelFromDb = await _unitOfWork.RecipeLabel.GetLabelWithRecipesAsync(labelId);

            if (labelFromDb == null)
                throw new Exception("Label not found");

            // Use AutoMapper to project to DTO
            return _mapper.Map<IEnumerable<RecipeDTO>>(labelFromDb.Recipes);
        }

        public async Task<LabelDTO> GetLabelByIdAsync(Guid labelId)
        {
            try
            {
                return _mapper.Map<LabelDTO>(_unitOfWork.RecipeLabel.Get(rl => rl.Id == labelId, includeProperties: "Recipes"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        public async Task CreateLabelAsync(RecipeLabelDTO recipeLabelDTO)
        {
            try
            {
                var labelExist = _unitOfWork.RecipeLabel.Any(rl =>
                    rl.Name == recipeLabelDTO.Name);

                if (labelExist)
                    throw new Exception($"Recipe {recipeLabelDTO.Name} already exist!");

                // adding
                _unitOfWork.RecipeLabel.Add(new RecipeLabel { Name = recipeLabelDTO.Name});

                // save
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateLabelAsync(RecipeLabelDTO recipeLabelDTO)
        {
            try
            {
                // checking new name is exist
                var labelExist = _unitOfWork.RecipeLabel.Any(rl =>
                    rl.Name == recipeLabelDTO.Name);

                if (labelExist)
                    throw new Exception($"Label {recipeLabelDTO.Name} already exist!");

                var labelFromDb = _unitOfWork.RecipeLabel.Get(rl =>
                    rl.Id == recipeLabelDTO.Id) ?? throw new Exception("Label not found!");
               
                // updating field(s)
                labelFromDb.Name = recipeLabelDTO.Name;

                // updating
                _unitOfWork.RecipeLabel.Update(labelFromDb);

                // save
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteLabelAsync(Guid labelId)
        {
            try
            {
                var labelFromDb = _unitOfWork.RecipeLabel.Get(rl =>
                    rl.Id == labelId) ?? throw new Exception("Label not found!");

                // deleting
                _unitOfWork.RecipeLabel.Remove(labelFromDb);

                // save
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
