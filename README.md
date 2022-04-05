# Connect Arduino to MySQL DB

This is a console app written in C# to connect your own Arduino to a MySQL database (local). With this console app, you can get the readings from the Arduino to the DB by using the serial port, so there is no WiFi, Ethernet or Bluetooth module/shield needed. You only need an Arduino, a cable to connect the Arduino to your device (laptop or computer), MySQL Workbench, Visual Studio 2019 or above and the Arduino IDE.


# What do you need to do?
### MySQL
It is important the install MySQL on your device. This can be done here: https://dev.mysql.com/downloads/installer/
Installing MySQL is pretty simple, but if you need any help to get started, please visit https://qawithexperts.com/article/c-sharp/mysql-connection-in-c-console-application-example/321 or contact me (for contact details, see below). You need to create a NEW database with a table containing the next items: 
- id (PK, autoincrement and not null)
- record (this is the reading from the Arduino)
- timestamp (this is the moment when the reading entered the DB)
- Maybe you need additional data, you can enter this here. Please note that you also need to change the INSERT statement in the C# code if you want to do this! 

### Arduino
The only thing you need to add to your existing Arduino code is a print statement. For example, if you have the variable `_distance-to-surface` when using an ultrasonic sensor, you write the following statement in your void: `Serial.println(_distance-to-surface)`. Every print statement will be captured in the `record` in your MySQL DB (see above). In some cases, you need to change the `BaudRate`. This depends on your Arduino code, so make sure the `BaudRate` in the Arduino code and the C# match. If they don't, there is a big chance of getting an error or invalid measurements/readings.

### Setup & link
Before you can use this program, you need to define the MySQL connection string in the code. This can be done very easily. Also, you need to make sure (see class "Arduino"), that you chose the right COM port. This will be different on every device you use, so make sure the right COM port is written in the code. If you don't know what serial port you are using right now, you can learn how do to do this here: https://support.arduino.cc/hc/en-us/articles/4406856349970-Select-board-and-port-in-Arduino-IDE

# Contact
If you have any questions or problems, please reach out to me by sending an email to 1915525rompen@zuyd.nl or info@stefanrompen.nl
