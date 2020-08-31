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
    public partial class FormAddConferenceType : Form
    {

        public int typeId;
        private readonly IConferenceTypeRepository conferenceTypeRepository;
        private BindingSource bsTypes = new BindingSource();
        public List<ConferenceTypeModel> conferenceTypes { get; set; }


        public FormAddConferenceType(IConferenceTypeRepository _conferenceTypeRepository)
        {
            conferenceTypeRepository = _conferenceTypeRepository;
            conferenceTypes = conferenceTypeRepository.getConferenceTypes();
            InitializeComponent();
            LoadConferenceTypes();
        }

        public void LoadConferenceTypes()
        {
            bsTypes.AllowNew = true;
            bsTypes.DataSource = null;
            bsTypes.DataSource = conferenceTypes;

            dgvConferenceTypes.DataSource = bsTypes;


            dgvConferenceTypes.Columns[0].HeaderText = "Name";
            dgvConferenceTypes.Columns[1].HeaderText = "Id";
            dgvConferenceTypes.Columns[1].Name = "Id";

        }

        public void LoadConferenceTypes(string keyword)
        {
            conferenceTypes = conferenceTypeRepository.getConferenceTypes(keyword);

            bsTypes.AllowNew = true;
            bsTypes.DataSource = null;
            bsTypes.DataSource = conferenceTypes;

            dgvConferenceTypes.DataSource = bsTypes;


            dgvConferenceTypes.Columns[0].HeaderText = "Name";
            dgvConferenceTypes.Columns[1].HeaderText = "Id";

            dgvConferenceTypes.Columns[1].Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            LoadConferenceTypes(keyword);
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
                if ((int)dgvConferenceTypes.Rows[e.RowIndex].Cells[1].Value != 0)
                {
                    conferenceTypeId = Convert.ToInt32(dgvConferenceTypes.Rows[e.RowIndex].Cells[1].Value.ToString());
                    conferenceTypeName = dgvConferenceTypes.Rows[e.RowIndex].Cells[0].Value.ToString();
                    conferenceTypeRepository.UpdateConferenceType(conferenceTypeId, conferenceTypeName);
                }

                else
                {
                    conferenceTypeName = dgvConferenceTypes.Rows[e.RowIndex].Cells[0].Value.ToString();

                    conferenceTypeRepository.InsertConferenceType(conferenceTypeName);
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
                conferenceTypeRepository.DeleteConferenceType(conferenceTypeId);
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
        }

        private void FormAddConferenceType_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormAddConferenceGeneral.conference.ConferenceType = typeId.ToString();

        }
    }
}
