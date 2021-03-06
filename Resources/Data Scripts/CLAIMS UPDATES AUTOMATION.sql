-- CLASS - no changes

-- CATEGORY
--ClaimCategoryId	ClaimCategory
-- Empty
UPDATE [dbo].[Claim] SET ClaimCategoryId=NULL WHERE ClaimId = 3223;

--1	Administrative Expense
UPDATE [dbo].[Claim] SET ClaimCategoryId=1 WHERE ClaimId = 2389;

--2	Convenience Claim
UPDATE [dbo].[Claim] SET ClaimCategoryId=2 WHERE ClaimId = 349;

--3	Creditor
UPDATE [dbo].[Claim] SET ClaimCategoryId=3 WHERE ClaimId = 3224;

--4	Investor
UPDATE [dbo].[Claim] SET ClaimCategoryId=4 WHERE ClaimId = 3219;

--5	Professional Fee\Expense
UPDATE [dbo].[Claim] SET ClaimCategoryId=5 WHERE ClaimId = 3220;

-- Class: Secured
UPDATE [dbo].[Claim] SET ImportClassTypeId=4 WHERE ClaimId = 1827;

--6	Secured Class One
UPDATE [dbo].[Claim] SET ClaimCategoryId=6 WHERE ClaimId = 1827;

-- Class: Secured
UPDATE [dbo].[Claim] SET ImportClassTypeId=4 WHERE ClaimId = 1825;

--7	Secured Class Two
UPDATE [dbo].[Claim] SET ClaimCategoryId=7 WHERE ClaimId = 1825;

-- Class: Unsecured
UPDATE [dbo].[Claim] SET ImportClassTypeId=3 WHERE ClaimId = 430;

--8	Unsecured Class One
UPDATE [dbo].[Claim] SET ClaimCategoryId=8 WHERE ClaimId = 430;

--9	Security Interest
UPDATE [dbo].[Claim] SET ClaimCategoryId=9 WHERE ClaimId = 431;

--10	Unsecured Class Two
UPDATE [dbo].[Claim] SET ClaimCategoryId=10 WHERE ClaimId = 1826;

--11	Wage Claim
UPDATE [dbo].[Claim] SET ClaimCategoryId=11 WHERE ClaimId = 1824;

-- STATUS
--ClaimStatusId	ClaimStatus
--1	Dismissed
UPDATE [dbo].[Claim] SET ClaimStatusId=1 WHERE ClaimId = 3224;
UPDATE [dbo].[Claim] SET ClaimStatusId=1 WHERE ClaimId = 431;

--2	Invalid
UPDATE [dbo].[Claim] SET ClaimStatusId=2 WHERE ClaimId = 1826;

--3	Superseded
UPDATE [dbo].[Claim] SET ClaimStatusId=3 WHERE ClaimId = 3220;
UPDATE [dbo].[Claim] SET ClaimStatusId=3 WHERE ClaimId = 1824;

--4	Valid To Pay
UPDATE [dbo].[Claim] SET ClaimStatusId=4 WHERE ClaimId = 3223;
UPDATE [dbo].[Claim] SET ClaimStatusId=4 WHERE ClaimId = 2389;

--5	Withdrawn
UPDATE [dbo].[Claim] SET ClaimStatusId=5 WHERE ClaimId = 1827;

--6	Objection Pending
UPDATE [dbo].[Claim] SET ClaimStatusId=6 WHERE ClaimId = 349;

--6	Objection Pending
UPDATE [dbo].[Claim] SET ClaimStatusId=6 WHERE ClaimId = 430;

------------------
-- Claim Values --
------------------
-- All Zeros
--CODE EMPTY
--ClaimId=1825 already has code NULL

----PAY SEQUENCE EMPTY
----WHERE ClaimId = 1823; FK: ClaiChartOfAccountId=108
UPDATE [dbo].[Claim] SET PaySequence=0 WHERE ClaimId = 1823;


--CLAIMED ZERO
UPDATE [dbo].[Claim] SET ClaimedAmount=0 WHERE ClaimId = 1823;
-- $1,479.36


--ALLOWED AMOUNT ZERO
UPDATE [dbo].[Claim] SET AllowedAmount=0 WHERE ClaimId = 1823;
-- $1,479.36


--PAID
UPDATE [dbo].[ClaimBankAccountTransaction] SET IsDeleted = 1 WHERE ClaimId = 1823;

--RESERVED
UPDATE [dbo].[Claim] SET ReservedAmount=0 WHERE ClaimId = 1823;

--INTEREST
--ALREADY 0

--BALANCE
--should automatically calculate to 0

--------------
--  All MAX --
--------------
--CLAIMED
UPDATE [dbo].[Claim] SET ClaimedAmount=4000000000.00 WHERE ClaimId = 1784;
-- $1,479.36

--ALLOWED AMOUNT
UPDATE [dbo].[Claim] SET AllowedAmount=3000000000.00 WHERE ClaimId = 1784;
-- $1,479.36


--PAID
UPDATE [dbo].[BankAccountTransactionAllocation] SET Amount = -2000000000.00 WHERE BankAccountTransactionAllocationId IN 
(SELECT BankAccountTransactionAllocationId 
FROM [dbo].[ClaimBankAccountTransaction] 
WHERE  ClaimId =1784)

--RESERVED
UPDATE [dbo].[Claim] SET ReservedAmount=1000000000.00 WHERE ClaimId = 1784;

--INTEREST
--ALREADY 0

--BALANCE
--should automatically calculate to MAX

--Administrative claim not paid totally so it appears on distribution claims
UPDATE [dbo].[BankAccountTransactionAllocation] SET Amount = -80.49 WHERE BankAccountTransactionAllocationId =2528