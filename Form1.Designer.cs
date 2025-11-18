namespace frmupdateblocker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblname = new System.Windows.Forms.Label();
            this.lblServiceStatus = new System.Windows.Forms.Label();
            this.rbAuto = new System.Windows.Forms.RadioButton();
            this.rbNotify = new System.Windows.Forms.RadioButton();
            this.rbBlock = new System.Windows.Forms.RadioButton();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblos = new System.Windows.Forms.Label();
            this.radioToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblname);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(-1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblServiceStatus);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(-1, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnApply);
            this.groupBox3.Controls.Add(this.rbBlock);
            this.groupBox3.Controls.Add(this.rbNotify);
            this.groupBox3.Controls.Add(this.rbAuto);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(-1, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(440, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblos);
            this.groupBox4.Location = new System.Drawing.Point(-1, 216);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(440, 65);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(39, 25);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(348, 24);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "WINDOWS UPDATE BLOCKER V1.1";
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblServiceStatus.Location = new System.Drawing.Point(13, 22);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(0, 20);
            this.lblServiceStatus.TabIndex = 0;
            // 
            // rbAuto
            // 
            this.rbAuto.AutoSize = true;
            this.rbAuto.Location = new System.Drawing.Point(6, 29);
            this.rbAuto.Name = "rbAuto";
            this.rbAuto.Size = new System.Drawing.Size(108, 24);
            this.rbAuto.TabIndex = 0;
            this.rbAuto.TabStop = true;
            this.rbAuto.Text = "Automatic";
            this.rbAuto.UseVisualStyleBackColor = true;
            // 
            // rbNotify
            // 
            this.rbNotify.AutoSize = true;
            this.rbNotify.Location = new System.Drawing.Point(120, 29);
            this.rbNotify.Name = "rbNotify";
            this.rbNotify.Size = new System.Drawing.Size(73, 24);
            this.rbNotify.TabIndex = 1;
            this.rbNotify.TabStop = true;
            this.rbNotify.Text = "Notify";
            this.rbNotify.UseVisualStyleBackColor = true;
            // 
            // rbBlock
            // 
            this.rbBlock.AutoSize = true;
            this.rbBlock.Location = new System.Drawing.Point(199, 29);
            this.rbBlock.Name = "rbBlock";
            this.rbBlock.Size = new System.Drawing.Size(71, 24);
            this.rbBlock.TabIndex = 2;
            this.rbBlock.TabStop = true;
            this.rbBlock.Text = "Block";
            this.rbBlock.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(334, 27);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(94, 29);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click_1);
            // 
            // lblos
            // 
            this.lblos.AutoSize = true;
            this.lblos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblos.Location = new System.Drawing.Point(13, 30);
            this.lblos.Name = "lblos";
            this.lblos.Size = new System.Drawing.Size(57, 20);
            this.lblos.TabIndex = 1;
            this.lblos.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 285);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(455, 324);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(455, 324);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblServiceStatus;
        private System.Windows.Forms.RadioButton rbBlock;
        private System.Windows.Forms.RadioButton rbNotify;
        private System.Windows.Forms.RadioButton rbAuto;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblos;
        private System.Windows.Forms.ToolTip radioToolTip;
    }
}

