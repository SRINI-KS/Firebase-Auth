namespace SProvider.Models{
			using System;
			using System.ComponentModel.DataAnnotations;
			using Microsoft.AspNetCore.Mvc;
			using System.Collections.Generic;
			using FluentValidation;
			using System.Linq;
			//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:20
			public class AlertTemplatesModel
			{

			 public System.Guid ?AlertTemplatesid	{ get; set; }

[xssFilter]
public String entityname{ get; set; }

[xssFilter]
public String entityaction{ get; set; }

public bool sendasbatch	{ get; set; }

[xssFilter]
public String alerttype{ get; set; }

[xssFilter]
public String alertsubject{ get; set; }

[xssFilter]
public String alertcopyto{ get; set; }

[xssFilter]
public String alertcarboncopyto{ get; set; }

[xssFilter]
public String alertcontent{ get; set; }
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
			

			public class AlertTemplatesModelValidator: AbstractValidator<AlertTemplatesModel>
			{
					 
					public AlertTemplatesModelValidator()
					{

						 When(model => model.craftmyapp_actionmethodname == "Create_Alert_Templates", () =>
                                    {
                                        {RuleFor(m => m.entityname)
.NotEmpty().WithMessage("Entity Name is required")
.MaximumLength(128).WithMessage("The allowed length of Entity Name is 128 characters or fewer")
;




RuleFor(m => m.alertcopyto)
.MaximumLength(50).WithMessage("The allowed length of Alert Copy To is 50 characters or fewer")
.EmailAddress()

;
RuleFor(m => m.alertcarboncopyto)
.MaximumLength(50).WithMessage("The allowed length of Alert Carbon Copy To  is 50 characters or fewer")
.EmailAddress()

;

}

                                    });
When(model => model.craftmyapp_actionmethodname == "Update_Alert_Templates", () =>
                                    {
                                        {RuleFor(m => m.entityname)
.NotEmpty().WithMessage("Entity Name is required")
.MaximumLength(128).WithMessage("The allowed length of Entity Name is 128 characters or fewer")
;




RuleFor(m => m.alertcopyto)
.MaximumLength(50).WithMessage("The allowed length of Alert Copy To is 50 characters or fewer")
.EmailAddress()

;
RuleFor(m => m.alertcarboncopyto)
.MaximumLength(50).WithMessage("The allowed length of Alert Carbon Copy To  is 50 characters or fewer")
.EmailAddress()

;

}

                                    });

						 
						
					}

			}

			

            


 


			}
