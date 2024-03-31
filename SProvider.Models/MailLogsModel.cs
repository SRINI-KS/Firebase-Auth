namespace SProvider.Models{
			using System;
			using System.ComponentModel.DataAnnotations;
			using Microsoft.AspNetCore.Mvc;
			using System.Collections.Generic;
			using FluentValidation;
			using System.Linq;
			//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:21
			public class MailLogsModel
			{

			 public System.Guid ?MailLogsid	{ get; set; }

[xssFilter]
public String entityname{ get; set; }

[xssFilter]
public String entityid{ get; set; }

[xssFilter]
public String mailfor{ get; set; }

[xssFilter]
public String mailsubject{ get; set; }

[xssFilter]
public String mailto{ get; set; }

[xssFilter]
public String mailbody{ get; set; }

public bool issent	{ get; set; }
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
[xssFilter]
                        [Required(ErrorMessage = "craftmyapp_actionmethodname is required,please pass current action name")]
                        public String craftmyapp_actionmethodname{ get; set; }



			}
			

			public class MailLogsModelValidator: AbstractValidator<MailLogsModel>
			{
					 
					public MailLogsModelValidator()
					{

						 When(model => model.craftmyapp_actionmethodname == "Create_MailLog", () =>
                                    {
                                        {RuleFor(m => m.entityname)
.NotEmpty().WithMessage("Entity Name is required")
.MaximumLength(128).WithMessage("The allowed length of Entity Name is 128 characters or fewer")
;






}

                                    });
When(model => model.craftmyapp_actionmethodname == "Update_MailLog", () =>
                                    {
                                        {RuleFor(m => m.entityname)
.NotEmpty().WithMessage("Entity Name is required")
.MaximumLength(128).WithMessage("The allowed length of Entity Name is 128 characters or fewer")
;






}

                                    });

						 
						
					}

			}

			

            


 


			}
