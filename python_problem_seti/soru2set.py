def kontrol(str,sayi):
  count = 0
  uzanti=sayi
  
 

  for ch in str:
    if ch == '@' and uzanti==2:
      for ch1 in str:
        if ch1=='.':
          count = count + 1


    if ch == '@' and uzanti==1:
          count = count + 1

    if ch == '@' and uzanti==3:
      for ch1 in str:
        if ch1=='.':
          count = count + 1
        for ch2 in str:
          if ch2==',':
            count = count + 1
  webKural = "?*/()!^+-%&{[]}"
  for karakter in str:
    if karakter in webKural:
        print("web sağlayıcı hatası..")
        count=count+3
 
  if count == 1 or count == 2:
    return True
  elif count==3:
    return False
  else:
    return False

uzanti=input('Mailin uzantı uzunluğunu giriniz')
for i in  range(0,int(uzanti)):
  if (i<= int(uzanti)):
    i=i+1
    

mail=input('Mail : ')
if (kontrol(mail,i)==True):
  print('Mail Adresiniz Doğrudur')
else:
  print('Mail Adresiniz Yanlıştır')
