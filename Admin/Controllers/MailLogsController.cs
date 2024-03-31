namespace Admin.Controllers
			{
				using System;
				using System.Data;
				using System.Linq;
				using Microsoft.AspNetCore.Mvc;
				using Newtonsoft.Json;
				using System.Net.Http;
				using System.Net.Http.Formatting;
				using System.Threading.Tasks;
				using System.Net.Http.Headers;
				using Microsoft.Extensions.Options;
				using Microsoft.AspNetCore.Http;
				using System.Collections.Generic;
				using System.IO;
				using Microsoft.AspNetCore.Hosting;
				using System.Net;
				using FluentValidation.Results;
				using SProvider.Models;
				using Microsoft.AspNetCore.Mvc.Infrastructure;
				using Microsoft.AspNetCore.HttpOverrides;
                using Microsoft.Extensions.Configuration;
                using Microsoft.Extensions.Logging;
                
                
				//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:21
				
                
                
				public class MailLogsController : Controller
				{	 
					private HttpClient  client = new HttpClient();
					private IWebHostEnvironment hostingEnv;
					private IOptions<ApiSettings> _balSettings;
                    private IOptions<MailSettings> _mailSettings;
					private string  url = "";
					private string  baseUrl = "";
                    private string  adminUrl = "";
                    private string  clientUrl = "";
                    private string  accesskey = "";
					private IHttpContextAccessor _accessor;
                    public IConfiguration Configuration { get; }
                    private readonly ILogger<MailLogsController> _logger;
                    
					public virtual HttpClient getHttpClient()
					{
						client.BaseAddress = new Uri(url);
						client.DefaultRequestHeaders.Accept.Clear();
						client.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("SProvidertoken")); 
						client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
						return client; 
					}
					public MailLogsController(IConfiguration configuration,IHttpContextAccessor accessor,IOptions<ApiSettings> ApiSettings, IOptions<MailSettings> MailSettings, IWebHostEnvironment env, ILogger<MailLogsController> logger)
					{
                        _logger = logger;
						this.hostingEnv = env;
						_balSettings = ApiSettings;
                        _mailSettings = MailSettings;
						url = _balSettings.Value.apiURL;
						baseUrl = _balSettings.Value.baseURL;
                        adminUrl = _balSettings.Value.adminURL;
                        clientUrl = _balSettings.Value.clientURL;
                        accesskey = _balSettings.Value.accesskey;
 
						_accessor = accessor;
                        Configuration = configuration;
                        
					}
					 public virtual IActionResult detail()
			         {
					        return View();
			         }

	

					
			  public virtual IActionResult Create_MailLog()
			  {
					return View();
			  }	
			  [HttpPost()]
			public virtual async Task<IActionResult> Create_MailLog(MailLogsModel model, IFormCollection collection)
			{
				string strReturnMessage = "";
				string redirectTo="";
				try
				{
					ModelState.Remove("MailLogsid");
                    ModelState.Remove("craftmyapp_actionmethodname");
                    model.craftmyapp_actionmethodname="Create_MailLog";
					ModelState.Remove("createduser");
					if(HttpContext.Session.GetString("SProviderloginUserID") != null)
						model.createduser =new Guid(HttpContext.Session.GetString("SProviderloginUserID"));
						else
						return RedirectToAction(redirectTo);
					
					

					if(HttpContext.Session.GetString("SProviderrole_JSON") != null){
					DataTable SProviderrole_JSON =HttpContext.Session.GetSession<DataTable>("SProviderroles");
						 DataView dv = new DataView(SProviderrole_JSON);
						 dv.RowFilter = "controllername='MailLogs' AND viewname='list'";

						if(dv.Count  >0){
						    redirectTo = dv[0]["actionmethodname"] as string;
							 
						}

					}
			 	 
					 if (ModelState.IsValid)
					 {
							 MailLogsModelValidator validator = new MailLogsModelValidator();
							 ValidationResult results = validator.Validate(model);
							 if (!results.IsValid)
							 {
								 var errorCollection = string.Join(" | ", results.Errors.Select(e => e.ErrorMessage.Replace("{propertyName}",e.PropertyName)));
								 strReturnMessage = errorCollection.ToString();
								 foreach (var failure in results.Errors)
								 {
									ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
								 }
							 }
							 else
							 {
								 
								 
								 strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/MailLogs/Create_MailLog", model);
							 }
					 }
					 else
					 {
							 var errorCollection = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
							 strReturnMessage = errorCollection.ToString();
					 }
			 }
			 catch (Exception ex)
			 {
                _logger.LogError("Error occured in - MailLogs / Create_MailLog , Error Message : " + ex.Message);
                Console.WriteLine(ex);
				 strReturnMessage = ex.Message;
			 }
		     ViewData["message"] = strReturnMessage;
			 if(strReturnMessage.Replace("\"", "").Contains("201.1")){
				 TempData["message"] = "Success";
				 
				 return RedirectToAction(redirectTo);
			 }else{
				  if(strReturnMessage=="401.1")
				  	 	 ViewData["message"] = "Authorization Failed";

				  return View(model);
			 }
 
		   }

				
			  public virtual async Task<IActionResult> Update_MailLog(string MailLogsid)
			  {
					var jsonObjMailLogs = await ApiClient.Get_ApiValues(getHttpClient(), "api/MailLogs/getById_MailLogs?MailLogsid="+MailLogsid+"&loginUserID="+HttpContext.Session.GetString("SProviderloginUserID"));
					if(jsonObjMailLogs.Length > 2)
					{
						jsonObjMailLogs = jsonObjMailLogs.Substring(1, jsonObjMailLogs.Length - 2);
						var model = JsonConvert.DeserializeObject<MailLogsModel>(jsonObjMailLogs);
						HttpContext.Session.SetSession("SProviderMailLogsModel", model);
						return View(model);
					}
					else
					{
						string redirectTo="";
						if(HttpContext.Session.GetString("SProviderrole_JSON") != null){
					DataTable SProviderrole_JSON =HttpContext.Session.GetSession<DataTable>("SProviderroles");
						 DataView dv = new DataView(SProviderrole_JSON);
						 dv.RowFilter = "controllername='MailLogs' AND viewname='list'";

						if(dv.Count  >0){
						    redirectTo = dv[0]["actionmethodname"] as string;
							 
						}

					}
						TempData["message"] = "Data Not Found - Contact Administrator";
						return RedirectToAction(redirectTo);
						 
					}
			  }	
			  [HttpPost()]
				public virtual async Task<IActionResult> Update_MailLog(MailLogsModel model, IFormCollection collection)
				{
					string strReturnMessage = "";
					string redirectTo="";
					try
					{
						
						if(HttpContext.Session.GetString("SProviderrole_JSON") != null){
					DataTable SProviderrole_JSON =HttpContext.Session.GetSession<DataTable>("SProviderroles");
						 DataView dv = new DataView(SProviderrole_JSON);
						 dv.RowFilter = "controllername='MailLogs' AND viewname='list'";

						if(dv.Count  >0){
						    redirectTo = dv[0]["actionmethodname"] as string;
							 
						}

					}

							 ModelState.Remove("MailLogsid");
                             ModelState.Remove("craftmyapp_actionmethodname");
                             model.craftmyapp_actionmethodname="Update_MailLog";

							
							
							if(HttpContext.Session.GetString("SProviderloginUserID") != null)
					model.modifieduser =new Guid(HttpContext.Session.GetString("SProviderloginUserID"));
					else
					return RedirectToAction(redirectTo);
							
                            
							if (ModelState.IsValid)
							{
									MailLogsModelValidator validator = new MailLogsModelValidator();
									ValidationResult results = validator.Validate(model);
									if (!results.IsValid)
									{
										var errorCollection = string.Join(" | ", results.Errors.Select(e => e.ErrorMessage.Replace("{propertyName}",e.PropertyName)));
										strReturnMessage = errorCollection.ToString();
										foreach (var failure in results.Errors)
										{
											ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
										}
									}
									else
									{
										
                                        var modelCopy = HttpContext.Session.GetSession<MailLogsModel> ("SProviderMailLogsModel");

										strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/MailLogs/Update_MailLog", model);
									}
							}
							else
							{
									var errorCollection = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
									strReturnMessage = errorCollection.ToString();
							}
					}
					catch (Exception ex)
					{
                        _logger.LogError("Error occured in - MailLogs / Update_MailLog , Error Message : " + ex.Message);
Console.WriteLine(ex);
						strReturnMessage = ex.Message;
					}
					ViewData["message"] = strReturnMessage;
					    if(strReturnMessage.Replace("\"", "")=="201.1"){
							TempData["message"] = "Success";
							
							return RedirectToAction(redirectTo);
						}else{
							if(strReturnMessage=="401.1")
									ViewData["message"] = "Authorization Failed";

							return View(model);
						}
		
				}
public virtual async Task<IActionResult> Remove_MailLog(string MailLogsid)
			{
				string message = "";
				try
				{
						message = await ApiClient.Get_ApiValues(getHttpClient(), "api/MailLogs/Remove_MailLog?MailLogsid="+MailLogsid+"&loginUserID="+HttpContext.Session.GetString("SProviderloginUserID"));

						 if(message.Replace("\"","")=="201.1")
						{
							TempData["message"] = "Success";

						}else{
							TempData["errMessage"] = message.Replace("\"","");
						}
						
				
				
				}
				catch (Exception ex)
				{
                    _logger.LogError("Error occured in - MailLogs / Remove_MailLog , Error Message : " + ex.Message);
Console.WriteLine(ex);
					 TempData["errMessage"] = ex.Message;
					 message = ex.Message;
				}

				string redirectTo="";
						if(HttpContext.Session.GetString("SProviderrole_JSON") != null){
					DataTable SProviderrole_JSON =HttpContext.Session.GetSession<DataTable>("SProviderroles");
						 DataView dv = new DataView(SProviderrole_JSON);
						 dv.RowFilter = "controllername='MailLogs' AND viewname='list'";

						if(dv.Count  >0){
						    redirectTo = dv[0]["actionmethodname"] as string;
							 
						}

					}
				
				return RedirectToAction(redirectTo);
			}

			public virtual IActionResult MailLogs_List()
			{
				return View();
			}
				
			[HttpGet()]
			public virtual async Task<string> get_MailLogs_List(string entityname
)
			{
				
				return await ApiClient.Get_ApiValues(getHttpClient(), "api/MailLogs/MailLogs_List?entityname="+entityname+"&loginUserID="+HttpContext.Session.GetString("SProviderloginUserID")
);
			}
			 

				
			  public virtual async Task<string> getById_sp_all_MailLogs(string MailLogsid)
			  {
					return await ApiClient.Get_ApiValues(getHttpClient(), "api/MailLogs/getById_sp_all_MailLogs?MailLogsid="+MailLogsid);
					 
			  }





                    


				}


			}
