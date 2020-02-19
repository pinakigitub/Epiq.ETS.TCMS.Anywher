DECLARE @Content varbinary(255) = (SELECT CONVERT(VARBINARY(255), 'Document content'));
DECLARE @MyChecksum varbinary(255) = (SELECT CONVERT(VARBINARY(255),'0xB5CD16DD'));
DECLARE @CaseId int = (SELECT CaseId FROM [dbo].[Case] WHERE CoreCaseNumber=@CoreCaseNumber)
DECLARE @OfficeId int = (SELECT OfficeId FROM [dbo].[Office] WHERE OfficeCode=@OfficeCode);
DECLARE @DocumentId int

DECLARE @RC int
EXECUTE @RC = [dbo].[DocumentSave] 
   @DocumentId = 0
  ,@DocumentDescription = 'A description for the document'
  ,@DocumentComment = 'A comment for the document'
  ,@FileName = @ItemName
  ,@FileExtension = 'pdf'
  ,@FilePath = NULL
  ,@ImportedOnDate = '2015-09-01 00:00:00'
  ,@OfficeId = @OfficeId
  ,@ModifiedByUserId = 3
  ,@DocumentSensitivityId = 2
  ,@DocumentTypeId = 2
  ,@DocumentNumber= 1
  ,@FiledOnDate = '2015-09-01 00:00:00'
  ,@DocumentStatusTypeId = 2
  ,@CaseId=@CaseId
  ,@DocumentContent = @Content
  ,@FileLength=200
  ,@Checksum = @MyChecksum