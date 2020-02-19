--BankAccountTransaction : DEPOSIT
--expected to show the new transaction
DECLARE @CaseId INT
SET @CaseId=1029
SELECT TOP 10 * FROM BankAccountTransaction WHERE BankAccountId IN (SELECT BankAccountId FROM BankAccount WHERE CaseId = @CaseId) ORDER BY 1 DESC

--BankAccountTransactionAllocation (ASSETS & CLOSING COSTS/NON PAYEE)
--expected to show one row for the trx and one per each linked asset, claim or non-claim payee
--here we see tha additioning of non-claim payee link
DECLARE @CaseId INT
SET @CaseId=1029
SELECT TOP 10 * FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId IN (
SELECT BankAccountTransactionId FROM BankAccountTransaction WHERE BankAccountId IN (SELECT BankAccountId FROM BankAccount WHERE CaseId = @CaseId)
)
ORDER BY 1 DESC

--ASSETS LINK
--expected to show all assets links
DECLARE @CaseId INT
SET @CaseId=1029
SELECT * FROM [dbo].[AssetBankAccountTransaction] WHERE BankAccountTransactionAllocationId IN (
SELECT TOP 10 BankAccountTransactionAllocationId FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId IN (
SELECT BankAccountTransactionId FROM BankAccountTransaction WHERE BankAccountId IN (SELECT BankAccountId FROM BankAccount WHERE CaseId = @CaseId)
) ORDER BY 1 DESC
)


--CLOSING COSTS ONLY CLAIM LINKS
--expected to show all closing cost links
DECLARE @CaseId INT
SET @CaseId=1029
SELECT * FROM [dbo].[ClaimBankAccountTransaction] WHERE BankAccountTransactionAllocationId IN (
SELECT TOP 10 BankAccountTransactionAllocationId FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId IN (
SELECT BankAccountTransactionId FROM BankAccountTransaction WHERE BankAccountId IN (SELECT BankAccountId FROM BankAccount WHERE CaseId = @CaseId)
) ORDER BY 1 DESC
)


--ASSETS DETAILS
--expected to display FADate on Asset if updated on Deposit creation
DECLARE @CaseId INT
SET @CaseId=1029

SELECT *, bat.BankAccountTransactionId FROM [dbo].[Asset] WHERE AssetId In (
SELECT AssetId FROM [dbo].[AssetBankAccountTransaction] WHERE BankAccountTransactionAllocationId IN (
SELECT TOP 10 BankAccountTransactionAllocationId FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId IN (
SELECT BankAccountTransactionId FROM BankAccountTransaction bat WHERE BankAccountId IN (SELECT BankAccountId FROM BankAccount WHERE CaseId = @CaseId)
) ORDER BY 1 DESC
))

--CLAIMS DETAILS
-- expected to display paid amount for claim increased by deposit
DECLARE @CaseId INT
SET @CaseId=1029
SELECT c.ClaimId,  c.CaseId,  c.ClaimNumber,  c.ClaimedAmount, c.ScheduleAmount, c.IsFrozen, c.AllowedAmount, [tcms].[GetClaimPaidAmount](c.ClaimId) [PaidAmount],  [tcms].[GetClaimBalanceDue](c.ClaimId) [BalanceAmount]
FROM [dbo].[Claim] c WHERE ClaimId In (
SELECT ClaimId FROM [dbo].[ClaimBankAccountTransaction] WHERE BankAccountTransactionAllocationId IN (
SELECT TOP 10 BankAccountTransactionAllocationId FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId IN (
SELECT BankAccountTransactionId FROM BankAccountTransaction WHERE BankAccountId IN (SELECT BankAccountId FROM BankAccount WHERE CaseId = @CaseId)
) ORDER BY 1 DESC
))


SELECT  c.ClaimId,  c.CaseId,  c.ClaimNumber,  c.ClaimedAmount, c.ScheduleAmount, c.IsFrozen, c.AllowedAmount, 
  [tcms].[GetClaimPaidAmount](c.ClaimId) [PaidAmount],  [tcms].[GetClaimBalanceDue](c.ClaimId) [BalanceAmount]
FROM dbo.Claim c WHERE c.ClaimId = 878;