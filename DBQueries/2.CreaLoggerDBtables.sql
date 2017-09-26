CREATE TABLE [dbo].[Logs](
 [ID] [INT]	IDENTITY(1,1) NOT NULL,
 [Level] [varchar] (255) NOT NULL,
 [CallSite] [varchar] (255) NOT NULL,
 [Type] [varchar] (255) NOT NULL,
 [Message] [varchar] (255) NOT NULL,
 [LoggedOnDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([ID] ASC)
)
GO

ALTER TABLE [dbo].[Logs] ADD CONSTRAINT [DF_Logs_TimeStamp] DEFAULT (getdate()) FOR [LoggedOnDate]
GO


CREATE PROCEDURE [dbo].[InsertLog]
(
@level varchar(20),
@callsite varchar(MAX),
@type varchar(MAX),
@message varchar(MAX)
)
AS
	INSERT INTO [dbo].[Logs]
	(
 [Level],
 [CallSite],
 [Type],
 [Message]	
	)
	VALUES
	(
	@level,
	@callsite,
	@type,
	@message
	)
GO

select * from Logs