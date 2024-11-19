namespace RSADigitalSignature
{
    partial class MainForm
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.LoadPrivateKey = new System.Windows.Forms.Button();
            this.LoadPublicKey = new System.Windows.Forms.Button();
            this.GenerateKeys = new System.Windows.Forms.Button();
            this.SignMessage = new System.Windows.Forms.Button();
            this.VerifySignature = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(189, 78);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(415, 20);
            this.txtMessage.TabIndex = 0;
            // 
            // LoadPrivateKey
            // 
            this.LoadPrivateKey.Location = new System.Drawing.Point(211, 175);
            this.LoadPrivateKey.Name = "LoadPrivateKey";
            this.LoadPrivateKey.Size = new System.Drawing.Size(144, 23);
            this.LoadPrivateKey.TabIndex = 1;
            this.LoadPrivateKey.Text = "Зчитати закритий ключ";
            this.LoadPrivateKey.UseVisualStyleBackColor = true;
            this.LoadPrivateKey.Click += new System.EventHandler(this.LoadPrivateKey_Click);
            // 
            // LoadPublicKey
            // 
            this.LoadPublicKey.Location = new System.Drawing.Point(466, 175);
            this.LoadPublicKey.Name = "LoadPublicKey";
            this.LoadPublicKey.Size = new System.Drawing.Size(138, 23);
            this.LoadPublicKey.TabIndex = 2;
            this.LoadPublicKey.Text = "Зчитати відкритий ключ";
            this.LoadPublicKey.UseVisualStyleBackColor = true;
            this.LoadPublicKey.Click += new System.EventHandler(this.LoadPublicKey_Click);
            // 
            // GenerateKeys
            // 
            this.GenerateKeys.Location = new System.Drawing.Point(360, 128);
            this.GenerateKeys.Name = "GenerateKeys";
            this.GenerateKeys.Size = new System.Drawing.Size(104, 23);
            this.GenerateKeys.TabIndex = 3;
            this.GenerateKeys.Text = "Генерація ключів";
            this.GenerateKeys.UseVisualStyleBackColor = true;
            this.GenerateKeys.Click += new System.EventHandler(this.GenerateKeys_Click);
            // 
            // SignMessage
            // 
            this.SignMessage.Location = new System.Drawing.Point(211, 250);
            this.SignMessage.Name = "SignMessage";
            this.SignMessage.Size = new System.Drawing.Size(144, 23);
            this.SignMessage.TabIndex = 4;
            this.SignMessage.Text = "Підписати повідомлення";
            this.SignMessage.UseVisualStyleBackColor = true;
            this.SignMessage.Click += new System.EventHandler(this.SignMessage_Click);
            // 
            // VerifySignature
            // 
            this.VerifySignature.Location = new System.Drawing.Point(466, 250);
            this.VerifySignature.Name = "VerifySignature";
            this.VerifySignature.Size = new System.Drawing.Size(138, 23);
            this.VerifySignature.TabIndex = 5;
            this.VerifySignature.Text = "Перевірити підпис";
            this.VerifySignature.UseVisualStyleBackColor = true;
            this.VerifySignature.Click += new System.EventHandler(this.VerifySignature_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VerifySignature);
            this.Controls.Add(this.SignMessage);
            this.Controls.Add(this.GenerateKeys);
            this.Controls.Add(this.LoadPublicKey);
            this.Controls.Add(this.LoadPrivateKey);
            this.Controls.Add(this.txtMessage);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button LoadPublicKey;
        private System.Windows.Forms.Button GenerateKeys;
        private System.Windows.Forms.Button SignMessage;
        private System.Windows.Forms.Button VerifySignature;
        private System.Windows.Forms.Button LoadPrivateKey;
    }
}

