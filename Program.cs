using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace csharp_oop {
    class Program {
        static void Main (string[] args) {
            // Logs test = new Logs();
            // test.write (0, "System hung. Contact system administrator immediately!");
            // test.write (1, "Achtung! Achtung!");
            // test.write (2, "Medic!! We've got critical damages.");
            // test.write (3, "We can't divide any numbers by zero.");
            // test.write (4, "Insufficient funds.");
            // test.write (5, "Someone loves your status.");
            // test.write (6, "This is an information about something.");
            // test.write (7, "This is debug message.");
            // test.write (0, "System hung. Contact system administrator immediately!");
            // test.write (1, "Achtung! Achtung!");
            // test.write (2, "Medic!! We've got critical damages.");
            // test.write (3, "We can't divide any numbers by zero.");
            // test.write (4, "Insufficient funds.");
            // test.write (5, "Someone loves your status.");
            // test.write (6, "This is an information about something.");
            // test.write (7, "This is debug message.");
            // test.filterMessage("We");
            // test.filterLevel("ALERT: ");
            // test.filterDate("2019-12-23");
            Cart cart = new Cart ();
            cart.addItem (new Item { item_id = 1, price = 30000, quantity = 3 })
                .addItem (new Item { item_id = 2, price = 10000 })
                .addItem (new Item { item_id = 3, price = 5000, quantity = 2 })
                .removeItem (new Item { item_id = 2 })
                .addItem (new Item { item_id = 4, price = 400, quantity = 6 })
                .addDiscount ("50%");
            cart.totalItems ();
            cart.totalQuantity ();
            cart.totalPrice ();
            cart.showAll ();
            cart.checkOut ();
        }
    }
}

//#1 Hash
class Hash {

    public static string md5 (string input) {

        MD5 md5Hash = MD5.Create ();
        byte[] data = md5Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

        StringBuilder sBuilder = new StringBuilder ();

        for (int i = 0; i < data.Length; i++) {
            sBuilder.Append (data[i].ToString ("x2"));
        }

        string sBuilderString = sBuilder.ToString ();

        Console.WriteLine (sBuilderString);
        return sBuilderString;

        // MD5 md5Hash = MD5.Create ();
        // byte[] data = md5Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

        // for (int i = 0; i < data.Length; i++) {
        //     Console.Write ($"{data[i]:x2}");
        // }
        // Console.WriteLine ();

    }

    public static string sha1 (string input) {

        SHA1 sha1Hash = SHA1.Create ();
        byte[] data = sha1Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

        StringBuilder sBuilder = new StringBuilder ();

        for (int i = 0; i < data.Length; i++) {
            sBuilder.Append (data[i].ToString ("x2"));
        }

        string sBuilderString = sBuilder.ToString ();

        Console.WriteLine (sBuilderString);
        return sBuilderString;

        // SHA1 sha1Hash = SHA1.Create ();
        // byte[] data = sha1Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

        // for (int i = 0; i < data.Length; i++) {
        //     Console.Write ($"{data[i]:x2}");
        // }
        // Console.WriteLine ();

    }

    public static string sha256 (string input) {

        SHA256 sha256Hash = SHA256.Create ();
        byte[] data = sha256Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

        StringBuilder sBuilder = new StringBuilder ();

        for (int i = 0; i < data.Length; i++) {
            sBuilder.Append (data[i].ToString ("x2"));
        }

        string sBuilderString = sBuilder.ToString ();

        Console.WriteLine (sBuilderString);
        return sBuilderString;

        // SHA256 sha256Hash = SHA256.Create ();
        // byte[] data = sha256Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

        // for (int i = 0; i < data.Length; i++) {
        //     Console.Write ($"{data[i]:x2}");
        // }
        // Console.WriteLine ();
    }

    public static string sha512 (string input) {

        SHA512 sha512Hash = SHA512.Create ();
        byte[] data = sha512Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

        StringBuilder sBuilder = new StringBuilder ();

        for (int i = 0; i < data.Length; i++) {
            sBuilder.Append (data[i].ToString ("x2"));
        }

        string sBuilderString = sBuilder.ToString ();

        Console.WriteLine (sBuilderString);
        return sBuilderString;

        // SHA512 sha512Hash = SHA512.Create ();
        // byte[] data = sha512Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

        // for (int i = 0; i < data.Length; i++) {
        //     Console.Write ($"{data[i]:x2}");
        // }
        // Console.WriteLine ();

    }

}

