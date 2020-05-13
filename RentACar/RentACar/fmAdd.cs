using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Windows.Forms;
using Common;

namespace RentACar
{
    public partial class fmAdd : Form
    {
        private string title;
        private List<InsuranceAgency> insuranceAgencies = new List<InsuranceAgency>();
        private List<CarBrand> carBrands = new List<CarBrand>();
        private List<Settlement> settlements = new List<Settlement>();
        private List<Client> clients = new List<Client>();
        private List<CarOwner> carOwners = new List<CarOwner>();
        private List<Insurance> insurances = new List<Insurance>();
        private List<Car> cars = new List<Car>();
        private List<Rent> rents = new List<Rent>();
        private bool first = true;
        //public List<InsuranceAgency> agenciesAdd = new List<InsuranceAgency>();
        public InsuranceAgency InsuranceAgencyAdd;
        public CarBrand CarBrand;
        public Settlement Settlement;
        public Client Client;
        public CarOwner CarOwner;
        public Insurance Insurance;
        public Car Car;
        public Rent Rent;

        public fmAdd(string title, bool flag, List<Rent> rents, List<Car> cars, List<Client> clients)
        {
            this.title = title;
            first = flag;
            this.rents = rents;
            this.cars = cars;
            this.clients = clients;
            InitializeComponent();
        }
        public fmAdd(string title, bool flag, Rent rent, List<Car> cars, List<Client> clients)
        {
            this.title = title;
            first = flag;
            Rent = rent;
            this.cars = cars;
            this.clients = clients;
            InitializeComponent();
        }
        public fmAdd(string title, List<InsuranceAgency> insuranceAgencies, bool flag)
        {
            this.title = title;
            this.insuranceAgencies = insuranceAgencies;
            first = flag;
            InitializeComponent();
        }
        public fmAdd(string title, InsuranceAgency insuranceAgency, bool flag)
        {
            this.title = title;
            this.InsuranceAgencyAdd = insuranceAgency;
            first = flag;
            InitializeComponent();
        }
        public fmAdd(string title, List<CarBrand> carBrands, bool flag)
        {
            this.title = title;
            this.carBrands = carBrands;
            first = flag;
            InitializeComponent();
        }
        public fmAdd(string title, CarBrand carBrand, bool flag)
        {
            this.title = title;
            this.CarBrand = carBrand;
            first = flag;
            InitializeComponent();
        }
        public fmAdd(string title, List<Settlement> settlements, bool flag)
        {
            this.title = title;
            this.settlements = settlements;
            first = flag;
            InitializeComponent();
        }
        public fmAdd(string title, Settlement settlement, bool flag)
        {
            this.title = title;
            this.Settlement = settlement;
            first = flag;
            InitializeComponent();
        }
        public fmAdd(string title, List<Client> clients, bool flag, List<Settlement> settlements)
        {
            this.title = title;
            this.clients = clients;
            first = flag;
            this.settlements = settlements;
            InitializeComponent();
        }
        public fmAdd(string title, Client client, bool flag, List<Settlement> settlements)
        {
            this.title = title;
            Client = client;
            first = flag;
            this.settlements = settlements;
            InitializeComponent();
        }
        public fmAdd(string title, List<CarOwner> carOwners, bool flag, List<Settlement> settlements)
        {
            this.title = title;
            this.carOwners = carOwners;
            first = flag;
            this.settlements = settlements;
            InitializeComponent();
        }
        public fmAdd(string title, CarOwner carOwner, bool flag, List<Settlement> settlements)
        {
            this.title = title;
            CarOwner = carOwner;
            first = flag;
            this.settlements = settlements;
            InitializeComponent();
        }
        public fmAdd(string title, bool flag, List<Insurance> insurances, List<CarOwner> carOwners, List<InsuranceAgency> insuranceAgencies)///
        {
            this.title = title;
            first = flag;
            this.carOwners = carOwners;
            this.insuranceAgencies = insuranceAgencies;
            this.insurances = insurances;
            InitializeComponent();
        }
        public fmAdd(string title, bool flag, Insurance insurance, List<CarOwner> carOwners, List<InsuranceAgency> insuranceAgencies)
        {
            this.title = title;
            first = flag;
            Insurance = insurance;
            this.carOwners = carOwners;
            this.insuranceAgencies = insuranceAgencies;
            InitializeComponent();
        }
        public fmAdd(string title, bool flag, List<Car> cars, List<CarOwner> carOwners, List<CarBrand> brands, List<Insurance> insurances)
        {
            this.title = title;
            first = flag;
            this.cars = cars;
            this.carOwners = carOwners;
            carBrands = brands;
            this.insurances = insurances;
            InitializeComponent();
        }
        public fmAdd(string title, bool flag, Car car, List<CarOwner> carOwners, List<CarBrand> brands, List<Insurance> insurances)
        {
            this.title = title;
            first = flag;
            Car = car;
            this.carOwners = carOwners;
            carBrands = brands;
            this.insurances = insurances;
            InitializeComponent();
        }
        
