using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.WinUi.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi.View
{
   
    public partial class FormAddConferenceCategory : Form
    {  
        public int categoryId = 0;
        private readonly IConferenceCategoryRepository conferenceCategoryRepository;
        
        public List<ConferenceCategoryModel> conferenceCategories = new List<ConferenceCategoryModel>();
        public int range = 0;
        public int step = 4;
        public int shown = 4;
        public int maxrange;
        public FormAddConferenceCategory(IConferenceCategoryRepository _conferenceCategoryRepository)
        {
            conferenceCategoryRepository = _conferenceCategoryRepository;
            InitializeComponent();
            LoadConferenceCategories();
            
        }

        private async void LoadConferenceCategories()
        {
            var url = "http://localhost:2794/api/ConferenceCategory/GetAllCategories";
            conferenceCategories = await HttpClientOperations.GetOperation<ConferenceCategoryModel>(url);
            dgvConferenceCategories.ColumnCount = 2;
            dgvConferenceCategories.Columns[0].Name = "Category";
            dgvConferenceCategories.Columns[1].Name = "Id";
            dgvConferenceCategories.Columns[1].Visible = false;
            maxrange = conferenceCategories.Count;
            WireUpCategories();
        }

        public async void LoadConferenceCategories(string keyword)
        {
            var url = "http://localhost:2794/api/ConferenceCategory/GetCategoryByKeyword?keyword=" + keyword;
            conferenceCategories = await HttpClientOperations.GetOperation<ConferenceCategoryModel>(url);
            //conferenceCategories = conferenceCategoryRepository.GetConferenceCategories(keyword);
            dgvConferenceCategories.ColumnCount = 2;
            dgvConferenceCategories.Columns[0].Name = "Category";
            dgvConferenceCategories.Columns[1].Name = "Id";
            dgvConferenceCategories.Columns[1].Visible = false;
            maxrange = conferenceCategories.Count;
            WireUpCategories();
        }
        private void WireUpCategories()
        {
            
            dgvConferenceCategories.Rows.Clear();
            for (int i = range; i < step; i++)
            {
                if (i >= maxrange)
                {
                    Console.WriteLine("breaked");
                    break;
                }
                else
                {
                    dgvConferenceCategories.Rows.Add(conferenceCategories[i].conferenceCategoryName,
                            conferenceCategories[i].conferenceCategoryId);
                }
                if (conferenceCategories.Count <= (int)comboBoxPagesNumber.SelectedItem)
                {
                    button2.Enabled = false;
                }
                else if (step < maxrange)
                {
                    button2.Enabled = true;
                }
            }

        }
        private void dgvConferenceCategories_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int conferenceCategoryId;
            string conferenceCategoryName = "";

            try
            {
                if ((dgvConferenceCategories.Rows[e.RowIndex].Cells[1].Value != null) && (Convert.ToInt32(dgvConferenceCategories.Rows[e.RowIndex].Cells[1].Value.ToString()) != 0))
                {
                    conferenceCategoryId = Convert.ToInt32(dgvConferenceCategories.Rows[e.RowIndex].Cells[1].Value.ToString());
                    conferenceCategoryName = dgvConferenceCategories.Rows[e.RowIndex].Cells[0].Value.ToString();
                    ConferenceCategoryModel categoryUpdated = new ConferenceCategoryModel();
                    categoryUpdated.conferenceCategoryId = conferenceCategoryId;
                    categoryUpdated.conferenceCategoryName = conferenceCategoryName;
                    HttpClientOperations.PutOperation<ConferenceCategoryModel>("http://localhost:5000/api/ConferenceCategory/UpdateCategory", categoryUpdated);
                    dgvConferenceCategories[e.ColumnIndex,e.RowIndex].Value = conferenceCategoryName;
                    //conferenceCategoryRepository.UpdateConferenceCategory(conferenceCategoryId, conferenceCategoryName);
                    //conferenceCategories[e.RowIndex].conferenceCategoryName = conferenceCategoryName;
                    //dgvConferenceCategories.Rows[e.RowIndex].Cells[e.ColumnIndex] = conferenceCategoryName;                    LoadConferenceCategories();
                }
                else
                {
                    conferenceCategoryName = dgvConferenceCategories.Rows[e.RowIndex].Cells[0].Value.ToString();
                    ConferenceCategoryModel model = new ConferenceCategoryModel();
                    model.conferenceCategoryName = conferenceCategoryName;
                    
                    HttpClientOperations.PostOperation<ConferenceCategoryModel>("http://localhost:2794/api/ConferenceCategory/InsertCategory", model);
                    // conferenceCategoryRepository.InsertConferenceCategory(conferenceCategoryName);
                    dgvConferenceCategories.Rows.Clear();
                    LoadConferenceCategories();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btnDelete_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvConferenceCategories.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvConferenceCategories.SelectedRows[0].Index;
                int conferenceCategoryId = Convert.ToInt32(dgvConferenceCategories[1, selectedIndex].Value);
                //conferenceCategoryRepository.DeleteConferenceCategory(conferenceCategoryId);
                ConferenceCategoryModel model = new ConferenceCategoryModel();

                model.conferenceCategoryId = conferenceCategoryId;

                HttpClientOperations.DeleteOperation<ConferenceCategoryModel>("http://localhost:2794/api/ConferenceCategory/DeleteCategory", model);
                LoadConferenceCategories();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            range = 0;
            btnPrevious.Enabled = false;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            if (keyword == "")
            {
                LoadConferenceCategories();
            }
            else
            {
                LoadConferenceCategories(keyword);
            }
            
        }

        private void dgvConferenceCategories_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvConferenceCategories.ClearSelection();
        }

        private void dgvConferenceCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvConferenceCategories.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString() != null)
            {
                categoryId = Convert.ToInt32(dgvConferenceCategories.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());
            }
            }

        private void FormAddConferenceCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormAddConferenceGeneral.conference.DictionaryConferenceCategoryId = categoryId;
            FormAddConferenceGeneral.conferenceModel.ConferenceCategory = categoryId.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvConferenceCategories.Rows.Clear();
            range = step;
            step += shown;
            btnPrevious.Enabled = true;
            if (step >= maxrange)
            {
                button2.Enabled = false;
            }
            WireUpCategories();

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dgvConferenceCategories.Rows.Clear();
            step = range;
            range -= shown;
            btnPrevious.Enabled = true;
            if (range == 0)
            {
                btnPrevious.Enabled = false;
            }
            WireUpCategories();

        }
        private void comboBoxPagesNumber_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Console.WriteLine("Am schimbat index");
            dgvConferenceCategories.Rows.Clear();
            range = 0;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnPrevious.Enabled = false;
            WireUpCategories();
        }

       /* private async Task<List<ConferenceCategoryModel>> GetResponse()
        {
            List<ConferenceCategoryModel> model = null;
            ConferenceCategoryModel model1 = new ConferenceCategoryModel();
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/ConferenceCategory/GetAllCategories");
            if (s.IsSuccessStatusCode)
            {

               
                var responseBody = await s.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<ConferenceCategoryModel>>(responseBody);
                Console.WriteLine(model);
                return model;
               
                


            }
            else
            {
                throw new Exception("NO");
            }



        }*/
    }
}
