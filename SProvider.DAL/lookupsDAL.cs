namespace SProvider.DAL
				{
										using System;
										using System.Text;
										using System.Data;
										using System.Data.Common;
										using SProvider.Models;
										using Npgsql;
										using NpgsqlTypes;
										//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:17
										public class lookupsDAL
										{
											public lookupsDAL(string connectionString)
											{
												db_connectionstring=connectionString;
											}
				 
											private string _connectionstring;
											public virtual string db_connectionstring
											{
												get
												{
													return _connectionstring;
												}
												set
												{
													_connectionstring=value;
												}
											}											
 
											public virtual string ins_lookups(lookupsModel model)
											{ 
											
											string ResponseMessage="";
												try{


												using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
												{
													npsql.Open();
													using (var dbCommand = new NpgsqlCommand("\"ins_sp_lookups\"", npsql))
													{
														dbCommand.CommandType = CommandType.StoredProcedure;
														dbCommand.Parameters.AddWithValue("pvar_entityname",model.entityname);
														dbCommand.Parameters.AddWithValue("pvar_attributetype",model.attributetype);
														dbCommand.Parameters.AddWithValue("pvar_fieldname",model.fieldname);
														dbCommand.Parameters.AddWithValue("pvar_fielddesc",model.fielddesc);
														dbCommand.Parameters.AddWithValue("pvar_createduser", NpgsqlDbType.Uuid, (object)model.createduser ?? DBNull.Value);
														 
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
												}
												return ResponseMessage
												;
											}
											public virtual System.Data.DataTable get_lookups()
											{
													
																	
														DataSet dataSet = new DataSet();
														DataTable dataTable=new DataTable();
														try{
																		using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
																		{
																			npsql.Open();
																			using (var dbCommand = new NpgsqlCommand("\"get_sp_lookups\"", npsql))
																			{
															
																														  
																				dbCommand.CommandType = CommandType.StoredProcedure;
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
											public virtual System.Data.DataTable getById_lookups(string id)
											{ 

														DataSet dataSet = new DataSet();
														DataTable dataTable=new DataTable();
														try{
																		using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
																		{
																			npsql.Open();
																			using (var dbCommand = new NpgsqlCommand("\"getById_sp_lookups\"", npsql))
																			{
															
																														  
																				dbCommand.CommandType = CommandType.StoredProcedure;
																				dbCommand.Parameters.AddWithValue("pvar_lookup_id",id);
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
											public virtual System.Data.DataTable get_lookups_by_entity(string id)
											{
													
														DataSet dataSet = new DataSet();
														DataTable dataTable=new DataTable();
														try{
																		using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
																		{
																			npsql.Open();
																			using (var dbCommand = new NpgsqlCommand("\"get_sp_lookups_by_entity\"", npsql))
																			{
															
																														  
																				dbCommand.CommandType = CommandType.StoredProcedure;
																				dbCommand.Parameters.AddWithValue("pvar_entityname",id);
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
											
	
		 
										}
									}
