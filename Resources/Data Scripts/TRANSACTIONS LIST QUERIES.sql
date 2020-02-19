/****** Script for STest Automation data setup prior to executo Transactions List tests  ******/
-- get case id for bank account by ba accoutn number
--SELECT *  FROM [dbo].[BankAccount]
--WHERE BankAccountNumber=2891496548 

-- get case id for bank account by ba id
--SELECT CaseId  FROM [dbo].[BankAccount]
--WHERE BankAccountId = 40

-- get * trx data by account id
--SELECT * FROM [dbo].[BankAccountTransaction]
--WHERE BankAccountId=141

-- get count of transaction types for a bank account
--SELECT count(DISTINCT BankAccountTransactionTypeId) as typecount 
--FROM [dbo].[BankAccountTransaction]
--WHERE BankAccountId=141

-- Get transactions for bank account
--SELECT * FROM [dbo].[BankAccountTransaction]
--WHERE BankAccountId=141 and IsDeleted=0


--Get Bank Account with the most of transaction types
--SELECT bat.BankAccountId FROM [dbo].[BankAccountTransaction] bat
--JOIN (SELECT BankAccountId, count(
--DISTINCT BankAccountTransactionTypeId) as typecount FROM [dbo].[BankAccountTransaction] group by BankAccountId) bat2
--ON bat.BankAccountId=bat2.BankAccountId
--WHERE typecount >= 9;

--WHERE BankAccountId=121

--DELETE FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId=5958;
--DELETE FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId=5980;
--DELETE FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId=6071;

--DELETE FROM [dbo].[BankAccountTransaction] WHERE BankAccountTransactionId=5958;
--DELETE FROM [dbo].[BankAccountTransaction] WHERE BankAccountTransactionId=5980;
--DELETE FROM [dbo].[BankAccountTransaction] WHERE BankAccountTransactionId=6071;


--Missing transaction types on Case with CadeId=20
--Adjustment Credit
--Adjustment Credit Reversal
--Adjustment Debit Reversal
--Disbursement
--Disbursement Reversal
--Interest Posting
--Transfer Out
--Negative Disbursement
--Negative Disbursement Reversal
--Negative Receipt
--Negative Receipt Reversal

--UPDATES TO ORDER ALL TYPES AT LIST BEGGINING BY TRX DATE
--transfer in
UPDATE [dbo].[BankAccountTransaction]
SET TransactionDate='2014-12-10 15:09:30.5637899'
WHERE BankAccountTransactionId=4393

UPDATE [dbo].[BankAccountTransaction]
SET ClearedDate='2015-01-10 10:12:30'
WHERE BankAccountTransactionId=4393


-- Neg Disbursement Reversal
UPDATE [dbo].[BankAccountTransaction]
SET TransactionDate='2014-06-06 01:00:00.0000000'
WHERE BankAccountTransactionId=4414

UPDATE [dbo].[BankAccountTransaction]
SET ClearedDate='2014-06-06 01:00:00'
WHERE BankAccountTransactionId=4414

-- Deposit
UPDATE [dbo].[BankAccountTransaction]
SET TransactionDate='2014-06-06 02:00:00.0000000'
WHERE BankAccountTransactionId=4408

UPDATE [dbo].[BankAccountTransaction]
SET ClearedDate='2014-06-06 02:00:00'
WHERE BankAccountTransactionId=4408

-- Negative Disbursement
UPDATE [dbo].[BankAccountTransaction]
SET TransactionDate='2014-06-06 02:30:00.0000000'
WHERE BankAccountTransactionId=4410

UPDATE [dbo].[BankAccountTransaction]
SET ClearedDate='2014-06-06 02:00:00'
WHERE BankAccountTransactionId=4410


-- Deposit Reversal
UPDATE [dbo].[BankAccountTransaction]
SET TransactionDate='2014-06-06 03:00:00.0000000'
WHERE BankAccountTransactionId=4409

UPDATE [dbo].[BankAccountTransaction]
SET ClearedDate='2014-06-06 03:00:00'
WHERE BankAccountTransactionId=4409

UPDATE [dbo].[BankAccountTransaction]
SET FullName='Virginia Heritage Bank Very Long Name for Automated Tests'
WHERE BankAccountTransactionId=4416

UPDATE [dbo].[BankAccountTransaction]
--BANK SERVICE FEE
SET TransactionDescription='Lorem ipsum ad his scripta blandit partiendo, eum fastidii accumsan euripidis in, eum liber hendrerit an. 
 ut wisi vocibus suscipiantur, quo dicit ridens inciderint id. Quo mundi lobortis reformidans eu, legimus senserit definiebas an eos.'
WHERE BankAccountTransactionId=4416


--SELECT * FROM [dbo].[BankAccountTransaction]
--WHERE BankAccountId=141 and IsDeleted=0
