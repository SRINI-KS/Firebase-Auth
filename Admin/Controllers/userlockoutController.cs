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

		 //This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:17 
		 
		public class userlockoutController : Controller
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
				}
				public userlockoutController(IOptions<ApiSettings> ApiSettings, IWebHostEnvironment env)
				{
				this.hostingEnv = env;
				_balSettings = ApiSettings;
				url = _balSettings.Value.apiURL;
				baseUrl = _balSettings.Value.baseURL;
				
				}



				public virtual IActionResult Index()
				{
				return View();
				}


				[HttpGet()]
				public virtual async Task<string> userlockout_List()
				{

				return await ApiClient.Get_ApiValues(getHttpClient(), "api/userlockout/get_userlockout");
				}



				public virtual async Task<IActionResult> Edit(string lockoutid)
				{
				userlockoutModel objuserlockoutModel=new userlockoutModel();
				objuserlockoutModel.lockoutid=lockoutid;
				objuserlockoutModel.loginUser=HttpContext.Session.GetString("SProviderloginUserID");

				string strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/userlockout/upd_userlockout", objuserlockoutModel);

				if(strReturnMessage=="201.1"){
				TempData["message"] = "Success";


				}else {

					TempData["message"] = strReturnMessage;
				}


				return RedirectToAction("Index");


				}




		}


}

