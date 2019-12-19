using System;
using System.Security.Cryptography;
using System.Text;

namespace csharp_oop {
    class Program {
        static void Main (string[] args) {
            Hash.sha512 ("secret");
        }
    }

    class Hash {

        public static void md5 (string input) {

            // MD5 md5Hash = MD5.Create ();
            // byte[] data = md5Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

            // StringBuilder sBuilder = new StringBuilder ();

            // for (int i = 0; i < data.Length; i++) {
            //     sBuilder.Append (data[i].ToString ("x2"));
            // }

            // string sBuilderString = sBuilder.ToString ();

            // Console.WriteLine (sBuilderString);
            // return sBuilderString;

            MD5 md5Hash = MD5.Create ();
            byte[] data = md5Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

            for (int i = 0; i < data.Length; i++) {
                Console.Write ($"{data[i]:x2}");
            }
            Console.WriteLine ();

        }

        public static void sha1 (string input) {

            // using (SHA1Managed sha1 = new SHA1Managed ()) {
            //     var hash = sha1.ComputeHash (Encoding.UTF8.GetBytes (input));
            //     var sb = new StringBuilder (hash.Length * 2);

            //     foreach (byte b in hash) {
            //         sb.Append (b.ToString ("x2"));
            //     }

            //     string sbString = sb.ToString ();

            //     Console.WriteLine (sbString);
            //     return sbString;
            // }

            SHA1 sha1Hash = SHA1.Create ();
            byte[] data = sha1Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

            for (int i = 0; i < data.Length; i++) {
                Console.Write ($"{data[i]:x2}");
            }
            Console.WriteLine ();

        }

        public static void sha256 (string input) {

            SHA256 sha256Hash = SHA256.Create ();
            byte[] data = sha256Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

            for (int i = 0; i < data.Length; i++) {
                Console.Write ($"{data[i]:x2}");
            }
            Console.WriteLine ();
        }

        public static void sha512 (string input) {

            // using (SHA512Managed sha512 = new SHA512Managed ()) {
            //     var hash = sha512.ComputeHash (Encoding.UTF8.GetBytes (input));
            //     var sb = new StringBuilder (hash.Length * 2);

            //     foreach (byte b in hash) {
            //         sb.Append (b.ToString ("x2"));
            //     }

            //     string sbString = sb.ToString ();

            //     Console.WriteLine (sbString);
            //     return sbString;
            // }

            SHA512 sha512Hash = SHA512.Create ();
            byte[] data = sha512Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

            for (int i = 0; i < data.Length; i++) {
                Console.Write ($"{data[i]:x2}");
            }
            Console.WriteLine ();

        }

    }

    class Cipher {

        public static string encrypt (string input, string password) {
            
        }

    }

    // var message = Cipher.encrypt('Ini tulisan rahasia', 'p4$$w0rd')

    // Console.Writeline(message) // Anyone without password can't read this message

    // var decryptedMessage = Cipher.decrypt(message, 'p4$$w0rd')

    // Console.Writeline(decryptedMessage) // Ini tulisan rahasia
}