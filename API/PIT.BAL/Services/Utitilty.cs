using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PIT.BAL.Services
{
    public class Utitilty
    {
        private const string LineBreaker = "\r\n\r=========================================================================================================================== \r\n\r";

        /*
                const string password = "SampleP455w0rd";
                byte[] salt = GenerateSalt();
 
                Console.WriteLine("Sample Password : " + password);
                Console.WriteLine("Generated Salt : " + Convert.ToBase64String(salt));
                Console.WriteLine();
 
                var hashedPassword = HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt);
 
                Console.WriteLine("Salted Hash Password : " + Convert.ToBase64String(hashedPassword));
                Console.WriteLine();
   
                Console.ReadLine();

    */

        public static byte[] GenerateSalt()
        {
            const int saltLength = 32;

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[saltLength];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }
        private static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }
        public static byte[] HashPasswordWithSalt(byte[] toBeHashed, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combinedHash = Combine(toBeHashed, salt);

                return sha256.ComputeHash(combinedHash);
            }
        }

        private static object LogLock = new object();
        public static void Log(string Contents)
        {
            string Path = AppDomain.CurrentDomain.BaseDirectory + "Log.txt";

            lock (LogLock)
            {
                System.IO.File.AppendAllText(Path, Contents);
            }

        }

        public  string GetVerificationCode(long CompanyId)
        {
            string VerificationCode = "";
            try
            {
                string RandomNumbmer = DateTime.UtcNow.Ticks.ToString().Substring(2) + DateTime.Now.Ticks.ToString().Substring(2);
                VerificationCode = "G" + CompanyId + RandomNumbmer;
                VerificationCode=VerificationCode.Substring(0,6);
            }
            catch (Exception ex)
            {
                VerificationCode = "";
            }
            return VerificationCode;
        }

        private static object ErrorLock = new object();

        public static void Error(Exception ex)
        {
            string Path = AppDomain.CurrentDomain.BaseDirectory + "Error" + DateTime.Now.ToString("yyyyMMddhhmm") + ".txt";

            lock (ErrorLock)
            {
                string messageToWrite = string.Format("{0}\r\n\r{1}\r\n\r\n{2}\r\n\r{3}\r\n\r{4}\r\n{5}\r\n{6}\r\n\r", LineBreaker, "ERROR OCCURRED", "DATE & TIME: " + DateTime.Now.ToString("dd-MM-yyyy") + " " + DateTime.Now.ToLongTimeString(), "SOURCE: " + ex.Source, "METHOD: " + ex.TargetSite, "ERROR: " + ex.Message, "STACKTRACE: " + ex.StackTrace);

                System.IO.File.AppendAllText(Path, messageToWrite);
            }

        }
    }
}
