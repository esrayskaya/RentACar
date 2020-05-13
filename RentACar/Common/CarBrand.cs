using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class CarBrand
    {
        private int code;
        private string name;
        private string model;
        public int Code
        {
            get { return code; }
            set
            {
                if (value <= 0)
                    throw new Exception("Значение поля не может быть равным или меньшим 0");
                else code = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value == String.Empty)
                    throw new Exception("Поле не может быть пустым");
                else name = value;
            }
        }
        public string Model
        {
            get { return model; }
            set
            {
                if (value == String.Empty)
                    throw new Exception("Поле не может быть пустым");
                else model = value;
            }
        }
        public CarBrand(int code, string name, string model)
        {
            Code = code;
            Name = name;
            Model = model;
        }
    }
}
