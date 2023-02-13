using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WindowsFormsApp1.Models
{
    public class Validation
    {
        
        public bool ValidatePerson(string Imie, string Nazwisko, DateTime data_ur, string pesel, string kod_pocztowy, string miasto, string ulica, string numer_domu, string numer_mieszkania, string telefon, string email)
        {
            string ErrorMSG = "";
            int i =0;
            if (!ValidateImie(Imie))
            {
                i++;
                ErrorMSG += "Imie jest wymagane lub są niepoprawne dane.";
                
            }
            
            if (!ValidateNazwisko(Nazwisko))
            {
                i++;
                ErrorMSG += "Nazwisko jest wymagane lub są niepoprawne dane.";
                
            }

            if (!ValidateDateOfBirth(data_ur))
            {
                i++;
                ErrorMSG += "Data urodzenia jest wymagana lub są niepoprawne dane.";
                
            }

            if (!ValidatePesel(pesel))
            {
                i++;
                ErrorMSG +="PESEL jest wymagany.";
                
            }

            if (!ValidatePostalCode(kod_pocztowy))
            {
                i++;
                ErrorMSG += "Kod pocztowy jest wymagany.";
                
            }

            if (!ValidateCity(miasto))
            {
                i++;
                ErrorMSG += "Miasto jest wymagane.";
                
            }

            if (!ValidateStreet(ulica))
            {
                i++;
                ErrorMSG += "Ulica jest wymagana.";
               
            }

            if (!ValidateHouseNumber(numer_domu))
            {
                i++;
                ErrorMSG += "Numer domu jest wymagany.";
                
            }

            if (!ValidateApartmentNumber(numer_mieszkania))
            {
                i++;
                ErrorMSG += "Numer mieszkania jest wymagany.";
                
            }

            if (!ValidatePhoneNumber(telefon))
            {
                i++;
                ErrorMSG += "Numer telefonu jest wymagany.";
                
            }

            if (!ValidateEmail(email))
            {
                i++;
                ErrorMSG += "Email jest wymagany.";
               
            }
            if (i > 0)
            {
                MessageBox.Show(ErrorMSG);
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public bool ValidateUser(string login, string password)
        {
            string ErrorMSG = "";
            int i = 0;
            if (!ValidateLogin(login))
            {
                i++;
                ErrorMSG += "Podany login lub hasło jest niepoprawne.";

            }

            if (!ValidatePassword(password))
            {
                i++;
                ErrorMSG += "Podany login lub hasło jest niepoprawne.";

            }
            if (i > 0)
            {
                MessageBox.Show(ErrorMSG);
                return false;
            }
            else
            {
                return true;
            }

        }
        
       public bool ValidateLogin(string login)
        {

            if (string.IsNullOrWhiteSpace(login))
            {
                return false;
            }
            return true;
        }
            
        public bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 3)
            {
                return false;
            }

            return true;
        }
           
        

        public bool ValidateImie(string imie)
        {
            return !string.IsNullOrWhiteSpace(imie) || imie.Any(char.IsDigit);
        }

        public bool ValidateNazwisko(string nazwisko)
        {
            return !string.IsNullOrWhiteSpace(nazwisko) || nazwisko.Any(char.IsDigit);
        }

        public bool ValidateDateOfBirth(DateTime data_ur)
        {
            //Sprawdzanie, czy data urodzenia jest prawidłowa i czy nie jest ustawiona na wartość domyślną
            if (data_ur == default(DateTime))
            {
                return false;
            }
            return true;
        }

        public bool ValidatePesel(string pesel)
        {
            //Sprawdzanie, czy PESEL jest wymagane i czy jego długość jest poprawna (11 cyfr)
            if (string.IsNullOrEmpty(pesel) || pesel.Length != 11)
            {
                return false;
            }
            return true;
        }

        public bool ValidatePostalCode(string kod_pocztowy)
        {
            //Sprawdzanie, czy kod pocztowy jest wymagany i czy jego format jest poprawny (XX-XXX)
            if (string.IsNullOrEmpty(kod_pocztowy) || !Regex.IsMatch(kod_pocztowy, @"^\d{2}-\d{3}$"))
            {
                return false;
            }
            return true;
        }

        public bool ValidateCity(string miasto)
        {
            //Sprawdzanie, czy miasto jest wymagane
            if (string.IsNullOrEmpty(miasto) || miasto.Any(char.IsDigit))
            {
                return false;
            }
            return true;
        }

        public bool ValidateStreet(string ulica)
        {
            //Sprawdzanie, czy ulica jest wymagana
            if (string.IsNullOrEmpty(ulica))
            {
                return false;
            }
            return true;
        }

        public bool ValidateHouseNumber(string numer_domu)
        {
            //Sprawdzanie, czy numer domu jest wymagany
            if (string.IsNullOrEmpty(numer_domu))
            {
                return false;
            }
            return true;
        }

        public bool ValidateApartmentNumber(string numer_mieszkania)
        {
            //Sprawdzanie, czy numer mieszkania jest wymagany
            if (string.IsNullOrEmpty(numer_mieszkania))
            {
                return false;
            }
            return true;
        }

        public bool ValidatePhoneNumber(string telefon)
        {
            //Sprawdzanie, czy numer telefonu jest wymagany i czy jego format jest poprawny (9 cyfr)
            if (string.IsNullOrEmpty(telefon) || telefon.Length != 9)
            {
                return false;
            }
            return true;
        }

        public bool ValidateEmail(string email)
        {
            var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }
    }
}