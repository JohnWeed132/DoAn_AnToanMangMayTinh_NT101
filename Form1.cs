using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Numerics;
using System.Diagnostics;

namespace DoAnCuoiKy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void tabPlayfail_Click(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void radio5x5matrix_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radio6x6matrix_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radio5x5matrix.Checked = true;
            txtKeyPlayfair.Text = "CIPHER";
            btnEncryptRSA.Enabled = false;
            btnDecryptRSA.Enabled = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnEncryptPlayfair_Click(object sender, EventArgs e)
        {
            int size = 0;
            string keyPlayfair;
            string inputText;
            if (radio5x5matrix.Checked == true)
            {
                inputText = richtbInputPlayfair.Text;
                string pattern = @"^[a-zA-Z ]*$";
                bool isMatch = Regex.IsMatch(inputText, pattern);
                if (!isMatch)
                {
                    MessageBox.Show("Khi chọn 5x5 matrix, input chỉ có thể là chữ cái", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                keyPlayfair = txtKeyPlayfair.Text;
                isMatch = Regex.IsMatch(keyPlayfair, pattern);
                if (!isMatch)
                {
                    MessageBox.Show("Khi chọn 5x5 matrix, key chỉ có thể là chữ cái", "Key Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                size = 5;
            }
            else 
            {
                inputText = richtbInputPlayfair.Text;
                string pattern = @"^[a-zA-Z0-9 ]*$";
                bool isMatch = Regex.IsMatch(inputText, pattern);
                if(!isMatch)
                {
                    MessageBox.Show("Khi chọn 6x6 matrix, input chỉ có thể là chữ cái và số", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                keyPlayfair = txtKeyPlayfair.Text;
                isMatch = Regex.IsMatch(keyPlayfair, pattern);
                if (!isMatch)
                {
                    MessageBox.Show("Khi chọn 6x6 matrix, key chỉ có thể là chữ cái và số", "Key Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                size = 6;
            }
            Label[,] labels = new Label[6, 6] {
                { label1, label2, label3, label4, label5, label6 },
                { label7, label8, label9, label10, label11, label12 },
                { label13, label14, label15, label16, label17, label18 },
                { label19, label20, label21, label22, label23, label24 },
                { label25, label26, label27, label28, label29, label30 },
                { label31, label32, label33, label34, label35, label36 }    
            };
            char[,] table = GenerateKeySquare(keyPlayfair, size);
            for (int i = 0; i < 6; ++i)
            {
                for (int j = 0; j < 6; ++j)
                {
                    labels[i, j].Text = "";
                }
            }
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    labels[i,j].Text =table[i, j].ToString();
                }
            }
            richtbOutputPlayfair.Text = Encipher(inputText, keyPlayfair, size);
        }

        private void btnDecryptPlayfair_Click(object sender, EventArgs e)
        { 
            int size = 0;
            string keyPlayfair;
            string inputText;
            if (radio5x5matrix.Checked == true)
            {
                inputText = richtbInputPlayfair.Text;
                string pattern = @"^[a-zA-Z ]*$";
                bool isMatch = Regex.IsMatch(inputText, pattern);
                if (!isMatch)
                {
                    MessageBox.Show("Khi chọn 5x5 matrix, input chỉ có thể là chữ cái", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                keyPlayfair = txtKeyPlayfair.Text;
                isMatch = Regex.IsMatch(keyPlayfair, pattern);
                if (!isMatch)
                {
                    MessageBox.Show("Khi chọn 5x5 matrix, key chỉ có thể là chữ cái", "Key Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                size = 5;
            }
            else
            {
                inputText = richtbInputPlayfair.Text;
                string pattern = @"^[a-zA-Z0-9 ]*$";
                bool isMatch = Regex.IsMatch(inputText, pattern);
                if (!isMatch)
                {
                    MessageBox.Show("Khi chọn 6x6 matrix, input chỉ có thể là chữ cái và số", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                keyPlayfair = txtKeyPlayfair.Text;
                isMatch = Regex.IsMatch(keyPlayfair, pattern);
                if (!isMatch)
                {
                    MessageBox.Show("Khi chọn 6x6 matrix, key chỉ có thể là chữ cái và số", "Key Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                size = 6;
            }
            Label[,] labels = new Label[6, 6] {
                { label1, label2, label3, label4, label5, label6 },
                { label7, label8, label9, label10, label11, label12 },
                { label13, label14, label15, label16, label17, label18 },
                { label19, label20, label21, label22, label23, label24 },
                { label25, label26, label27, label28, label29, label30 },
                { label31, label32, label33, label34, label35, label36 }
            };
            char[,] table = GenerateKeySquare(keyPlayfair, size);
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    labels[i, j].Text = table[i, j].ToString();
                }
            }
            richtbOutputPlayfair.Text = Decipher(inputText, keyPlayfair, size);
        }

        private void btnInputPlayfair_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Kiểm tra dung lượng của tệp
                FileInfo fileInfo = new FileInfo(filePath);
                long fileSizeInBytes = fileInfo.Length;
                double fileSizeInMb = (double)fileSizeInBytes / (1024 * 1024);

                if (fileSizeInMb <= 10)
                {
                    // Dung lượng tệp nhỏ hơn hoặc bằng 10MB, tiếp tục đọc nội dung
                    string fileContent = File.ReadAllText(filePath);
                    richtbInputPlayfair.Text = fileContent;
                }
                else
                {
                    // Dung lượng tệp lớn hơn 10MB, thông báo người dùng
                    MessageBox.Show("File size exceeds 10MB. Please choose a smaller file.","Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnOutputPlayfair_Click(object sender, EventArgs e)
        {
            if (richtbOutputPlayfair.Text == "")
            {
                MessageBox.Show("Output is empty.");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                   
                // Lưu nội dung của RichTextBox vào tệp văn bản
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(richtbOutputPlayfair.Text);
                }

                MessageBox.Show("File saved successfully!");
            }
        }
        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        private static List<int> FindAllOccurrences(string str, char value)
        {
            List<int> indexes = new List<int>();

            int index = 0;
            while ((index = str.IndexOf(value, index)) != -1)
                indexes.Add(index++);

            return indexes;
        }

        private static string RemoveAllDuplicates(string str, List<int> indexes)
        {
            string retVal = str;

            for (int i = indexes.Count - 1; i >= 1; i--)
                retVal = retVal.Remove(indexes[i], 1);

            return retVal;
        }

        private static char[,] GenerateKeySquare(string key, int size)
        {
            char[,] keySquare = new char[size, size];
            string defaultKeySquare;
            key = key.Replace(" ", "");
            if (size == 5)
            {
                defaultKeySquare = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            }
            else if (size == 6)
            {
                defaultKeySquare = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            }
            else
            {
                throw new ArgumentException("Unsupported table size. Use 5 or 6.");
            }

            string tempKey = string.IsNullOrEmpty(key) ? "CIPHER" : key.ToUpper();

            if (size == 5)
            {
                tempKey = tempKey.Replace("J", "");
            }
            tempKey += defaultKeySquare;
            for (int i = 0; i < size * size; ++i)
            {
                List<int> indexes = FindAllOccurrences(tempKey, defaultKeySquare[i]);
                tempKey = RemoveAllDuplicates(tempKey, indexes);
            }

            tempKey = tempKey.Substring(0, size * size);

            for (int i = 0; i < size * size; ++i)
                keySquare[(i / size), (i % size)] = tempKey[i];

            return keySquare;
        }
        private static void GetPosition(ref char[,] keySquare, char ch, ref int row, ref int col, int size)
        {
            if (size == 5)
            {
                if (ch == 'J')
                    GetPosition(ref keySquare, 'I', ref row, ref col, size);
            }

            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    if (keySquare[i, j] == ch)
                    {
                        row = i;
                        col = j;
                    }
        }

        private static char[] SameRow(ref char[,] keySquare, int row, int col1, int col2, int encipher, int size)
        {
            return new char[] { keySquare[row, Mod((col1 + encipher), size)], keySquare[row, Mod((col2 + encipher), size)] };
        }

        private static char[] SameColumn(ref char[,] keySquare, int col, int row1, int row2, int encipher, int size)
        {
            return new char[] { keySquare[Mod((row1 + encipher), size), col], keySquare[Mod((row2 + encipher), size), col] };
        }

        private static char[] SameRowColumn(ref char[,] keySquare, int row, int col, int encipher, int size)
        {
            return new char[] { keySquare[Mod((row + encipher), size), Mod((col + encipher), size)], keySquare[Mod((row + encipher), size), Mod((col + encipher), size)] };
        }

        private static char[] DifferentRowColumn(ref char[,] keySquare, int row1, int col1, int row2, int col2)
        {
            return new char[] { keySquare[row1, col2], keySquare[row2, col1] };
        }

        private static string RemoveOtherChars(string input)
        {
            string output = input;

            for (int i = 0; i < output.Length; ++i)
                if (output[i] == ' ')
                    output = output.Remove(i, 1);

            return output;
        }

        private static string AdjustOutput(string input, string output)
        {
            StringBuilder retVal = new StringBuilder(output);

            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == ' ')
                    retVal = retVal.Insert(i, input[i].ToString());

                // if (char.IsLower(input[i]))
                //     retVal[i] = char.ToLower(retVal[i]);
            }

            return retVal.ToString();
        }

        private static string Cipher(string input, string key, bool encipher, int size)
        {
            string retVal = string.Empty;
            char[,] keySquare = GenerateKeySquare(key, size);
            string tempInput = RemoveOtherChars(input);
            int e = encipher ? 1 : -1;

            if ((tempInput.Length % 2) != 0)
            {
                tempInput += "X";
            }

            for (int i = 0; i < tempInput.Length; i += 2)
            {
                int row1 = 0;
                int col1 = 0;
                int row2 = 0;
                int col2 = 0;

                GetPosition(ref keySquare, char.ToUpper(tempInput[i]), ref row1, ref col1, size);
                GetPosition(ref keySquare, char.ToUpper(tempInput[i + 1]), ref row2, ref col2, size);

                if (row1 == row2 && col1 == col2)
                {
                    retVal += new string(SameRowColumn(ref keySquare, row1, col1, e, size));
                }
                else if (row1 == row2)
                {
                    retVal += new string(SameRow(ref keySquare, row1, col1, col2, e, size));
                }
                else if (col1 == col2)
                {
                    retVal += new string(SameColumn(ref keySquare, col1, row1, row2, e, size));
                }
                else
                {
                    retVal += new string(DifferentRowColumn(ref keySquare, row1, col1, row2, col2));
                }
            }

            retVal = AdjustOutput(input, retVal);

            return retVal;
        }

        public static string Encipher(string input, string key, int size)
        {
            return Cipher(input, key, true, size);
        }

        public static string Decipher(string input, string key, int size)
        {
            return Cipher(input, key, false, size);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateTextBox();
        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtUperlimitP.Text == "" || txtLowerlimitP.Text == "")
            {
                return;
            }
            BigInteger m = BigInteger.Parse(txtLowerlimitP.Text);
            BigInteger n = BigInteger.Parse(txtUperlimitP.Text);
            if (m >= n)
            {
                MessageBox.Show("Lower limit must lower than Upper limit");
                return;
            }
            BigInteger P = GenerateLargePrime(m, n);
            txtPrimeP.Text = P.ToString();
        }

        private void btnGenerateQ_Click(object sender, EventArgs e)
        {
            if(txtUperlimitQ.Text =="" || txtLowerlimitQ.Text == "")
            {
                return;
            }
            BigInteger m = BigInteger.Parse(txtLowerlimitQ.Text);
            BigInteger n = BigInteger.Parse(txtUperlimitQ.Text);
            if (m >= n)
            {
                MessageBox.Show("Lower limit must lower than Upper limit");
                return;
            }
            BigInteger Q = GenerateLargePrime(m, n);
            txtPrimeQ.Text = Q.ToString();
        }

        private void label47_Click(object sender, EventArgs e)
        {

        }
        private void txtPrimeQ_TextChanged(object sender, EventArgs e)
        {
            UpdateTextBox();
        }

        private void txtPrimeQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true; 
            }
        }

        private void txtPrimeP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void UpdateTextBox()
        {
            if (txtPrimeQ.Text == "" || txtPrimeP.Text == "")
            {
                txtN.Text = "";
                txtPhi.Text = "";
                txtD.Text = "";
                txtE.Text = "";
                return;
            }
            BigInteger Q = BigInteger.Parse(txtPrimeQ.Text);
            BigInteger P = BigInteger.Parse(txtPrimeP.Text);
            if (IsPrime(Q) && IsPrime(P) && Q != P)
            {
                txtN.Text = (Q*P).ToString();
                BigInteger phi = (Q - 1) * (P - 1);
                txtPhi.Text = phi.ToString();
                BigInteger E = SelectE(phi);
                if (E == 0)
                {
                    MessageBox.Show("Cannot find e");
                    txtD.Text = "";
                    txtE.Text = "";
                    return;
                }
                txtE.Text = E.ToString();
                txtD.Text = CalculateD(E, phi).ToString();
            }
            else
            {
                txtN.Text = "";
                txtPhi.Text = "";
                txtD.Text = "";
                txtE.Text = "";
            }
        }
        static BigInteger GenerateLargePrime(BigInteger m, BigInteger n)
        {
            Random random = new Random();
            BigInteger candidate;
            do
            {
                // Tạo một số ngẫu nhiên với bitLength bits
                //byte[] bytes = new byte[bitLength / 8];
                BigInteger range = n - m;
                byte[] bytes = range.ToByteArray();
                random.NextBytes(bytes);
                candidate = new BigInteger(bytes) % range + m;
                // Đảm bảo số nguyên tố là số lẻ
                candidate |= BigInteger.One;

                // Kiểm tra xem số có phải là số nguyên tố không
            } while (!IsPrime(candidate));

            return candidate;
        }

        static bool IsPrime(BigInteger number)
        {
            // Số lần kiểm tra Miller-Rabin
            int k = 10;

            // Kiểm tra số nguyên tố bằng thuật toán Miller-Rabin
            if (number < 2)
                return false;

            if (number == 2 || number == 3)
                return true;

            if (number % 2 == 0)
                return false;

            BigInteger d = number - 1;
            int s = 0;
            while (d % 2 == 0)
            {
                d /= 2;
                s++;
            }

            for (int i = 0; i < k; i++)
            {
                BigInteger a = RandomBigInteger(2, number - 2);
                BigInteger x = BigInteger.ModPow(a, d, number);

                if (x == 1 || x == number - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, number);
                    if (x == 1)
                        return false;
                    if (x == number - 1)
                        break;
                }

                if (x != number - 1)
                    return false;
            }

            return true;
        }

        static BigInteger RandomBigInteger(BigInteger min, BigInteger max)
        {
            Random random = new Random();
            byte[] bytes = new byte[max.ToByteArray().LongLength];
            BigInteger candidate;

            do
            {
                random.NextBytes(bytes);
                candidate = new BigInteger(bytes);
            } while (candidate < min || candidate >= max);

            return candidate;
        }
        static BigInteger SelectE(BigInteger phi)
        {
            // Chọn một số nguyên tố e sao cho 1 < e < phi và không có ước số chung với phi
            BigInteger e = 0;
            BigInteger temp;
            Stopwatch sw = new Stopwatch();
            while (sw.Elapsed.TotalSeconds < 5)
            {
                temp = RandomBigInteger(2, phi - 1);
                if (BigInteger.GreatestCommonDivisor(temp, phi) == 1)
                {
                    e = temp;
                    break;
                }
                
            }
            sw.Stop();
            return e;
        }

        static BigInteger CalculateD(BigInteger e, BigInteger phi)
        {
            // Tính d sao cho (d * e) % phi = 1

            // Sử dụng thuật toán mở rộng Euclid để tìm modular multiplicative inverse
            // của e modulo phi, tức là tìm d sao cho (e * d) % phi = 1.
            BigInteger d = ModInverse(e, phi);

            // Đảm bảo d là một giá trị dương
            d = (d % phi + phi) % phi;

            return d;
        }

        static BigInteger ModInverse(BigInteger a, BigInteger b)
        {
            // Trả về x sao cho (a * x) % b = 1

            // Nếu b là 0, thì x là 1 và y là 0, và a là ước số chung lớn nhất của a và b.
            if (b == 0)
                return 1;

            BigInteger x1, y1;
            BigInteger gcd = ExtendedEuclideanAlgorithm(b, a % b, out x1, out y1);

            // Sử dụng kết quả trả về từ lời gọi đệ quy để tính x và y
            BigInteger x = y1;
            BigInteger y = x1 - a / b * y1;

            return x;
        }

        static BigInteger ExtendedEuclideanAlgorithm(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
        {
            // Trả về x và y sao cho (a * x) + (b * y) = gcd(a, b)

            // Nếu b là 0, thì x là 1 và y là 0, và a là ước số chung lớn nhất của a và b.
            if (b == 0)
            {
                x = 1;
                y = 0;
                return a;
            }

            // Gọi đệ quy để tính x và y từ lời gọi đệ quy
            BigInteger x1, y1;
            BigInteger gcd = ExtendedEuclideanAlgorithm(b, a % b, out x1, out y1);

            // Sử dụng kết quả trả về từ lời gọi đệ quy để tính x và y
            x = y1;
            y = x1 - a / b * y1;

            return gcd;
        }
        static List<BigInteger> EncryptRSA(string message, BigInteger e, BigInteger n)
        {
            List<BigInteger> encryptedBlocks = new List<BigInteger>();

            foreach (char c in message)
            {
                // Chuyển mỗi kí tự thành mã ASCII và mã hóa
                BigInteger encryptedChar = BigInteger.ModPow((int)c, e, n);
                encryptedBlocks.Add(encryptedChar);
            }

            return encryptedBlocks;
        }

        static string DecryptRSA(List<BigInteger> encryptedBlocks, BigInteger d, BigInteger n)
        {
            StringBuilder decryptedMessage = new StringBuilder();

            foreach (BigInteger encryptedChar in encryptedBlocks)
            {
                // Giải mã từng mã ASCII và chuyển về kí tự
                int decryptedValue = (int)BigInteger.ModPow(encryptedChar, d, n);
                char decryptedChar = (char)decryptedValue;
                decryptedMessage.Append(decryptedChar);
            }

            return decryptedMessage.ToString();
        }

        private void btnGenerateE_Click(object sender, EventArgs e)
        {   
            if(txtPrimeP.Text == "" && txtPrimeQ.Text == "")
            {
                return;
            }
            BigInteger Q = BigInteger.Parse(txtPrimeQ.Text);
            BigInteger P = BigInteger.Parse(txtPrimeP.Text);
            if(Q == P )
            {
                MessageBox.Show("Q và P phải khác nhau");
                return;
            }
            BigInteger E = SelectE((Q-1)*(P-1));
            if (E == 0)
            {
                MessageBox.Show("Cannot find e");
            }
            else txtE.Text = E.ToString();
        }

        private void btnEdefault_Click(object sender, EventArgs e)
        {
            txtE.Text = "65537";
        }

        private void txtLowerlimitQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtUperlimitQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtLowerlimitP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtUperlimitP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnFileInputRSA_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Kiểm tra dung lượng của tệp
                FileInfo fileInfo = new FileInfo(filePath);
                long fileSizeInBytes = fileInfo.Length;
                double fileSizeInMb = (double)fileSizeInBytes / (1024 * 1024);

                if (fileSizeInMb <= 10)
                {
                    // Dung lượng tệp nhỏ hơn hoặc bằng 10MB, tiếp tục đọc nội dung
                    string fileContent = File.ReadAllText(filePath);
                    richtbInputRSA.Text = fileContent;
                }
                else
                {
                    // Dung lượng tệp lớn hơn 10MB, thông báo người dùng
                    MessageBox.Show("File size exceeds 10MB. Please choose a smaller file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnDecryptRSA_Click(object sender, EventArgs e)
        {
            if (txtD.Text == "")
            {
                MessageBox.Show("Lỗi, hãy xem lại các thông số");
                return;
            }
            string encryptmessage = richtbInputRSA.Text;
            string pattern = @"^[0-9 ]*$";
            bool isMatch = Regex.IsMatch(encryptmessage, pattern);
            if (!isMatch)
            {
                MessageBox.Show("Encryptmessage chỉ có thể là số và dấu cách");
                return;
            }
            BigInteger D = BigInteger.Parse(txtD.Text);
            BigInteger N = BigInteger.Parse(txtN.Text);
            richtbOutputRSA.Text = DecryptRSA(ConvertToBigIntegerList(encryptmessage), D, N);
        }
        static List<BigInteger> ConvertToBigIntegerList(string input)
        {
            List<BigInteger> result = new List<BigInteger>();

            // Tách chuỗi theo dấu phẩy và loại bỏ khoảng trắng
            string[] numberStrings = input.Split(' ');

            foreach (string numberString in numberStrings)
            {
                // Chuyển mỗi chuỗi thành số BigInteger và thêm vào danh sách
                if (BigInteger.TryParse(numberString.Trim(), out BigInteger number))
                {
                    result.Add(number);
                }
                else
                {
                    // Xử lý trường hợp không chuyển đổi được nếu cần thiết
                    Console.WriteLine($"Không thể chuyển đổi chuỗi: {numberString}");
                }
            }

            return result;
        }
            private void btnEncryptRSA_Click(object sender, EventArgs e)
        {
            if (txtD.Text == "")
            {
                MessageBox.Show("Lỗi, hãy xem lại các thông số");
                return;
            }
            string message = richtbInputRSA.Text;
            BigInteger E = BigInteger.Parse(txtE.Text);
            BigInteger N = BigInteger.Parse(txtN.Text);
            richtbOutputRSA.Text = string.Join(" ", EncryptRSA(message, E, N));
        }

        private void btnFileexportRSA_Click(object sender, EventArgs e)
        {
            if (richtbOutputRSA.Text == "")
            {
                MessageBox.Show("Output is empty.");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Lưu nội dung của RichTextBox vào tệp văn bản
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(richtbOutputRSA.Text);
                }

                MessageBox.Show("File saved successfully!");
            }
        }

        private void txtD_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtD.Text))
            {
                // Nếu rỗng, vô hiệu hóa nút
                btnEncryptRSA.Enabled = false;
                btnDecryptRSA.Enabled = false; 
            }
            else
            {
                // Nếu không rỗng, kích hoạt nút
                btnEncryptRSA.Enabled = true;
                btnDecryptRSA.Enabled = false;
            }
        }

        private void txtE_TextChanged(object sender, EventArgs e)
        {
            if(txtE.Text != "")
            {
                BigInteger E = BigInteger.Parse(txtE.Text);
                if(txtPhi.Text != "")
                {
                    BigInteger phi = BigInteger.Parse(txtPhi.Text);
                    if(BigInteger.GreatestCommonDivisor(E, phi) == 1)
                    {
                        BigInteger D = CalculateD(E, phi);
                        txtD.Text = D.ToString();
                    }
                    else
                    {
                        txtD.Text = "";
                    }
                 
                }
              
            }
            else
            {
                txtD.Text = "";
            }
        }
    }
}
