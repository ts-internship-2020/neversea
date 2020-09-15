using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.WinUi.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormAddConferenceType : Form
    {

        public int typeId;
        private readonly IConferenceTypeRepository conferenceTypeRepository;
        private BindingSource bsTypes = new BindingSource();
        public List<ConferenceTypeModel> conferenceTypes { get; set; }
        public int range = 0;
        public int step = 4;
        public int shown = 4;
        public int maxrange;

        public FormAddConferenceType(IConferenceTypeRepository _conferenceTypeRepository)
        {
            conferenceTypeRepository = _conferenceTypeRepository;
            
            InitializeComponent();
            LoadConferenceTypes();
        }

        public async void LoadConferenceTypes()
        {
            //conferenceTypes = conferenceTypeRepository.getConferenceTypes();
            var url = "http://localhost:5000/api/ConferenceType/GetAllTypes";
            conferenceTypes = await HttpClientOperations.GetOperation<ConferenceTypeModel>(url);
            maxrange = conferenceTypes.Count;
            dgvConferenceTypes.ColumnCount = 2;
            dgvConferenceTypes.Columns[0].Name = "Type";
            dgvConferenceTypes.Columns[1].Name = "Id";
            dgvConferenceTypes.Columns[1].Visible = false;
            WireUpCities();
        }

        public async void LoadConferenceTypes(string keyword)
        {
            var url = "http://localhost:5000/api/ConferenceType/GetTypesByKeyword?keyword=" + keyword;
            conferenceTypes = await HttpClientOperations.GetOperation<ConferenceTypeModel>(url);
            //conferenceTypes = conferenceTypeRepository.getConferenceTypes(keyword);
            maxrange = conferenceTypes.Count;
            dgvConferenceTypes.ColumnCount = 2;
            dgvConferenceTypes.Columns[0].Name = "Type";
            dgvConferenceTypes.Columns[1].Name = "Id";
            dgvConferenceTypes.Columns[1].Visible = false;


            WireUpCities();
        }
        private void WireUpCities()
        {
            dgvConferenceTypes.Rows.Clear();
            for (int i = range; i < step; i++)
            {
                if (i >= maxrange)
                {
                    Console.WriteLine("breaked");
                    break;
                }
                else
                {
                    dgvConferenceTypes.Rows.Add(conferenceTypes[i].conferenceTypeName,
                            conferenceTypes[i].conferenceTypeId);
                }
                if (conferenceTypes.Count <= (int)comboBoxPagesNumber.SelectedItem)
                {
                    button2.Enabled = false;
                }
                else if (step < maxrange)
                {
                    button2.Enabled = true;
                }
            }

            dgvConferenceTypes.FirstDisplayedCell.Selected = false;


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
                LoadConferenceTypes();
            }
            else
            {
                LoadConferenceTypes(keyword);
            }
            
        }

        private void dgvConferenceType_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int counter = 1;

            //dgvConferenceType.Sort(dgvConferenceType.Columns[0], ListSortDirection.Descending);

            if (counter == 1)
            {

                dgvConferenceTypes.DataSource = null;
                conferenceTypes.Sort();
                dgvConferenceTypes.DataSource = conferenceTypes;
                dgvConferenceTypes.Refresh();
                counter++;
            }
            else
            {
                dgvConferenceTypes.DataSource = null;
                conferenceTypes.Reverse();
                dgvConferenceTypes.DataSource = conferenceTypes;
                dgvConferenceTypes.Refresh();
            }


        }

        private void dgvConferenceTypes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int conferenceTypeId;
            string conferenceTypeName = "";

            try
            {
                if ((dgvConferenceTypes.Rows[e.RowIndex].Cells[1].Value != null) && Convert.ToInt32(dgvConferenceTypes.Rows[e.RowIndex].Cells[1].Value.ToString()) != 0)
                {
                    conferenceTypeId = Convert.ToInt32(dgvConferenceTypes.Rows[e.RowIndex].Cells[1].Value.ToString());
                    conferenceTypeName = dgvConferenceTypes.Rows[e.RowIndex].Cells[0].Value.ToString();
                    conferenceTypeRepository.UpdateConferenceType(conferenceTypeId, conferenceTypeName);
                    LoadConferenceTypes();
                }

                else
                {
                    conferenceTypeName = dgvConferenceTypes.Rows[e.RowIndex].Cells[0].Value.ToString();
                    ConferenceTypeModel model = new ConferenceTypeModel();
                    model.conferenceTypeName = conferenceTypeName;

                    HttpClientOperations.PostOperation<ConferenceTypeModel>("http://localhost:5000/api/ConferenceType/PostConferenceType", model);
                    // conferenceTypeRepository.InsertConferenceType(conferenceTypeName);
                    LoadConferenceTypes();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnDelete_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvConferenceTypes.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvConferenceTypes.SelectedRows[0].Index;
                int conferenceTypeId = Convert.ToInt32(dgvConferenceTypes[1, selectedIndex].Value);
               // conferenceTypeRepository.DeleteConferenceType(conferenceTypeId);
                ConferenceTypeModel model = new ConferenceTypeModel();

                model.conferenceTypeId = conferenceTypeId;

                HttpClientOperations.DeleteOperation<ConferenceTypeModel>("http://localhost:5000/api/ConferenceType/DeleteConferenceType", model);
                dgvConferenceTypes.Rows.Clear();
                LoadConferenceTypes();
            }
        }

        private void dgvConferenceTypes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvConferenceTypes.ClearSelection();
        }

        private void dgvConferenceTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            typeId = Convert.ToInt32(dgvConferenceTypes.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());
            FormAddConferenceGeneral.conference.DictionaryConferenceTypeId = typeId;
        }

        private void FormAddConferenceType_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormAddConferenceGeneral.conference.DictionaryConferenceTypeId = typeId;
            FormAddConferenceGeneral.conferenceModel.ConferenceType = typeId.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvConferenceTypes.Rows.Clear();
            range = step;
            step += shown;
            btnPrevious.Enabled = true;
            if (step >= maxrange)
            {
                button2.Enabled = false;
            }
            Console.WriteLine("Am dat Next: range=" + range + " si step=" + step);
            WireUpCities();

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dgvConferenceTypes.Rows.Clear();
            step = range;
            range -= shown;
            btnPrevious.Enabled = true;
            if (range == 0)
            {
                btnPrevious.Enabled = false;
            }
            Console.WriteLine("Am dat Back: range=" + range + " si step=" + step);
            WireUpCities();
        }

        private void comboBoxPagesNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvConferenceTypes.Rows.Clear();
            range = 0;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnPrevious.Enabled = false;
            WireUpCities();
        }
    }
}
