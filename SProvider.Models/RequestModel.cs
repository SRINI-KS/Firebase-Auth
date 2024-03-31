namespace SProvider.Models{
			using System;
			using System.ComponentModel.DataAnnotations;
			using Microsoft.AspNetCore.Mvc;
			using System.Collections.Generic;
			using FluentValidation;
			using System.Linq;
			//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:42:33
			public class RequestModel
			{

			 public System.Guid ?Requestid	{ get; set; }
public System.Guid ?tenantid { get; set; }

[xssFilter]
public String name{ get; set; }

[xssFilter]
public String email{ get; set; }

[xssFilter]
public String mobilenumber{ get; set; }
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
			

			public class RequestModelValidator: AbstractValidator<RequestModel>
			{
					 
					public RequestModelValidator()
					{

						 When(model => model.craftmyapp_actionmethodname == "Add_Request", () =>
                                    {
                                        {
RuleFor(m => m.email)
.MaximumLength(128).WithMessage("The allowed length of Email is 128 characters or fewer")
.EmailAddress()

;
RuleFor(m => m.mobilenumber)
.MaximumLength(20).WithMessage("The allowed length of mobile number is 20 characters or fewer ")

;
}

                                    });
When(model => model.craftmyapp_actionmethodname == "Update_Request", () =>
                                    {
                                        {
RuleFor(m => m.email)
.MaximumLength(128).WithMessage("The allowed length of Email is 128 characters or fewer")
.EmailAddress()

;
RuleFor(m => m.mobilenumber)
.MaximumLength(20).WithMessage("The allowed length of mobile number is 20 characters or fewer ")

;
}

                                    });

						 
						
					}

			}

			

            


 


			}
