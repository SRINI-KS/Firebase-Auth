CREATE TABLE IF NOT EXISTS system_logging(
				system_logging_guid uuid NOT NULL DEFAULT uuid_generate_v4(),
				entered_date Timestamp(3) NOT NULL DEFAULT NOW(),
				log_application varchar(200) NULL,
				log_date varchar(100) NULL,
				log_level varchar(100) NULL,
				log_logger varchar(8000) NULL,
				log_message varchar(8000) NULL,
				log_machine_name varchar(8000) NULL,
				log_user_name varchar(8000) NULL,
				log_call_site varchar(8000) NULL,
				log_thread varchar(100) NULL,
				log_exception varchar(8000) NULL,
				log_stacktrace varchar(8000) NULL,
				ipaddress varchar(256) NULL,
				log_code varchar(128) NULL,
				CONSTRAINT PK_system_logging PRIMARY KEY (system_logging_guid) 
				);
CREATE TABLE IF NOT EXISTS projectstructure(
								projectelementname Varchar(128) NULL,
								elementtype Varchar(128) NULL,
								parentnode Varchar(128) NULL,
								subsystem Varchar(128) NULL,
								structureorder int NULL,
								assignedentityname Varchar(128) NULL,
								displayicon Varchar(128) NULL
							);
CREATE TABLE IF NOT EXISTS roles(
									rolesid uuid NOT NULL,
									rolename Varchar(128) NULL,
									rolegroupname Varchar(128) NULL,
									parentname Varchar(128) NULL,
									rolehierarchynumber Varchar(128) NULL
							);
CREATE TABLE IF NOT EXISTS roleauthorization(
									roleauthorizationid uuid NOT NULL,
									controllername Varchar(128) NULL,
									actionname Varchar(128) NULL,
									viewname Varchar(128) NULL,
									viewactionroles Varchar(256) NULL,
									actiondisplayname Varchar(256) NULL,
									actionmethodname Varchar(256) NULL
							);
CREATE TABLE IF NOT EXISTS userlockout(
							username Varchar(150) NOT NULL,
							lastupdateddate Timestamp(3) NOT NULL,
							lockremovedby Varchar(250) NULL,
							latlan Varchar(150) NULL,
							remoteipaddress Varchar(150) NULL,
							clientipaddress Varchar(150) NULL,
							isdeleted boolean NULL,
							lockoutid uuid NULL
							);
CREATE TABLE IF NOT EXISTS lookups(
							lookupid uuid NOT NULL,
							entityname Varchar(256) NULL,
							attributetype Varchar(256) NULL,
							fieldname Varchar(256) NULL,
							fielddesc Varchar(1024) NULL,
							createduser uuid NULL,
							createddate Timestamp(3) NULL,
							modifieduser uuid NULL,
							modifieddate Timestamp(3) NULL,
							isdeleted Boolean NULL,
							CONSTRAINT PK_lookups PRIMARY KEY (lookupid)
							);
CREATE TABLE access_logs
										(
											access_logsid uuid NOT NULL,
											users_id character varying(256),
											logged_date timestamp(3) without time zone NOT NULL DEFAULT now(),
											expiry_date timestamp(3) without time zone NOT NULL DEFAULT now(),
											user_token character varying(4000),
											external_users_id character varying(256),
											external_entity_name character varying(256),
											latlan character varying(256),
											clientipaddress character varying(256),
											devicename character varying(256),
											browsername character varying(256),
											createddate timestamp(3) without time zone NOT NULL DEFAULT now(),
											modifieduser uuid,
											modifieddate timestamp(3) without time zone,
											isdeleted boolean DEFAULT false,
											createduser uuid NOT NULL,
											logout_date timestamp(3) without time zone,
											CONSTRAINT access_logs_pkey PRIMARY KEY (access_logsid)
										);
										
CREATE TABLE access_logs_details
										(
												 access_logsid uuid NOT NULL
												,action_method_name character varying(256)
												,api_response character varying(1024)
												,accessed_date timestamp(3) without time zone NOT NULL DEFAULT now()
										);
CREATE TABLE api_access_logs
										(
											api_access_logsid uuid NOT NULL,
											users_id character varying(256),
											logged_date timestamp(3) without time zone NOT NULL DEFAULT now(),
											user_token character varying(4000),
											api_url character varying(256),
											request_type character varying(256),
											request_json json,
											response_json json,
											createddate timestamp(3) without time zone NOT NULL DEFAULT now(),
											modifieduser uuid,
											modifieddate timestamp(3) without time zone,
											isdeleted boolean DEFAULT false,
											createduser uuid NOT NULL,
											CONSTRAINT api_access_logspkey PRIMARY KEY (api_access_logsid)
										);
CREATE TABLE IF NOT EXISTS history(
												table_name varchar(50) NULL
												,log_date Timestamp(3) NULL
												,log_xml xml  NULL
												);

