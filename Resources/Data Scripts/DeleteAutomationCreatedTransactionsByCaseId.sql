--DECLARE @CaseId INT
--SET @CaseId=1092

DECLARE @NameOrDescriptionLikeText varchar(50)
SET @NameOrDescriptionLikeText ='%Test Automation%'

--ASSETS LINK
DELETE FROM [dbo].[AssetBankAccountTransaction] WHERE AssetBankAccountTransactionId IN (
SELECT AssetBankAccountTransactionId FROM [dbo].[AssetBankAccountTransaction] WHERE BankAccountTransactionAllocationId IN (
SELECT BankAccountTransactionAllocationId FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId IN (
SELECT BankAccountTransactionId FROM BankAccountTransaction WHERE BankAccountId IN (SELECT BankAccountId FROM BankAccount WHERE CaseId = @CaseId) 
AND (FullName LIKE @NameOrDescriptionLikeText OR TransactionDescription LIKE @NameOrDescriptionLikeText))))

--CLOSING COSTS Y NON PAYEE
DELETE FROM [dbo].[ClaimBankAccountTransaction] WHERE ClaimBankAccountTransactionId IN (
SELECT ClaimBankAccountTransactionId FROM [dbo].[ClaimBankAccountTransaction] WHERE BankAccountTransactionAllocationId IN (
SELECT BankAccountTransactionAllocationId FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId IN (
SELECT BankAccountTransactionId FROM BankAccountTransaction WHERE BankAccountId IN (SELECT BankAccountId FROM BankAccount WHERE CaseId = @CaseId) 
AND (FullName LIKE @NameOrDescriptionLikeText OR TransactionDescription LIKE @NameOrDescriptionLikeText))))

--BankAccountTransactionAllocation (ASSETS & CLOSING COSTS/NON PAYEE)
DELETE FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionAllocationId IN (
SELECT BankAccountTransactionAllocationId FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId IN (
SELECT BankAccountTransactionId FROM BankAccountTransaction WHERE BankAccountId IN (SELECT BankAccountId FROM BankAccount WHERE CaseId = @CaseId) 
AND (FullName LIKE @NameOrDescriptionLikeText OR TransactionDescription LIKE @NameOrDescriptionLikeText)))

--Print Status
DELETE FROM [dbo].[BankAccountTransactionPrintStatus] WHERE BankAccountTransactionId IN (
SELECT BankAccountTransactionId FROM BankAccountTransaction WHERE BankAccountId IN (SELECT BankAccountId FROM BankAccount WHERE CaseId = @CaseId) 
AND (FullName LIKE @NameOrDescriptionLikeText OR TransactionDescription LIKE @NameOrDescriptionLikeText))

DELETE FROM [dbo].[BankAccountTransactionPrintLog] WHERE BankAccountTransactionId IN (
SELECT BankAccountTransactionId FROM BankAccountTransaction WHERE BankAccountId IN (SELECT BankAccountId FROM BankAccount WHERE CaseId = @CaseId) 
AND (FullName LIKE @NameOrDescriptionLikeText OR TransactionDescription LIKE @NameOrDescriptionLikeText))

--BankAccountTransaction : DEPOSIT
DELETE FROM BankAccountTransaction WHERE BankAccountTransactionId IN (
SELECT BankAccountTransactionId FROM BankAccountTransaction WHERE BankAccountId IN (SELECT BankAccountId FROM BankAccount WHERE CaseId = @CaseId) 
AND (FullName LIKE @NameOrDescriptionLikeText OR TransactionDescription LIKE @NameOrDescriptionLikeText))