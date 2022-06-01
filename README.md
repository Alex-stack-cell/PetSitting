#Introduction
L'application contient les �l�ments suivants :
	1. Une couche DAL (Data Acess Layer), responsable d'acc�der aux donn�es de la base de donn�es par l'interm�diaire 
	d'une connection string. Cette couche contient ellem�mes diff�rents �l�ments :
		1. Entities qui correspond aux entit�s en base de donn�es;
		2. Repositories, qui d�finit l'ensemble des "contrats" que doivent remplir des classes (Services) pour acc�der aux donn�es
		3. Services, reprend l'ensemble des fonctionnalit�s CRUD.
	De mani�re synth�tique, la DAL communiquera les donn�es par l'interm�diaire de Mapper � la BLL afin de les manipuler.
	2. Une couche BLL (Business Logic Layer). Cette partie du projet contiendra essentiellement les op�rations 
	d'arithm�tiques et de logiques n�cessaires au bon fonctionnement de l'application :
		Inscription des utilisateurs;
		Notation des prestations;
		etc.
		Tout comme la DAL cette couche dispose de repositories, services, et mappers
	3. Une API (Application Program Interface) qui agiera d'interface entre l'application globale et le front-end.
	Elle se distingue des couches pr�c�dentes notamment de part la partie Controller, responsable d'envoie et de r�cepetion de requ�tes HTTP
	entre le client et l'application PetSitting.
	4. Le front-end, qui affiche les donn�es dans le navigateur et permet de communiquer via l'interface graphique avec l'application.

L'ensemble du projet repose sur les designs patterns suivant : Injection de d�pendance, Repository, MVC, Mapper, Singelton.

#To do
R�aliser les contraintes m�tiers pour : 
	Pet-Sitter (il ne peut pas avoir plusieurs prestation)
	Owner (le score doit �tre calcul� sur base des commentaires)

R�aliser l'API (on-going)
R�aliser le front-end
