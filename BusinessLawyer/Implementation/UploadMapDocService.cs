using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;
using MigrateMap.Bal.Interfaces;
using MigrateMap.Bal.Models.Request;
using MigrateMap.Bal.Models.Response;

namespace MigrateMap.Bal.Implementation
{
    public class UploadMapDocService:IUploadMapDocService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UploadMapDocService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task SaveMapDoc(MapDocRequest request)
        {
            var dbCorp = _mapper.Map<MapDoc>(request);
            _unitOfWork.MapDoc.Add(dbCorp);
            await _unitOfWork.SaveAsync(); // Use the async save method
        }

        public async Task UpdateMapDoc(MapDocRequest request)
        {
            // Fetch the existing record by SqNo
            var existingRecord = _unitOfWork.MapDoc.FirstOrDefault(x => x.SqNo == request.SqNo);

            if (existingRecord == null)
            {
                throw new Exception($"Record with SqNo {request.SqNo} not found.");
            }

            // Update the fields with values from the request
            existingRecord.FieldDescriptionMc = request.FieldDescriptionMc;
            existingRecord.FieldNameLtmc = request.FieldNameLtmc;
            existingRecord.TargetStructureDescriptionMc = request.TargetStructureDescriptionMc;
            existingRecord.TargetStructureMc = request.TargetStructureMc;
            existingRecord.FieldGroup = request.FieldGroup;
            existingRecord.MandatoryFieldS4 = request.MandatoryFieldS4;
            existingRecord.InScopeForAuping = request.InScopeForAuping;
            existingRecord.FieldType = request.FieldType;
            existingRecord.Length = request.Length;
            existingRecord.Decimal = request.Decimal;
            existingRecord.Comments = request.Comments;
            existingRecord.DataCleansingConsiderations = request.DataCleansingConsiderations;
            existingRecord.TransformationRule = request.TransformationRule;
            existingRecord.SourceField1To1Mapping = request.SourceField1To1Mapping;
            existingRecord.CrossReferenceTable = request.CrossReferenceTable;
            existingRecord.DefaultValue = request.DefaultValue;
            existingRecord.ConversionRulesLogic = request.ConversionRulesLogic;
            existingRecord.ReusableLogicYN = request.ReusableLogicYN;
            existingRecord.CriticalErrorHandlingIfApplicable = request.CriticalErrorHandlingIfApplicable;
            existingRecord.Comments2 = request.Comments2;
            existingRecord.SourceGroupView = request.SourceGroupView;
            existingRecord.SourceTableName = request.SourceTableName;
            existingRecord.SourceFieldName = request.SourceFieldName;
            existingRecord.SourceFieldDescription = request.SourceFieldDescription;
            existingRecord.SourceDataType = request.SourceDataType;
            existingRecord.SourceDataLength = request.SourceDataLength;
            existingRecord.ViewFieldName = request.ViewFieldName;
            existingRecord.Filename = request.Filename;
            existingRecord.Obj = request.Obj;
            existingRecord.UpdatedAt = request.UpdatedAt?.ToUniversalTime() ?? DateTime.UtcNow;
            existingRecord.UpdatedBy = request.UpdatedBy;
            existingRecord.Email = request.Email;

            // Mark the entity as modified
            _unitOfWork.MapDoc.Update(existingRecord);

            // Save changes asynchronously
            await _unitOfWork.SaveAsync();
        }




    }
}
