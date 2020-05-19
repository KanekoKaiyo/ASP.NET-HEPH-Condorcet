using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
/* 
    Projet scolaire HEPH Condorcet 2019-2020
    Made by Simon Jonathan        
*/
namespace TeacherParadise.Attribute {
    public class DoBMajorAttribute:ValidationAttribute {
        public DoBMajorAttribute() : base("La {0} c'est pas valide ! Il faut avoir 18 ans minimum") { }
        public override bool IsValid(object value) {
            // Vérification si l'inscrit à plus de 18 ans :
            DateTime dob = (DateTime)value;
            int temp = DateTime.Now.Year - dob.Year;
            // 1) On calcul la différence d'année, si c'est supérieur a 18, il a forcement plus de 18 ans, si c'est égal à 18 il faut faire plus de test, dans les autres cas, il n'est pas majeur
            if(temp > 18) {
                return true;
            } else if (temp == 18) {
                // 2) On calcul la différence des mois, si c'est inférieur a 0, il n'est pas majeur, si c'est égal à 0, il faut tester le jour, si c'est supérieur à 0, il est majeur
                temp = DateTime.Now.Month - dob.Month;
                if(temp < 0) {
                    return false;
                } else if(temp > 0) {
                    return true;
                } else if(temp == 0) {
                    // 3) On calcule la différence des jouers, si c'est inférieur a 0, il n'est pas majeur, si c'est égal à 0 c'est son anniversaire et il est majeur ( Happy Birthday youhou ! ), si c'est supérieur à 0 son anniversaire est déjà passé et est donc majeur
                    temp = DateTime.Now.Day - dob.Day;
                    if(temp < 0) {
                        return false;
                    } else if(temp > 0) {
                        return true;
                    } else if(temp == 0) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            } else {
                return false;
            }

        }
    }
}
