
select BankAccountId from [dbo].[BankAccount] where BankAccountNumber='9701837878';

SELECT * FROM [dbo].[BankAccountTransaction]
WHERE BankAccountId=121 and IsDeleted=0

--SELECT * FROM [dbo].[BankAccountTransaction] WHERE TransactionDescription LIKE '%Automation%';
DELETE FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId IN (select [BankAccountTransactionId] from [dbo].[BankAccountTransaction] WHERE TransactionDescription LIKE '%Automation%');
DELETE FROM [dbo].[BankAccountTransaction] WHERE TransactionDescription LIKE '%Test Automation%';

DELETE FROM [dbo].[BankAccountTransaction_BankAccountTransactionAllocation] WHERE BankAccountTransactionId IN (select [BankAccountTransactionId] from [dbo].[BankAccountTransaction] WHERE FullName LIKE '%Test Automation %');
DELETE FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId IN (select [BankAccountTransactionId] from [dbo].[BankAccountTransaction] WHERE FullName LIKE '%Test Automation %');
DELETE FROM [dbo].[BankAccountTransaction] WHERE FullName LIKE '%Test Automation %';

--DELETE FROM [dbo].[BankAccountTransactionAllocation] WHERE BankAccountTransactionId=6213;
--DELETE FROM [dbo].[BankAccountTransaction] WHERE BankAccountTransactionId=6213;

