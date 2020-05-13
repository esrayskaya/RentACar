using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using System.Data.SqlClient;
using System.Configuration;
using SqlLibrary;

namespace RentACar
{
    public partial class fmAdmin : Form
    {
        List<InsuranceAgency> insuranceAgencies = new List<InsuranceAgency>();
        List<CarBrand> carBrands = new List<CarBrand>();
        List<Settlement> settlements = new List<Settlement>();
        List<Client> clients = new List<Client>();
        List<CarOwner> carOwners = new List<CarOwner>();
        List<Insurance> insurances = new List<Insurance>();
        List<Car> cars = new List<Car>();
        List<Rent> rents = new List<Rent>();
        int row = 0;
        public fmAdmin()
        {
            InitializeComponent();
        }

        private void fmAdmin_Deactivate(object sender, EventArgs e)
        {
        }
        private void OutputInsuerenseAgencies()
        {
            dgInsuerenceAgent.Rows.Clear();
            insuranceAgencies = InsuerenceAgencySql.GetAllInsuerenceAgency();
            for (int i = 0; i < insuranceAgencies.Count; i++)
            {
                dgInsuerenceAgent.Rows.Add();
                dgInsuerenceAgent[0, i].Value = insuranceAgencies[i].Code;
                dgInsuerenceAgent[1, i].Value = insuranceAgencies[i].Name;
            }
        }
        private void OutputCarBrands()
        {
            dgCarBrand.Rows.Clear();
            carBrands = CarBrandSql.GetAllCarBrand();
            for (int i = 0; i < carBrands.Count; i++)
            {
                dgCarBrand.Rows.Add();
                dgCarBrand[0, i].Value = carBrands[i].Code;
                dgCarBrand[1, i].Value = carBrands[i].Name;
                dgCarBrand[2, i].Value = carBrands[i].Model;
            }
        }
        private void OutputSettlements()
        {
            dgCity.Rows.Clear();
            settlements = SettlementsSql.GetAllSettlements();
            for (int i = 0; i < settlements.Count; i++)
            {
                dgCity.Rows.Add();
                dgCity[0, i].Value = settlements[i].CodeCity;
                dgCity[1, i].Value = settlements[i].NameCity;
            }
        }
        private void OutputClients()
        {
            dgClients.Rows.Clear();
            clients = ClientSql.GetAllClients();
            for (int i = 0; i < clients.Count; i++)
            {
                dgClients.Rows.Add();
                dgClients[0, i].Value = clients[i].DrivenCertificate;
                dgClients[1, i].Value = clients[i].LastName;
                dgClients[2, i].Value = clients[i].FirstName;
                dgClients[3, i].Value = clients[i].Patronymic;
                dgClients[4, i].Value = clients[i].Passport;
                dgClients[5, i].Value = clients[i].BirtDay.ToShortDateString();
                dgClients[6, i].Value = clients[i].CityLife;
                dgClients[7, i].Value = clients[i].CityRent;
            }
        }
        private void OutputCarOwners()
        {
            dgCarOwners.Rows.Clear();
            carOwners = CarOwnerSql.GetAllCarOwners();
            for(int i = 0; i < carOwners.Count; i++)
            {
                dgCarOwners.Rows.Add();
                dgCarOwners[0, i].Value = carOwners[i].DrivenCertificate;
                dgCarOwners[1, i].Value = carOwners[i].LastName;
                dgCarOwners[2, i].Value = carOwners[i].FirstName;
                dgCarOwners[3, i].Value = carOwners[i].Patronymic;
                dgCarOwners[4, i].Value = carOwners[i].Passport;
                dgCarOwners[5, i].Value = carOwners[i].BirtDay.ToShortDateString();
                dgCarOwners[6, i].Value = carOwners[i].CityLife;
            }
        }
        private void OutputInsurance()
        {
            dgInsurances.Rows.Clear();
            insurances = InsueranceSql.GettAllInsurances();
            for(int i = 0; i < insurances.Count; i++)
            {
                dgInsurances.Rows.Add();
                dgInsurances[0, i].Value = insurances[i].CarOwner;
                dgInsurances[1, i].Value = insurances[i].InsuranceAgency;
                dgInsurances[2, i].Value = insurances[i].Price;
                dgInsurances[3, i].Value = insurances[i].StartDate.ToShortDateString();
                dgInsurances[4, i].Value = insurances[i].EndDate.ToShortDateString();
                dgInsurances[5, i].Value = insurances[i].Number;
            }
        }
        private void OutputCars()
        {
            dgCars.Rows.Clear();
            cars = CarSql.GetAllCars();
            
            for(int i = 0; i < cars.Count; i++)
            {
                dgCars.Rows.Add();
                dgCars[0, i].Value = cars[i].NRegistation;
                dgCars[1, i].Value = cars[i].CarOwner;
                dgCars[2, i].Value = cars[i].Brand;
                dgCars[3, i].Value = cars[i].Insurance;
                dgCars[4, i].Value = cars[i].Mileage;
                dgCars[5, i].Value = cars[i].YaerOfIssue;
                dgCars[6, i].Value = cars[i].Color;
            }    
        }
        private void OutputRents()
        {
            dgRents.Rows.Clear();
            rents = RentSql.GetAllRents();
            for(int i = 0; i < rents.Count; i++)
            {
                dgRents.Rows.Add();
                dgRents[0, i].Value = rents[i].Car;
                dgRents[1, i].Value = rents[i].Client;
                dgRents[2, i].Value = rents[i].Price;
                dgRents[3, i].Value = rents[i].StartDate.ToShortDateString();
                dgRents[4, i].Value = rents[i].EndDate.ToShortDateString();
                dgRents[5, i].Value = rents[i].N;
            }
        }
        private int GetSelectedRow(DataGridView dgv, DataGridViewCellMouseEventArgs e)
        {
            int row = 0;
            dgv.Rows[0].Cells[0].Selected = false;
            //if (e.Button == MouseButtons.Left) return;
            if (e.RowIndex >= 0 && e.Button==MouseButtons.Right)
            {
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                row = e.RowIndex;

                Point point = MousePosition;
                cmsDelete.Show(point.X, point.Y);

                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
            }
            return row;
        }

