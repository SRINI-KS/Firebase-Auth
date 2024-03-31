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
				//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:21
				public class MailLogsController : Controller
				{
				public MailLogsController(IOptions<ConnectionSettings> connectionSettings, ILoggerFactory loggerFactory, IConfiguration configuration,IWebHostEnvironment hostingEnvironment)
				{
					 _configuration = configuration;
					 _logger = loggerFactory.CreateLogger<MailLogsController>();
					 _connectionSettings = connectionSettings;
					 objMailLogsDAL = new MailLogsDAL(_connectionSettings.Value.ConnectionString);
                     obj_External_System_DAL =new External_System_DAL(_connectionSettings.Value.ConnectionString);
                     objExternalSystemUtitlity = new ExternalSystemUtility(_connectionSettings, _configuration);
					 hostingEnv = hostingEnvironment;
				}
				private MailLogsDAL objMailLogsDAL;
                private External_System_DAL obj_External_System_DAL;
				private IOptions<ConnectionSettings> _connectionSettings;
				private ILogger _logger;
				private IConfiguration _configuration;
				private IWebHostEnvironment hostingEnv;
                private ExternalSystemUtility objExternalSystemUtitlity;

 

			    [AllowAnonymous()]
                                                [HttpGet()]
                                                [ActionName("MailSender")]
                                                public virtual System.Data.DataTable MailSender(string mailfor, string entityid, string createduser)
                                                {

	                                                DataTable dtMailLogs = new DataTable();
	                                                try
	                                                {
		                                                dtMailLogs = objMailLogsDAL.MailSender(mailfor,entityid, createduser);
	                                                }
	                                                catch (Exception ex)
	                                                {
		                                                _logger.LogError(ex.Message);
	                                                }
	                                                return dtMailLogs;

                                                }
[AllowAnonymous()]
            [HttpPost()]
            [ActionName("Create_MailLog")]
            public virtual IActionResult Create_MailLog([FromBody]MailLogsModel model)
            { 
              string message = "";
                access_logsdetailsModel obj_access_logsdetailsModel = new access_logsdetailsModel();
                   obj_access_logsdetailsModel.action_method_name="Create_MailLog";
            try{

            if (ModelState.IsValid)
            {

            	MailLogsModelValidator validator = new MailLogsModelValidator();
            	ValidationResult results = validator.Validate(model);
            	if (!results.IsValid)
            	{
            		var errorCollection = string.Join(" | ", results.Errors.Select(e => e.ErrorMessage.Replace("{propertyName}",e.PropertyName)));
             		message = ("Validation Error : " + errorCollection);


            	}else{

                                   var authHeader = HttpContext.Request.Headers["Authorization"][0];
                                if (authHeader.StartsWith("Bearer "))
                                {
                                 var token = authHeader.Substring("Bearer ".Length);
                                String[] userdetails=obj_External_System_DAL.get_users_by_token(token);
		                        model.createduser=new Guid(userdetails[0].ToString());
                                obj_access_logsdetailsModel.access_logsid=new Guid(userdetails[1].ToString());
		     

                                
            		                
                                   message = objMailLogsDAL.Create_MailLog(model);
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

            	_logger.LogError("MailLogsModel - Create_MailLog , Validation Error :" + message);
            	message = ("Validation Error : " + message);
            }






            }catch(Exception ex){
            	message=ex.Message;
            	_logger.LogError(ex.Message);
            	message = ("Exception : " + ex.Message);
            }

            obj_access_logsdetailsModel.api_response=message.Replace("\"",""); 
            obj_External_System_DAL.create_access_logs_details(obj_access_logsdetailsModel);
                     

            if(message.Replace("\"","").Contains("201.1"))
            return Ok(message);
            else if(message.Replace("\"","")=="401.1")
            return Unauthorized(message);
            else
            return BadRequest("DB Exception : " +message);
             }
[HttpGet()]
			  [ActionName("getById_MailLogs")]
			  public virtual System.Data.DataTable getById_MailLogs(string MailLogsid,string loginUserID="")
			  { 
				    DataTable dtMailLogs = new DataTable();
					try
					{
						  dtMailLogs = objMailLogsDAL.getById_MailLogs(MailLogsid);
					}
					catch (Exception ex)
					{
						_logger.LogError(ex.Message);
					}
					return dtMailLogs;

			  }
			  [HttpPost()]
			  [ActionName("Update_MailLog")]
			  public virtual IActionResult Update_MailLog([FromBody]MailLogsModel model)
			  { 
				    string message = "";
                   access_logsdetailsModel obj_access_logsdetailsModel = new access_logsdetailsModel();
                   obj_access_logsdetailsModel.action_method_name="Update_MailLog";

					try{

					if (ModelState.IsValid)
					{

						MailLogsModelValidator validator = new MailLogsModelValidator();
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

		       
                                	
							    message = objMailLogsDAL.Update_MailLog(model);	
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

						_logger.LogError("MailLogsModel - Update_MailLog, Validation Error :" + message);
					
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
            public virtual string Remove_MailLog(string MailLogsid,string loginUserID="")
			{
					string message ="";
                    access_logsdetailsModel obj_access_logsdetailsModel = new access_logsdetailsModel();
                   obj_access_logsdetailsModel.action_method_name="Remove_MailLog";

					try{
						
						  var authHeader = HttpContext.Request.Headers["Authorization"][0];
	                        if (authHeader.StartsWith("Bearer "))
	                        {
		                        var token = authHeader.Substring("Bearer ".Length);
		                         
		                        String[] userdetails=obj_External_System_DAL.get_users_by_token(token);
		                        loginUserID=userdetails[0].ToString();
                                obj_access_logsdetailsModel.access_logsid=new Guid(userdetails[1].ToString());
		                      
		       
                        	 message = objMailLogsDAL.Remove_MailLog(MailLogsid,loginUserID);
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
			
			[ActionName("MailLogs_List")]
			public virtual System.Data.DataTable MailLogs_List(string entityname=""
,string loginUserID="")
			{
					 
				  	DataTable dtMailLogs = new DataTable();
					try
					{
						dtMailLogs = objMailLogsDAL.MailLogs_List( entityname
);
					}
					catch (Exception ex)
					{
						_logger.LogError(ex.Message);
					}
					return dtMailLogs;

			   }
			   
[HttpGet()]
			
			[ActionName("get_all_MailLogs")]
			public virtual System.Data.DataTable get_all_MailLogs(string tenantid,string loginUserID="")
			{
					 
				  	DataTable dtMailLogs = new DataTable();
					try
					{
						dtMailLogs = objMailLogsDAL.get_all_MailLogs(tenantid);
					}
					catch (Exception ex)
					{
						_logger.LogError(ex.Message);
					}
					return dtMailLogs;

			   }
[HttpGet()]
			  [ActionName("getById_sp_all_MailLogs")]
			  public virtual System.Data.DataSet getById_sp_all_MailLogs(string MailLogsid)
			  { 
				    DataSet dsMailLogs = new DataSet();
					try
					{
						  dsMailLogs = objMailLogsDAL.getById_sp_all_MailLogs(MailLogsid);
					}
					catch (Exception ex)
					{
						_logger.LogError(ex.Message);
					}
					return dsMailLogs;

			  }







				}


			}
