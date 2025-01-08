using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLawyer.Models
{
    [Table("map_doc")]
    public class MapDoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generate primary key
        [Column("sq_no")]
        public int SqNo { get; set; } // INTEGER type in the database

        [Column("field_description_mc")]
        public string FieldDescriptionMc { get; set; } // VARCHAR(255)

        [Column("field_name_ltmc")]
        public string FieldNameLtmc { get; set; } // VARCHAR(255)

        [Column("target_structure_description_mc")]
        public string TargetStructureDescriptionMc { get; set; } // VARCHAR(255)

        [Column("target_structure_mc")]
        public string TargetStructureMc { get; set; } // VARCHAR(255)

        [Column("field_group")]
        public string? FieldGroup { get; set; } // VARCHAR(255)

        [Column("mandatory_field_s4")]
        public string? MandatoryFieldS4 { get; set; } // Make it nullable

        [Column("in_scope_for_auping")]
        public string? InScopeForAuping { get; set; } // VARCHAR(50)

        [Column("field_type")]
        public string FieldType { get; set; } // VARCHAR(50)

        [Column("length")]
        public string Length { get; set; } // VARCHAR(50)

        [Column("decimal")]
        public int? Decimal { get; set; } // INTEGER, nullable

        [Column("comments")]
        public string? Comments { get; set; } // TEXT, nullable

        [Column("data_cleansing_considerations")]
        public string? DataCleansingConsiderations { get; set; } // TEXT, nullable

        [Column("transformation_rule")]
        public string? TransformationRule { get; set; } // TEXT, nullable

        [Column("source_field_1_to_1_mapping")]
        public string? SourceField1To1Mapping { get; set; } // VARCHAR(255), nullable

        [Column("cross_reference_table")]
        public string? CrossReferenceTable { get; set; } // VARCHAR(255), nullable

        [Column("default_value")]
        public string? DefaultValue { get; set; } // VARCHAR(255), nullable

        [Column("conversion_rules_logic")]
        public string? ConversionRulesLogic { get; set; } // TEXT, nullable

        [Column("reusable_logic_y_n")]
        [MaxLength(1)] // Restrict the maximum length to 1 character
        public string? ReusableLogicYN { get; set; } // CHARACTER(1)

        [Column("critical_error_handeling_if_applicable")]
        public string? CriticalErrorHandlingIfApplicable { get; set; } // TEXT, nullable

        [Column("comments2")]
        public string? Comments2 { get; set; } // TEXT, nullable

        [Column("source_group_view")]
        public string? SourceGroupView { get; set; } // VARCHAR(255), nullable

        [Column("source_table_name")]
        public string? SourceTableName { get; set; } // VARCHAR(255)

        [Column("source_field_name")]
        public string? SourceFieldName { get; set; } // VARCHAR(255)

        [Column("source_field_description")]
        public string? SourceFieldDescription { get; set; } // TEXT, nullable

        [Column("source_data_type")]
        public string? SourceDataType { get; set; } // VARCHAR(50), nullable

        [Column("source_data_length")]
        public int? SourceDataLength { get; set; } // INTEGER, nullable

        [Column("view_field_name")]
        public string? ViewFieldName { get; set; } // VARCHAR(255)

        [Column("filename")]
        public string? Filename { get; set; } // VARCHAR(255)

        [Column("obj")]
        public string? Obj { get; set; } // VARCHAR(255)

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } // TIMESTAMP WITHOUT TIME ZONE, nullable

        [Column("updated_by")]
        public string? UpdatedBy { get; set; } // VARCHAR(255)

        [Column("email")]
        public string Email { get; set; } // VARCHAR(255)
    }
}
