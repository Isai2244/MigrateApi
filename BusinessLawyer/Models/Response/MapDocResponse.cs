using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateMap.Bal.Models.Response
{
          public class MapDocResponse 
        {
        public int? SqNo { get; set; }
        public string FieldDescriptionMc { get; set; }
        public string FieldNameLtmc { get; set; }
        public string TargetStructureDescriptionMc { get; set; }
        public string TargetStructureMc { get; set; }
        public string FieldGroup { get; set; }
        public string? MandatoryFieldS4 { get; set; }
        public string InScopeForAuping { get; set; }
        public string FieldType { get; set; }
        public string? Length { get; set; } // Changed to nullable if the database allows nulls
        public int? Decimal { get; set; }
        public string? Comments { get; set; }
        public string? DataCleansingConsiderations { get; set; }
        public string? TransformationRule { get; set; }
        public string? SourceField1To1Mapping { get; set; }
        public string? CrossReferenceTable { get; set; }
        public string? DefaultValue { get; set; }
        public string? ConversionRulesLogic { get; set; }
        public string ReusableLogicYN { get; set; }
        public string? CriticalErrorHandlingIfApplicable { get; set; }
        public string? Comments2 { get; set; }
        public string? SourceGroupView { get; set; }
        public string SourceTableName { get; set; }
        public string SourceFieldName { get; set; }
        public string? SourceFieldDescription { get; set; }
        public string? SourceDataType { get; set; }
        public int? SourceDataLength { get; set; }
        public string ViewFieldName { get; set; }
        public string Filename { get; set; }
        public string Obj { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string Email { get; set; }
    }
    
}
