using System;

public class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public void SetNama(string Nama)
    {
        this.nama = Nama;
    }

    public string GetNama()
    {
        return nama;
    }

    public void SetId(string Id)
    {
        this.id = Id;
    }

    public string GetId()
    {
        return id;
    }

    public void SetGajiPokok(double GajiPokok)
    {
        this.gajiPokok = GajiPokok;
    }

    public double GetGajiPokok()
    {
        return gajiPokok;
    }

    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

public class KaryawanTetap : Karyawan
{
    public override double HitungGaji()
    {
        return GetGajiPokok() + 500000;
    }
}

public class KaryawanKontrak : Karyawan
{
    public override double HitungGaji()
    {
        return GetGajiPokok() - 200000;
    }
}

public class KaryawanMagang : Karyawan
{
    public override double HitungGaji()
    {
        return GetGajiPokok();
    }
}

public class Program
{
    static void Main()
    {
        Console.WriteLine("Sistem Manajemen Karyawan");
        Console.WriteLine("1. Tetap");
        Console.WriteLine("2. Kontrak");
        Console.WriteLine("3. Magang");
        Console.Write("Pilih Jenis Karyawan (1/2/3):");
        string Pilihan = Console.ReadLine();

        Karyawan karyawan;

        if (Pilihan == "1")
        {
            karyawan = new KaryawanTetap();
        }
        else if (Pilihan == "2")
        {
            karyawan = new KaryawanKontrak();
        }
        else if (Pilihan == "3")
        {
            karyawan = new KaryawanMagang();
        }
        else
        {
            Console.WriteLine("Pilihan tidak Sesuai!");
            return;
        }

        Console.Write("Masukkan Nama: ");
        string Nama = Console.ReadLine();

        Console.Write("Masukkan ID: ");
        string Id = Console.ReadLine();

        Console.Write("Masukkan Gaji Pokok: ");
        string InputGaji = Console.ReadLine();
        double GajiPokok = 0;
        bool CekAngka = true;
        foreach (char LenAngka in InputGaji)
        {
            if (LenAngka >= '0' && LenAngka <= '9')
            {
                GajiPokok = GajiPokok * 10 + (LenAngka - '0');
            }
            else
            {
                CekAngka = false;
                break;
            }
        }

        if (!CekAngka)
        {
            Console.WriteLine("Input gaji harus angka!");
            return;
        }

        karyawan.SetNama(Nama);
        karyawan.SetId(Id);
        karyawan.SetGajiPokok(GajiPokok);

        Console.WriteLine("\nInformasi Karyawan");
        Console.WriteLine("Nama      : " + karyawan.GetNama());
        Console.WriteLine("ID        : " + karyawan.GetId());
        Console.WriteLine("Jenis     : " + (Pilihan == "1" ? "Tetap" : Pilihan == "2" ? "Kontrak" : "Magang"));
        Console.WriteLine("Gaji Pokok: " + karyawan.GetGajiPokok());
        Console.WriteLine("Gaji Akhir: " + karyawan.HitungGaji());
    }
}