--nullify the Claim.ChartOfAccountId value to make a claim of 'Unknown' type
UPDATE dbo.Claim SET ChartOfAccountId = NULL WHERE ClaimId = 1825

--if you want to rollback, just set the ID back to what it was before
UPDATE dbo.Claim SET ChartOfAccountId = 108 WHERE ClaimId = 1825


select * from BankAccountTransaction