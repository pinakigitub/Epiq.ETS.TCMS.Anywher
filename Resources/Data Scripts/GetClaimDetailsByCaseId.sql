declare @claimInfo table (
 ClaimdId int,
 ClaimNumber int,
 Suffix NVARCHAR(12),
 ClaimName NVARCHAR(60),
 ClaimStatus NVARCHAR(60),
 ClaimStatusColor int,
 ClassId int,
 ClaimClass NVARCHAR(60),
 ClaimCategory NVARCHAR(60),
 ClaimUTC NVARCHAR(10),
 PaySequence int,
 ClaimedAmount NVARCHAR(15),
 PaidAmount NVARCHAR(15),
 ReservedAmount NVARCHAR(15),
 InterestAmount NVARCHAR(15),
 BalanceAmount NVARCHAR(15),
 AllowerdAmount NVARCHAR(15)
 )

insert into @claimInfo exec [TCMS].[ClaimsByCaseRetrieve] @CaseId, @OfficeId

SELECT *
 FROM @claimInfo info
 left join (
	select c.ClaimId, tcms.FormatAsCurrencyWithBrackets([tcms].[GetClaimBalanceDue](c.ClaimId)) [ClaimBalance], creditor.SortName
	FROM [dbo].[Claim] c
	INNER JOIN dbo.Participation creditorParticipation WITH ( NOLOCK )
	ON creditorParticipation.ParticipationID = c.CreditorParticipationId
    INNER JOIN dbo.Participant creditor WITH ( NOLOCK )
	ON creditor.ParticipantId = creditorParticipation.ParticipantId
	where c.CaseId = @CaseId
 ) AS balance
 ON info.ClaimdId = balance.ClaimId				
 WHERE info.ClaimStatus='VALID TO PAY'