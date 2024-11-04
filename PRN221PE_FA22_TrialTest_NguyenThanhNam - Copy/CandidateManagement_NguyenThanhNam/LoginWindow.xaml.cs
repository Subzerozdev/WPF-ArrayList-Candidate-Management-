using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Candidate_BusinessObjects;
using Candidate_Services;

namespace CandidateManagement_NguyenThanhNam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IHRAccountService iAccountService;

        public LoginWindow()
        {
            InitializeComponent();
            iAccountService = new HRAccountService();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = iAccountService.GetHraccountByEmail(txtEmail.Text.Trim());

            if (hraccount != null && txtPassword.Password.Equals(hraccount.Password))
            {
                // can be null
                int? roleID = hraccount.MemberRole;
                switch (roleID)
                {
                    case 1:
                        this.Hide();
                        //JobPostingWindow jopForm = new JobPostingWindow();
                        CandidateProfileManagement candForm = new CandidateProfileManagement(roleID);
                        candForm.Show();
                        break;
                    case 2:
                        this.Hide();
                        //JobPostingWindow jopForm = new JobPostingWindow();
                        CandidateProfileManagement staffCandidate = new CandidateProfileManagement(roleID);
                        staffCandidate.Show();
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }

                
            }
            else
            {
                MessageBox.Show("Bye Bye!");
            }
        }
    }
}