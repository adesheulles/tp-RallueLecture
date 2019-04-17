using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppe
{
    class Eleve
    {
        private string nom;
        private string prenom;
        private string login;
        private string passWord;
       static Random random = new Random();
        public Eleve(string nom, string prenom, string login,PassWordType type)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.login = login;
            this.passWord = GetNewPassWord(type);
        }
        static private string GetPassWordAleatoire() // créer un mot de passe aléatoire
        {
            string minuscule = "abcdefghijklmnopqrstuvwxyz"; // liste des lettres minuscule
            string majuscule = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // liste des lettres majuscule
            string caractèreSpécial = "&@#"; // liste caractère spéciaux
            string chiffre = "123456789"; // liste chiffre
            string mdpAleatorie =""; 
            
            int positionMajuscule;
            int positionChiffre;
            int positionCaractèreSpécial;
            positionMajuscule = random.Next(0, 8); // position de la lettre majuscule
            positionChiffre = positionMajuscule; // on donne la position de la lettre majuscule à la position de chiffre
                                                   // pour servire de condition et eviter que leur position soit egale
            positionCaractèreSpécial = positionMajuscule;
            while (positionChiffre == positionMajuscule) 
            {
                positionChiffre = random.Next(0, 8);
            }
            while (positionCaractèreSpécial == positionMajuscule)
            {
                positionCaractèreSpécial = random.Next(0, 8);
            }
            for (int i = 0; i < 9; i++) // boucle pour créer le mot de passe
            {
                if (i == positionMajuscule || i == positionChiffre || i==positionCaractèreSpécial)
                {
                    if (i == positionChiffre|| i==positionCaractèreSpécial)
                    {
                        if (i == positionChiffre) // choisit un chiffre aléatoire
                        {
                            mdpAleatorie += chiffre[random.Next(0, chiffre.Count())];
                        }
                        else // choisit un caractère spécial aléatoire
                        {
                            mdpAleatorie+=caractèreSpécial[random.Next(0,caractèreSpécial.Count())];
                        }
                    }
                    else// choisit une majuscule aléatoire
                    {
                        mdpAleatorie += majuscule[random.Next(0,majuscule.Count())];
                    }
                }
                else// choisit une minuscule aléatoire
                {
                    mdpAleatorie += minuscule[random.Next(0,minuscule.Count())];
                }
                
            }
            return mdpAleatorie;
        } 
        private string GetPassWordConstruit() // créer un mot de passe construit
        {
            string mdp;
            mdp = Convert.ToString(this.prenom[0])+this.nom;
            return mdp;
        }
        public string GetNewPassWord( PassWordType type)
        {
            string mdp;
            switch (type)
            {
                case PassWordType.Aléatoire : // créer un mot de passe aléatoire
                    mdp = GetPassWordAleatoire();
                    return mdp;
                case PassWordType.Construit: // créer un mot de passe construit
                    mdp = this.GetPassWordConstruit();
                    return mdp;
                default: // créer un mot de passe aléatoire
                    mdp = GetPassWordAleatoire();
                    return mdp;

            }
        }
        public new string ToString => string.Format("nom : {0} prenom : {1} login : {2} mdp : {3}", this.nom, this.prenom, this.login, this.passWord);
        public string PassWord { get { return passWord; } }
        public string Login { get { return login; } }
        public string Prenom { get { return prenom; } }
        public string Nom { get { return nom; } }

    }
}
