namespace RentACar
{
    partial class fmRent
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbCar = new System.Windows.Forms.Label();
            this.lbClient = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbDate1 = new System.Windows.Forms.Label();
            this.lbDate2 = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.btFind = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите номер аренды:";
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(14, 88);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(88, 17);
            this.lbNumber.TabIndex = 1;
            this.lbNumber.Text = "Аренда №: -";
            // 
            // lbCar
            // 
            this.lbCar.AutoSize = true;
            this.lbCar.Location = new System.Drawing.Point(14, 128);
            this.lbCar.Name = "lbCar";
            this.lbCar.Size = new System.Drawing.Size(70, 17);
            this.lbCar.TabIndex = 2;
            this.lbCar.Text = "Машина: ";
            // 
            // lbClient
            // 
            this.lbClient.AutoSize = true;
            this.lbClient.Location = new System.Drawing.Point(12, 168);
            this.lbClient.Name = "lbClient";
            this.lbClient.Size = new System.Drawing.Size(115, 17);
            this.lbClient.TabIndex = 3;
            this.lbClient.Text = "Права клиента: ";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(310, 88);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(132, 17);
            this.lbPrice.TabIndex = 4;
            this.lbPrice.Text = "Стоимость за час: ";
            // 
            // lbDate1
            // 
            this.lbDate1.AutoSize = true;
            this.lbDate1.Location = new System.Drawing.Point(310, 128);
            this.lbDate1.Name = "lbDate1";
            this.lbDate1.Size = new System.Drawing.Size(152, 17);
            this.lbDate1.TabIndex = 5;
            this.lbDate1.Text = "Дата начала аренды:";
            // 
            // lbDate2
            // 
            this.lbDate2.AutoSize = true;
            this.lbDate2.Location = new System.Drawing.Point(310, 168);
            this.lbDate2.Name = "lbDate2";
            this.lbDate2.Size = new System.Drawing.Size(143, 17);
            this.lbDate2.TabIndex = 6;
            this.lbDate2.Text = "Дата конца аренды:";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbResult.Location = new System.Drawing.Point(12, 239);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(148, 25);
            this.lbResult.TabIndex = 7;
            this.lbResult.Text = "Итого (руб.): ";
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(184, 9);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(100, 22);
            this.tbNumber.TabIndex = 8;
            this.tbNumber.Validating += new System.ComponentModel.CancelEventHandler(this.tbNumber_Validating);
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(12, 40);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(107, 27);
            this.btFind.TabIndex = 9;
            this.btFind.Text = "Найти";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(125, 40);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(107, 27);
            this.btPrint.TabIndex = 10;
            this.btPrint.Text = "Печать";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // fmRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 294);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btFind);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.lbDate2);
            this.Controls.Add(this.lbDate1);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbClient);
            this.Controls.Add(this.lbCar);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.label1);
            this.Name = "fmRent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация об аренде";
            this.Load += new System.EventHandler(this.fmRent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbCar;
        private System.Windows.Forms.Label lbClient;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbDate1;
        private System.Windows.Forms.Label lbDate2;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}