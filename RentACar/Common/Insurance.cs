using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Insurance
    {
        private Int64 carOwner;
        private int insuranceAgency;
        private Decimal price;
        private DateTime startDate;
        private DateTime endDate;
        private Int64 number;
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
        public int InsuranceAgency
        {
            get { return insuranceAgency; }
            set
            {
                if (value <0)
                    throw new Exception("Поле не может быть пустым");
                else insuranceAgency = value;
            }
        }
        public Decimal Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                    throw new Exception("Значение поля не может быть меньше или равно 0");
                else price = value;
            }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new Exception("Дата не может быть больше текущей");
                else startDate = value;
            }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value < startDate) 
                    throw new Exception("ERROR");
                else endDate = value;
            }
        }
        public Int64 Number
        {
            get { return number; }
            set
            {
                if (value <= 0)
                    throw new Exception("Значение поля не может быть меньше или равно 0");
                else number = value;
            }
        }
        public Insurance(Int64 carOwner, int insuranceAgency, Decimal price, DateTime startDate, DateTime endDate, Int64 number)
        {
            CarOwner = carOwner;
            InsuranceAgency = insuranceAgency;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
            Number = number;
        }
    }
}
