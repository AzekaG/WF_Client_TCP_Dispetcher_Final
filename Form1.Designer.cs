namespace WF_Client_TCP_Dispetcher_Final
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Connect = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnStopProcess = new System.Windows.Forms.Button();
            this.btnRefreshListProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(12, 1);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(198, 35);
            this.btn_Connect.TabIndex = 0;
            this.btn_Connect.Text = "Подключиться к серверу";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(775, 355);
            this.listBox1.TabIndex = 1;
            // 
            // btnStopProcess
            // 
            this.btnStopProcess.Location = new System.Drawing.Point(480, 415);
            this.btnStopProcess.Name = "btnStopProcess";
            this.btnStopProcess.Size = new System.Drawing.Size(307, 23);
            this.btnStopProcess.TabIndex = 2;
            this.btnStopProcess.Text = "Отправить запрос на остановку процесса";
            this.btnStopProcess.UseVisualStyleBackColor = true;
            this.btnStopProcess.Click += new System.EventHandler(this.btnStopProcess_Click);
            // 
            // btnRefreshListProcess
            // 
            this.btnRefreshListProcess.Location = new System.Drawing.Point(13, 415);
            this.btnRefreshListProcess.Name = "btnRefreshListProcess";
            this.btnRefreshListProcess.Size = new System.Drawing.Size(295, 23);
            this.btnRefreshListProcess.TabIndex = 3;
            this.btnRefreshListProcess.Text = "Обновить лист процессов";
            this.btnRefreshListProcess.UseVisualStyleBackColor = true;
            this.btnRefreshListProcess.Click += new System.EventHandler(this.btnRefreshListProcess_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefreshListProcess);
            this.Controls.Add(this.btnStopProcess);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_Connect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnStopProcess;
        private System.Windows.Forms.Button btnRefreshListProcess;
    }
}

