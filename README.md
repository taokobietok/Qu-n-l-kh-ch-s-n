Chạy file sql:
Bước 1: Mở file QLKS.sql: 
Bước 2: Thay đổi đường dẫn tệp : D:\SQL SEVER\MSSQL16.MSSQLSERVER ----> VỊ TRÍ LƯU TRỮ DỮ LIỆU CỦA SQL SEVER
ví dụ: C:\Programfile\SQL SEVER\MSSQL16.MSSQLSERVER tùy vào cách cài đặt của mỗi người
( NAME = N'Test_Data', FILENAME = N'D:\SQL SEVER\MSSQL16.MSSQLSERVER\MSSQL\DATA\Test_Data.mdf' , SIZE = 10240KB , MAXSIZE = 51200KB , FILEGROWTH = 3072KB )
 LOG ON 
( NAME = N'Test_Log', FILENAME = N'D:\SQL SEVER\MSSQL16.MSSQLSERVER\MSSQL\DATA\Test_Log.ldf' , SIZE = 10240KB , MAXSIZE = 40960KB , FILEGROWTH = 3072KB )
Bước 3: click Execute
chạy file cs
