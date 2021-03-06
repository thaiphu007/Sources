/****** Object:  Table [dbo].[News]    Script Date: 08/22/2013 18:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[News]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArTitle] [nvarchar](150) NOT NULL,
	[ArSummary] [nvarchar](max) NOT NULL,
	[ArContent] [nvarchar](max) NOT NULL,
	[ImageDefault] [nvarchar](500) NOT NULL,
	[IsPublished] [bit] NOT NULL,
	[CreateDated] [datetime] NOT NULL,
	[CateId] [int] NULL,
	[NumberView] [int] NOT NULL,
	[PublishDated] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[HotNews] [bit] NOT NULL,
	[MetaTitle] [nvarchar](500) NULL,
	[MetaKeyword] [nvarchar](500) NULL,
	[MetaDesc] [nvarchar](500) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_News_Category_News]') AND parent_object_id = OBJECT_ID(N'[dbo].[News]'))
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Category_News] FOREIGN KEY([CateId])
REFERENCES [dbo].[Category_News] ([Id])
ON DELETE SET NULL
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_News_Category_News]') AND parent_object_id = OBJECT_ID(N'[dbo].[News]'))
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Category_News]
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_News_IsPublished]') AND parent_object_id = OBJECT_ID(N'[dbo].[News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_News_IsPublished]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_IsPublished]  DEFAULT ((0)) FOR [IsPublished]
END


End
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_News_CreateDated]') AND parent_object_id = OBJECT_ID(N'[dbo].[News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_News_CreateDated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_CreateDated]  DEFAULT (getdate()) FOR [CreateDated]
END


End
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_News_CateId]') AND parent_object_id = OBJECT_ID(N'[dbo].[News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_News_CateId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_CateId]  DEFAULT ((0)) FOR [CateId]
END


End
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_News_NumberView]') AND parent_object_id = OBJECT_ID(N'[dbo].[News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_News_NumberView]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_NumberView]  DEFAULT ((0)) FOR [NumberView]
END


End
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_News_PublishDated]') AND parent_object_id = OBJECT_ID(N'[dbo].[News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_News_PublishDated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_PublishDated]  DEFAULT ((0)) FOR [PublishDated]
END


End
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_News_DisplayOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_News_DisplayOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
END


End
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_News_HotNews]') AND parent_object_id = OBJECT_ID(N'[dbo].[News]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_News_HotNews]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_HotNews]  DEFAULT ((0)) FOR [HotNews]
END


End
GO
