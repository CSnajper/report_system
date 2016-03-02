using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zgloszenia
{
    class Encrypt
    {
        public static string[] dane = new String[20];
        // Szyfrowanie Pliku
        public static bool zaszyfrujPlik(string haslo, string ciag, string plik)
        {
            if (CryptFile(haslo, ciag, plik))
                return true;
            return false;
        }
        // Odszyfrowanie Pliku
        public static void odszyfrujPlik(string haslo, string plik)
        {
            DeCryptFile(haslo, plik);
        }
        // praca na strumieniach wejsciowym i wyjsciowym ....

        public static bool CryptFile(string haslo, string ciag, string plik)
        {
            byte[] ciag_byte = System.Text.Encoding.UTF8.GetBytes(ciag);
            using (MemoryStream wejscie = new MemoryStream(ciag_byte))
            {
                using (FileStream wyjscie = new FileStream(plik, FileMode.Create, FileAccess.Write))
                {
                    if(CryptStream(haslo, wejscie, wyjscie))
                        return true;
                    return false;
                }
            }
        }

        public static bool CryptStream(string haslo, Stream wejscie, Stream wyjscie)
        {
            bool wynik = false;
            // Używamy operatora AES do szyfrowania
            AesCryptoServiceProvider aes_provider = new AesCryptoServiceProvider();

            // Wyszukiwanie długości klucza
            int bitow_klucza = 0;
            for (int i = 1024; i > 1; i--)
            {
                if (aes_provider.ValidKeySize(i))
                {
                    bitow_klucza = i;
                    break;
                }
            }
            Debug.Assert(bitow_klucza > 0);
            //MessageBox.Show("Duugość Klucza: " + bitow_klucza);

            // Pobieramy rozmiar bloku dla operatora AES
            int rozmiar_bloku = aes_provider.BlockSize;

            // Generowanie Klucza
            byte[] klucz = null;
            byte[] wektor = null;
            byte[] kod = { 0x0, 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0xF1, 0xF0, 0xEE, 0x21, 0x22, 0x45 };
            TwKlucz_wektor(haslo, kod, bitow_klucza, rozmiar_bloku, out klucz, out wektor);

            // Szyfrowanie czy Odszyfrowywanie
            ICryptoTransform SzyfroTransformacja;
            SzyfroTransformacja = aes_provider.CreateEncryptor(klucz, wektor);

            // gdy używamy niewłaściwego hasła zamykamy strumień
            try
            {
                using (CryptoStream strumien_crypto = new CryptoStream(wyjscie, SzyfroTransformacja, CryptoStreamMode.Write))
                {
                    // kodowanie lub odkodowywanie pliku
                    //const int rozmiar_bloku2 = 1024;
                    byte[] bufor = new byte[rozmiar_bloku];
                    int odczytane_bity;
                    while (true)
                    {
                        // Czytamy.
                        odczytane_bity = wejscie.Read(bufor, 0, rozmiar_bloku);
                        if (odczytane_bity == 0) break;

                        // zapisujemy odczytane bity do strumienia.
                        strumien_crypto.Write(bufor, 0, odczytane_bity);
                    }
                }
                wynik = true;
            }
            catch
            {
                wynik = false;
            }

            SzyfroTransformacja.Dispose();

            return wynik;
        }
        public static void DeCryptFile(string haslo, string plik)
        {
            using (FileStream wejscie = new FileStream(plik, FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream wyjscie = new MemoryStream())
                {
                    byte[] wyjscie2;
                    DeCryptStream(haslo, wejscie, wyjscie);
                    wyjscie2 = wyjscie.ToArray();
                    ASCIIEncoding asciii = new ASCIIEncoding();
                    byte[] enter = {13};
                    string enter_string = asciii.GetString(enter);
                    char char_enter = enter_string[0];
                    ASCIIEncoding ascii = new ASCIIEncoding();
                    string napis = ascii.GetString(wyjscie2);
                    dane = napis.Split(char_enter);
                    DBConnect.SetDataBase(dane[0], dane[1], dane[2], dane[3]);
                    Kontakt.UzupelnijDaneKontaktowe(dane[4], dane[5], dane[6], dane[7]);
                }
            }
        }

        public static void DeCryptStream(string haslo, Stream wejscie, MemoryStream wyjscie)
        {
            // Używamy operatora AES do szyfrowania
            AesCryptoServiceProvider aes_provider = new AesCryptoServiceProvider();

            // Wyszukiwanie długości klucza
            int bitow_klucza = 0;
            for (int i = 1024; i > 1; i--)
            {
                if (aes_provider.ValidKeySize(i))
                {
                    bitow_klucza = i;
                    break;
                }
            }
            Debug.Assert(bitow_klucza > 0);
            //MessageBox.Show("Duugość Klucza: " + bitow_klucza);

            // Pobieramy rozmiar bloku dla operatora AES
            int rozmiar_bloku = aes_provider.BlockSize;

            // Generowanie Klucza
            byte[] klucz = null;
            byte[] wektor = null;
            byte[] kod = { 0x0, 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0xF1, 0xF0, 0xEE, 0x21, 0x22, 0x45 };
            TwKlucz_wektor(haslo, kod, bitow_klucza, rozmiar_bloku, out klucz, out wektor);

            // Szyfrowanie czy Odszyfrowywanie
            ICryptoTransform SzyfroTransformacja;
            SzyfroTransformacja = aes_provider.CreateDecryptor(klucz, wektor);

            // gdy używamy niewłaściwego hasła zamykamy strumień
            try
            {
                using (CryptoStream strumien_crypto = new CryptoStream(wyjscie, SzyfroTransformacja, CryptoStreamMode.Write))
                {
                    // kodowanie lub odkodowywanie pliku
                    //const int rozmiar_bloku2 = 1024;
                    byte[] bufor = new byte[rozmiar_bloku];
                    int odczytane_bity;
                    while (true)
                    {
                        // Czytamy.
                        odczytane_bity = wejscie.Read(bufor, 0, rozmiar_bloku);
                        if (odczytane_bity == 0) break;

                        // zapisujemy odczytane bity do strumienia.
                        strumien_crypto.Write(bufor, 0, odczytane_bity);
                    }
                }
            }
            catch
            {
            }

            SzyfroTransformacja.Dispose();
        }
        // Używanie hasła do generowania klucza
        private static void TwKlucz_wektor(string haslo, byte[] kod, int bitow_klucza, int rozmiar_bloku, out byte[] klucz, out byte[] wektor)
        {
            Rfc2898DeriveBytes zamotaneBajty = new Rfc2898DeriveBytes(haslo, kod, 1500);
 
            klucz = zamotaneBajty.GetBytes(bitow_klucza / 8);
            wektor = zamotaneBajty.GetBytes(rozmiar_bloku / 8);
        }
    }
}
