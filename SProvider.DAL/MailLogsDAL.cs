namespace SProvider.DAL{
			    using System;
			    using System.Text;
			    using System.Data;
			    using System.Data.Common;
			    using SProvider.Models;
			    using EncrypDecrypt;
			    using Newtonsoft.Json;
                using Npgsql;
				using NpgsqlTypes;
			    //This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:21
			    public class MailLogsDAL
			    {
					public virtual string db_connectionstring{get;set;}
			 	    public MailLogsDAL(string connectionString)
				    {
					    db_connectionstring=connectionString;
				    }
				  
			        public virtual System.Data.DataTable MailSender(string mailfor,string entityid,string createduser){
				   DataTable dataTable=new DataTable();
                    DataSet dataSet=new DataSet();
					try
					{
							  
                            
                             using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
                            {
	                            npsql.Open();
	                            using (var dbCommand = new NpgsqlCommand("\"MailSender\"", npsql))
	                            {
		                            dbCommand.CommandType = CommandType.StoredProcedure;
		                            dbCommand.Parameters.AddWithValue("pvar_mailfor",(object)mailfor??DBNull.Value);
									dbCommand.Parameters.AddWithValue("pvar_entityid",(object)entityid??DBNull.Value);
									dbCommand.Parameters.AddWithValue("pvar_createduser",(object)createduser??DBNull.Value);
		                            using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(dbCommand))
		                            {
			                            dataSet.Reset();
			                            dataAdapter.Fill(dataSet);
			                            dataTable = dataSet.Tables[0];
			                            if (dbCommand.Connection.State != ConnectionState.Closed)
			                            {
				                            dbCommand.Connection.Dispose();
			                            }
		                            }
	                            }
	                            npsql.Close();
                            }

						
					}
					catch{
						throw;
					}
					return dataTable;	
				}

              public virtual string Create_MailLog(MailLogsModel model)
			  { 
				  String ResponseMessage="";
					 
					try{
							 
                            using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
					        {
						        npsql.Open();
						        using (var dbCommand = new NpgsqlCommand("\"Create_MailLog\"", npsql))
						        {
                                        dbCommand.CommandType = CommandType.StoredProcedure;
						            	
								        					dbCommand.Parameters.AddWithValue("pvar_maillogsid",NpgsqlDbType.Uuid,(object)model.MailLogsid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_entityname",NpgsqlDbType.Varchar,(object)model.entityname??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_entityid",NpgsqlDbType.Varchar,(object)model.entityid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_mailfor",NpgsqlDbType.Varchar,(object)model.mailfor??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_mailsubject",NpgsqlDbType.Varchar,(object)model.mailsubject??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_mailto",NpgsqlDbType.Varchar,(object)model.mailto??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_mailbody",NpgsqlDbType.Varchar,(object)model.mailbody??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_issent",NpgsqlDbType.Boolean,(object)model.issent??DBNull.Value);
dbCommand.Parameters.AddWithValue("pvar_createduser",NpgsqlDbType.Uuid,(object)model.createduser??DBNull.Value);	
                                        NpgsqlParameter outParm = new NpgsqlParameter("pvar_returnMessage", NpgsqlDbType.Varchar)
                                        {
                                             Direction = ParameterDirection.Output
                                        };
                                        dbCommand.Parameters.Add(outParm);;

                                        dbCommand.ExecuteNonQuery();
								        ResponseMessage = outParm.Value.ToString();
								        if (dbCommand.Connection.State != ConnectionState.Closed)
                    			        {
										         dbCommand.Connection.Dispose();
								        }

						        }
						        npsql.Close();
					        }
 

					}catch(Exception ex){
						ResponseMessage=ex.Message;
						Console.WriteLine(ex);
					} 
					
					return ResponseMessage;

			   }
public virtual System.Data.DataTable getById_MailLogs(string MailLogsid)
									 {
										DataTable dataTable = new DataTable();
										DataSet dataSet = new DataSet();
										try{
												 
												using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
												{
													npsql.Open();
													using (var dbCommand = new NpgsqlCommand("\"getById_sp_MailLogs\"", npsql))
													{
														dbCommand.CommandType = CommandType.StoredProcedure;
														dbCommand.Parameters.AddWithValue("pvar_maillogsid",(object)MailLogsid??DBNull.Value);
														using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(dbCommand))
														{
															dataSet.Reset();
															dataAdapter.Fill(dataSet);
															dataTable = dataSet.Tables[0];
															if (dbCommand.Connection.State != ConnectionState.Closed)
															{
																dbCommand.Connection.Dispose();
															}
														}
													}
													npsql.Close();
												}
					 
										}catch{
												throw;
										}
										return dataTable;
									 }
			 public virtual string  Update_MailLog(MailLogsModel model)
			 { 
				 String ResponseMessage="";
					try{
						 	 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"Update_MailLog\"", npsql))
								{
										dbCommand.CommandType = CommandType.StoredProcedure;
															dbCommand.Parameters.AddWithValue("pvar_maillogsid",NpgsqlDbType.Uuid,(object)model.MailLogsid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_entityname",NpgsqlDbType.Varchar,(object)model.entityname??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_entityid",NpgsqlDbType.Varchar,(object)model.entityid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_mailfor",NpgsqlDbType.Varchar,(object)model.mailfor??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_mailsubject",NpgsqlDbType.Varchar,(object)model.mailsubject??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_mailto",NpgsqlDbType.Varchar,(object)model.mailto??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_mailbody",NpgsqlDbType.Varchar,(object)model.mailbody??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_issent",NpgsqlDbType.Boolean,(object)model.issent??DBNull.Value);
dbCommand.Parameters.AddWithValue("pvar_modifieduser",NpgsqlDbType.Uuid,model.modifieduser);	
										NpgsqlParameter outParm = new NpgsqlParameter("@returnMessage", NpgsqlDbType.Varchar)
										{
											 Direction = ParameterDirection.Output
										};
										dbCommand.Parameters.Add(outParm);;

										dbCommand.ExecuteNonQuery();
										ResponseMessage = outParm.Value.ToString();
										if (dbCommand.Connection.State != ConnectionState.Closed)
										{
												 dbCommand.Connection.Dispose();
										}

								}
								npsql.Close();
							}		 

					}catch(Exception ex){
						ResponseMessage=ex.Message;
					}
					
					return ResponseMessage;

			   }
