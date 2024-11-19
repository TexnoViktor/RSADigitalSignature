using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RSADigitalSignature
{
    public partial class MainForm : Form
    {
        private string privateKeyPath = string.Empty;
        private string publicKeyPath = string.Empty;

        public MainForm()
        {
            InitializeComponent();
        }

        // Генерація ключів
        private void GenerateKeys_Click(object sender, EventArgs e)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Зберігаємо закритий ключ у файл
                File.WriteAllText("privateKey.xml", rsa.ToXmlString(true));
                // Зберігаємо відкритий ключ у файл
                File.WriteAllText("publicKey.xml", rsa.ToXmlString(false));
                MessageBox.Show("Ключі згенеровані та збережені!");
            }
        }

        // Зчитування закритого ключа
        private void LoadPrivateKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML Files (*.xml)|*.xml",
                Title = "Виберіть файл із закритим ключем"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                privateKeyPath = openFileDialog.FileName;
                MessageBox.Show($"Закритий ключ завантажено: {privateKeyPath}");
            }
        }

        // Зчитування відкритого ключа
        private void LoadPublicKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML Files (*.xml)|*.xml",
                Title = "Виберіть файл із відкритим ключем"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                publicKeyPath = openFileDialog.FileName;
                MessageBox.Show($"Відкритий ключ завантажено: {publicKeyPath}");
            }
        }

        // Підписання повідомлення
        private void SignMessage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(privateKeyPath))
            {
                MessageBox.Show("Будь ласка, завантажте закритий ключ.");
                return;
            }

            string message = txtMessage.Text;

            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Будь ласка, введіть повідомлення для підпису.");
                return;
            }

            string privateKey = File.ReadAllText(privateKeyPath);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);

                // Перетворюємо повідомлення у байти
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);

                // Генеруємо хеш повідомлення
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
                {
                    byte[] hash = sha1.ComputeHash(messageBytes);

                    // Створюємо цифровий підпис
                    byte[] signature = rsa.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));

                    // Зберігаємо підпис у файл
                    File.WriteAllBytes("signature.sig", signature);
                    MessageBox.Show("Повідомлення підписане та підпис збережено у файл signature.sig.");
                }
            }
        }

        // Перевірка підпису
        private void VerifySignature_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(publicKeyPath))
            {
                MessageBox.Show("Будь ласка, завантажте відкритий ключ.");
                return;
            }

            string message = txtMessage.Text;

            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Будь ласка, введіть повідомлення для перевірки.");
                return;
            }

            // Вибираємо файл підпису
            OpenFileDialog openSignatureDialog = new OpenFileDialog
            {
                Filter = "Signature Files (*.sig)|*.sig",
                Title = "Виберіть файл із підписом"
            };

            if (openSignatureDialog.ShowDialog() != DialogResult.OK)
                return;

            byte[] signature = File.ReadAllBytes(openSignatureDialog.FileName);

            string publicKey = File.ReadAllText(publicKeyPath);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);

                // Перетворюємо повідомлення у байти
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);

                // Генеруємо хеш повідомлення
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
                {
                    byte[] hash = sha1.ComputeHash(messageBytes);

                    // Перевіряємо підпис
                    bool isValid = rsa.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);

                    MessageBox.Show(isValid ? "Підпис дійсний!" : "Підпис недійсний!");
                }
            }
        }
    }
}
