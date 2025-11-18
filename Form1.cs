using Microsoft.Win32;
using System;
using System.Drawing;
using System.Management;
using System.ServiceProcess;
using System.Windows.Forms;

namespace frmupdateblocker
{
    public partial class Form1 : Form
    {
        // Đường dẫn khóa Registry Chính sách Windows Update
        private const string AU_KEY = @"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU";
        public Form1()
        {
            InitializeComponent();
            CheckWindowsUpdateServiceStatus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //hiện ngày tháng trên thanh tiêu đề và cập nhật mỗi giây
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 giây
            timer.Tick += Timer_Tick;
            timer.Start();
            // Cập nhật lần đầu ngay khi Form khởi động
            
            UpdateTitleWithDateTime();

            //hiển thị hđh
            // Source - https://stackoverflow.com/a
            // Posted by Rovann Linhalis
            // Retrieved 2025-11-18, License - CC BY-SA 4.0

            string r = "";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
            {
                ManagementObjectCollection information = searcher.Get();
                if (information != null)
                {
                    foreach (ManagementObject obj in information)
                    {
                        r = obj["Caption"].ToString() + " - " + obj["OSArchitecture"].ToString();
                    }
                }
                r = r.Replace("NT 5.1.2600", "XP");
                r = r.Replace("NT 5.2.3790", "Server 2003");
                lblos.Text=r;

                ConfigureRadioToolTips();

                // 2. TẢI CẤU HÌNH REGISTRY VÀ CHỌN RADIO BUTTON
                LoadCurrentSettings();
            }
        }

        // Hàm cấu hình ToolTip
        private void ConfigureRadioToolTips()
        {
            // Giả sử bạn đã kéo ToolTip vào Form và đặt tên là radioToolTip

            radioToolTip.SetToolTip(rbAuto,
                "Windows automatically downloads and installs all updates without user intervention."
            );

            radioToolTip.SetToolTip(rbNotify,
                "Windows automatically downloads updates, but will notify you to decide when to install them."
            );

            radioToolTip.SetToolTip(rbBlock,
                "Block automatic download and installation. Windows will always ask you before starting to download any updates\"."
            );
        }
        private void UpdateTitleWithDateTime()
        {
            // Gán chuỗi ngày giờ hiện tại vào thuộc tính Text (Thanh tiêu đề) của Form
            this.Text = "Windows Update Blocker" + " " + "-" + "" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Khi Timer Tick (sau mỗi 1 giây), gọi lại hàm cập nhật tiêu đề
            UpdateTitleWithDateTime();
        }

        private void CheckWindowsUpdateServiceStatus()
        {
            try
            {
                ServiceController sc = new ServiceController("wuauserv");
                string statusMessage;
                Color statusColor;

                ServiceControllerStatus status = sc.Status;

                switch (status)
                {
                    case ServiceControllerStatus.Running:
                        statusMessage = "Running\r\nUpdates are allowed to run.";
                        statusColor = Color.Green;
                        break;
                    case ServiceControllerStatus.Stopped:
                        statusMessage = "Stopped\r\nUpdates are paused.";
                        statusColor = Color.Red;
                        break;
                    case ServiceControllerStatus.StopPending:
                    case ServiceControllerStatus.StartPending:
                        statusMessage = "Changing State)...";
                        statusColor = Color.Orange;
                        break;
                    default:
                        statusMessage = $"Unknown Status: ({status})";
                        statusColor = Color.Gray;
                        break;
                }

                lblServiceStatus.Text = "Service Status: " + statusMessage;
                lblServiceStatus.ForeColor = statusColor;
            }
            catch (Exception ex)
            {
                lblServiceStatus.Text = $"Error checking service:: {ex.Message}";
                lblServiceStatus.ForeColor = Color.DarkRed;
            }
        }

        /* --- CHỨC NĂNG 3: ÁP DỤNG CHÍNH SÁCH VÀ KHỞI ĐỘNG LẠI DỊCH VỤ --- */
        

        // Hàm thiết lập chính sách Registry và xử lý quyền Admin
       // private const string AU_KEY = @"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU";

