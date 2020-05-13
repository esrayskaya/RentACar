namespace RentACar
{
    partial class fmMain
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
            this.btClient = new System.Windows.Forms.Button();
            this.btCarOwner = new System.Windows.Forms.Button();
            this.btAdmin = new System.Windows.Forms.Button();
            this.lbMain = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbUser = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClient
            // 
            this.btClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btClient.Location = new System.Drawing.Point(65, 32);
            this.btClient.Name = "btClient";
            this.btClient.Size = new System.Drawing.Size(188, 47);
            this.btClient.TabIndex = 0;
            this.btClient.Text = "Клиент";
            this.btClient.UseVisualStyleBackColor = true;
            // 
            // btCarOwner
            // 
            this.btCarOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCarOwner.Location = new System.Drawing.Point(65, 85);
            this.btCarOwner.Name = "btCarOwner";
            this.btCarOwner.Size = new System.Drawing.Size(188, 47);
            this.btCarOwner.TabIndex = 1;
            this.btCarOwner.Text = "Арендатор";
            this.btCarOwner.UseVisualStyleBackColor = true;
            // 
            // btAdmin
            // 
            this.btAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAdmin.Location = new System.Drawing.Point(65, 138);
            this.btAdmin.Name = "btAdmin";
            this.btAdmin.Size = new System.Drawing.Size(188, 47);
            this.btAdmin.TabIndex = 2;
            this.btAdmin.Text = "Администратор";
            this.btAdmin.UseVisualStyleBackColor = true;
            this.btAdmin.Click += new System.EventHandler(this.btAdmin_Click);
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMain.Location = new System.Drawing.Point(157, 9);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(472, 29);
            this.lbMain.TabIndex = 3;
            this.lbMain.Text = "Приложение для поиска и аренды авто";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbUser);
            this.panel1.Controls.Add(this.btClient);
            this.panel1.Controls.Add(this.btCarOwner);
            this.panel1.Controls.Add(this.btAdmin);
            this.panel1.Location = new System.Drawing.Point(235, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 239);
            this.panel1.TabIndex = 4;
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUser.Location = new System.Drawing.Point(41, 5);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(236, 24);
            this.lbUser.TabIndex = 5;
            this.lbUser.Text = "Выберете пользователя:";
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbMain);
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аренда авто";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClient;
        private System.Windows.Forms.Button btCarOwner;
        private System.Windows.Forms.Button btAdmin;
        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbUser;
    }
}

