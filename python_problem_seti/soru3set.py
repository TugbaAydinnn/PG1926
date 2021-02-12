i=0
a=0
liste=[]
while i<7:
  sayi=int(input("Lutfen bir sayi giriniz"))
  liste.append(sayi)
  i=i+1
print(liste)

while a<7:
  if liste[a]==0:
    depo=liste[a]
    del(liste[a])
    liste.insert(0,depo)

  
  a=a+1
print(liste)
