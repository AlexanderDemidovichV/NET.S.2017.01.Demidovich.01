# NET.S.2017.01.Demidovich.01

# Task1:

>Задачи
  1. Cоздать многофайловую сборку
  2. Назначить сборке строе имя и поместить в GAC
  
>Решение
  1. run Developer Command Prompt for VS as administrator
  2. Создание cat.netmodule: csc.exe /t:module cat.cs 
  3. Создание dog.netmodule: csc.exe /t:module dog.cs
  4. Cоздать файл keypair.snk, содержащий открытый и закрытый ключи в двоичном формате: sn.exe -k keypair.snk
  
  4.1 При необходимости после создания этого файла можно использовать SNexe, чтобы увидеть открытый ключ.
    Для этого нужно выполнить SN.exe дважды: sn.exe –p keypair.keys keypair.PublicKey; sn.exe –tp keypair.PublicKey 
  5. Получение многофайловой сборки с нестрогим именем: 
    csc.exe /t:library /addmodule:cat.netmodule /addmodule:dog.netmodule /out:animal.dll mouse.cs
    
  5.1 Получение многофайловой сборки со строгим именем: 
    csc.exe /t:library /addmodule:cat.netmodule /addmodule:dog.netmodule /keyfile:keypair.snk /out:animal.dll mouse.cs
    
  5.2 Помещение сборки со строгим именем в GAC:
    gacutil -i animal.dll
   
  
# Task2: 

>Задачи
  1. Реализовать метод сортировки слиянием для целочисленного массива.  Протестировать работу метода в консольном приложении.
