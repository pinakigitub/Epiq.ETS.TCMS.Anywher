/****** Script for SelectTopNRows command from SSMS  ******/
--SELECT *  FROM [TCMS21].[dbo].[Distribution]
--WHERE CaseId=10;

UPDATE [TCMS21].[dbo].[Distribution]
SET Name='Final Distribution 2'
WHERE DistributionId=48;