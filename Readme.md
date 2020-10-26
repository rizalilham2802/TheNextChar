# The Next Car
sebuah aplikasi dashboard electric car yang menggunakan konsep MVC(Model View Controller) 

fungsi dari MVC sebagai berikut

- Model berfungsi untuk mengatur data, fungsi dan aturan dari aplikas.
- View berfungsi untuk mengatur tampilan atau output yang di tampilkan di layar tidak hanya berupa data namun juga termasuk komponen lain, seperti gambar, video, diagram, dan sebagainnya.
- Controller merupakan program yang mengatur menerima input dan menjelaskann beberapa perintah untuk menjalankan di model


# Scope & Functionalities
- User dapat menyalakan dan mematikan mobil dengan tombol on/off pada aplikasi
- user dapat mendapatkan informasi jika pintu belum di tutup maupun sudah di tutup
- User dapat mendapatkan informasi jika secuuriy lock belum di kunci
- User dapat lebih aman menggunakan mobil karena apabila pintu mobil belum di tutup mobil tidak akan menyala 


# How Doest It Work ?


Diawali dari method MainWindow pada class MainWindow.xaml.cs, kita memanggil class class untuk di eksekusi.
``` java
public MainWindow()
        {
            InitializeComponent();
            AccubatteryController accubatteryController = new AccubatteryController(this);
            DoorController doorController = new DoorController(this);

            nextCar = new Car(doorController, accubatteryController, this);
        }
```
cara kerja pada program di bawah, mobil akan menyala apabila pintu sudah tertutup dan harus mengunci
 mobil lalu tekan tombol started mobil akan menyala, dan apabila salah satu mobil belum tertutup pintunya 
atau belum terkuci maka akan ada informasi bahwa pintu belum tertutup atau belum terkuci dan mobil tidak akan bisa menyala.
``` java
 public void startEngine()
        {
            if (!doorIsClosed())
            {
                this.callback.onCarEngineStateChanged("STOPED", "Close the door");
                return;
            }
            if (!doorIsLocked())
            {
                this.callback.onCarEngineStateChanged("STOPED", "Lock the door");
                return;
            }
            if (!poweIsReady())
            {
                this.callback.onCarEngineStateChanged("STOPED", "no power avaliable");
                return;
            }
            this.callback.onCarEngineStateChanged("STARTED", "Engine Started");
        }
```


Class diagram

![Class Diagram1](ClassDiagram1.jpg)

Kegunaan DoorController.cs

Digunakan mendefiniskan lebih rinci fungsi fungsi pada class door.cs

Kegunaan model door.cs

Digunakan untuk mendefinisikan seperangkat variabel dan method untuk object yang di deklarasikan