public virtual string  Remove_MailLog(string id,string loginUserID)
			  { 
				  String ResponseMessage="";
					try{ 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"Remove_MailLog\"", npsql))
								{
										dbCommand.CommandType = CommandType.StoredProcedure;
										dbCommand.Parameters.AddWithValue("pvar_maillogsid",(object)id??DBNull.Value);
										dbCommand.Parameters.AddWithValue("pvar_modifieduser",(object)loginUserID??DBNull.Value);
										NpgsqlParameter outParm = new NpgsqlParameter("@returnMessage", NpgsqlDbType.Varchar)
										{
											 Direction = ParameterDirection.Output
										};
										dbCommand.Parameters.Add(outParm);;

										dbCommand.ExecuteNonQuery();
										ResponseMessage = outParm.Value.ToString();
										if (dbCommand.Connection.State != ConnectionState.Closed)
										{
												 dbCommand.Connection.Dispose();
										}

								}
								npsql.Close();
							}	 

					}catch(Exception ex){
						ResponseMessage=ex.Message;
					}
					
					return ResponseMessage;

			   }
public virtual System.Data.DataTable MailLogs_List(string entityname
)
			  { 
					DataTable dataTable = new DataTable();
                DataSet dataSet = new DataSet(); 

					try{
 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"MailLogs_List\"", npsql))
								{
									dbCommand.CommandType = CommandType.StoredProcedure;
									dbCommand.Parameters.AddWithValue("pvar_entityname",(object)entityname??DBNull.Value);

									using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(dbCommand))
									{
										dataSet.Reset();
										dataAdapter.Fill(dataSet);
										dataTable = dataSet.Tables[0];
										if (dbCommand.Connection.State != ConnectionState.Closed)
										{
											dbCommand.Connection.Dispose();
										}
									}
								}
								npsql.Close();
							}

						 

					}catch{
						throw;
					}


					return dataTable;	


					 

			   }
			   
			 
public virtual System.Data.DataTable get_all_MailLogs(string tenantid)
			  { 

				    DataTable dataTable = new DataTable();
					DataSet dataSet = new DataSet();

					try{
 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"get_all_MailLogs\"", npsql))
								{
									dbCommand.CommandType = CommandType.StoredProcedure;
									dbCommand.Parameters.AddWithValue("pvar_tenantid",(object)tenantid??DBNull.Value);
									using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(dbCommand))
									{
										dataSet.Reset();
										dataAdapter.Fill(dataSet);
										dataTable = dataSet.Tables[0];
										if (dbCommand.Connection.State != ConnectionState.Closed)
										{
											dbCommand.Connection.Dispose();
										}
									}
								}
								npsql.Close();
							}
						

					}catch{
						throw;
					}
					return dataTable;	


					 

			   }
public virtual System.Data.DataSet getById_sp_all_MailLogs(string MailLogsid)
			 {
				DataSet dataSet=new DataSet();
				try{
					     
						using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
						{
							npsql.Open();
							using (var dbCommand = new NpgsqlCommand("\"getById_sp_all_MailLogs\"", npsql))
							{
								dbCommand.CommandType = CommandType.StoredProcedure;
								dbCommand.Parameters.AddWithValue("pvar_maillogsid",(object)MailLogsid??DBNull.Value);
								using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(dbCommand))
								{
									dataSet.Reset();
									dataAdapter.Fill(dataSet);
									if (dbCommand.Connection.State != ConnectionState.Closed)
									{
										dbCommand.Connection.Dispose();
									}
								}
							}
							npsql.Close();
						}
					 
				}catch{
						throw;
				}
				return dataSet;
			 }
			  public virtual string  verify_MailLogs(string MailLogsid,string verifiedby,string verifiedstatus,string reviewcomments)
			 { 
				 String ResponseMessage="";
					try{
						 
							 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"verify_MailLogs\"", npsql))
								{
										dbCommand.CommandType = CommandType.StoredProcedure;
										 dbCommand.Parameters.AddWithValue("pvar_maillogsid",(object)MailLogsid??DBNull.Value);
										dbCommand.Parameters.AddWithValue("pvar_verifiedby",(object)verifiedby??DBNull.Value);
										dbCommand.Parameters.AddWithValue("pvar_verifiedstatus",(object)verifiedstatus??DBNull.Value);
										dbCommand.Parameters.AddWithValue("pvar_reviewcomments",(object)reviewcomments??DBNull.Value); 
										NpgsqlParameter outParm = new NpgsqlParameter("@returnMessage", NpgsqlDbType.Varchar)
										{
											 Direction = ParameterDirection.Output
										};
										dbCommand.Parameters.Add(outParm);;

										dbCommand.ExecuteNonQuery();
										ResponseMessage = outParm.Value.ToString();
										if (dbCommand.Connection.State != ConnectionState.Closed)
										{
												 dbCommand.Connection.Dispose();
										}

								}
								npsql.Close();
							}
						 

					}catch(Exception ex){
						ResponseMessage=ex.Message;
					}
					
					return ResponseMessage;

			   }








			    }


			    }
