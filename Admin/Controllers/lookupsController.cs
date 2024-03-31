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
	 //This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:17 
	 
	public class lookupsController : Controller
	{
		private HttpClient  client = new HttpClient();
		private IWebHostEnvironment hostingEnv;
		private IOptions<ApiSettings> _balSettings;
		private string  url = "";
		private string  baseUrl = "";
		public virtual HttpClient getHttpClient()
		{
			client.BaseAddress = new Uri(url);
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("SProvidertoken")); 
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
return client; 
;
		}
		public lookupsController(IOptions<ApiSettings> ApiSettings, IWebHostEnvironment env)
		{
			this.hostingEnv = env;
_balSettings = ApiSettings;
url = _balSettings.Value.apiURL;
baseUrl = _balSettings.Value.baseURL;
;
		}
		public virtual IActionResult Index()
		{
			return View();
		}
 
		[HttpGet()]
		public virtual async Task<string> get_lookups()
		{
					return await ApiClient.Get_ApiValues(getHttpClient(), "api/lookups/get_lookups");
;
		}
		[HttpGet()]
		public virtual async Task<string> get_lookups_by_entity(string id)
		{
					return await ApiClient.Get_ApiValues(getHttpClient(), "api/lookups/get_lookups_by_entity?id="+id);
;
		}
		public virtual async Task<IActionResult> Create(string id)
		{
					 var jsonObj = await ApiClient.Get_ApiValues(getHttpClient(), "api/lookups/getById_lookups?id="+id);
if(jsonObj.Length > 2)
{
jsonObj = jsonObj.Substring(1, jsonObj.Length - 2);
var model = JsonConvert.DeserializeObject<lookupsModel>(jsonObj);
return View(model);
}
else
return View()
;
		}
		[HttpPost()]
		public virtual async Task<IActionResult> Create(lookupsModel model, IFormCollection collection)
		{
			string message = "";
		 try
		 {
if(HttpContext.Session.GetString("SProviderUserID") != null)
model.createduser =new Guid(HttpContext.Session.GetString("SProviderloginUserID"));
				 if (ModelState.IsValid)
				 {
			  
				 message = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/lookups/ins_lookups", model);
			  
				 }
				 else
				 {
						 var errorCollection = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
						 message = errorCollection.ToString();
				 }
		 }
		 catch (Exception ex)
		 {
			 message = ex.Message;
		 }
		 ViewData["message"] = message;
			 if(message=="Success"){
TempData["message"] = message;
				 return RedirectToAction("Index");
			 }else{
				  return View(model);
			 }
;
		}
		
		
		 
	 
	}
}