        private void fmAdmin_Load(object sender, EventArgs e)
        {
            fmMain fm = Owner as fmMain;
            fm.Hide();
                        
            OutputInsuerenseAgencies();
            OutputCarBrands();
            OutputSettlements();
            OutputClients();
            OutputCarOwners();
            OutputInsurance();
            OutputCars();
            OutputRents();
        }

        private void btAddInsuerenceAgent_Click(object sender, EventArgs e)
        {
            fmAdd fm = new fmAdd("InsuerenceAgency", insuranceAgencies, true);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if (InsuerenceAgencySql.AddInsuerenceAgency(fm.InsuranceAgencyAdd) > 0)
                    OutputInsuerenseAgencies();
                else MessageBox.Show("Не удалось добавить запись");

            }
        }

        private void dgInsuerenceAgent_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = GetSelectedRow(dgInsuerenceAgent, e);          
        }

        private void dgInsuerenceAgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {    
            switch (tcInfo.SelectedIndex)
            {
                case 0:
                    if (MessageBox.Show($"Вы действительно ходите удалить владельца авто '{carOwners[row].DrivenCertificate}' по фамилии {carOwners[row].LastName}?",
                        "Предупреждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show(CarOwnerSql.DeleteCarOwner(carOwners[row]));
                        OutputCarOwners();
                    }
                    break;
                case 1:
                    if (MessageBox.Show($"Вы действительно ходите удалить авто '{cars[row].NRegistation}'?",
                        "Предупреждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show(CarSql.DeleteCar(cars[row]));
                        OutputCars();
                    }
                        break;
                case 2:
                    if (MessageBox.Show($"Вы действительно ходите удалить аренду №'{rents[row].N}'?",
                        "Предупреждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (RentSql.DeleteRent(rents[row]) > 0)
                            OutputRents();
                        else MessageBox.Show("Не удалось удалить запись");
                    }
                        break;
                case 3:
                    if (MessageBox.Show($"Вы действительно ходите удалить '{settlements[row].NameCity}'?",
                        "Предупреждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (SettlementsSql.DeleteSettlements(settlements[row]) > 0)
                            OutputSettlements();
                        else MessageBox.Show("Не удалось удалить запись");
                    }
                    break;
                case 4:
                    if (MessageBox.Show($"Вы действительно ходите удалить клиента '{clients[row].DrivenCertificate}' по фамилии {clients[row].LastName}?",
                        "Предупреждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (ClientSql.DeleteClient(clients[row]) > 0)
                            OutputClients();
                        else MessageBox.Show("Не удалось удалить запись");
                    }
                    break;
                case 5:
                    if(MessageBox.Show($"Вы действительно ходите удалить '{carBrands[row].Name}'?",
                        "Предупреждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (CarBrandSql.DeleteCarBrand(carBrands[row]) > 0)
                            OutputCarBrands();
                        else MessageBox.Show("Не удалось удалить запись");
                    }
                    break;
                case 6:
                    if (MessageBox.Show($"Вы действительно хотите удалить страховку №'{insurances[row].Number}'?",
                                         "Предупреждение",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show(InsueranceSql.DeleteInsurance(insurances[row]));
                        OutputInsurance();
                    }
                        break;
                case 7:
                    if (MessageBox.Show($"Вы действительно хотите удалить '{insuranceAgencies[row].Name}'?",
                                         "Предупреждение",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (InsuerenceAgencySql.DeleteInsuerenceAgency(insuranceAgencies[row]) > 0)
                            OutputInsuerenseAgencies();
                        else MessageBox.Show("Не удалось удалить запись");
                    }
                    break;
                default:
                    break;
            }
        }

        private void cmsDelete_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {            
            switch (tcInfo.SelectedIndex)
            {
                case 0:
                    fmAdd fmCarOwner = new fmAdd("CarOwner", carOwners[row], false, settlements);
                    if (fmCarOwner.ShowDialog() == DialogResult.OK)
                    {
                        if (CarOwnerSql.UpdateCarOwner(fmCarOwner.CarOwner) > 0)
                            OutputCarOwners();
                        else MessageBox.Show("Не удалось изменить запись");
                    }
                    break;
                case 1:
                    fmAdd fmCar = new fmAdd("Car", false, cars[row], carOwners, carBrands, insurances);
                    if (fmCar.ShowDialog() == DialogResult.OK)
                    {
                        if (CarSql.UpdateCar(fmCar.Car) > 0)
                            OutputCars();
                        else MessageBox.Show("Не удалось изменить запись");
                    }
                    break;                    
                case 2:
                    fmAdd fmRent = new fmAdd("Rent", false, rents[row], cars, clients);
                    if (fmRent.ShowDialog() == DialogResult.OK)
                    {
                        if (RentSql.UpdateRent(fmRent.Rent) > 0)
                            OutputRents();
                        else MessageBox.Show("Не удалось изменить запись");
                    }
                    break;
                case 3:
                    fmAdd fmCity = new fmAdd("City", settlements[row], false);
                    if (fmCity.ShowDialog() == DialogResult.OK)
                    {
                        SettlementsSql.UpdateSettlements(fmCity.Settlement);
                        OutputSettlements();
                    }
                    break;
                case 4:
                    fmAdd fmClient = new fmAdd("Client", clients[row], false, settlements);/////////
                    if (fmClient.ShowDialog() == DialogResult.OK)
                    {
                        if (ClientSql.UpdateClient(fmClient.Client) > 0)
                            OutputClients();
                        else MessageBox.Show("Не удалось изменить запись");
                    }
                    break;
                case 5:
                    fmAdd fmCarBrand = new fmAdd("CarBrand", carBrands[row], false);
                    if (fmCarBrand.ShowDialog() == DialogResult.OK)
                    {
                        CarBrandSql.UpdateCarBrand(fmCarBrand.CarBrand);
                        OutputCarBrands();
                    }
                    break;
                case 6:
                    fmAdd fmInsurance = new fmAdd("Insurance", false, insurances[row], carOwners, insuranceAgencies);
                    if (fmInsurance.ShowDialog() == DialogResult.OK)
                    {
                        if (InsueranceSql.UpdateInsurance(fmInsurance.Insurance) > 0)
                            OutputInsurance();
                        else MessageBox.Show("Не удалось изменить запись");
                    }
                    break;
                case 7:
                    fmAdd fm = new fmAdd("InsuerenceAgency", insuranceAgencies[row], false);
                    if (fm.ShowDialog() == DialogResult.OK)
                    {
                        InsuerenceAgencySql.UpdateInsuerenceAgency(fm.InsuranceAgencyAdd);
                        OutputInsuerenseAgencies();
                    }
                    break;
                default:
                    break;
            }
        }

        private void btAddCarBrand_Click(object sender, EventArgs e)
        {
            fmAdd fm = new fmAdd("CarBrand", carBrands, true);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if (CarBrandSql.AddCarBrand(fm.CarBrand) > 0)
                    OutputCarBrands();
                else MessageBox.Show("Не удалось добавить запись");

            }
        }

        private void dgCarBrand_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = GetSelectedRow(dgCarBrand, e);
        }

        private void dgCity_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = GetSelectedRow(dgCity, e);
        }

        private void btAddCity_Click(object sender, EventArgs e)
        {
            fmAdd fm = new fmAdd("City", carBrands, true);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if (SettlementsSql.AddSettlements(fm.Settlement) > 0)
                    OutputSettlements();
                else MessageBox.Show("Не удалось добавить запись");
            }
        }

        private void btAddClient_Click(object sender, EventArgs e)
        {
            fmAdd fm = new fmAdd("Client", clients, true, settlements);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if(ClientSql.AddClient(fm.Client)>0)
                    OutputClients();
                else MessageBox.Show("Не удалось добавить запись");
            }
        }

        private void dgClients_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = GetSelectedRow(dgClients, e);
        }

        private void btAddCarOwner_Click(object sender, EventArgs e)
        {
            fmAdd fm = new fmAdd("CarOwner", carOwners, true, settlements);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if (CarOwnerSql.AddCarOwner(fm.CarOwner) > 0)
                    OutputCarOwners();
                else MessageBox.Show("Не удалось добавить запись");
            }            
        }

        private void dgCarOwners_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = GetSelectedRow(dgCarOwners, e);
        }

        private void btAddInsurance_Click(object sender, EventArgs e)
        {
            fmAdd fm = new fmAdd("Insurance", true, insurances, carOwners, insuranceAgencies);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if (InsueranceSql.AddInsurance(fm.Insurance) > 0)
                    OutputInsurance();
                else MessageBox.Show("Не удалось добавить запись");
            }
        }

        private void dgInsurances_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = GetSelectedRow(dgInsurances, e);
        }

        private void btAddCar_Click(object sender, EventArgs e)
        {
            fmAdd fm = new fmAdd("Car", true, cars, carOwners, carBrands, insurances);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if (CarSql.AddCar(fm.Car) > 0)
                    OutputCars();
                else MessageBox.Show("Не удалось добавить запись");
            }
        }

        private void dgCars_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = GetSelectedRow(dgCars, e);
        }

        private void btAddRent_Click(object sender, EventArgs e)
        {
            fmAdd fm = new fmAdd("Rent", true, rents, cars, clients);//взять в арендуможно только свободные машины
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if (RentSql.AddRent(fm.Rent) > 0)
                    OutputRents();
                else MessageBox.Show("Не удалось добавить запись");
            }
        }

        private void dgRents_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = GetSelectedRow(dgRents, e);
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void найтиАрендуToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsmiFindRent_Click(object sender, EventArgs e)
        {
            fmRent fmRent = new fmRent();
            fmRent.ShowDialog();
        }

        private void tsmiReducePrice_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Уменьшить стоимость аренды для машин на 5%, которые арендуются 1 раз?", 
                "Изменение данных", 
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RentSql.ReducePrice();
                OutputRents();
            }
        }

        private void tsmiIncreasePrice_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Увеличить стоимость аренды для машин на 5%, которые арендуются более 1 раза?",
                "Изменение данных",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RentSql.IncreasePrice();
                OutputRents();
            }
        }
    }
}
