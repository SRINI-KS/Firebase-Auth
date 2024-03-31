namespace SProviderWebApi.Controllers
				{
					using System;
					using System.Data;
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
					
					 //This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:17
					[Route("api/[controller]/[action]")]
					public class lookupsController : Controller
					{
						public lookupsController(IOptions<ConnectionSettings> connectionSettings, ILoggerFactory loggerFactory, IConfiguration configuration)
						{
							_configuration = configuration;
				_logger = loggerFactory.CreateLogger<lookupsController>();
				_connectionSettings = connectionSettings;
				objlookupsDAL = new lookupsDAL(_connectionSettings.Value.ConnectionString)
				;
						}
						private lookupsDAL objlookupsDAL;
						private IOptions<ConnectionSettings> _connectionSettings;
						private ILogger _logger;
						private IConfiguration _configuration;
						[HttpPost()]
						[ActionName("ins_lookups")]
						public virtual string ins_lookups([FromBody]lookupsModel model)
						{
							string message = objlookupsDAL.ins_lookups(model);
							return message;
						}
						[HttpGet()]
						[ActionName("get_lookups")]
						public virtual System.Data.DataTable get_lookups()
						{
							DataTable dtlookups = new DataTable();
							try
							{
									dtlookups = objlookupsDAL.get_lookups();
							}
							catch (Exception ex)
							{
									_logger.LogError(ex.Message);
							}
							return dtlookups
							;
						}
						[HttpGet()]
						[ActionName("getById_lookups")]
						public virtual System.Data.DataTable getById_lookups(string id)
						{
							DataTable dt = objlookupsDAL.getById_lookups(id);
							return dt;
						}
						
						[HttpGet()]
						[ActionName("get_lookups_by_entity")]
						public virtual System.Data.DataTable get_lookups_by_entity(string id)
						{
							DataTable dt = objlookupsDAL.get_lookups_by_entity(id);
							return dt;
						}
						
						
						
						
					}
				}
				
