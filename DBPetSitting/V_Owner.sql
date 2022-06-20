CREATE VIEW V_Owner
AS SELECT o.Id, o.LastName, o.FirstName, o.BirthDate, o.Email, AVG(CONVERT(FLOAT,c.Score)) AS Score
FROM [Owner] o
LEFT JOIN Comment c ON c.ID_Owner = o.Id
GROUP BY o.Id, o.LastName, o.FirstName, o.BirthDate, o.Email