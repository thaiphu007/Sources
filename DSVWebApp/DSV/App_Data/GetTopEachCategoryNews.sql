/****** Object:  StoredProcedure [dbo].[GetTopEachCategoryNews]    Script Date: 08/23/2013 10:34:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTopEachCategoryNews]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER Procedure [dbo].[GetTopEachCategoryNews]
As
;WITH cte AS
(
   SELECT n.*,
   ROW_NUMBER() OVER (PARTITION BY CateId ORDER BY n.DisplayOrder ASC) AS rn
   FROM News n inner join Category_News cn on n.cateid=cn.Id
   where cn.IsHidden=1
)
SELECT *
FROM cte
WHERE rn = 1' 
END
