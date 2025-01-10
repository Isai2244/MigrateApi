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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; // For JObject and JArray


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
        public async Task SaveMapDoc(object request)
        {
            if (request == null)
            {
                throw new ArgumentException("Request cannot be null.");
            }

            try
            {
                if (request is JObject singleRequestObject)
                {
                    // Deserialize single object
                    var singleRequest = singleRequestObject.ToObject<MapDocRequest>();
                    var dbEntity = _mapper.Map<MapDoc>(singleRequest);
                    _unitOfWork.MapDoc.Add(dbEntity);
                }
                else if (request is JArray batchRequestArray)
                {
                    // Deserialize array
                    var batchRequests = batchRequestArray.ToObject<List<MapDocRequest>>();
                    var dbEntities = _mapper.Map<List<MapDoc>>(batchRequests);
                    _unitOfWork.MapDoc.AddRange(dbEntities);
                }
                else if (request is MapDocRequest singleRequest)
                {
                    // Handle directly deserialized single object
                    var dbEntity = _mapper.Map<MapDoc>(singleRequest);
                    _unitOfWork.MapDoc.Add(dbEntity);
                }
                else if (request is IEnumerable<MapDocRequest> batchRequests)
                {
                    // Handle directly deserialized array
                    var dbEntities = _mapper.Map<List<MapDoc>>(batchRequests);
                    _unitOfWork.MapDoc.AddRange(dbEntities);
                }
                else
                {
                    throw new ArgumentException("Invalid request format. Expected a single MapDocRequest or a collection of MapDocRequest.");
                }

                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error processing request: {ex.Message}", ex);
            }
        }


        public async Task UpdateMapDoc(object request)
        {
            if (request == null)
            {
                throw new ArgumentException("Request cannot be null.");
            }

            try
            {
                List<MapDocRequest> requests;

                if (request is JObject singleRequestObject)
                {
                    // Deserialize single object
                    var singleRequest = singleRequestObject.ToObject<MapDocRequest>();
                    requests = new List<MapDocRequest> { singleRequest };
                }
                else if (request is JArray batchRequestArray)
                {
                    // Deserialize array
                    requests = batchRequestArray.ToObject<List<MapDocRequest>>();
                }
                else if (request is MapDocRequest singleRequest)
                {
                    // Directly handle a single request object
                    requests = new List<MapDocRequest> { singleRequest };
                }
                else if (request is IEnumerable<MapDocRequest> batchRequests)
                {
                    // Directly handle a batch of requests
                    requests = batchRequests.ToList();
                }
                else
                {
                    throw new ArgumentException("Invalid request format. Expected a single MapDocRequest or a collection of MapDocRequest.");
                }

                // Extract SqNo values
                var sqNos = requests.Select(r => r.SqNo).ToList();

                // Fetch existing records in bulk
                var existingRecords = _unitOfWork.MapDoc.Find(x => sqNos.Contains(x.SqNo)).ToList();

                if (!existingRecords.Any())
                {
                    throw new Exception("No matching records found for the provided SqNo values.");
                }

                // Create a lookup for efficient matching
                var requestLookup = requests.ToDictionary(r => r.SqNo);

                foreach (var record in existingRecords)
                {
                    if (requestLookup.TryGetValue(record.SqNo, out var mapDocRequest))
                    {
                        // Update fields
                        record.FieldDescriptionMc = mapDocRequest.FieldDescriptionMc;
                        record.FieldNameLtmc = mapDocRequest.FieldNameLtmc;
                        record.TargetStructureDescriptionMc = mapDocRequest.TargetStructureDescriptionMc;
                        record.TargetStructureMc = mapDocRequest.TargetStructureMc;
                        record.FieldGroup = mapDocRequest.FieldGroup;
                        record.MandatoryFieldS4 = mapDocRequest.MandatoryFieldS4;
                        record.InScopeForAuping = mapDocRequest.InScopeForAuping;
                        record.FieldType = mapDocRequest.FieldType;
                        record.Length = mapDocRequest.Length;
                        record.Decimal = mapDocRequest.Decimal;
                        record.Comments = mapDocRequest.Comments;
                        record.DataCleansingConsiderations = mapDocRequest.DataCleansingConsiderations;
                        record.TransformationRule = mapDocRequest.TransformationRule;
                        record.SourceField1To1Mapping = mapDocRequest.SourceField1To1Mapping;
                        record.CrossReferenceTable = mapDocRequest.CrossReferenceTable;
                        record.DefaultValue = mapDocRequest.DefaultValue;
                        record.ConversionRulesLogic = mapDocRequest.ConversionRulesLogic;
                        record.ReusableLogicYN = mapDocRequest.ReusableLogicYN;
                        record.CriticalErrorHandlingIfApplicable = mapDocRequest.CriticalErrorHandlingIfApplicable;
                        record.Comments2 = mapDocRequest.Comments2;
                        record.SourceGroupView = mapDocRequest.SourceGroupView;
                        record.SourceTableName = mapDocRequest.SourceTableName;
                        record.SourceFieldName = mapDocRequest.SourceFieldName;
                        record.SourceFieldDescription = mapDocRequest.SourceFieldDescription;
                        record.SourceDataType = mapDocRequest.SourceDataType;
                        record.SourceDataLength = mapDocRequest.SourceDataLength;
                        record.ViewFieldName = mapDocRequest.ViewFieldName;
                        record.Filename = mapDocRequest.Filename;
                        record.Obj = mapDocRequest.Obj;
                        record.UpdatedAt = mapDocRequest.UpdatedAt?.ToUniversalTime() ?? DateTime.UtcNow;
                        record.UpdatedBy = mapDocRequest.UpdatedBy;
                        record.Email = mapDocRequest.Email;
                    }
                }

                // Save changes in a single transaction
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error processing update request: {ex.Message}", ex);
            }
        }






    }
}
