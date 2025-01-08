//using Microsoft.AspNetCore.Mvc;
//using Npgsql;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;

//namespace Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UploadDocument : ControllerBase
//    {
//        private readonly string _connectionString = "Host=cratedb-test.aks1.eastus2.azure.cratedb.net;Port=5432;Username=admin;Password=R))4nF2Gy,cTG742XP1)3m!v;Database=migratepro";
//        private readonly ILogger<UploadDocument> _logger;

//        public UploadDocument(ILogger<UploadDocument> logger)
//        {
//            _logger = logger;
//        }

//        // POST api/uploaddocument/submit-forms
//        [HttpPost("SubmitForms")]
//        public async Task<IActionResult> SubmitForms([FromBody] List<MapDocRequest> data)
//        {
//            // Check if the data is null or empty
//            if (data == null || data.Count == 0)
//            {
//                return BadRequest("Invalid data. Expected a list of records.");
//            }

//            try
//            {
//                // Open a connection to CrateDB
//                using (var connection = new NpgsqlConnection(_connectionString))
//                {
//                    await connection.OpenAsync();

//                    foreach (var record in data)
//                    {
//                        // Prepare the SQL query
//                        var sql = @"
//                            INSERT INTO map_doc (
//                                sq_no, field_description_mc, field_name_ltmc, target_structure_description_mc,
//                                target_structure_mc, field_group, mandatory_field_s4, in_scope_for_auping, field_type, length, decimal,
//                                comments, data_cleansing_considerations, transformation_rule, source_field_1_to_1_mapping,
//                                cross_reference_table, default_value, conversion_rules_logic, reusable_logic_y_n,
//                                critical_error_handling_if_applicable, comments2, source_group_view,
//                                source_table_name, source_field_name, source_field_description, source_data_type,
//                                source_data_length, view_field_name, filename, obj, updated_by, email
//                            )
//                            VALUES (
//                                @sq_no, @field_description_mc, @field_name_ltmc, @target_structure_description_mc,
//                                @target_structure_mc, @field_group, @mandatory_field_s4, @in_scope_for_auping, @field_type, @length, @decimal,
//                                @comments, @data_cleansing_considerations, @transformation_rule, @source_field_1_to_1_mapping,
//                                @cross_reference_table, @default_value, @conversion_rules_logic, @reusable_logic_y_n,
//                                @critical_error_handling_if_applicable, @comments2, @source_group_view,
//                                @source_table_name, @source_field_name, @source_field_description, @source_data_type,
//                                @source_data_length, @view_field_name, @filename, @obj, @updated_by, @email
//                            );
//                        ";

//                        // Execute the SQL query for each record
//                        using (var cmd = new NpgsqlCommand(sql, connection))
//                        {
//                            cmd.Parameters.AddWithValue("sq_no", record.SqNo);
//                            cmd.Parameters.AddWithValue("field_description_mc", record.FieldDescriptionMc);
//                            cmd.Parameters.AddWithValue("field_name_ltmc", record.FieldNameLtmc);
//                            cmd.Parameters.AddWithValue("target_structure_description_mc", record.TargetStructureDescriptionMc);
//                            cmd.Parameters.AddWithValue("target_structure_mc", record.TargetStructureMc);
//                            cmd.Parameters.AddWithValue("field_group", record.FieldGroup);
//                            cmd.Parameters.AddWithValue("mandatory_field_s4", record.MandatoryFieldS4);
//                            cmd.Parameters.AddWithValue("in_scope_for_auping", record.InScopeForAuping);
//                            cmd.Parameters.AddWithValue("field_type", record.FieldType);
//                            cmd.Parameters.AddWithValue("length", record.Length);
//                            cmd.Parameters.AddWithValue("decimal", record.Decimal);
//                            cmd.Parameters.AddWithValue("comments", record.Comments);
//                            cmd.Parameters.AddWithValue("data_cleansing_considerations", record.DataCleansingConsiderations);
//                            cmd.Parameters.AddWithValue("transformation_rule", record.TransformationRule);
//                            cmd.Parameters.AddWithValue("source_field_1_to_1_mapping", record.SourceField1To1Mapping);
//                            cmd.Parameters.AddWithValue("cross_reference_table", record.CrossReferenceTable);
//                            cmd.Parameters.AddWithValue("default_value", record.DefaultValue);
//                            cmd.Parameters.AddWithValue("conversion_rules_logic", record.ConversionRulesLogic);
//                            cmd.Parameters.AddWithValue("reusable_logic_y_n", record.ReusableLogicYN);
//                            cmd.Parameters.AddWithValue("critical_error_handling_if_applicable", record.CriticalErrorHandlingIfApplicable);
//                            cmd.Parameters.AddWithValue("comments2", record.Comments2);
//                            cmd.Parameters.AddWithValue("source_group_view", record.SourceGroupView);
//                            cmd.Parameters.AddWithValue("source_table_name", record.SourceTableName);
//                            cmd.Parameters.AddWithValue("source_field_name", record.SourceFieldName);
//                            cmd.Parameters.AddWithValue("source_field_description", record.SourceFieldDescription);
//                            cmd.Parameters.AddWithValue("source_data_type", record.SourceDataType);
//                            cmd.Parameters.AddWithValue("source_data_length", record.SourceDataLength);
//                            cmd.Parameters.AddWithValue("view_field_name", record.ViewFieldName);
//                            cmd.Parameters.AddWithValue("filename", record.Filename);
//                            cmd.Parameters.AddWithValue("obj", record.Obj);
//                            cmd.Parameters.AddWithValue("updated_by", record.UpdatedBy);
//                            cmd.Parameters.AddWithValue("email", record.Email);

//                            await cmd.ExecuteNonQueryAsync();
//                        }
//                    }
//                }

//                return Ok(new { message = "Data inserted successfully." });
//            }
//            catch (Exception ex)
//            {
//                // Log the error and return a 500 status code
//                _logger.LogError("Error inserting data: " + ex.Message);
//                return StatusCode(500, new { error = ex.Message });
//            }
//        }
//    }

//    // Define the MapDocRequest model here
//    public class MapDocRequest
//    {
//        public string SqNo { get; set; }
//        public string FieldDescriptionMc { get; set; }
//        public string FieldNameLtmc { get; set; }
//        public string TargetStructureDescriptionMc { get; set; }
//        public string TargetStructureMc { get; set; }
//        public string FieldGroup { get; set; }
//        public string MandatoryFieldS4 { get; set; }
//        public string InScopeForAuping { get; set; }
//        public string FieldType { get; set; }
//        public string Length { get; set; }
//        public string Decimal { get; set; }
//        public string Comments { get; set; }
//        public string DataCleansingConsiderations { get; set; }
//        public string TransformationRule { get; set; }
//        public string SourceField1To1Mapping { get; set; }
//        public string CrossReferenceTable { get; set; }
//        public string DefaultValue { get; set; }
//        public string ConversionRulesLogic { get; set; }
//        public string ReusableLogicYN { get; set; }
//        public string CriticalErrorHandlingIfApplicable { get; set; }
//        public string Comments2 { get; set; }
//        public string SourceGroupView { get; set; }
//        public string SourceTableName { get; set; }
//        public string SourceFieldName { get; set; }
//        public string SourceFieldDescription { get; set; }
//        public string SourceDataType { get; set; }
//        public string SourceDataLength { get; set; }
//        public string ViewFieldName { get; set; }
//        public string Filename { get; set; }
//        public string Obj { get; set; }
//        public string UpdatedBy { get; set; }
//        public string Email { get; set; }
//    }
//}
