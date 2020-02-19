DECLARE	@return_value int
DELETE FROM Asset WHERE Name LIKE '%'+@ItemsNameLike+'%';
DELETE FROM Docket WHERE DocketText LIKE '%'+@ItemsNameLike+'%';
DELETE FROM Document WHERE FileName LIKE '%'+@ItemsNameLike+'%';
