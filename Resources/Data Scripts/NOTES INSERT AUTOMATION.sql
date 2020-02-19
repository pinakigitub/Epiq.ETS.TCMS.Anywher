--Staff note for edition
INSERT INTO [dbo].[CaseNote] VALUES ('This is a Note for Edition Test',397,2,3,'2016-04-12 05:45:07','2016-04-12 05:42:56',4,'This is a Trustee Note');

--Trustee note for edition
INSERT INTO [dbo].[CaseNote] VALUES ('This is a Note for Edition Test',397,1,3,'2016-04-12 05:45:07','2016-04-12 05:42:56',4,'This is a Trustee Note');


-- Trustee Type Note
INSERT INTO [dbo].[CaseNote] VALUES ('This is a Trustee Note',397,1,3,'2016-04-12 05:45:07','2016-04-12 05:42:56',4,'This is a Trustee Note');

-- Staff Type Note
INSERT INTO [dbo].[CaseNote] VALUES ('This is an Staff Note',397,2,3,'2016-05-09 08:03:43','2016-05-09 08:03:43',3,'This is an Staff Note');

-- Very Long Note to test Read More
INSERT INTO [dbo].[CaseNote] VALUES ('Lorem ipsum ad his scripta blandit partiendo, eum fastidii accumsan euripidis in, eum liber hendrerit an. 
 ut wisi vocibus suscipiantur, quo dicit ridens inciderint id. Quo mundi lobortis reformidans eu, legimus senserit definiebas an eos. 
 Eu sit tincidunt incorrupte definitionem, vis mutat affert percipit cu, eirmod consectetuer signiferumque eu per. 
 In usu latine equidem dolores. Quo no falli viris intellegam, ut fugit veritus placerat per. Ius id vidit volumus mandamus, 
 vide veritus democritum te nec, ei eos debet libris consulatu. No mei ferri graeco dicunt, ad cum veri accommodare. 
 Sed at malis omnesque delicata, usu et iusto zzril meliore. Dicunt maiorum eloquentiam cum cu, sit summo dolor essent te. 
 Ne quodsi nusquam legendos has, ea dicit voluptua eloquentiam pro, ad sit quas qualisque. Eos vocibus deserunt quaestio ei. 
 Blandit incorrupte quaerendum in quo, nibh impedit id vis, vel no nullam semper audiam. Ei populo graeci consulatu mei, 
 has ea stet modus phaedrum. Inani oblique ne has, duo et veritus detraxit.',
 397,2,3,'2016-05-09 08:03:43','2016-05-09 08:03:43',3,
 'Lorem ipsum ad his scripta blandit partiendo, eum fastidii accumsan euripidis in, eum liber hendrerit an. 
 ut wisi vocibus suscipiantur, quo dicit ridens inciderint id. Quo mundi lobortis reformidans eu, legimus senserit definiebas an eos. 
 Eu sit tincidunt incorrupte definitionem, vis mutat affert percipit cu, eirmod consectetuer signiferumque eu per. 
 In usu latine equidem dolores. Quo no falli viris intellegam, ut fugit veritus placerat per. Ius id vidit volumus mandamus, 
 vide veritus democritum te nec, ei eos debet libris consulatu. No mei ferri graeco dicunt, ad cum veri accommodare. 
 Sed at malis omnesque delicata, usu et iusto zzril meliore. Dicunt maiorum eloquentiam cum cu, sit summo dolor essent te. 
 Ne quodsi nusquam legendos has, ea dicit voluptua eloquentiam pro, ad sit quas qualisque. Eos vocibus deserunt quaestio ei. 
 Blandit incorrupte quaerendum in quo, nibh impedit id vis, vel no nullam semper audiam. Ei populo graeci consulatu mei, 
 has ea stet modus phaedrum. Inani oblique ne has, duo et veritus detraxit.');