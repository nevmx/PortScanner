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
<img src="http://i.imgur.com/IjQ3qOi.jpg" />

## Technical Description
### ScannerManagerSingleton Class
This class manages the port scanning activities. 
