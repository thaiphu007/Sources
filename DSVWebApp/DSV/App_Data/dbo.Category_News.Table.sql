/****** Object:  Table [dbo].[Category_News]    Script Date: 08/22/2013 18:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_News]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Category_News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsHidden] [bit] NOT NULL,
 CONSTRAINT [PK_Category_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Category_News_DisplayOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Category_News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Category_News_DisplayOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Category_News] ADD  CONSTRAINT [DF_Category_News_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
END


End
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Category_News_IsHidden]') AND parent_object_id = OBJECT_ID(N'[dbo].[Category_News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Category_News_IsHidden]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Category_News] ADD  CONSTRAINT [DF_Category_News_IsHidden]  DEFAULT ((0)) FOR [IsHidden]
END


End
GO
