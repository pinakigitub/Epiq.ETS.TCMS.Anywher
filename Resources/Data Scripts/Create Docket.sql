DECLARE @CaseId int = (SELECT CaseId FROM [dbo].[Case] WHERE CoreCaseNumber=@CoreCaseNumber);
DECLARE @OfficeId int = (SELECT OfficeId FROM [dbo].[Office] WHERE OfficeCode=@OfficeCode);
DECLARE	@return_value int
DECLARE @DocketId int
EXEC @return_value = [dbo].[DocketSave] 
   @DocketId OUTPUT
  ,@DocketNumber = 137
  ,@DocketText = @ItemName
  ,@DocketComment = ' Here some comments'
  ,@CaseId = @CaseId
  ,@FiledOnDate='2015-09-01 00:00:00'