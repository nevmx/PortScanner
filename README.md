# PortScanner
This application is a fully functional port scanner written in C# using Visual Studio 2015 and .NET 4.5.

## Description
This software allows you to scan a port or a range of ports. You specify an IP address or hostname, a port or a range of ports, select a protocol (TCP or UDP) and a timeout period. The application will then scan the ports and output the results in the main log window.

## Highlights
* Application built in OOP
* Asynchronous port scanning
* Cancel button allows stopping of port scanning operation

## Features
* Single port scanning
* Port range scanning
* TCP protocol
* UDP protocol
* User-defined timeout time

## Class Diagram
![class diagram](http://s30.postimg.org/h55go01dt/PS_Class_Diagram.png "Class Diagram")

## Technical Description
### ScannerManagerSingleton Class
This class manages port scanning activities. The MainWindow class has a reference to the instance of this singleton class, and calls the ExecuteOneAsync() method after the appropriate button is pushed. The MainWindow class passes a callback delegate that serves as an indicator that one port has been scanned.

### PortScannerBase
This is an abstract class that defines the base for PortScanner classes. All specific port scanner classes will inherit from this class. ScannerManagerSingleton refers to all types of PortScanners as PortScannerBase (polymorphism). This class holds the Hostname, Port and Timeout properties that are used by its derived classes for scanning ports. Only one port can be scanned at a tim ehe=
### TCPPortScanner
This is a class that extends PortScannerBase. It implements the method that scans one port.
