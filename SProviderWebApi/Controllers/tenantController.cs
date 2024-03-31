namespace SProviderWebApi.Controllers
			{
				using System;
				using System.Data;
				using System.Linq;
				using Microsoft.AspNetCore.Mvc;
				using System.Collections.Generic;
				using Microsoft.Extensions.Options;
				using Microsoft.Extensions.Logging;
				using Microsoft.AspNetCore.Authorization;
				using Microsoft.Extensions.Configuration;
				using System.IdentityModel.Tokens.Jwt;
				using System.Security.Claims;
				using System.Text;
				using Microsoft.IdentityModel.Tokens;
				using SProvider.Models;
				using SProvider.DAL;
				using FluentValidation.Results;

				using Microsoft.AspNetCore.Hosting;
				using System.IO;
				using System.Net.Http.Headers;
				[Authorize()]
				[Route("api/[controller]/[action]")]
				//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:19
				public class tenantController : Controller
				{
				public tenantController(IOptions<ConnectionSettings> connectionSettings, ILoggerFactory loggerFactory, IConfiguration configuration,IWebHostEnvironment hostingEnvironment)
				{
					 _configuration = configuration;
					 _logger = loggerFactory.CreateLogger<tenantController>();
					 _connectionSettings = connectionSettings;
					 objtenantDAL = new tenantDAL(_connectionSettings.Value.ConnectionString);
                     obj_External_System_DAL =new External_System_DAL(_connectionSettings.Value.ConnectionString);
                     objExternalSystemUtitlity = new ExternalSystemUtility(_connectionSettings, _configuration);
					 hostingEnv = hostingEnvironment;
				}
				private tenantDAL objtenantDAL;
                private External_System_DAL obj_External_System_DAL;
				private IOptions<ConnectionSettings> _connectionSettings;
				private ILogger _logger;
				private IConfiguration _configuration;
				private IWebHostEnvironment hostingEnv;
                private ExternalSystemUtility objExternalSystemUtitlity;

 

			    [AllowAnonymous()]
            [HttpPost()]
            [ActionName("Create_tenant")]
            public virtual IActionResult Create_tenant([FromBody]tenantModel model)
            { 
              string message = "";
             
            try{

            if (ModelState.IsValid)
            {

            	tenantModelValidator validator = new tenantModelValidator();
            	ValidationResult results = validator.Validate(model);
            	if (!results.IsValid)
            	{
            		var errorCollection = string.Join(" | ", results.Errors.Select(e => e.ErrorMessage.Replace("{propertyName}",e.PropertyName)));
             		message = ("Validation Error : " + errorCollection);


            	}else{
                         message = objtenantDAL.Create_tenant(model);
                        
            	}


            }
            else
            {
            	var errorCollection = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            	message = errorCollection.ToString();

            	_logger.LogError("tenantModel - Create_tenant , Validation Error :" + message);
            	message = ("Validation Error : " + message);
            }






            }catch(Exception ex){
            	message=ex.Message;
            	_logger.LogError(ex.Message);
            	message = ("Exception : " + ex.Message);
            }

                

            if(message.Replace("\"","").Contains("201.1"))
            return Ok(message);
            else if(message.Replace("\"","")=="401.1")
            return Unauthorized(message);
            else
            return BadRequest("DB Exception : " +message);
             }
[HttpGet()]
			  [ActionName("getById_tenant")]
			  public virtual System.Data.DataTable getById_tenant(string tenantid,string loginUserID="")
			  { 
				    DataTable dttenant = new DataTable();
					try
					{
						  dttenant = objtenantDAL.getById_tenant(tenantid);
					}
					catch (Exception ex)
					{
						_logger.LogError(ex.Message);
					}
					return dttenant;

			  }
			  [HttpPost()]
			  [ActionName("Update_tenant")]
			  public virtual IActionResult Update_tenant([FromBody]tenantModel model)
			  { 
				    string message = "";
                   access_logsdetailsModel obj_access_logsdetailsModel = new access_logsdetailsModel();
                   obj_access_logsdetailsModel.action_method_name="Update_tenant";

					try{

					if (ModelState.IsValid)
					{

						tenantModelValidator validator = new tenantModelValidator();
						ValidationResult results = validator.Validate(model);
						if (!results.IsValid)
						{
							var errorCollection = string.Join(" | ", results.Errors.Select(e => e.ErrorMessage.Replace("{propertyName}",e.PropertyName)));
							message = errorCollection.ToString();
							//return BadRequest("Validation Error : " + message);

						}else{
                            var authHeader = HttpContext.Request.Headers["Authorization"][0];
	                        if (authHeader.StartsWith("Bearer "))
	                        {
		                      
                                var token = authHeader.Substring("Bearer ".Length);
		                        String[] userdetails=obj_External_System_DAL.get_users_by_token(token);
                                model.modifieduser=new Guid(userdetails[0].ToString());
                                obj_access_logsdetailsModel.access_logsid=new Guid(userdetails[1].ToString());

		       
                                	
							    message = objtenantDAL.Update_tenant(model);	
                            }
                            else{
                                message = "Invalid Token";
                                 
                            }
							
						}


					}
					else
					{
						var errorCollection = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
						message = errorCollection.ToString();

						_logger.LogError("tenantModel - Update_tenant, Validation Error :" + message);
					
						//return BadRequest("Validation Error : " + message);
					}






					}catch(Exception ex){
						message=ex.Message;
						_logger.LogError(ex.Message);
						//return BadRequest("Exception : " + ex.Message);
					}

                        obj_access_logsdetailsModel.api_response=message.Replace("\"",""); 
                       obj_External_System_DAL.create_access_logs_details(obj_access_logsdetailsModel);

					if(message.Replace("\"","")=="201.1")
					return Ok(message);
					else if(message.Replace("\"","")=="401.1")
					return Unauthorized(message);
					else
					return BadRequest("DB Exception : " +message);

					


			   }
[HttpGet()]
            public virtual string Remove_tenant(string tenantid,string loginUserID="")
			{
					string message ="";
                    access_logsdetailsModel obj_access_logsdetailsModel = new access_logsdetailsModel();
                   obj_access_logsdetailsModel.action_method_name="Remove_tenant";

					try{
						
						  var authHeader = HttpContext.Request.Headers["Authorization"][0];
	                        if (authHeader.StartsWith("Bearer "))
	                        {
		                        var token = authHeader.Substring("Bearer ".Length);
		                         
		                        String[] userdetails=obj_External_System_DAL.get_users_by_token(token);
		                        loginUserID=userdetails[0].ToString();
                                obj_access_logsdetailsModel.access_logsid=new Guid(userdetails[1].ToString());
		                      
		       
                        	 message = objtenantDAL.Remove_tenant(tenantid,loginUserID);
						    }
	                        else{
		                        message = "Invalid Token";
		                       
	                        }
					 

					}catch(Exception ex){
						message=ex.Message;
						_logger.LogError(ex.Message);
					}
				    obj_access_logsdetailsModel.api_response=message.Replace("\"",""); 
                    obj_External_System_DAL.create_access_logs_details(obj_access_logsdetailsModel);
                 
					return message;

			}
[HttpGet()]
			[AllowAnonymous()]
			[ActionName("ViewList_tenant")]
			public virtual System.Data.DataTable ViewList_tenant(string loginUserID="")
			{
					 
				  	DataTable dttenant = new DataTable();
					try
					{
						dttenant = objtenantDAL.ViewList_tenant();
					}
					catch (Exception ex)
					{
						_logger.LogError(ex.Message);
					}
					return dttenant;

			   }
			   
[HttpGet()]
			[AllowAnonymous()]
			[ActionName("get_all_tenant")]
			public virtual System.Data.DataTable get_all_tenant(string tenantid,string loginUserID="")
			{
					 
				  	DataTable dttenant = new DataTable();
					try
					{
						dttenant = objtenantDAL.get_all_tenant(tenantid);
					}
					catch (Exception ex)
					{
						_logger.LogError(ex.Message);
					}
					return dttenant;

			   }
[HttpGet()]
			[ActionName("get_project_tenant")]
			public virtual System.Data.DataTable get_project_tenant()
			{
					 
				  	DataTable dttenant = new DataTable();
					try
					{
						dttenant = objtenantDAL.get_project_tenant();
					}
					catch (Exception ex)
					{
						_logger.LogError(ex.Message);
					}
					return dttenant;

			  }
[HttpGet()]
			  [ActionName("getById_sp_all_tenant")]
			  public virtual System.Data.DataSet getById_sp_all_tenant(string tenantid)
			  { 
				    DataSet dstenant = new DataSet();
					try
					{
						  dstenant = objtenantDAL.getById_sp_all_tenant(tenantid);
					}
					catch (Exception ex)
					{
						_logger.LogError(ex.Message);
					}
					return dstenant;

			  }







				}


			}
