#Introduction
L'application contient les éléments suivants :
	1. Une couche DAL (Data Acess Layer), responsable d'accéder aux données de la base de données par l'intermédiaire 
	d'une connection string. Cette couche contient ellemêmes différents éléments :
		1. Entities qui correspond aux entités en base de données;
		2. Repositories, qui définit l'ensemble des "contrats" que doivent remplir des classes (Services) pour accéder aux données
		3. Services, reprend l'ensemble des fonctionnalités CRUD.
	De manière synthétique, la DAL communiquera les données par l'intermédiaire de Mapper à la BLL afin de les manipuler.
	2. Une couche BLL (Business Logic Layer). Cette partie du projet contiendra essentiellement les opérations 
	d'arithmétiques et de logiques nécessaires au bon fonctionnement de l'application :
		Inscription des utilisateurs;
		Notation des prestations;
		etc.
		Tout comme la DAL cette couche dispose de repositories, services, et mappers
	3. Une API (Application Program Interface) qui agiera d'interface entre l'application globale et le front-end.
	Elle se distingue des couches précédentes notamment de part la partie Controller, responsable d'envoie et de récepetion de requêtes HTTP
	entre le client et l'application PetSitting.
	4. Le front-end, qui affiche les données dans le navigateur et permet de communiquer via l'interface graphique avec l'application.

L'ensemble du projet repose sur les designs patterns suivant : Injection de dépendance, Repository, MVC, Mapper, Singelton.

#To do
Réaliser les contraintes métiers pour : 
	Pet-Sitter (il ne peut pas avoir plusieurs prestation)
	Owner (le score doit être calculé sur base des commentaires)

Réaliser l'API (on-going)
Réaliser le front-end