        private void OutputInfoAboutCarOwner(CarOwner carOwner, ListBox listBox)
        {            
            listBox.Items.Clear();
            listBox.Items.Add("Информация о владельце");
            listBox.Items.Add("Права: "+ carOwner.DrivenCertificate.ToString());
            listBox.Items.Add("Фамилия: "+ carOwner.LastName);
            listBox.Items.Add("Имя: "+ carOwner.FirstName);
            listBox.Items.Add("Отчество: "+ carOwner.Patronymic);
            listBox.Items.Add("Паспорт: "+ carOwner.Passport.ToString());
            listBox.Items.Add("Дата рождения: "+ carOwner.BirtDay.ToShortDateString());
            listBox.Items.Add("Место жительства: "+ carOwner.CityLife.ToString());
        }
        private void OutputInfoAboutCarBrand(CarBrand carBrand, ListBox listBox)
        {
            listBox.Items.Clear();
            listBox.Items.Add("Информация о марке авто");
            listBox.Items.Add("Шифр: " + carBrand.Code.ToString());
            listBox.Items.Add("Название: " + carBrand.Name);
            listBox.Items.Add("Модель: " + carBrand.Model);
        }
        private void OutputInfoAboutCar(Car car, ListBox listBox)
        {
            listBox.Items.Clear();
            listBox.Items.Add("Информация об авто");
            listBox.Items.Add("Регистрационный номер: " + car.NRegistation);
            listBox.Items.Add("Владелец: " + car.CarOwner);
            listBox.Items.Add("Марка: " + car.Brand);
            listBox.Items.Add("Страховка: " + car.Insurance);
            listBox.Items.Add("Пробег: " + car.Mileage);
            listBox.Items.Add("Год выпуска: " + car.YaerOfIssue);
            listBox.Items.Add("Цвет: " + car.Color);
        }
        private void OutputInfoAboutClient(Client client, ListBox listBox)
        {
            listBox.Items.Clear();
            listBox.Items.Add("Информация о клиенте");
            listBox.Items.Add("Права: " + client.DrivenCertificate.ToString());
            listBox.Items.Add("Фамилия: " + client.LastName);
            listBox.Items.Add("Имя: " + client.FirstName);
            listBox.Items.Add("Отчество: " + client.Patronymic);
            listBox.Items.Add("Паспорт: " + client.Passport.ToString());
            listBox.Items.Add("Дата рождения: " + client.BirtDay.ToShortDateString());
            listBox.Items.Add("Место жительства: " + client.CityLife.ToString());
            listBox.Items.Add("Место аренды: " + client.CityLife.ToString());
        }
        private void fmAdd_Load(object sender, EventArgs e)
        {
            if(title == "InsuerenceAgency")
            {
                panelInsuerenceAgency.Visible = true;
                panelCarBrand.Visible = false;
                panelCity.Visible = false;
                panelClient.Visible = false;
                panelInsurance.Visible = false;
                panelCar.Visible = false;
                tbIACode.Enabled = false;                 
                this.Text = "Страховая служба";
                if (!first)
                {
                    tbIACode.Text = InsuranceAgencyAdd.Code.ToString();
                    tbIAName.Text = InsuranceAgencyAdd.Name;                    
                    btOK.Text = "Сохранить";
                }
                else
                {
                    tbIACode.Text = (insuranceAgencies[insuranceAgencies.Count - 1].Code + 1).ToString();
                    btOK.Text = "Добавить";
                }
            }
            else if(title == "CarBrand") 
            {
                panelCarBrand.Visible = true;
                panelInsuerenceAgency.Visible = false;
                panelCity.Visible = false;
                panelClient.Visible = false;
                panelInsurance.Visible = false;
                panelCar.Visible = false;
                Text = "Автомарка";                
                tbCarBrandCode.Enabled = false;
                if (!first)
                {
                    tbCarBrandCode.Text = CarBrand.Code.ToString();
                    tbCarBrandName.Text = CarBrand.Name;
                    tbModel.Text = CarBrand.Model;
                    btOK.Text = "Сохранить";
                }
                else
                {
                    tbCarBrandCode.Text = (carBrands[carBrands.Count - 1].Code + 1).ToString();
                    btOK.Text = "Добавить";
                }
            }
            else if (title == "City")
            {
                panelCity.Visible = true;
                panelCarBrand.Visible = false;
                panelInsuerenceAgency.Visible = false;
                panelClient.Visible = false;
                panelInsurance.Visible = false;
                panelCar.Visible = false;
                Text = "Населённый пункт";
                if (!first)
                {
                    tbCityCode.Text = Settlement.CodeCity.ToString();
                    tbCityCode.Enabled = false;
                    tbCityName.Text = Settlement.NameCity;
                    btOK.Text = "Сохранить";
                }
                else
                {
                    tbCityCode.Enabled = true;
                    btOK.Text = "Добавить";
                }
            }
            else if (title == "Client")
            {
                panelClient.Visible = true;
                panelInsurance.Visible = false;
                panelInsuerenceAgency.Visible = false;
                panelCarBrand.Visible = false;
                panelCity.Visible = false;
                panelCar.Visible = false;
                Text = "Клиент";
                cbCityLife.Items.Clear();
                cbCityRent.Items.Clear();
                cbCityRent.Visible = true;
                lbCityRent.Visible = true;
                foreach (var settlement in settlements)
                {
                    cbCityLife.Items.Add(settlement.NameCity);
                    cbCityRent.Items.Add(settlement.NameCity);
                }
                if (!first)
                {
                    tbDrivenCertificateClient.Enabled = false;
                    tbDrivenCertificateClient.Text = Client.DrivenCertificate.ToString();
                    tbFirstNameClient.Text = Client.FirstName;
                    tbLastNameClient.Text = Client.LastName;
                    tbPatronymicClient.Text = Client.Patronymic;
                    tbPassportClient.Text = Client.Passport.ToString();
                    dtpBirhDay.Value = Client.BirtDay;
                    foreach(var settlement in settlements)
                    {
                        if (settlement.CodeCity == Client.CityLife)
                        {
                            cbCityLife.Text = settlement.NameCity;
                        }
                        if (settlement.CodeCity == Client.CityRent)
                        {
                            cbCityRent.Text = settlement.NameCity;
                        }
                    }
                    btOK.Text = "Сохранить";
                }
                else
                {
                    btOK.Text = "Добавить";
                    tbDrivenCertificateClient.Enabled = true;
                }
            }
            else if (title == "CarOwner")
            {
                panelClient.Visible = true;
                panelInsurance.Visible = false;
                panelInsuerenceAgency.Visible = false;
                panelCarBrand.Visible = false;
                panelCity.Visible = false;
                panelCar.Visible = false;
                Text = "Автовладелец";
                cbCityRent.Visible = false;
                cbCityLife.Items.Clear();
                lbCityRent.Visible = false;
                foreach(var settlement in settlements)
                    cbCityLife.Items.Add(settlement.NameCity);
                if (!first)
                {
                    btOK.Text = "Сохранить";
                    tbDrivenCertificateClient.Enabled = false;
                    tbDrivenCertificateClient.Text = CarOwner.DrivenCertificate.ToString();
                    tbLastNameClient.Text = CarOwner.LastName;
                    tbFirstNameClient.Text = CarOwner.FirstName;
                    tbPatronymicClient.Text = CarOwner.Patronymic;
                    tbPassportClient.Text = CarOwner.Passport.ToString();
                    dtpBirhDay.Value = CarOwner.BirtDay;
                    foreach (var settlement in settlements)
                        if (settlement.CodeCity == CarOwner.CityLife)
                            cbCityLife.Text = settlement.NameCity;                     
                }
                else
                {
                    btOK.Text = "Добавить";
                    tbDrivenCertificateClient.Enabled = true;
                }
            }
            else if(title == "Insurance")
            {
                panelClient.Visible = false;
                panelInsurance.Visible = true;
                panelInsuerenceAgency.Visible = false;
                panelCarBrand.Visible = false;
                panelCity.Visible = false;
                panelCar.Visible = false;
                lbDrivenOrCar.Text = "Водительские права владельца";
                lbAgentOrClient.Text = "Страховое агенство";
                lbPrice.Text = "Стоимость";
                lbDateStart.Text = "Дата выдачи";
                lbDateEnd.Text = "Дата окончания";
                Text = "Страховка";
                tbNumber.Enabled = false;
                lboxClient.Visible = false;
                foreach (var element in carOwners)
                    cbDrivenCertificateOrCar.Items.Add(element.DrivenCertificate);
                foreach (var element in insuranceAgencies)
                    cbAgentOrClient.Items.Add(element.Name);//отображается имя страховой, а сохранять код!!!
                if (!first)
                {
                    btOK.Text = "Сохранить";                    
                    cbDrivenCertificateOrCar.Enabled = false;
                    cbDrivenCertificateOrCar.Text = Insurance.CarOwner.ToString();
                    foreach (var i in insuranceAgencies)
                        if (i.Code == Insurance.InsuranceAgency)
                            cbAgentOrClient.Text = i.Name;
                    tbPrice.Text = Insurance.Price.ToString();
                    dtpStart.Value = Insurance.StartDate;
                    dtpEnd.Value = Insurance.EndDate;
                    tbNumber.Text = Insurance.Number.ToString();
                    foreach (var i in carOwners)
                        if (i.DrivenCertificate.ToString() == cbDrivenCertificateOrCar.Text)
                            OutputInfoAboutCarOwner(i, lboxDriverCar);
                }
                else
                {
                    btOK.Text = "Добавить";
                    cbDrivenCertificateOrCar.Enabled = true;
                    tbNumber.Text = (insurances[insurances.Count - 1].InsuranceAgency + 1).ToString();
                }
            }
            else if (title == "Car")
            {
                Text = "Авто";
                panelCar.Visible = true;
                panelInsuerenceAgency.Visible = false;
                panelCarBrand.Visible = false;
                panelCity.Visible = false;
                panelClient.Visible = false;
                panelInsurance.Visible = false;
                cbCarBrands.Enabled = first;
                // cbCarOwners.Enabled = first;
                //cbInsuranceAgencies.Enabled = false;
                cbDrivenCertificateOrCar.Enabled = false;
                foreach (var i in carOwners)
                    cbCarOwners.Items.Add(i.DrivenCertificate);  
                foreach (var i in carBrands)
                    cbCarBrands.Items.Add(i.Code);              
                /*foreach (var i in insuranceAgencies)
                    cbInsuranceAgencies.Items.Add(i.Name);*/
                if (!first)
                {                    
                    btOK.Text = "Сохранить";                    
                    tbNRegistation.Enabled = false;
                    tbNRegistation.Text = Car.NRegistation;
                    cbCarOwners.Text = Car.CarOwner.ToString();
                    cbCarBrands.Text = Car.Brand.ToString();
                    cbInsuranceAgencies.Text = Car.Insurance.ToString();
                    /*foreach (var i in insuranceAgencies)
                        if (i.Code == Car.Insurance)
                            cbInsuranceAgencies.Text = i.Name;*/
                    tbMileage.Text = Car.Mileage.ToString();
                    tbYear.Text = Car.YaerOfIssue.ToString();
                    tbColor.Text = Car.Color.ToString();
                    foreach (var i in carOwners)
                    {
                        if (i.DrivenCertificate.ToString() == cbCarOwners.Text)
                            OutputInfoAboutCarOwner(i, lboxDriver);
                    }
                    foreach (var i in carBrands)
                    {
                        if (i.Code.ToString() == cbCarBrands.Text)
                            OutputInfoAboutCarBrand(i, lboxBrand);
                    }
                }
                else
                {
                    btOK.Text = "Добавить";
                    tbNRegistation.Enabled = true;
                }
            }
            else if(title=="Rent")
            {
                Text = "Аренда";
                panelInsurance.Visible = true;
                panelInsuerenceAgency.Visible = false;
                panelCarBrand.Visible = false;
                panelCity.Visible = false;
                panelClient.Visible = false;
                panelCar.Visible = false;
                lbDrivenOrCar.Text = "Номер авто";
                lbAgentOrClient.Text = "Клиент";
                lbDateStart.Text = "Начало аренды";
                lbDateEnd.Text = "Конец аренды";
                tbNumber.Enabled = false;                
                foreach (var i in cars)
                    cbDrivenCertificateOrCar.Items.Add(i.NRegistation);
                foreach (var i in clients)
                    cbAgentOrClient.Items.Add(i.DrivenCertificate);
                lboxClient.Visible = true;
                if (!first)
                {
                    cbDrivenCertificateOrCar.Text = Rent.Car;
                    cbAgentOrClient.Text = Rent.Client.ToString();
                    tbPrice.Text = Rent.Price.ToString();
                    dtpStart.Value = Rent.StartDate;
                    dtpEnd.Value = Rent.EndDate;
                    tbNumber.Text = Rent.N.ToString();
                    btOK.Text = "Сохранить";
                    foreach (var i in cars)
                        if (i.NRegistation == cbDrivenCertificateOrCar.Text)
                            OutputInfoAboutCar(i, lboxDriverCar);
                    foreach (var i in clients)
                        if (i.DrivenCertificate.ToString() == cbAgentOrClient.Text)
                            OutputInfoAboutClient(i, lboxClient);
                }
                else
                {
                    tbNumber.Text = (rents[rents.Count - 1].N + 1).ToString();
                    btOK.Text = "Добавить";                    
                }
            }
        }

