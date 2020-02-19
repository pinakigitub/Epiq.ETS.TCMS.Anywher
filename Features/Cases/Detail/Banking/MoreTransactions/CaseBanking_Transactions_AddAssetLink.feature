@Regression
@Ignore @DoNotExecute
@BankingTransactions
Feature: CaseBanking_Transactions - Add Asset Link

@AssetsPage
@US110744
Scenario Outline: 001_"Transactions_AddAssetLink" Verify Code and Sub Code are at the top, highighted in blue and not cleared out
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	When Click on Add Asset Link button
	Then Verify Add Asset Link section layout
	Examples:
	| transactionName                  | moreTrx |
	| Deposit                          | No      |
	| Deposit Correcting Check         | Yes     |
	| Deposit Correcting Debit         | Yes     |

@AssetsPage
@US110744
Scenario Outline: 002_"Transactions_AddAssetLink" Verify Add Assets List section layout
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	Then Verify Assets List section layout
	Examples:
	| transactionName                  | moreTrx |
	| Deposit                          | No      |
	| Deposit Correcting Check         | Yes     |
	| Deposit Correcting Debit         | Yes     |

@AssetsPage
@US110744
Scenario Outline: 003_"Transactions_AddAssetLink" Verify Add Assets List Predictive search behavior
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	Then Verify searched Asset Link results contains value '<value>' in column '<columnName>'
	Examples: 
	| transactionName          | moreTrx | value | columnName   |
	#| Deposit                  | No      | 9     | Asset Number |
	#| Deposit                  | No      | 1270  | Code         |
	| Deposit Correcting Check | Yes     | 9     | Asset Number |
	#| Deposit Correcting Check | Yes     | 1270  | Code         |
	| Deposit Correcting Debit | Yes     | 9     | Asset Number |
	#| Deposit Correcting Debit | Yes     | 1270  | Code         |

@AssetsPage
@US110744
Scenario Outline: 004_"Transactions_AddAssetLink" Verify Add Assets selection behavior
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	When Search and Select Asset Link with value '<value>' in column '<columnName>'
	Then Verify Assets List shows correct data for linked Assets
	Examples: 
	| transactionName          | moreTrx | value | columnName   |
	#| Deposit                  | No      |  8    | Asset Number |
	#| Deposit                  | No      | 1270  | Code         |
	#| Deposit Correcting Check | Yes     |  8    | Asset Number |
	| Deposit Correcting Check | Yes     | 1270  | Code         |
	#| Deposit Correcting Debit | Yes     |  8    | Asset Number |
	| Deposit Correcting Debit | Yes     | 1270  | Code         |

@AssetsPage @regenerateAsset8ForCase1378
@US121331
Scenario Outline: 005_"Transactions_AddAdditionalAssetLink" Verify Add Assets List Predictive search behavior
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Click on Add Additional Asset Link button
	#Then Verify searched Asset Link results contains value '<value>' in column '<columnName>'
	Examples: 
	| transactionName          | moreTrx | value | columnName   |
	#| Deposit                  | No      | 9999  | Asset Number |
	#| Deposit                  | No      | 1270  | Code         |
	| Deposit Correcting Check | Yes     | 9999  | Asset Number |
	| Deposit Correcting Check | Yes     | 1270  | Code         |
	| Deposit Correcting Debit | Yes     | 9999  | Asset Number |
	| Deposit Correcting Debit | Yes     | 1270  | Code         |

@AssetsPage @regenerateAsset8ForCase1378
@US121331
Scenario Outline: 006_"Transactions_AddAdditionalAssetLink" Verify Add Assets selection behavior
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	#And Search and Select Asset Link with value '<value1>' in column '<columnName1>'
	#And Click on Add Additional Asset Link button
	#When Search and Select Asset Link with value '<value2>' in column '<columnName2>'
	#Then Verify Assets List shows correct data for linked Assets
	Examples: 
	| transactionName          | moreTrx | value1 | columnName1   | value2 | columnName2   |
	#| Deposit                  | No      |  8     | Asset Number  |  9999  | Asset Number  |
	#| Deposit                  | No      |  8     | Asset Number  |  1270  | Code          |
	| Deposit Correcting Check | Yes     |  8     | Asset Number  |  9999  | Asset Number  |
	| Deposit Correcting Check | Yes     |  8     | Asset Number  |  1270  | Code          |
	| Deposit Correcting Debit | Yes     |  8     | Asset Number  |  9999  | Asset Number  |
	| Deposit Correcting Debit | Yes     |  8     | Asset Number  |  1270  | Code          |

@AssetsPage @regenerateAsset8ForCase1378
@US121331
Scenario Outline: 007_"Transactions_AddAdditionalAssetLink" Verify Add Assets List section layout
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Click on Add Additional Asset Link button
	Then Verify Assets List section layout
	Examples:
	| transactionName                  | moreTrx |
	#| Deposit                          | No      |
	| Deposit Correcting Check         | Yes     |
	| Deposit Correcting Debit         | Yes     |

@AssetsPage @regenerateAsset8ForCase1378
@US121344
Scenario Outline: 008_"RemoveAssetLink" Verify removing an asset updates Sum of Allocation
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Enter Linked Amount value '150' for Asset Number '8'
	And Click on Add Additional Asset Link button
	And Search and Select Asset Link with value '9999' in column 'Asset Number'
	And I count Asset Link rows
	And Enter Linked Amount value '150' for Asset Number '9999'
	And Remove Asset Link with Asset Number '8'
	When Verify Add Additional Asset Link is displayed
	Then Verify counted Asset Link rows descended
	Examples:
	| transactionName                  | moreTrx |
	#| Deposit                          | No      |
	| Deposit Correcting Check         | Yes     |
	| Deposit Correcting Debit         | Yes     |

