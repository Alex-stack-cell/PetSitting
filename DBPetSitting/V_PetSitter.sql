CREATE VIEW V_PetSitter
AS SELECT p.Id, p.LastName, p.FirstName, p.BirthDate, p.Email,  p.PetPreference ,AVG(CONVERT(FLOAT,c.Score)) AS Score
FROM [PetSitter] p
LEFT JOIN Comment c ON c.ID_Owner = p.Id
GROUP BY p.Id, p.LastName, p.FirstName, p.BirthDate, p.Email,  p.PetPreference 