        private void tbIACode_Validating(object sender, CancelEventArgs e)
        {
            /*if (tbIACode.Text == String.Empty)
            {
                errorProvider.SetError(tbIACode, "Поле не может быть пустым");
                e.Cancel = true;
            }
            else if(!int.TryParse( tbIACode.Text, out int result))
            {
                errorProvider.SetError(tbIACode, "Значение должно быть числом");
                e.Cancel = true;
            }
            else foreach(InsuranceAgency agency in insuranceAgencies)
            {
                if (agency.Code == int.Parse(tbIACode.Text))
                {
                    MessageBox.Show($"Код {agency.Code} уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(tbIACode, "Код уже существует");
                    e.Cancel = true;
                }                    
            }*/
        }

        private void tbIAName_Validating(object sender, CancelEventArgs e)
        {
            if (tbIAName.Text == String.Empty)
            {
                errorProvider.SetError(tbIAName, "Поле не может быть пустым");
                e.Cancel = true;
            }
            else foreach (InsuranceAgency agency in insuranceAgencies)
            {
                if (agency.Name == tbIAName.Text)
                {
                    MessageBox.Show($"Агенство {agency.Code} уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(tbIAName, "Поле не может быть пустым");
                    e.Cancel = true;
                }                   
            }
        }

        private void tbIACode_Validated(object sender, EventArgs e)
        {
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (title == "InsuerenceAgency")
            {
                if (first)
                    //agenciesAdd.Add(new InsuranceAgency(int.Parse(tbIACode.Text), tbIAName.Text));
                    InsuranceAgencyAdd = new InsuranceAgency(int.Parse(tbIACode.Text), tbIAName.Text);
                else InsuranceAgencyAdd.Name = tbIAName.Text;
            }
            else if(title == "CarBrand")
            {
                if (first)
                    CarBrand = new CarBrand(int.Parse(tbCarBrandCode.Text), tbCarBrandName.Text, tbModel.Text);
                else
                {
                    CarBrand.Name = tbCarBrandName.Text;
                    CarBrand.Model = tbModel.Text;
                }
            }
            else if (title == "City")
            {
                if (first)
                    Settlement = new Settlement(int.Parse(tbCityCode.Text), tbCityName.Text);
                else Settlement.NameCity = tbCityName.Text;
            }
            else if (title == "Client")
            {
                if (first)
                    Client = new Client(Int64.Parse(tbDrivenCertificateClient.Text),
                                        tbLastNameClient.Text,
                                        tbFirstNameClient.Text,
                                        tbPatronymicClient.Text,
                                        Int64.Parse(tbPassportClient.Text),
                                        dtpBirhDay.Value,
                                        (settlements[cbCityLife.SelectedIndex].CodeCity),
                                        (settlements[cbCityRent.SelectedIndex].CodeCity));
                else
                {
                    Client.DrivenCertificate = Int64.Parse(tbDrivenCertificateClient.Text);
                    Client.FirstName = tbFirstNameClient.Text;
                    Client.LastName = tbLastNameClient.Text;
                    Client.Patronymic = tbPatronymicClient.Text;
                    Client.Passport = Int64.Parse(tbPassportClient.Text);
                    Client.BirtDay = dtpBirhDay.Value;
                    foreach(var element in settlements)
                    {
                        if (element.NameCity == cbCityLife.Text)
                            Client.CityLife = element.CodeCity;
                        if (element.NameCity == cbCityRent.Text)
                            Client.CityRent = element.CodeCity;
                    }
                }
            }
            if (title == "CarOwner")
            {
                if (first)
                {
                    CarOwner = new CarOwner(Int64.Parse(tbDrivenCertificateClient.Text),
                                            tbLastNameClient.Text,
                                            tbFirstNameClient.Text,
                                            tbPatronymicClient.Text,
                                            Int64.Parse(tbPassportClient.Text),
                                            dtpBirhDay.Value,
                                            settlements[cbCityLife.SelectedIndex].CodeCity);
                }
                else
                {
                    CarOwner.DrivenCertificate = Int64.Parse(tbDrivenCertificateClient.Text);
                    CarOwner.LastName = tbLastNameClient.Text;
                    CarOwner.FirstName = tbFirstNameClient.Text;
                    CarOwner.Patronymic = tbPatronymicClient.Text;
                    CarOwner.Passport = Int64.Parse(tbPassportClient.Text);
                    CarOwner.BirtDay = dtpBirhDay.Value;
                    foreach (var settlement in settlements)
                        if (settlement.NameCity == cbCityLife.Text)
                            CarOwner.CityLife = settlement.CodeCity;
                }
            }
            else if(title == "Insurance")
            {
                if (!first)
                {
                    foreach (var element in insuranceAgencies)
                        if (element.Name == cbAgentOrClient.Text)
                            Insurance.InsuranceAgency = element.Code;
                    Insurance.Price = Decimal.Parse(tbPrice.Text);
                    Insurance.StartDate = dtpStart.Value;
                    Insurance.EndDate = dtpEnd.Value;
                }
                else
                {                    
                    int code;
                    foreach (var element in insuranceAgencies)
                        if (element.Name == cbAgentOrClient.Text)
                            code = element.Code;
                    Insurance = new Insurance(Int64.Parse(cbDrivenCertificateOrCar.Text),
                                              insuranceAgencies[cbAgentOrClient.SelectedIndex].Code,
                                              Decimal.Parse(tbPrice.Text),
                                              dtpStart.Value,
                                              dtpEnd.Value,
                                              Int64.Parse(tbNumber.Text));
                }
            }
            else if (title == "Car")
            {
                if (!first)
                {
                    Car.CarOwner = Int64.Parse(cbCarOwners.Text);
                    Car.Brand = int.Parse(cbCarBrands.Text);
                    Car.Insurance = Int64.Parse(cbInsuranceAgencies.Text);
                    Car.Mileage = int.Parse(tbMileage.Text);
                    Car.YaerOfIssue = int.Parse(tbYear.Text);
                    Car.Color = tbColor.Text;
                }
                else
                {
                    Car = new Car(tbNRegistation.Text,
                                  carOwners[cbCarOwners.SelectedIndex].DrivenCertificate,
                                  carBrands[cbCarBrands.SelectedIndex].Code,
                                  insurances[cbInsuranceAgencies.SelectedIndex].Number,
                                  int.Parse(tbMileage.Text),
                                  int.Parse(tbYear.Text),
                                  tbColor.Text);
                }
            }
            else if(title=="Rent")
            {
                if (!first)
                {
                    Rent.Car = cbDrivenCertificateOrCar.Text;
                    Rent.Client = Int64.Parse(cbAgentOrClient.Text);
                    Rent.Price = int.Parse(tbPrice.Text);
                    Rent.StartDate = dtpStart.Value;
                    Rent.EndDate = dtpEnd.Value;
                }
                else
                {
                    Rent = new Rent(cbDrivenCertificateOrCar.Text,
                                    Int64.Parse(cbAgentOrClient.Text),
                                    int.Parse(tbPrice.Text),
                                    dtpStart.Value,
                                    dtpEnd.Value,
                                    int.Parse(tbNumber.Text));
                }
            }
        }

        private void tbCarBrandCode_Validating(object sender, CancelEventArgs e)
        {
            /*if (tbCarBrandCode.Text == String.Empty)
            {
                errorProvider.SetError(tbCarBrandCode, "Поле не может быть пустым");
                e.Cancel = true;
            }
            else if (!int.TryParse(tbCarBrandCode.Text, out int result))
            {
                errorProvider.SetError(tbCarBrandCode, "Значение должно быть числом");
                e.Cancel = true;
            }
            else foreach (CarBrand carBrand in carBrands)
                {
                    if (carBrand.Code == int.Parse(tbCarBrandCode.Text))
                    {
                        MessageBox.Show($"Код {carBrand.Code} уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider.SetError(tbCarBrandCode, "Код уже существует");
                        e.Cancel = true;
                    }
                }*/
        }

        private void tbCarBrandName_Validating(object sender, CancelEventArgs e)
        {
            if (tbCarBrandName.Text == String.Empty)
            {
                errorProvider.SetError(tbCarBrandName, "Поле не может быть пустым");
                e.Cancel = true;
            }
            else foreach (CarBrand carBrand in carBrands)
                {
                    if (carBrand.Name == tbCarBrandName.Text)
                    {
                        MessageBox.Show($"Марка {carBrand.Code} уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider.SetError(tbCarBrandName, "Поле не может быть пустым");
                        e.Cancel = true;
                    }
                }
        }

        private void tbModel_Validating(object sender, CancelEventArgs e)
        {
            if (tbModel.Text == String.Empty)
            {
                errorProvider.SetError(tbModel, "Поле не может быть пустым");
                e.Cancel = true;
            }
        }

        private void tbCityCode_Validating(object sender, CancelEventArgs e)
        {
            if (tbCityCode.Text == String.Empty)
            {
                errorProvider.SetError(tbCityCode, "Поле не может быть пустым");
                e.Cancel = true;
            }
            else if(!int.TryParse(tbCityCode.Text, out int result)){
                errorProvider.SetError(tbCityCode, "Значение должно быть числом");
                e.Cancel = true;
            }
            else
            {
                foreach(Settlement settlement in settlements)
                {
                    if (int.Parse(tbCityCode.Text) == settlement.CodeCity)
                    {
                        MessageBox.Show($"Код {settlement.CodeCity} уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider.SetError(tbCityCode, "Код уже существует");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void tbCityName_Validating(object sender, CancelEventArgs e)
        {
            if (tbCityName.Text == String.Empty)
            {
                errorProvider.SetError(tbCityName, "Поле не может быть пустым");
                e.Cancel = true;
            }
            else
            {
                foreach (Settlement settlement in settlements)
                {
                    if (tbCityName.Text == settlement.NameCity)
                    {
                        MessageBox.Show($"Город {settlement.NameCity} уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider.SetError(tbCityName, "Код уже существует");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void tbDrivenCertificateClient_Validating(object sender, CancelEventArgs e)
        {
            if (tbDrivenCertificateClient.Text == String.Empty)
            {
                errorProvider.SetError(tbDrivenCertificateClient, "Поле не может быть пустым");
                e.Cancel = true;
            }
            else if (!Int64.TryParse(tbDrivenCertificateClient.Text, out Int64 result))
            {
                errorProvider.SetError(tbDrivenCertificateClient, "Значение должно быть числом");
                e.Cancel = true;
            }
            else foreach (Client client in clients)
                {
                    if (client.DrivenCertificate == Int64.Parse(tbDrivenCertificateClient.Text))
                    {
                        MessageBox.Show($"Удостоверение {client.DrivenCertificate} уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider.SetError(tbDrivenCertificateClient, "Код уже существует");
                        e.Cancel = true;
                    }
                }
        }

        private void tbLastNameClient_Validating(object sender, CancelEventArgs e)
        {
            if (tbLastNameClient.Text == String.Empty)
            {
                errorProvider.SetError(tbLastNameClient, "Поле не может быть пустым");
                e.Cancel = true;
            }
        }

        private void tbFirstNameClient_Validating(object sender, CancelEventArgs e)
        {
            if (tbFirstNameClient.Text == String.Empty)
            {
                errorProvider.SetError(tbFirstNameClient, "Поле не может быть пустым");
                e.Cancel = true;
            }
        }

        private void tbPatronymicClient_Validating(object sender, CancelEventArgs e)
        {
            if (tbPatronymicClient.Text == String.Empty)
            {
                errorProvider.SetError(tbPatronymicClient, "Поле не может быть пустым");
                e.Cancel = true;
            }
        }

        private void tbPassportClient_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassportClient.Text == String.Empty)
            {
                errorProvider.SetError(tbPassportClient, "Поле не может быть пустым");
                e.Cancel = true;
            }
            else if (!Int64.TryParse(tbPassportClient.Text, out Int64 result))
            {
                errorProvider.SetError(tbPassportClient, "Значение должно быть числом");
                e.Cancel = true;
            }
            else foreach (Client client in clients)
                {
                    if (client.Passport == Int64.Parse(tbPassportClient.Text))
                    {
                        MessageBox.Show($"Паспорт {client.DrivenCertificate} уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider.SetError(tbPassportClient, "Код уже существует");
                        e.Cancel = true;
                    }
                }
        }

        private void cbCityLife_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbCityRent_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dtpBirhDay_Validating(object sender, CancelEventArgs e)
        {
            if (dtpBirhDay.Value >= DateTime.Now)
            {
                errorProvider.SetError(dtpBirhDay, "Неверная дата");
                e.Cancel = true;
            }
        }

        private void dtpEnd_Validating(object sender, CancelEventArgs e)
        {
            if (dtpEnd.Value < dtpStart.Value)
            {
                errorProvider.SetError(dtpEnd, "Неверная дата окончания");
                e.Cancel = true;
            }
        }

        private void cbAgentOrClient_Validating(object sender, CancelEventArgs e)
        {
            if (cbAgentOrClient.Text == String.Empty)
            {
                errorProvider.SetError(cbAgentOrClient, "Поле не может быть пустым");
                e.Cancel = true;
            }
        }

        private void cbDrivenCertificateOrCar_Validating(object sender, CancelEventArgs e)
        {
            if (cbDrivenCertificateOrCar.Text == String.Empty)
            {
                errorProvider.SetError(cbDrivenCertificateOrCar, "Поле не может быть пустым");
                e.Cancel = true;
            }
        }

        private void tbPrice_Validating(object sender, CancelEventArgs e)
        {
            if(tbPrice.Text==String.Empty || !Decimal.TryParse(tbPrice.Text, out decimal result))
            {
                errorProvider.SetError(tbPrice, "Неверное значение поля");
                e.Cancel = true;
            }
        }

        private void tbNumber_Validating(object sender, CancelEventArgs e)
        {
            /*if(tbNumber.Text==String.Empty || !Int64.TryParse(tbNumber.Text, out Int64 result))
            {
                errorProvider.SetError(tbNumber, "Неверное значение поля");
                e.Cancel = true;
            }*/
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbNRegistation_Validating(object sender, CancelEventArgs e)
        {
            if (tbNRegistation.Text == String.Empty || tbNRegistation.Text.Length < 6)
            {
                errorProvider.SetError(tbNRegistation, "Неверное значение поля");
                e.Cancel = true;
            }
        }

        private void tbMileage_Validating(object sender, CancelEventArgs e)
        {
            if(!int.TryParse(tbMileage.Text, out int result))
            {
                errorProvider.SetError(tbMileage, "Error");
                e.Cancel = true;
            }
        }

        private void tbYear_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(tbYear.Text, out int result) || tbYear.Text.Length != 4) 
            {
                errorProvider.SetError(tbYear, "Error");
                e.Cancel = true;
            }            
        }

        private void tbColor_Validating(object sender, CancelEventArgs e)
        {
        }

        private void cbCarOwners_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OutputInfoAboutCarOwner(carOwners[cbCarOwners.SelectedIndex], lboxDriver);
            /*foreach (var i in insurances)
                if (i.CarOwner.ToString() == cbCarOwners.Text)*/
                    //cbInsuranceAgencies.Text = i.InsuranceAgency.ToString();
                   // cbInsuranceAgencies.Items.Add(i.Number);
        }

        private void cbCarBrands_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OutputInfoAboutCarBrand(carBrands[cbCarBrands.SelectedIndex], lboxBrand);
        }

        private void cbDrivenCertificateOrCar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(title=="Rent")
                OutputInfoAboutCar(cars[cbDrivenCertificateOrCar.SelectedIndex], lboxDriverCar);
            else OutputInfoAboutCarOwner(carOwners[cbDrivenCertificateOrCar.SelectedIndex], lboxDriverCar);
        }

        private void cbAgentOrClient_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OutputInfoAboutClient(clients[cbAgentOrClient.SelectedIndex], lboxClient);          
        }

        private void cbInsuranceAgencies_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void cbCarOwners_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbInsuranceAgencies.Items.Clear();
            foreach (var i in insurances)
                if (i.CarOwner.ToString() == cbCarOwners.Text)
                    //cbInsuranceAgencies.Text = i.InsuranceAgency.ToString();
                    cbInsuranceAgencies.Items.Add(i.Number);
        }
    }
}
