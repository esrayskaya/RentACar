using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Rent
    {
        private string car;
        private Int64 client;
        private int price;
        private DateTime startDate;
        private DateTime endDate;
        private int n;
        public string Car
        {
            get { return car; }
            set
            {
                if (value == String.Empty)
                    throw new Exception("Поле не может быть пустым");
                else car = value;
            }
        }
        public Int64 Client
        {
            get { return client; }
            set
            {
                if (value <0)
                    throw new Exception("Поле не может быть пустым");
                else client = value;
            }
        }
        public int Price
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
                //if (value > DateTime.Now)
                  //  throw new Exception("Дата не может быть больше текущей");
                /*else*/ startDate = value;
            }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value < startDate)
                    throw new Exception("Дата не может быть меньше текущей");
                else endDate = value;
            }
        }
        public int N
        {
            get { return n; }
            set
            {
                if (value <= 0)
                    throw new Exception("Значение поля не может быть меньше или равно 0");
                else n = value;
            }
        }
        public Rent(string car, Int64 client, int price, DateTime startDate, DateTime endDate, int n)
        {
            Car = car;
            Client = client;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
            N = n;
        }
    }
}
