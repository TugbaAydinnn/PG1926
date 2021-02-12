class Okul():   #Okul adında bir sınıf tanımlaması yapıldı.
    calisanSayisi=25
    derslikSayisi=18
    ogrenciSayisi=850
    def __init__(self, okulRenk, tur, katSayisi):
        self.okulRenk = okulRenk
        self.tur = tur
        self.katSayisi = katSayisi

class Ogretmen():
   # brans= ['fizik','kimya','beden','dilBilgisi']
    #unvanı = 'ogretmen'
    def __init__(self, ad, brans, unvanı):
        self.ad = ad
        self.brans = brans
        self.unvanı = unvanı

class Ogrenci():
    sinif= ['lise1','lise2','lise3','lise4']
    unvanı = 'ogrenci'
class Mudur():
    brans= ['fizik','kimya','beden','dilBilgisi']
    unvanı = 'mudur'
class MudurYardimcisi():
    brans= ['fizik','kimya','beden','dilBilgisi']
    unvanı = 'mudurYardimcisi'
class Hizmetli():
    unvanı = 'hizmetli'
class memur():
    unvanı = 'memur'
class Kantinci():
    unvanı = 'kantinci'

ogrt_mehmet = Ogretmen("Mehmet", "fizik", "ogretmen")
print(ogrt_mehmet.brans)

okul1=Okul('beyaz','fenLisesi','2')
okul2=Okul('kirmizi','anadoluLisesi','2')
okul3=Okul('pembe','teknikLise','3')
okul3.calisanSayisi=30
okul3.derslikSayisi=20
okul1.ogrenciSayisi=500
print('okul3 Calisan Sayisi',okul3.calisanSayisi)
print('okul2 Calisan Sayisi'okul2.calisanSayisi)
print('okul1 Calisan Sayisi'okul1.calisanSayisi)
print('okul3 Derslik Sayisi',okul3.derslikSayisi)
print('okul1 Ogrenci Sayisi',okul1.ogrenciSayisi)