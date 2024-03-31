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
			    //This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:19
			    public class tenantDAL
			    {
					public virtual string db_connectionstring{get;set;}
			 	    public tenantDAL(string connectionString)
				    {
					    db_connectionstring=connectionString;
				    }
				  
			        
              public virtual string Create_tenant(tenantModel model)
			  { 
				  String ResponseMessage="";
					 
					try{
							 
                            using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
					        {
						        npsql.Open();
						        using (var dbCommand = new NpgsqlCommand("\"Create_tenant\"", npsql))
						        {
                                        dbCommand.CommandType = CommandType.StoredProcedure;
						            	RandomStringGenerator objRandom =new RandomStringGenerator();
				string user_passwordkey = objRandom.CreateRandomPassword(8);
				string user_password = PwdEncrypDecrypt.Encrypt(user_passwordkey,model.userpassword);
				model.userpassword=user_password;
				model.passwordkey=user_passwordkey;
								        					dbCommand.Parameters.AddWithValue("pvar_tenantid",NpgsqlDbType.Uuid,(object)model.tenantid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_firstname",NpgsqlDbType.Varchar,(object)model.firstname??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_lastname",NpgsqlDbType.Varchar,(object)model.lastname??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_username",NpgsqlDbType.Varchar,(object)model.username??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_userrole",NpgsqlDbType.Varchar,(object)model.userrole??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_userpassword",NpgsqlDbType.Varchar,(object)model.userpassword??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_emailid",NpgsqlDbType.Varchar,(object)model.emailid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_mobilenumber",NpgsqlDbType.Varchar,(object)model.mobilenumber??DBNull.Value);
dbCommand.Parameters.AddWithValue("pvar_passwordkey",NpgsqlDbType.Varchar,model.passwordkey);
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
public virtual System.Data.DataTable getById_tenant(string tenantid)
									 {
										DataTable dataTable = new DataTable();
										DataSet dataSet = new DataSet();
										try{
												 
												using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
												{
													npsql.Open();
													using (var dbCommand = new NpgsqlCommand("\"getById_sp_tenant\"", npsql))
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
			 public virtual string  Update_tenant(tenantModel model)
			 { 
				 String ResponseMessage="";
					try{
						 	 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"Update_tenant\"", npsql))
								{
										dbCommand.CommandType = CommandType.StoredProcedure;
															dbCommand.Parameters.AddWithValue("pvar_tenantid",NpgsqlDbType.Uuid,(object)model.tenantid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_firstname",NpgsqlDbType.Varchar,(object)model.firstname??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_lastname",NpgsqlDbType.Varchar,(object)model.lastname??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_username",NpgsqlDbType.Varchar,(object)model.username??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_userrole",NpgsqlDbType.Varchar,(object)model.userrole??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_userpassword",NpgsqlDbType.Varchar,(object)model.userpassword??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_emailid",NpgsqlDbType.Varchar,(object)model.emailid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_mobilenumber",NpgsqlDbType.Varchar,(object)model.mobilenumber??DBNull.Value);
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
public virtual string  Remove_tenant(string id,string loginUserID)
			  { 
				  String ResponseMessage="";
					try{ 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"Remove_tenant\"", npsql))
								{
										dbCommand.CommandType = CommandType.StoredProcedure;
										dbCommand.Parameters.AddWithValue("pvar_tenantid",(object)id??DBNull.Value);
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
public virtual System.Data.DataTable ViewList_tenant()
			  { 
					DataTable dataTable = new DataTable();
                DataSet dataSet = new DataSet(); 

					try{
 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"ViewList_tenant\"", npsql))
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
			   
			 
public virtual System.Data.DataTable get_all_tenant(string tenantid)
			  { 

				    DataTable dataTable = new DataTable();
					DataSet dataSet = new DataSet();

					try{
 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"get_all_tenant\"", npsql))
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
public virtual System.Data.DataTable get_project_tenant()
			  { 
					DataTable dataTable = new DataTable();
                DataSet dataSet = new DataSet(); 

					try{
 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"get_project_tenant\"", npsql))
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
			   
			 
public virtual System.Data.DataSet getById_sp_all_tenant(string tenantid)
			 {
				DataSet dataSet=new DataSet();
				try{
					     
						using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
						{
							npsql.Open();
							using (var dbCommand = new NpgsqlCommand("\"getById_sp_all_tenant\"", npsql))
							{
								dbCommand.CommandType = CommandType.StoredProcedure;
								dbCommand.Parameters.AddWithValue("pvar_tenantid",(object)tenantid??DBNull.Value);
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
			  public virtual string  verify_tenant(string tenantid,string verifiedby,string verifiedstatus,string reviewcomments)
			 { 
				 String ResponseMessage="";
					try{
						 
							 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"verify_tenant\"", npsql))
								{
										dbCommand.CommandType = CommandType.StoredProcedure;
										 dbCommand.Parameters.AddWithValue("pvar_tenantid",(object)tenantid??DBNull.Value);
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
