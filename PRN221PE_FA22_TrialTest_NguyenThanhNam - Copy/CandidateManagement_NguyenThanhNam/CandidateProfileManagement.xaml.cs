using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Candidate_BusinessObjects;
using Candidate_Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CandidateManagement_NguyenThanhNam
{
    /// <summary>
    /// Interaction logic for CandidateProfileManagement.xaml
    /// </summary>
    public partial class CandidateProfileManagement : Window
    {
        // Service
        private readonly ICandidateProfileService profileService;
        private readonly IJobPostingService jobService;
        private readonly int? RoleID;
        public CandidateProfileManagement()
        {
            InitializeComponent();
            // Load Service
            this.profileService = new CandidateProfileService();
            this.jobService = new JobPostingService();
        }

        public CandidateProfileManagement(int? roleID)
        {
            InitializeComponent();
            // Load Service
            this.profileService = new CandidateProfileService();
            this.jobService = new JobPostingService();
            this.RoleID = roleID;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (RoleID)
            {
                case 1:
                    break;
                case 2:
                    // Staff
                    this.btnAdd.IsEnabled = false;
                    break;
                case 3:
                    break;
                default:
                    this.Close();
                    break;
            }
            this.loadDataInit();
        }

        private void loadDataInit()
        {
            List<CandidateProfile> list = profileService.GetCandidateProfiles();
            this.dtgCandidateProfile.ItemsSource = null;
            this.dtgCandidateProfile.ItemsSource = list;
            this.cmbJobPosting.ItemsSource = jobService.GetJobPostings();
            this.cmbJobPosting.DisplayMemberPath = "JobPostingTitle";
            this.cmbJobPosting.SelectedValuePath = "PostingId";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(cmbJobPosting.SelectedValue.ToString());

            // Create new candidate and set all value from form
            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCandidateID.Text;
            candidateProfile.Fullname = txtFullName.Text;
            candidateProfile.Birthday = dpBirthDay.SelectedDate; // DateTime.Parse(dpBirthDay.Text)
            candidateProfile.ProfileShortDescription = txtDescription.Text;
            candidateProfile.ProfileUrl = txtImageURL.Text;
            candidateProfile.PostingId = cmbJobPosting.SelectedValue.ToString();
            // Save candidate to DB
            if (profileService.AddCandidateProfile(candidateProfile))
            {
                MessageBox.Show("Add Successful !");
                this.loadDataInit();
            }
            else
            {
                MessageBox.Show("Something went wrong !");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ?
            DataGrid? dataGrid = sender as DataGrid;
            DataGridRow? row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            if (row != null)
            {
                DataGridCell? RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                String? id = ((TextBlock)RowColumn.Content).Text;
                if (id != null)
                {
                    // Keep user input in form
                    CandidateProfile candidateProfile = profileService.GetCandidateProfile(id);
                    txtCandidateID.Text = candidateProfile.CandidateId;
                    txtFullName.Text = candidateProfile.Fullname;
                    dpBirthDay.SelectedDate = candidateProfile.Birthday;
                    txtDescription.Text = candidateProfile.ProfileShortDescription;
                    txtImageURL.Text = candidateProfile.ProfileUrl;
                    cmbJobPosting.SelectedValue = candidateProfile.PostingId;
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (profileService.DeleteCandidateProfile(txtCandidateID.Text.ToString()))
            {
                MessageBox.Show("Delete Successful !");
                this.loadDataInit();
            }
            else
            {
                MessageBox.Show("Something went wrong !");
            }

        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Create new candidate and set all value from form
            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCandidateID.Text;
            candidateProfile.Fullname = txtFullName.Text;
            candidateProfile.Birthday = dpBirthDay.SelectedDate;
            candidateProfile.ProfileShortDescription = txtDescription.Text;
            candidateProfile.ProfileUrl = txtImageURL.Text;
            candidateProfile.PostingId = cmbJobPosting.SelectedValue.ToString();
            // Update candidate to DB
            if (profileService.UpdateCandidateProfile(candidateProfile))
            {
                MessageBox.Show("Update Successful !");
                this.loadDataInit();
            }
            else
            {
                MessageBox.Show("Something went wrong !");
            }
        }

        private void btnNavigate_Click(object sender, RoutedEventArgs e)
        {
            JobPostingWindow jobPostingWindow = new JobPostingWindow();
            jobPostingWindow.ShowDialog();
            this.loadDataInit();
        }
    }
}
