using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormAddConferenceCity : Form
    {
        private readonly IConferenceCityRepository conferenceCityRepository;
        public FormAddConferenceCity(IConferenceCityRepository _conferenceCityRepository)
        {
            conferenceCityRepository = _conferenceCityRepository;
            InitializeComponent();
            LoadCities();
        }

        private void LoadCities()
        {
            List<ConferenceCityModel> cities = new List<ConferenceCityModel>();
            cities = conferenceCityRepository.GetConferenceCities(1);
            dgvCities.ColumnCount = 2;
            dgvCities.Columns[0].Name = "Id";
            dgvCities.Columns[1].Name = "City";
            this.dgvCities.Columns[0].Visible = false;
            for (int i = 0; i < cities.Count; i++)
            {
                //if (i >= maxrange)
                //{
                //    Console.WriteLine("breaked");
                //    break;
                //}
                //else
                //{
                dgvCities.Rows.Add(cities[i].ConferenceCityId,
                            cities[i].ConferenceCityName);
                //}

            }
            Console.WriteLine(dgvCities.ColumnCount);
        }

        private void btnDelete_MouseClick(object sender, MouseEventArgs e)
        {
            int selectedIndex = dgvCities.SelectedRows[0].Index;
            int cityId = Convert.ToInt32(dgvCities[0, selectedIndex].Value);
            //int districtId = Convert.ToInt32(dgvCities[2, selectedIndex].Value);
            conferenceCityRepository.DeleteCity(cityId, 1);
            dgvCities.Rows.Clear();
            LoadCities();
        }

        private void dgvCities_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvCities.Columns[e.ColumnIndex].Name == "City")
            {
                try
                {
                    if (dgvCities.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value != null)
                    {
                        int indexCity = Convert.ToInt32(dgvCities.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString());
                        string nameCity = dgvCities.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        conferenceCityRepository.updateCity(indexCity, nameCity, 1);
                    }
                    else
                    {
                        string nameCity = dgvCities.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        conferenceCityRepository.insertCity(nameCity, 1);
                        dgvCities.Rows.Clear();
                        LoadCities();
                    }
                }
                catch
                {

                }
            }
        }
    }
}
