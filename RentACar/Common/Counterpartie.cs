using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Counterpartie
    {
        private Int64 drivenCertificate;
        private string lastName;
        private string firstName;
        private string patronymic;
        private Int64 passport;
        private DateTime birthDay;
        public Int64 DrivenCertificate
        {
            get { return drivenCertificate; }
            set
            {
                if (value <= 0)
                    throw new Exception("Значение поля не может быть меньше или равно 0");
                else drivenCertificate = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == String.Empty)
                    throw new Exception("Поле не может быть пустым");
                else lastName = value;
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == String.Empty)
                    throw new Exception("Поле не может быть пустым");
                else firstName = value;
            }
        }
        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                if (value == String.Empty)
                    throw new Exception("Поле не может быть пустым");
                else patronymic = value;
            }
        }
        public Int64 Passport
        {
            get { return passport; }
            set
            {
                if (value <= 0)
                    throw new Exception("Значение поля не может быть меньше или равно 0");
                else passport = value;
            }
        }
        public DateTime BirtDay
        {
            get { return birthDay; }
            set
            {
                if (value > DateTime.Now)
                    throw new Exception("Дата не может быть больше текущей");
                else birthDay = value;
            }
        }
        public Counterpartie(Int64 drivanSertificate, string lastName, string firstName, string patronymic, Int64 passport, DateTime birthDay)
        {
            DrivenCertificate = drivanSertificate;
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            Passport = passport;
            BirtDay = birthDay;
        }
    }
}
