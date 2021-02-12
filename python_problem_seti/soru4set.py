i=0
liste=[]
while i<9:
  sayi=int(input("Lutfen bir sayi giriniz"))
  liste.append(sayi)
  i=i+1
print(liste)

if (max(liste)%2==1):
  print("Listemizdeki en büyük tek sayi",max(liste))
else:
  print("Listemizdeki en büyük tek sayi",max(liste)-1)