        private bool SetUpdatePolicy(int userChoice)
        {
            // === CASE 1: XÓA CHÍNH SÁCH (AUTOMATIC/KHÔI PHỤC) ===
            if (userChoice == 1)
            {
                try
                {
                    // Xóa khóa WindowsUpdate và tất cả các khóa con (bao gồm AU)
                    // Lệnh này loại bỏ hoàn toàn chính sách quản lý
                    Registry.LocalMachine.DeleteSubKeyTree(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate", false);

                    MessageBox.Show("Configured: Fully Automatic.\r\nPlease RESTART YOUR COMPUTER to complete the restoration process.", "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    // Lỗi khi xóa thường xảy ra nếu ứng dụng thiếu quyền Admin hoặc bị xung đột
                    MessageBox.Show($"ERROR DELETING REGISTRY: {ex.Message}. Please check Admin permissions.\" .",
                                    "Registry Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }
            }

            // === CASES 2 & 3: GHI CHÍNH SÁCH (NOTIFY/BLOCK) ===
            try
            {
                // Tạo hoặc Mở khóa AU. Nếu key == null, tức là thiếu quyền Admin.
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(AU_KEY))
                {
                    if (key == null)
                    {
                        MessageBox.Show("ACCESS DENIED ERROR: The application must be run with Administrator privileges (Run as Administrator) to modify system settings.\"",
                                        "Registry Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return false;
                    }

                    int noAutoUpdateValue;
                    int auOptionsValue;
                    string message;

                    switch (userChoice)
                    {
                        case 2: // Notify before Install
                            noAutoUpdateValue = 0; auOptionsValue = 3;
                            message = "Configured: Automatic download, notify on installation.";
                            break;
                        case 3: // Block (Notify before Download)
                            noAutoUpdateValue = 1; auOptionsValue = 2;
                            message = "Configured: Automatic block, always ask before downloading.";
                            break;
                        default:
                            // Lựa chọn không hợp lệ (Không phải 1, 2, hay 3)
                            return false;
                    }

                    // Ghi giá trị và thông báo thành công
                    key.SetValue("NoAutoUpdate", noAutoUpdateValue, RegistryValueKind.DWord);
                    key.SetValue("AUOptions", auOptionsValue, RegistryValueKind.DWord);

                    MessageBox.Show($"{message}\r\n\"Please restart the Windows Update service to apply.",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Lỗi chung khi ghi Registry (ví dụ: bị khóa file, lỗi định dạng)
                MessageBox.Show($"REGISTRY WRITE ERROR: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        // Hàm khởi động lại dịch vụ

        private void LoadCurrentSettings()
        {
            try
            {
                // Chỉ mở khóa Registry, không tạo khóa (sử dụng OpenSubKey)
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(AU_KEY))
                {
                    // Nếu khóa chưa tồn tại, nghĩa là đang dùng cài đặt mặc định (Auto)
                    if (key == null)
                    {
                        rbAuto.Checked = true;
                        return;
                    }

                    // Đọc hai giá trị chính sách
                    object noAutoUpdateObj = key.GetValue("NoAutoUpdate");
                    object auOptionsObj = key.GetValue("AUOptions");

                    int noAutoUpdate = (noAutoUpdateObj != null) ? (int)noAutoUpdateObj : 0;
                    int auOptions = (auOptionsObj != null) ? (int)auOptionsObj : 0;

                    // Logic Quyết định Chế độ
                    if (noAutoUpdate == 1)
                    {
                        // NoAutoUpdate = 1 (Chặn tự động)
                        rbBlock.Checked = true;
                    }
                    else if (noAutoUpdate == 0)
                    {
                        // Cập nhật được phép, kiểm tra cách thức (AUOptions)
                        if (auOptions == 4)
                        {
                            // Tự động hoàn toàn
                            rbAuto.Checked = true;
                        }
                        else if (auOptions == 3)
                        {
                            // Tự động tải xuống, hỏi khi cài đặt
                            rbNotify.Checked = true;
                        }
                        else
                        {
                            // Nếu là 0 hoặc không xác định (mặc định), đặt là Auto
                            rbAuto.Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Thường gặp nếu thiếu quyền Admin khi đọc, nhưng chúng ta chỉ đang đọc HKLM\Policies nên ít lỗi hơn.
                // Giả sử Auto là lựa chọn an toàn nếu xảy ra lỗi.
                rbAuto.Checked = true;
                MessageBox.Show($"Error reading Registry configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnApply_Click_1(object sender, EventArgs e)
        {
            int selectedMode = 0;

            if (rbAuto.Checked)
                selectedMode = 1; // Auto
            else if (rbNotify.Checked)
                selectedMode = 2; // Notify before Install
            else if (rbBlock.Checked)
                selectedMode = 3; // Block (Notify before Download)

            if (selectedMode > 0)
            {
                if (SetUpdatePolicy(selectedMode)) // Ghi Registry thành công?
                {
                   
                    // Cập nhật lại trạng thái dịch vụ sau khi khởi động lại
                    CheckWindowsUpdateServiceStatus();
                }
            }
            else
            {
                MessageBox.Show("Please select an update mode.", "Missing selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
