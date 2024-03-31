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
			    //This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 03/28/2024 06:41:18
			    public class usersDAL
			    {
					public virtual string db_connectionstring{get;set;}
			 	    public usersDAL(string connectionString)
				    {
					    db_connectionstring=connectionString;
				    }
				  
			        public virtual System.Data.DataTable getById_alloweddevices(string usersid)
			 {
					DataTable dataTable=new DataTable();
					DataSet dataSet=new DataSet();
					try
					{
						  
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"getById_sp_users_alloweddevices\"", npsql))
								{
									dbCommand.CommandType = CommandType.StoredProcedure;
									dbCommand.Parameters.AddWithValue("pvar_usersid",(object)usersid??DBNull.Value);
								
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


              public virtual string Register_Profile(usersModel model)
			  { 
				  String ResponseMessage="";
					 
					try{
							 
                            using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
					        {
						        npsql.Open();
						        using (var dbCommand = new NpgsqlCommand("\"Register_Profile\"", npsql))
						        {
                                        dbCommand.CommandType = CommandType.StoredProcedure;
						            	RandomStringGenerator objRandom =new RandomStringGenerator();
				string user_passwordkey = objRandom.CreateRandomPassword(8);
				string user_password = PwdEncrypDecrypt.Encrypt(user_passwordkey,model.userpassword);
				model.userpassword=user_password;
				model.passwordkey=user_passwordkey;
								        					dbCommand.Parameters.AddWithValue("pvar_usersid",NpgsqlDbType.Uuid,(object)model.usersid??DBNull.Value);
dbCommand.Parameters.AddWithValue("pvar_tenantid",NpgsqlDbType.Uuid,(object)model.tenantid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_firstname",NpgsqlDbType.Varchar,(object)model.firstname??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_lastname",NpgsqlDbType.Varchar,(object)model.lastname??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_profilepicture",NpgsqlDbType.Varchar,(object)model.profilepicture??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_username",NpgsqlDbType.Varchar,(object)model.username??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_userpassword",NpgsqlDbType.Varchar,(object)model.userpassword??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_emailid",NpgsqlDbType.Varchar,(object)model.emailid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_mobilenumber",NpgsqlDbType.Varchar,(object)model.mobilenumber??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_userrole",NpgsqlDbType.Varchar,(object)model.userrole??DBNull.Value);
dbCommand.Parameters.AddWithValue("pvar_passwordkey",NpgsqlDbType.Varchar,model.passwordkey);
dbCommand.Parameters.AddWithValue("pvar_createduser",NpgsqlDbType.Uuid,(object)model.createduser??DBNull.Value);if(model.alloweddevices !=null  && model.alloweddevices.Count >0)
dbCommand.Parameters.AddWithValue("pvar_alloweddevices",NpgsqlDbType.Json,JsonConvert.SerializeObject(model.alloweddevices));
else
dbCommand.Parameters.AddWithValue("pvar_alloweddevices",NpgsqlDbType.Json,DBNull.Value);
	
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
public virtual System.Data.DataTable getById_users(string usersid)
									 {
										DataTable dataTable = new DataTable();
										DataSet dataSet = new DataSet();
										try{
												 
												using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
												{
													npsql.Open();
													using (var dbCommand = new NpgsqlCommand("\"getById_sp_users\"", npsql))
													{
														dbCommand.CommandType = CommandType.StoredProcedure;
														dbCommand.Parameters.AddWithValue("pvar_usersid",(object)usersid??DBNull.Value);
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
			 public virtual string  Update_Profile(usersModel model)
			 { 
				 String ResponseMessage="";
					try{
						 	 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"Update_Profile\"", npsql))
								{
										dbCommand.CommandType = CommandType.StoredProcedure;
															dbCommand.Parameters.AddWithValue("pvar_usersid",NpgsqlDbType.Uuid,(object)model.usersid??DBNull.Value);
dbCommand.Parameters.AddWithValue("pvar_tenantid",NpgsqlDbType.Uuid,(object)model.tenantid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_firstname",NpgsqlDbType.Varchar,(object)model.firstname??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_lastname",NpgsqlDbType.Varchar,(object)model.lastname??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_profilepicture",NpgsqlDbType.Varchar,(object)model.profilepicture??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_username",NpgsqlDbType.Varchar,(object)model.username??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_emailid",NpgsqlDbType.Varchar,(object)model.emailid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_mobilenumber",NpgsqlDbType.Varchar,(object)model.mobilenumber??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_userrole",NpgsqlDbType.Varchar,(object)model.userrole??DBNull.Value);
dbCommand.Parameters.AddWithValue("pvar_modifieduser",NpgsqlDbType.Uuid,model.modifieduser);if(model.alloweddevices !=null  && model.alloweddevices.Count >0)
dbCommand.Parameters.AddWithValue("pvar_alloweddevices",NpgsqlDbType.Json,JsonConvert.SerializeObject(model.alloweddevices));
else
dbCommand.Parameters.AddWithValue("pvar_alloweddevices",NpgsqlDbType.Json,DBNull.Value);
	
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
public virtual string  Suspend_Profile(string id,string loginUserID)
			  { 
				  String ResponseMessage="";
					try{ 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"Suspend_Profile\"", npsql))
								{
										dbCommand.CommandType = CommandType.StoredProcedure;
										dbCommand.Parameters.AddWithValue("pvar_usersid",(object)id??DBNull.Value);
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

				public virtual string get_decryptedPassword(string userName)
				{

					string decryptedPassword = "";
					DataTable pwdandKey = checkUserKey_users(userName);
					if (pwdandKey.Rows.Count > 0)
					{
						string user_password = pwdandKey.Rows[0]["userpassword"].ToString();
						string user_passwordKey = pwdandKey.Rows[0]["passwordkey"].ToString();
						decryptedPassword = PwdEncrypDecrypt.Decrypt(user_passwordKey, user_password);
						//password= decryptedPassword; 

					}

					return decryptedPassword;
				}
		
			public virtual System.Data.DataTable get_roleAuthorizations(string viewactionroles)
			{
					DataTable dataTable=new DataTable();
                    DataSet dataSet=new DataSet();
					 
					try
					{ 
                            using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
                            {
	                            npsql.Open();
	                            using (var dbCommand = new NpgsqlCommand("\"get_sp_roleauthorizations\"", npsql))
	                            {
		                            dbCommand.CommandType = CommandType.StoredProcedure;
		                            dbCommand.Parameters.AddWithValue("pvar_viewactionroles",(object)viewactionroles??DBNull.Value);
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
			public virtual System.Data.DataTable get_project_Menu(string viewactionroles,string subsystem)
			{

				   DataTable dataTable=new DataTable();
                    DataSet dataSet=new DataSet();
					try
					{
							  
                            
                             using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
                            {
	                            npsql.Open();
	                            using (var dbCommand = new NpgsqlCommand("\"get_sp_project_Menu\"", npsql))
	                            {
		                            dbCommand.CommandType = CommandType.StoredProcedure;
		                            dbCommand.Parameters.AddWithValue("pvar_viewactionroles",(object)viewactionroles??DBNull.Value);
									dbCommand.Parameters.AddWithValue("pvar_subsystem",(object)subsystem??DBNull.Value);
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
			public virtual System.Data.DataTable get_roles(string roles)
			{ 
 				   DataTable dataTable=new DataTable();
                    DataSet dataSet=new DataSet();
					try
					{
                            using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
                            {
	                            npsql.Open();
	                            using (var dbCommand = new NpgsqlCommand("\"get_sp_roles\"", npsql))
	                            {
		                            dbCommand.CommandType = CommandType.StoredProcedure;
		                            dbCommand.Parameters.AddWithValue("pvar_roles",(object)roles??DBNull.Value);
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
			public virtual System.Data.DataTable checkUserKey_users(string username)
			{
				   DataTable dataTable=new DataTable();
                    DataSet dataSet=new DataSet();
					try
					{
						 	 
                            using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
                            {
	                            npsql.Open();
	                            using (var dbCommand = new NpgsqlCommand("\"checkUserKey_sp_users\"", npsql))
	                            {
		                            dbCommand.CommandType = CommandType.StoredProcedure;
		                            dbCommand.Parameters.AddWithValue("pvar_username",(object)username??DBNull.Value);
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

			
			
			public virtual System.Data.DataTable checkUserAuthentication_users(userloginModel model)
			{ 
				
				DataTable dataTable=new DataTable();
			if(model.source=="Internal"){	
			DataTable pwdandKey = checkUserKey_users(model.username);
				if(pwdandKey.Rows.Count > 0)
				{
					string user_password = pwdandKey.Rows[0]["userpassword"].ToString();
					string user_passwordkey = pwdandKey.Rows[0]["passwordkey"].ToString(); 
					string decryptedPassword = PwdEncrypDecrypt.Decrypt(user_passwordkey, user_password); 
					
					if (model.userpassword == decryptedPassword)
					{
						model.userpassword = user_password;
					}
					else
                    {
                        return dataTable;
                    }
				}
				}

				   
                    DataSet dataSet=new DataSet();
					try
					{ 
							if(model.userpassword !=null && model.mobilenumber !=null)
							{
								RandomStringGenerator objRandom =new RandomStringGenerator();
								string user_passwordkey = objRandom.CreateRandomPassword(8);
								string user_password = PwdEncrypDecrypt.Encrypt(user_passwordkey,model.userpassword);
								model.userpassword=user_password;
								 
				
							}
                            using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
                            {
	                            npsql.Open();
	                            using (var dbCommand = new NpgsqlCommand("\"checkUser_sp_users\"", npsql))
	                            {
		                            dbCommand.CommandType = CommandType.StoredProcedure;
		                            dbCommand.Parameters.AddWithValue("pvar_username",(object)model.username??DBNull.Value);
                                    dbCommand.Parameters.AddWithValue("pvar_userpassword",(object)model.userpassword??DBNull.Value);
									dbCommand.Parameters.AddWithValue("pvar_source",(object)model.source??DBNull.Value);
									dbCommand.Parameters.AddWithValue("pvar_devicename",(object)model.devicename??DBNull.Value);
									dbCommand.Parameters.AddWithValue("pvar_deviceid",(object)model.deviceid??DBNull.Value);
									dbCommand.Parameters.AddWithValue("pvar_notificationid",(object)model.notificationid??DBNull.Value);
									dbCommand.Parameters.AddWithValue("pvar_mobilenumber",(object)model.mobilenumber??DBNull.Value);
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
public virtual System.Data.DataTable List_of_User_Profiles(string tenantid
)
			  { 
					DataTable dataTable = new DataTable();
                DataSet dataSet = new DataSet(); 

					try{
 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"List_of_User_Profiles\"", npsql))
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
			   
			 
public virtual System.Data.DataTable get_all_users(string tenantid)
			  { 

				    DataTable dataTable = new DataTable();
					DataSet dataSet = new DataSet();

					try{
 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"get_all_users\"", npsql))
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
public virtual string ChangePassword(usersChangePasswordModel  model)
			  { 
				  String ResponseMessage="";
					 
					try{
							 
                            using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
					        {
						        npsql.Open();
						        using (var dbCommand = new NpgsqlCommand("\"ChangePassword\"", npsql))
						        {
                                        dbCommand.CommandType = CommandType.StoredProcedure;
                                        RandomStringGenerator objRandom =new RandomStringGenerator();
                                        string user_passwordkey = objRandom.CreateRandomPassword(8);
                                        string user_password = PwdEncrypDecrypt.Encrypt(user_passwordkey,model.userpassword);
                                        model.userpassword=user_password;
                                        model.passwordkey=user_passwordkey;

                                        dbCommand.Parameters.AddWithValue("pvar_usersid",(object)model.usersid.ToString()??DBNull.Value);
                                        dbCommand.Parameters.AddWithValue("pvar_userpassword",(object)model.userpassword??DBNull.Value);
										dbCommand.Parameters.AddWithValue("pvar_passwordkey",(object)model.passwordkey??DBNull.Value);

                                        dbCommand.Parameters.AddWithValue("pvar_modifieduser",NpgsqlDbType.Uuid,model.modifieduser);


		     			 

                                        NpgsqlParameter outParm = new NpgsqlParameter("pvar_returnMessage", NpgsqlDbType.Varchar)
                                        {
                                             Direction = ParameterDirection.Output
                                        };
                                        dbCommand.Parameters.Add(outParm);

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
public virtual System.Data.DataSet getById_sp_all_users(string usersid)
			 {
				DataSet dataSet=new DataSet();
				try{
					     
						using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
						{
							npsql.Open();
							using (var dbCommand = new NpgsqlCommand("\"getById_sp_all_users\"", npsql))
							{
								dbCommand.CommandType = CommandType.StoredProcedure;
								dbCommand.Parameters.AddWithValue("pvar_usersid",(object)usersid??DBNull.Value);
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
			  public virtual string  verify_users(string usersid,string verifiedby,string verifiedstatus,string reviewcomments)
			 { 
				 String ResponseMessage="";
					try{
						 
							 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"verify_users\"", npsql))
								{
										dbCommand.CommandType = CommandType.StoredProcedure;
										 dbCommand.Parameters.AddWithValue("pvar_usersid",(object)usersid??DBNull.Value);
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
