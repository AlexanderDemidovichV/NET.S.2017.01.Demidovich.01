# NET.S.2017.01.Demidovich.01
Task1:

Задачи
  1. Cоздать многофайловую сборку
  2. Назначить сборке строе имя и поместить в GAC
  
Решение
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
   
Отложенное подписание:

1. Во время разработки сборки следует получить файл, содержащий лишь от-
крытый ключ компании, и добавить в строку компиляции сборки параметры
/keyfile и /delaysign:
 csc /keyfile:MyCompany.PublicKey /delaysign MyAssembly.cs
 
2. После построения сборки надо выполнить показанную далее команду, чтобы
получить возможность тестирования этой сборки, установки ее в каталог GAC
и компоновки других сборок, ссылающихся на нее. Эту команду достаточно
исполнить лишь раз, не нужно делать это при каждой компоновке сборки.
 SN.exe -Vr MyAssembly.dll
 
3. Подготовившись к упаковке и развертыванию сборки, надо получить закрытый
ключ компании и выполнить приведенную далее команду. При желании можно
установить новую версию в GAC, но не пытайтесь это сделать до выполнения
шага 4. SN.exe -R MyAssembly.dll MyCompany.PrivateKey

4. Для тестирования сборки в реальных условиях снова включите проверку сле-
дующей командой:
 SN -Vu MyAssembly.dll
  
Task2: 

Задачи
  1. Реализовать метод сортировки слиянием для целочисленного массива.  Протестировать работу метода в консольном приложении.
