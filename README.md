# Zabbix_Sender

Zabbix_Sender is a C# utility for sending custom metrics and data to a Zabbix server or proxy. This project is designed to help system administrators, DevOps engineers, and developers integrate external data sources with their Zabbix monitoring setup.

## Features

- Send custom metrics to Zabbix server or proxy
- Simple integration with scripts, applications, or monitoring tools

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- Access to a running Zabbix server or proxy

### Installation

Clone the repository:

```bash
git clone https://github.com/SzPeti8/Zabbix-Agent.git
cd Zabbix-Agent
```

Build the project:

```bash
dotnet build
```

### Usage

You need to configure the application to suit your Zabbix Server and implement getting data from the device you want to monitor. After that start the application and it works automatically.

## Configuration

Configure the application in appsettings.json

## Contributing

Contributions are welcome! Please open issues and submit pull requests to help improve the project.


## Acknowledgements

- [Zabbix Documentation](https://www.zabbix.com/documentation/current/manual/concepts/sender)
- Inspired by the official Zabbix sender utility
