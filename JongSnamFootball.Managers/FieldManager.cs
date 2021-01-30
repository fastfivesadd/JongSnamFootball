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

        public async Task<BasePagingDto<FieldDto>> GetFieldByStoreId(int storeId, int currentPage, int pageSize)
        {
            var listStore = await _fieldRepository.GetByStoreID(storeId);

            var listFieldDto = _mapper.Map<List<FieldDto>>(listStore);

            var result = MakePaging.FieldDtotoToPaging(listFieldDto, currentPage, pageSize);

            return result;
        }


        public async Task<FieldByIdFieldDto> GetFieldById(int id)
        {
            var field = await _fieldRepository.GetFieldById(id);

            var result = _mapper.Map<FieldByIdFieldDto>(field);

            return result;
        }

        public async Task<bool> AddField(AddFieldRequest request)
        {
            try
            {
                var fieldModel = _mapper.Map<FieldModel>(request.FieldRequest);

                var disCountModel = _mapper.Map<DiscountModel>(request.DiscountRequest);

                var pictureFields = _mapper.Map<IEnumerable<PictureFieldModel>>(request.PictureFieldRequest);

                // open begn transaction when we must insert foreign key to other tables
                await _repositoryWrapper.BeginTransactionAsync();

                // get return model to assign field id to other tables
                var fieldAfterSaved = await _repositoryWrapper.Field.CreateAsync(fieldModel);

                // Save to get Id Field then assign to discountModel and PictureFieldModel
                await _repositoryWrapper.SaveAsync();

                // assing id field before save
                disCountModel.IdField = fieldAfterSaved.Id;
                await _repositoryWrapper.Discount.CreateAsync(disCountModel);

                // assing id field before save
                foreach (var item in pictureFields)
                {
                    item.IdField = fieldAfterSaved.Id;
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
                var field = await _fieldRepository.GetFieldById(id);

                if (field == null)
                {
                    return false;
                }
                await _repositoryWrapper.BeginTransactionAsync();

                //field = _mapper.Map<FieldModel>(updateFieldRequest.FieldRequest);

                field.Name = updateFieldRequest.Name;
                field.Size = updateFieldRequest.Size;
                field.Price = updateFieldRequest.Price;
                field.Status = updateFieldRequest.Status;

                field.DiscountModel.Percentage = updateFieldRequest.UpdateDiscountRequest.Percentage.GetValueOrDefault();
                field.DiscountModel.StartTime = updateFieldRequest.UpdateDiscountRequest.StartTime.GetValueOrDefault();
                field.DiscountModel.EndTime = updateFieldRequest.UpdateDiscountRequest.EndTime.GetValueOrDefault();
                field.DiscountModel.Detail = updateFieldRequest.UpdateDiscountRequest.Detail;

                foreach (var item in updateFieldRequest.UpdatePictureFieldRequest)
                {
                    var picToUpdate = field.PictureFieldModel.Where(w => w.Id == item.Id).FirstOrDefault();
                    if (picToUpdate == null)
                    {
                        field.PictureFieldModel.Add(
                            new PictureFieldModel
                            {
                                IdField = field.Id,
                                Picture = item.Picture,
                                Date = item.Date
                            });
                    }
                    else
                    {
                        picToUpdate.Picture = item.Picture;
                        picToUpdate.Date = item.Date;
                    }
                }

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
