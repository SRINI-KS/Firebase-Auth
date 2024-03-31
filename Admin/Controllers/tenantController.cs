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
                
                
				//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:19
				
                
                
				public class tenantController : Controller
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
                    private readonly ILogger<tenantController> _logger;
                    
					public virtual HttpClient getHttpClient()
					{
						client.BaseAddress = new Uri(url);
						client.DefaultRequestHeaders.Accept.Clear();
						client.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("SProvidertoken")); 
						client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
						return client; 
					}
					public tenantController(IConfiguration configuration,IHttpContextAccessor accessor,IOptions<ApiSettings> ApiSettings, IOptions<MailSettings> MailSettings, IWebHostEnvironment env, ILogger<tenantController> logger)
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

	

					
			  public virtual IActionResult Create_tenant()
			  {
					return View();
			  }	
			  [HttpPost()]
			public virtual async Task<IActionResult> Create_tenant(tenantModel model, IFormCollection collection)
			{
				string strReturnMessage = "";
				string redirectTo="";
				try
				{
					ModelState.Remove("tenantid");
                    ModelState.Remove("craftmyapp_actionmethodname");
                    model.craftmyapp_actionmethodname="Create_tenant";
					ModelState.Remove("createduser");
					
					
					

					if(HttpContext.Session.GetString("SProviderrole_JSON") != null){
					DataTable SProviderrole_JSON =HttpContext.Session.GetSession<DataTable>("SProviderroles");
						 DataView dv = new DataView(SProviderrole_JSON);
						 dv.RowFilter = "controllername='tenant' AND viewname='list'";

						if(dv.Count  >0){
						    redirectTo = dv[0]["actionmethodname"] as string;
							 
						}

					}
			 	 
					 if (ModelState.IsValid)
					 {
							 tenantModelValidator validator = new tenantModelValidator();
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
								 model.tenantid =Guid.NewGuid();
								 
								 strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/tenant/Create_tenant", model);
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
                _logger.LogError("Error occured in - tenant / Create_tenant , Error Message : " + ex.Message);
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

				
			  public virtual async Task<IActionResult> Update_tenant(string tenantid)
			  {
					var jsonObjtenant = await ApiClient.Get_ApiValues(getHttpClient(), "api/tenant/getById_tenant?tenantid="+tenantid+"&loginUserID="+HttpContext.Session.GetString("SProviderloginUserID"));
					if(jsonObjtenant.Length > 2)
					{
						jsonObjtenant = jsonObjtenant.Substring(1, jsonObjtenant.Length - 2);
						var model = JsonConvert.DeserializeObject<tenantModel>(jsonObjtenant);
						HttpContext.Session.SetSession("SProvidertenantModel", model);
						return View(model);
					}
					else
					{
						string redirectTo="";
						if(HttpContext.Session.GetString("SProviderrole_JSON") != null){
					DataTable SProviderrole_JSON =HttpContext.Session.GetSession<DataTable>("SProviderroles");
						 DataView dv = new DataView(SProviderrole_JSON);
						 dv.RowFilter = "controllername='tenant' AND viewname='list'";

						if(dv.Count  >0){
						    redirectTo = dv[0]["actionmethodname"] as string;
							 
						}

					}
						TempData["message"] = "Data Not Found - Contact Administrator";
						return RedirectToAction(redirectTo);
						 
					}
			  }	
			  [HttpPost()]
				public virtual async Task<IActionResult> Update_tenant(tenantModel model, IFormCollection collection)
				{
					string strReturnMessage = "";
					string redirectTo="";
					try
					{
						
						if(HttpContext.Session.GetString("SProviderrole_JSON") != null){
					DataTable SProviderrole_JSON =HttpContext.Session.GetSession<DataTable>("SProviderroles");
						 DataView dv = new DataView(SProviderrole_JSON);
						 dv.RowFilter = "controllername='tenant' AND viewname='list'";

						if(dv.Count  >0){
						    redirectTo = dv[0]["actionmethodname"] as string;
							 
						}

					}

							 ModelState.Remove("tenantid");
                             ModelState.Remove("craftmyapp_actionmethodname");
                             model.craftmyapp_actionmethodname="Update_tenant";

							
							
							if(HttpContext.Session.GetString("SProviderloginUserID") != null)
					model.modifieduser =new Guid(HttpContext.Session.GetString("SProviderloginUserID"));
					else
					return RedirectToAction(redirectTo);
							
                            
							if (ModelState.IsValid)
							{
									tenantModelValidator validator = new tenantModelValidator();
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
										
                                        var modelCopy = HttpContext.Session.GetSession<tenantModel> ("SProvidertenantModel");

										strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/tenant/Update_tenant", model);
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
                        _logger.LogError("Error occured in - tenant / Update_tenant , Error Message : " + ex.Message);
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
public virtual async Task<IActionResult> Remove_tenant(string tenantid)
			{
				string message = "";
				try
				{
						message = await ApiClient.Get_ApiValues(getHttpClient(), "api/tenant/Remove_tenant?tenantid="+tenantid+"&loginUserID="+HttpContext.Session.GetString("SProviderloginUserID"));

						 if(message.Replace("\"","")=="201.1")
						{
							TempData["message"] = "Success";

						}else{
							TempData["errMessage"] = message.Replace("\"","");
						}
						
				
				
				}
				catch (Exception ex)
				{
                    _logger.LogError("Error occured in - tenant / Remove_tenant , Error Message : " + ex.Message);
Console.WriteLine(ex);
					 TempData["errMessage"] = ex.Message;
					 message = ex.Message;
				}

				string redirectTo="";
						if(HttpContext.Session.GetString("SProviderrole_JSON") != null){
					DataTable SProviderrole_JSON =HttpContext.Session.GetSession<DataTable>("SProviderroles");
						 DataView dv = new DataView(SProviderrole_JSON);
						 dv.RowFilter = "controllername='tenant' AND viewname='list'";

						if(dv.Count  >0){
						    redirectTo = dv[0]["actionmethodname"] as string;
							 
						}

					}
				
				return RedirectToAction(redirectTo);
			}

			public virtual IActionResult ViewList_tenant()
			{
				return View();
			}
				
			[HttpGet()]
			public virtual async Task<string> get_ViewList_tenant()
			{
				
				return await ApiClient.Get_ApiValues(getHttpClient(), "api/tenant/ViewList_tenant?loginUserID="+HttpContext.Session.GetString("SProviderloginUserID")
);
			}
			 
[HttpGet()]
			public virtual async Task<string> get_project_tenant()
			{
	 			return await ApiClient.Get_ApiValues(getHttpClient(), "api/tenant/get_project_tenant");
			}

				
			  public virtual async Task<string> getById_sp_all_tenant(string tenantid)
			  {
					return await ApiClient.Get_ApiValues(getHttpClient(), "api/tenant/getById_sp_all_tenant?tenantid="+tenantid);
					 
			  }





                    


				}


			}
