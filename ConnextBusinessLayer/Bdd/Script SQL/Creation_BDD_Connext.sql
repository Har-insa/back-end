/* USER */

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[ID_USER] [int] IDENTITY(1,1) NOT NULL,
	[FIRST_NAME] [varchar](255) NOT NULL,
	[LAST_NAME] [varchar](255) NOT NULL,
	[EMAIL] [varchar](255) NOT NULL,
	[PASSWORD] [varchar](255) NOT NULL,
	[ID_AGENCY] [int] NOT NULL,
	[DESCRIPTION] [varchar](255) NULL,
	CONSTRAINT [UQ_codes] UNIQUE NONCLUSTERED
(
    [EMAIL]
),
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[ID_USER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

/* AGENCY */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AGENCY](
	[ID_AGENCY] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](255) NOT NULL,
	[LATITUDE] [decimal](9,6) NOT NULL,
	[LONGITUDE] [decimal](9,6) NOT NULL,
 CONSTRAINT [PK_AGENCY] PRIMARY KEY CLUSTERED 
(
	[ID_AGENCY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD  CONSTRAINT [FK_USER_AGENCY] FOREIGN KEY([ID_AGENCY])
REFERENCES [dbo].[AGENCY] ([ID_AGENCY])

INSERT [dbo].[AGENCY] ([NAME], [LATITUDE], [LONGITUDE]) VALUES ('INSA de Lyon', 45.78264, 4.878073)

INSERT [dbo].[USER] ([FIRST_NAME], [LAST_NAME], [EMAIL], [PASSWORD], [ID_AGENCY], [DESCRIPTION]) VALUES ('Terces', 'Connext', 'terces.connext@hardis.fr', 'password', 1, 'Test User')

/* TRAVEL */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRAVEL](
	[ID_TRAVEL] [int] IDENTITY(1,1) NOT NULL,
	[ID_DEPARTUREAGENCY] [int] NOT NULL,
	[ID_ARRIVALAGENCY] [int] NOT NULL,
	[CAPACITY] [int] NOT NULL,
	[DEPARTUREHOUR] [datetime] NOT NULL,
	[ARRIVALHOUR] [datetime] NOT NULL,
	[MEETINGPLACE] [varchar] (255),
 CONSTRAINT [PK_TRAVEL] PRIMARY KEY CLUSTERED 
(
	[ID_TRAVEL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TRAVEL]  WITH CHECK ADD  CONSTRAINT [FK_TRAVEL_DEPARTUREAGENCY] FOREIGN KEY([ID_DEPARTUREAGENCY])
REFERENCES [dbo].[AGENCY] ([ID_AGENCY])

GO
ALTER TABLE [dbo].[TRAVEL]  WITH CHECK ADD  CONSTRAINT [FK_TRAVEL_ARRIVALAGENCY] FOREIGN KEY([ID_ARRIVALAGENCY])
REFERENCES [dbo].[AGENCY] ([ID_AGENCY])

INSERT [dbo].[TRAVEL] ([ID_DEPARTUREAGENCY], [ID_ARRIVALAGENCY], [CAPACITY], [DEPARTUREHOUR], [ARRIVALHOUR]) VALUES (1, 1, 4, '2015-12-06 12:30:00', '2015-12-07 15:30:00')

/* GROUP */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GROUP](
	[ID_GROUP] [int] IDENTITY(1,1) NOT NULL,
	[LABEL] [varchar](255) NOT NULL,
 CONSTRAINT [PK_GROUP] PRIMARY KEY CLUSTERED 
(
	[ID_GROUP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT [dbo].[GROUP] ([LABEL]) VALUES ('Hexanome')

/* USERGROUP */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERGROUP](
	[ID_USERGROUP] [int] IDENTITY(1,1) NOT NULL,
	[ID_USER] [int] NOT NULL,
	[ID_GROUP] [int] NOT NULL,
 CONSTRAINT [PK_USERGROUP] PRIMARY KEY CLUSTERED 
(
	[ID_USERGROUP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[USERGROUP]  WITH CHECK ADD  CONSTRAINT [FK_USERGROUP_USER] FOREIGN KEY([ID_USER])
REFERENCES [dbo].[USER] ([ID_USER])

GO
ALTER TABLE [dbo].[USERGROUP]  WITH CHECK ADD  CONSTRAINT [FK_USERGROUP_GROUP] FOREIGN KEY([ID_GROUP])
REFERENCES [dbo].[GROUP] ([ID_AGENCY])

INSERT [dbo].[USERGROUP] ([ID_USER], [ID_GROUP]) VALUES ( 1, 1)

INSERT [dbo].[USERGROUP] ([ID_USER], [ID_GROUP]) VALUES ( 2, 1)

/* PUBLICATION */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PUBLICATION](
	[ID_PUBLICATION] [int] IDENTITY(1,1) NOT NULL,
	[TITLE] [varchar] (255) NOT NULL,
	[DESCRIPTION] [varchar] (255),
	[ID_CATEGORY] [int] NOT NULL,
	[ID_TRAVEL] [int] NOT NULL,
 CONSTRAINT [PK_PUBLICATION] PRIMARY KEY CLUSTERED 
(
	[ID_PUBLICATION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PUBLICATION]  WITH CHECK ADD  CONSTRAINT [FK_PUBLICATION_TRAVEL] FOREIGN KEY([ID_TRAVEL])
REFERENCES [dbo].[TRAVEL] ([ID_TRAVEL])

/* CATEGORY */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY](
	[ID_CATEGORY] [int] IDENTITY(1,1) NOT NULL,
	[TITLE] [varchar] (255) NOT NULL,
	[DESCRIPTION] [varchar] (255),
 CONSTRAINT [PK_CATEGORY] PRIMARY KEY CLUSTERED 
(
	[ID_CATEGORY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PUBLICATION]  WITH CHECK ADD  CONSTRAINT [FK_PUBLICATION_CATEGORY] FOREIGN KEY([ID_CATEGORY])
REFERENCES [dbo].[CATEGORY] ([ID_CATEGORY])

INSERT [dbo].[CATEGORY] ([TITLE], [DESCRIPTION]) VALUES ( 'Covoiturage', 'Trajet en voiture � plusieurs')

INSERT [dbo].[PUBLICATION] ([TITLE], [DESCRIPTION], [ID_CATEGORY], [ID_TRAVEL]) VALUES ( 'Covoiturage vers Lyon', 'Trajet en voiture � plusieurs', 1, 1)

/* QUESTION */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUESTION](
	[ID_QUESTION] [int] IDENTITY(1,1) NOT NULL,
	[TITLE] [varchar] (255) NOT NULL,
	[DESCRIPTION] [varchar] (255),
	[ID_PUBLICATION] [int] NOT NULL,
 CONSTRAINT [PK_QUESTION] PRIMARY KEY CLUSTERED 
(
	[ID_QUESTION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[QUESTION]  WITH CHECK ADD  CONSTRAINT [FK_QUESTION_PUBLICATION] FOREIGN KEY([ID_PUBLICATION])
REFERENCES [dbo].[PUBLICATION] ([ID_PUBLICATION])