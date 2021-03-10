using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;
using JongSnamFootball.Managers.Extensions;

namespace JongSnamFootball.Managers
{
    public class FieldManager : IFieldManager
    {
        private readonly IMapper _mapper;
        private readonly IFieldRepository _fieldRepository;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public FieldManager(IMapper mapper, IFieldRepository fieldRepository, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _fieldRepository = fieldRepository;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<BasePagingDto<FieldDto>> GetFieldBySearch(SearchFieldRequest request, int currentPage, int pageSize)
        {
            var listField = await _fieldRepository.GetFieldBySearch(request);

            var listFieldDto = _mapper.Map<List<FieldDto>>(listField);

            var result = MakePaging.FieldDtotoToPaging(listFieldDto, currentPage, pageSize);

            return result;
        }

        public async Task<BasePagingDto<FieldDto>> GetFieldByStoreId(int storeId, int currentPage, int pageSize)
        {
            var listStore = await _fieldRepository.GetByStoreId(storeId);

            var listFieldDto = _mapper.Map<List<FieldDto>>(listStore);

            var result = MakePaging.FieldDtotoToPaging(listFieldDto, currentPage, pageSize);

            return result;
        }

        public async Task<FieldDetailDto> GetFieldById(int id)
        {
            var field = await _fieldRepository.GetFieldById(id);

            if (field == null)
            {
                //return false;
            }

            var result = _mapper.Map<FieldDetailDto>(field);

            return result;
        }

        public async Task<bool> AddField(AddFieldRequest request)
        {
            try
            {
                var fieldModel = _mapper.Map<FieldModel>(request.FieldRequest);
                fieldModel.CreatedDate = DateTime.Now;
                fieldModel.UpdatedDate = DateTime.Now;

                var disCountModel = _mapper.Map<DiscountModel>(request.DiscountRequest);
                disCountModel.CreatedDate = DateTime.Now;
                disCountModel.UpdatedDate = DateTime.Now;

                var pictureFields = _mapper.Map<IEnumerable<ImageFieldModel>>(request.PictureFieldRequest);

                // open begn transaction when we must insert foreign key to other tables
                await _repositoryWrapper.BeginTransactionAsync();

                // get return model to assign field id to other tables
                var fieldAfterSaved = await _repositoryWrapper.Field.CreateAsync(fieldModel);

                // Save to get Id Field then assign to discountModel and PictureFieldModel
                await _repositoryWrapper.SaveAsync();

                // assing id field before save
                disCountModel.FieldId = fieldAfterSaved.Id;
                await _repositoryWrapper.Discount.CreateAsync(disCountModel);

                // assing id field before save
                foreach (var item in pictureFields)
                {
                    item.FieldId = fieldAfterSaved.Id;
                    item.CreatedDate = DateTime.Now;
                    item.UpdatedDate = DateTime.Now;
                }

                await _repositoryWrapper.PictureField.CreateRangeAsync(pictureFields);

                await _repositoryWrapper.SaveAsync();

                // comfirm Transaction
                await _repositoryWrapper.CommitAsync();

                return true;


            }
            catch (Exception ex)
            {
                await _repositoryWrapper.RollbackAsync();
                throw ex;
            }
            finally
            {
                _repositoryWrapper.Dispose();
            }
        }

        public async Task<bool> UpdeteField(int id, UpdateFieldRequest updateFieldRequest)
        {
            try
            {
                var fieldModel = await _fieldRepository.GetFieldById(id);

                if (fieldModel == null)
                {
                    return false;
                }
                await _repositoryWrapper.BeginTransactionAsync();

                //field = _mapper.Map<FieldModel>(updateFieldRequest.FieldRequest);

                fieldModel.Name = updateFieldRequest.Name;
                fieldModel.Size = updateFieldRequest.Size;
                fieldModel.Price = updateFieldRequest.Price;
                fieldModel.IsOpen = updateFieldRequest.IsOpen;

                fieldModel.DiscountModel.Percentage = updateFieldRequest.UpdateDiscountRequest.Percentage.Value;
                fieldModel.DiscountModel.StartDate = updateFieldRequest.UpdateDiscountRequest.StartDate.Value;
                fieldModel.DiscountModel.EndDate = updateFieldRequest.UpdateDiscountRequest.EndDate.Value;
                fieldModel.DiscountModel.Detail = updateFieldRequest.UpdateDiscountRequest.Detail;
                fieldModel.UpdatedDate = DateTime.Now;
                foreach (var item in updateFieldRequest.UpdatePictureFieldRequest)
                {
                    var picToUpdate = fieldModel.ImageFieldModel.Where(w => w.Id == item.Id).FirstOrDefault();
                    if (picToUpdate == null)
                    {
                        fieldModel.ImageFieldModel.Add(
                            new ImageFieldModel
                            {
                                FieldId = fieldModel.Id,
                                Image = item.Image,
                                UpdatedDate = DateTime.Now,
                                CreatedDate = DateTime.Now
                            });
                    }
                    else
                    {
                        picToUpdate.Image = item.Image;
                        picToUpdate.UpdatedDate = DateTime.Now;
                    }
                }
                _repositoryWrapper.Field.Updete(fieldModel);

                await _repositoryWrapper.SaveAsync();

                await _repositoryWrapper.CommitAsync();

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _repositoryWrapper.Dispose();
            }
        }

        public async Task<bool> DeleteField(int id)
        {
            try
            {
                var field = await _fieldRepository.GetFieldById(id);
                if (field == null)
                {
                    return false;
                }
                await _repositoryWrapper.BeginTransactionAsync();

                field.Active = false;

                _repositoryWrapper.Field.Updete(field);

                await _repositoryWrapper.SaveAsync();

                await _repositoryWrapper.CommitAsync();

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _repositoryWrapper.Dispose();
            }
        }
    }
}