//#2 Cipher
class EncryptionHelper {
    public static string Encrypt (string clearText, string EncryptionKey) {
        byte[] clearBytes = Encoding.Unicode.GetBytes (clearText);
        using (Aes encryptor = Aes.Create ()) {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes (EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes (32);
            encryptor.IV = pdb.GetBytes (16);
            using (MemoryStream ms = new MemoryStream ()) {
                using (CryptoStream cs = new CryptoStream (ms, encryptor.CreateEncryptor (), CryptoStreamMode.Write)) {
                    cs.Write (clearBytes, 0, clearBytes.Length);
                    cs.Close ();
                }
                clearText = Convert.ToBase64String (ms.ToArray ());
            }
        }
        Console.WriteLine ("Anyone without password can't read this message");
        return clearText;
    }
    public static string Decrypt (string cipherText, string EncryptionKey) {
        try {
            cipherText = cipherText.Replace (" ", "+");
            byte[] cipherBytes = Convert.FromBase64String (cipherText);
            using (Aes encryptor = Aes.Create ()) {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes (EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes (32);
                encryptor.IV = pdb.GetBytes (16);
                using (MemoryStream ms = new MemoryStream ()) {
                    using (CryptoStream cs = new CryptoStream (ms, encryptor.CreateDecryptor (), CryptoStreamMode.Write)) {
                        cs.Write (cipherBytes, 0, cipherBytes.Length);
                        cs.Close ();
                    }
                    cipherText = Encoding.Unicode.GetString (ms.ToArray ());
                }
            }
            Console.WriteLine (cipherText);
            return cipherText;
        } catch (Exception e) {
            string message = "Wrong Password";
            return message;
        }
    }
}

// [2018-04-03T12:10:36.100Z] INFO: This is an information about something.
// [2018-04-03T13:21:36.201Z] ERROR: We can't divide any numbers by zero.
// [2018-04-03T16:45:36.210Z] NOTICE: Someone loves your status.
// [2018-04-03T23:40:36.215Z] WARNING: Insufficient funds.
// [2018-04-03T23:56:36.215Z] DEBUG: This is debug message.
// [2018-04-04T04:54:36.102Z] ALERT: Achtung! Achtung!
// [2018-04-04T05:01:36.103Z] CRITICAL: Medic!! We've got critical damages.
// [2018-04-04T05:05:36.104Z] EMERGENCY: System hung. Contact system administrator immediately!

//#3 Log
class Log {
    public DateTime dt { get; set; }
    public string level { get; set; }
    public string message { get; set; }
    public string logLine { get; set; }
}

class Logs {

    public List<Log> logApp = new List<Log> ();
    public string m_exePath = string.Empty;

    public List<Log> write (int levelNum, string message) {
        Log test = new Log ();
        switch (levelNum) {
            case 0:
                test.level = "EMERGENCY: ";
                break;
            case 1:
                test.level = "ALERT: ";
                break;
            case 2:
                test.level = "CRITICAL: ";
                break;
            case 3:
                test.level = "ERROR: ";
                break;
            case 4:
                test.level = "WARNING: ";
                break;
            case 5:
                test.level = "NOTICE: ";
                break;
            case 6:
                test.level = "INFO: ";
                break;
            case 7:
                test.level = "DEBUG: ";
                break;
        }
        test.dt = DateTime.Now;
        test.message = message;
        test.logLine = ($"[{test.dt.ToString("s",DateTimeFormatInfo.InvariantInfo)}] {test.level} {test.message}");
        m_exePath = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location);
        try {
            using (StreamWriter w = File.AppendText (m_exePath + "\\" + "app.log")) {
                log (test.logLine, w);
            }
            logApp.Add (test);
        } catch (Exception ex) { }

        return logApp;
    }

    public static void log (string logMessage, TextWriter txtWriter) {
        try {
            txtWriter.WriteLine (logMessage);
        } catch (Exception ex) { }
    }

    public dynamic filterMessage (string keyword) {
        List<string> w = new List<string> ();
        foreach (var line in File.ReadLines (@"D:\csharp-oop\bin\Debug\netcoreapp3.1\app.log")) {
            if (line.Contains (keyword)) {
                w.Add (line);
                Console.WriteLine (line);
            }
        }
        return w;
    }

    public dynamic filterLevel (string lvl) {

        List<string> w = new List<string> ();
        foreach (var line in logApp) {
            if (line.level == lvl) {
                w.Add (line.logLine);
            }
        }
        foreach (var item in w) {
            Console.WriteLine (item);
        }
        return w;
    }

    public dynamic filterDate (string date) {

        DateTime result;
        DateTime.TryParse (date, out result);
        List<string> w = new List<string> ();
        foreach (var line in logApp) {
            if (line.dt.Date == result) {
                w.Add (line.logLine);
            }
        }
        foreach (var item in w) {
            Console.WriteLine (item);
        }
        return w;
    }

}

public class Item {
    public int item_id { get; set; }
    public long price { get; set; }
    public int quantity { get; set; }

    public Item () {
        quantity = 1;
    }
}

//#5 Cart - Method Chaining
public class Cart {
    public List<Item> buyList = new List<Item> ();
    string discount = string.Empty;

    public Cart addItem (Item barang) {
        buyList.Add (barang);
        return this;
    }

    public Cart removeItem (Item barang) {
        buyList.RemoveAll (e => e.item_id == barang.item_id);
        return this;
    }

    public string addDiscount (string diskon) {
        discount = diskon;
        return discount;
    }

    public int totalItems () {
        int total = buyList.Count;
        Console.WriteLine (total);
        return total;
    }

    public int totalQuantity () {
        int total = 0;
        foreach (var item in buyList) {
            total = total + item.quantity;
        }
        Console.WriteLine (total);
        return total;
    }

    public long totalPrice () {
        long total = 0;
        long finalTotal = 0;
        foreach (var item in buyList) {
            total = total + item.price * item.quantity;
        }
        long num = long.Parse (discount.Replace ("%", ""));
        finalTotal = total * num / 100;
        Console.WriteLine (finalTotal);
        return finalTotal;
    }

    public void showAll () {
        foreach (var item in buyList) {
            Console.WriteLine ($"{item.item_id}, {item.price}, {item.quantity}");
        }
    }

    public void checkOut () {
        string m_exePath = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location);
        try {
            using (StreamWriter w = File.AppendText (m_exePath + "\\" + "cart.txt")) {
                foreach (var item in buyList) {
                    log ($"{item.item_id}, {item.price}, {item.quantity}", w);
                }
            }
        } catch (Exception ex) { }
    }

    public static void log (string logMessage, TextWriter txtWriter) {
        try {
            txtWriter.WriteLine (logMessage);
        } catch (Exception ex) { }
    }
}

//#4 Auth
class Auth
{
    
}