@AssetsPage @regenerateAsset8ForCase1378
@US121344
Scenario Outline: 009_"RemoveAssetLink" Verify removing all Asset Links behavior
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Enter Linked Amount value '150' for Asset Number '8'
	And Click on Add Additional Asset Link button
	And Search and Select Asset Link with value '9999' in column 'Asset Number'
	And Enter Linked Amount value '150' for Asset Number '9999'
	And Remove Asset Link with Asset Number '8'
	And Remove Asset Link with Asset Number '9999'
	When Click on Add Asset Link button
	Then Verify Add Asset Link section layout
	Examples:
	| transactionName                  | moreTrx |
	#| Deposit                          | No      |
	| Deposit Correcting Check         | Yes     |
	| Deposit Correcting Debit         | Yes     |

@AssetsPage @regenerateAsset8ForCase1378 @Ignore @DoNotExecute
@US121333
Scenario Outline: 010_"UpdateAssetLink" Verify Code drowdown results are correctly sorted
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Search Code with text '' for Asset Link with Asset number '8'
	And Verify Codes for Asset Link behavior and layout
	Examples:
	| transactionName                  | moreTrx |
	#| Deposit                          | No      |
	| Deposit Correcting Check         | Yes     |
	| Deposit Correcting Debit         | Yes     |

@AssetsPage @regenerateAsset8ForCase1378
@US121333
Scenario Outline: 011_"UpdateAssetLink" Verify Code can be updated for Asset Link
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	When Search and Select Asset Link with value '8' in column 'Asset Number'
	Then Search and Select Code with text '1110' for Asset Link with Asset number '8'
	Examples:
	| transactionName                  | moreTrx |
	#| Deposit                          | No      |
	| Deposit Correcting Check         | Yes     |
	| Deposit Correcting Debit         | Yes     |

@AssetsPage @regenerateAsset8ForCase1378
@US121333
Scenario Outline: 012_"UpdateAssetLink" Verify FA Date can be updated for Asset Link
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	When Search and Select Asset Link with value '8' in column 'Asset Number'
	Then Select day '26' in FA Date datepicker for Asset Number '8'
	Examples:
	| transactionName                  | moreTrx |
	#| Deposit                          | No      |
	| Deposit Correcting Check         | Yes     |
	| Deposit Correcting Debit         | Yes     |

@DoNotExecute @RegressionFixesNeeded @Ignore 
@AssetsPage @regenerateAsset8ForCase1378
@US121333
Scenario Outline: 013_"UpdateAssetLink" Verify Remaining value is set to $0.00 if FA Date is entered
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And Click on Assets tab
	And Click Edit button for asset with Description 2003 DODGE PICKUP 45K MILES EXCELLENT
	And Click Save New Asset button
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Enter Linked Amount value '200' for Asset Number '8'
	And Verify Remaining value displayed is '$300.00' for Asset Number '8'
	When Select day '26' in FA Date datepicker for Asset Number '8'
	Then Verify Remaining value displayed is '$0.00' for Asset Number '8'
	Examples:
	| transactionName                  | moreTrx |
	#| Deposit                          | No      |
	| Deposit Correcting Check         | Yes     |
	| Deposit Correcting Debit         | Yes     |

@AssetsPage @regenerateAsset8ForCase1378
@US121333 @TC123597
Scenario Outline: 014_"UpdateAssetLink" Verify FA Date previous to Petition/Openning are diabled
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	When Search and Select Asset Link with value '1' in column 'Asset Number'
	Then Verify day '19' in FA Date datepicker for Asset Number '1' is disabled
	Examples:
	| transactionName                  | moreTrx |
	#| Deposit                          | No      |
	| Deposit Correcting Check         | Yes     |
	| Deposit Correcting Debit         | Yes     |

@AssetsPage @regenerateAsset8ForCase1378
@US121333
Scenario Outline: 015_"UpdateAssetLink" Verify FA Date default datepicker date is today
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	When Search and Select Asset Link with value '8' in column 'Asset Number'
	#Then Verify default date in FA Date datepicker for Asset Number '8' is today
	Examples:
	| transactionName                  | moreTrx |
	#| Deposit                          | No      |
	| Deposit Correcting Check         | Yes     |
	| Deposit Correcting Debit         | Yes     |

@DoNotExecute @RegressionFixesNeeded @Ignore 
@AssetsPage @regenerateAsset8ForCase1378
@US121333
Scenario Outline: 016_"UpdateAssetLink" Verify Linked amount field behavior
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And Click on Assets tab
	And Click Edit button for asset with Description 2003 DODGE PICKUP 45K MILES EXCELLENT
	And Click Save New Asset button
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Enter Linked Amount value '20' for Asset Number '8'
	And Verify Remaining value displayed is '$480.00' for Asset Number '8'
	When Enter Linked Amount value '0' for Asset Number '8'
	Then Verify Remaining value displayed is '$500.00' for Asset Number '8'
	Examples:
	| transactionName                  | moreTrx |
	#| Deposit                          | No      |
	| Deposit Correcting Check         | Yes     |
	| Deposit Correcting Debit         | Yes     |		


