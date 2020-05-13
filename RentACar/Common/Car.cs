using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Common
{
    public class Car
    {
        private string nRegistration;
        private Int64 carOwner;
        private int brand;
        private Int64 insurance;
        private int mileage;
        private int yearOfIssue;
        private string color;
        public string NRegistation
        {
            get { return nRegistration; }
            set
            {
                if (value == String.Empty)
                    throw new Exception("Поле не может быть пустым");
                else nRegistration = value;
            }
        }
        public Int64 CarOwner
        {
            get { return carOwner; }
            set
            {
                if (value <0)
                    throw new Exception("Поле не может быть пустым");
                else carOwner = value;
            }
        }
        public int Brand
        {
            get { return brand; }
            set
            {
                if (value <0)
                    throw new Exception("Поле не может быть пустым");
                else brand = value;
            }
        }
        public Int64 Insurance
        {
            get { return insurance; }
            set
            {
                if (value <= 0)
                    throw new Exception("Поле не может быть меньше или равно 0");
                else insurance = value;
            }
        }
        public int Mileage
        {
            get { return mileage; }
            set
            {
                if (value <=0)
                    throw new Exception("Поле не может быть меньше или равно 0");
                else mileage = value;
            }
        }
        public int YaerOfIssue
        {
            get { return yearOfIssue; }
            set
            {
                if (value <= 0)
                    throw new Exception("Поле не может быть меньше или равно 0");
                else yearOfIssue = value;
            }
        }
        public string Color
        {
            get { return color; }
            set 
            { 
                color = value; 
            }
        }
        public Car(string nRegistation, Int64 carOwner, int brand, Int64 insurance, int mileage, int yearOfIssue, string color)
        {
            NRegistation = nRegistation;
            CarOwner = carOwner;
            Brand = brand;
            Insurance = insurance;
            Mileage = mileage;
            YaerOfIssue = yearOfIssue;
            Color = color;
        }
        public Car(string nRegistation)
        {
            NRegistation = NRegistation;
        }
    }
}
