namespace SProvider.Models
								{
									using System.ComponentModel.DataAnnotations;
									using Microsoft.AspNetCore.Mvc;
									//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:17
									public class lookupsModel
									{
										[Required(ErrorMessage="lookupid is Required")]
										public System.Guid lookupid	{ get; set; }
										public string entityname	{ get; set; }
										public string attributetype	{ get; set; }
										public string fieldname	{ get; set; }
										public string fielddesc	{ get; set; }
										public System.Guid ?createduser	{ get; set; }
										[DataType(DataType.Date)]
										[ModelBinder(BinderType = typeof(DateTimeModelBinder))]
										[DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
										public System.DateTime ?createddate	{ get; set; }
										public System.Guid ?modifieduser	{ get; set; }
										[DataType(DataType.Date)]
										[ModelBinder(BinderType = typeof(DateTimeModelBinder))]
										[DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
										public System.DateTime ?modifieddate	{ get; set; }
										public bool isdeleted	{ get; set; }
									}
								}
