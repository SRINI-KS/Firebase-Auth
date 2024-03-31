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

namespace Admin.Controllers
{
    public class MailSender
    {

		public async Task<bool> sendMail(
			 string entityname
			, string entityactionname
			, string entityid
			, string mailfor
			 
			, IOptions<MailSettings> _mailSettings
			, string loginUserID
			, HttpClient client
			, string optionaldataOne=""
			,string optionaldataTwo="")
		{




			DataTable mailData = new DataTable();

			bool mailSent = false;
			HttpResponseMessage response_alert_maildata = await ApiClient.GET_ApiValuesGetRespnse(client, "api/MailLogs/MailSender?mailfor=" + entityactionname + "&entityid=" + entityid + "&createduser=" + loginUserID);


			if (response_alert_maildata.IsSuccessStatusCode)
			{
				mailData = await response_alert_maildata.Content.ReadAsAsync<DataTable>();

				if (mailData.Rows.Count > 0)
				{

					HttpResponseMessage response_alert_templates = await ApiClient.GET_ApiValuesGetRespnse(client, "api/AlertTemplates/Alert_Templates_List?entityname=" + entityname + "&entityaction=" + entityactionname + "");


					if (response_alert_templates.IsSuccessStatusCode)
					{
						DataTable dt_alert_template = await response_alert_templates.Content.ReadAsAsync<DataTable>();
						if (dt_alert_template.Rows.Count > 0)
						{
							if (dt_alert_template.Rows[0]["alerttype"].ToString() == "Email")
							{
								string alertcontent = dt_alert_template.Rows[0]["alertcontent"].ToString();
								string alertsubject = "";
								switch (entityactionname)
								{
									 
									case "forgotpassword":
										alertcontent = alertcontent.Replace("{toname}", mailData.Rows[0]["toname"].ToString())
											.Replace("{username}", mailData.Rows[0]["username"].ToString())
											.Replace("{userpassword}", optionaldataTwo)
											.Replace("{userrole}", mailData.Rows[0]["userrole"].ToString())
											.Replace("{clienturl}", optionaldataTwo);

										alertsubject = dt_alert_template.Rows[0]["alertsubject"].ToString();

										break;

									default:
										break;

								}


								Mailer objmail = new Mailer(_mailSettings);

								string tomail = mailData.Rows[0]["receiveremail"].ToString();
								if (tomail != "")
								{
									mailSent = objmail.SendMail_TLS(tomail, alertsubject, alertcontent, true, null, true);


									MailLogsModel objMailLogsModel = new MailLogsModel();
									objMailLogsModel.entityname = entityname;
									objMailLogsModel.entityid = entityid;
									objMailLogsModel.mailfor = mailfor;
									objMailLogsModel.mailto = tomail;
									objMailLogsModel.mailsubject = alertsubject;
									objMailLogsModel.mailbody = alertcontent;
									objMailLogsModel.issent = mailSent;
									objMailLogsModel.createduser =new Guid(loginUserID);
									objMailLogsModel.craftmyapp_actionmethodname = "Create_MailLog";
									string strMailLogsReturnMessage = await ApiClient.Post_ApiValuesGetString(client, "api/MailLogs/Create_MailLog", objMailLogsModel);
								}

							}
						}
					}

				}

		}

			return mailSent;
		}

	}
}


